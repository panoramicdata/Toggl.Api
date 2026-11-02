using AwesomeAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

/// <summary>
/// Credential-free: a refused write throws before any request is sent.
/// </summary>
public class ReadOnlyOptionTests
{
	private const string ReportsSearchUrl = "https://api.track.toggl.com/reports/api/v3/workspace/1/search/time_entries";

	private sealed class StubHandler : HttpMessageHandler
	{
		public List<HttpRequestMessage> Requests { get; } = [];

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			Requests.Add(request);
			return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
		}
	}

	private static (HttpClient Client, StubHandler Stub) CreateClient(bool isReadOnly)
	{
		var stub = new StubHandler();
		var options = new TogglClientOptions { Key = "fake-key", IsReadOnly = isReadOnly };
		return (new HttpClient(new ReadOnlyHandler(options) { InnerHandler = stub }), stub);
	}

	[Fact]
	public void IsReadOnly_DefaultsToFalse()
		=> new TogglClientOptions { Key = "fake-key" }.IsReadOnly.Should().BeFalse();

	[Theory]
	[InlineData("POST", "https://api.track.toggl.com/api/v9/workspaces/1/time_entries")]
	[InlineData("PUT", "https://api.track.toggl.com/api/v9/workspaces/1/time_entries/2")]
	[InlineData("PATCH", "https://api.track.toggl.com/api/v9/workspaces/1/time_entries/2")]
	[InlineData("DELETE", "https://api.track.toggl.com/api/v9/workspaces/1/time_entries/2")]
	[InlineData("POST", "https://api.track.toggl.com/api/v9/me/export")]
	public async Task Write_IsRefused_WhenIsReadOnly(string method, string url)
	{
		var (client, stub) = CreateClient(isReadOnly: true);
		using var _ = client;

		var act = () => client.SendAsync(new HttpRequestMessage(new HttpMethod(method), url), TestContext.Current.CancellationToken);

		await act.Should().ThrowAsync<InvalidOperationException>();
		stub.Requests.Should().BeEmpty();
	}

	[Fact]
	public async Task Write_IsAllowed_WhenNotReadOnly()
	{
		var (client, stub) = CreateClient(isReadOnly: false);
		using var _ = client;

		using var response = await client.DeleteAsync("https://api.track.toggl.com/api/v9/workspaces/1/time_entries/2", TestContext.Current.CancellationToken);

		stub.Requests.Should().ContainSingle();
	}

	[Theory]
	[InlineData("GET")]
	[InlineData("HEAD")]
	[InlineData("OPTIONS")]
	public async Task Read_IsAllowed_WhenIsReadOnly(string method)
	{
		var (client, stub) = CreateClient(isReadOnly: true);
		using var _ = client;

		using var response = await client.SendAsync(new HttpRequestMessage(new HttpMethod(method), "https://api.track.toggl.com/api/v9/me"), TestContext.Current.CancellationToken);

		stub.Requests.Should().ContainSingle();
	}

	[Fact]
	public async Task ReportsSearchPost_IsAllowed_WhenIsReadOnly()
	{
		var (client, stub) = CreateClient(isReadOnly: true);
		using var _ = client;

		using var response = await client.PostAsync(ReportsSearchUrl, new StringContent("{}"), TestContext.Current.CancellationToken);

		stub.Requests.Should().ContainSingle();
	}

	[Fact]
	public async Task ClientWrite_IsRefused_WhenIsReadOnly()
	{
		using var client = new TogglClient(new TogglClientOptions { Key = "fake-key", IsReadOnly = true });

		var act = () => client.Clients.DeleteAsync(1, 2, TestContext.Current.CancellationToken);

		var thrown = await act.Should().ThrowAsync<Exception>();
		(thrown.Which as InvalidOperationException ?? thrown.Which.InnerException as InvalidOperationException).Should().NotBeNull();
	}
}

using AwesomeAssertions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

/// <summary>
/// Offline tests for the authentication and rate limit handling, run against a loopback listener.
/// </summary>
public class AuthenticatedHttpClientHandlerTests
{
	private const string QuotaRemaining = "X-Toggl-Quota-Remaining";
	private const string ResetsIn = "X-Toggl-Quota-Resets-In";

	private sealed record CannedResponse(int Status, string? Quota, string? Resets, string Body);

	private sealed class CapturingLogger : ILogger
	{
		public List<string> Messages { get; } = [];

		public IDisposable? BeginScope<TState>(TState state) where TState : notnull
		{
			Messages.Add($"scope {state}");
			return null;
		}

		public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
			=> Messages.Add($"{logLevel} {eventId.Id} {formatter(state, exception)}");
	}

	private sealed class LoopbackServer : IDisposable
	{
		private readonly HttpListener _listener = new();
		private readonly Task _loop;

		public LoopbackServer(IReadOnlyList<CannedResponse> responses)
		{
			var probe = new TcpListener(IPAddress.Loopback, 0);
			probe.Start();
			var port = ((IPEndPoint)probe.LocalEndpoint).Port;
			probe.Stop();

			BaseUri = new Uri($"http://127.0.0.1:{port}/");
			_listener.Prefixes.Add(BaseUri.AbsoluteUri);
			_listener.Start();
			_loop = Task.Run(() => ServeAsync(responses));
		}

		public Uri BaseUri { get; }

		public List<string?> AuthorizationHeaders { get; } = [];

		private async Task ServeAsync(IReadOnlyList<CannedResponse> responses)
		{
			foreach (var canned in responses)
			{
				var context = await _listener.GetContextAsync();
				AuthorizationHeaders.Add(context.Request.Headers["Authorization"]);
				context.Response.StatusCode = canned.Status;
				if (canned.Quota is not null)
				{
					context.Response.Headers.Add(QuotaRemaining, canned.Quota);
				}

				if (canned.Resets is not null)
				{
					context.Response.Headers.Add(ResetsIn, canned.Resets);
				}

				var bytes = Encoding.UTF8.GetBytes(canned.Body);
				await context.Response.OutputStream.WriteAsync(bytes);
				context.Response.Close();
			}
		}

		public async Task WaitAsync() => await _loop;

		public void Dispose() => _listener.Close();
	}

	private static HttpClient CreateClient(bool handleRateLimiting, ILogger? logger = null)
		=> new(new AuthenticatedHttpClientHandler(new TogglClientOptions
		{
			Key = "fake-key",
			HandleRateLimiting = handleRateLimiting,
			Logger = logger
		}));

	[Fact]
	public async Task SendAsync_AddsBasicAuthorizationHeader()
	{
		using var server = new LoopbackServer([new CannedResponse(200, null, null, "ok")]);
		using var client = CreateClient(false);

		using var response = await client.GetAsync(server.BaseUri, TestContext.Current.CancellationToken);
		await server.WaitAsync();

		var expected = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("fake-key:api_token"));
		response.StatusCode.Should().Be(HttpStatusCode.OK);
		server.AuthorizationHeaders.Should().ContainSingle().Which.Should().Be(expected);
	}

	[Fact]
	public async Task SendAsync_PaymentRequiredWithoutRateLimiting_ReturnsResponseAsIs()
	{
		using var server = new LoopbackServer([new CannedResponse(402, "0", "0", "no")]);
		using var client = CreateClient(false);

		using var response = await client.GetAsync(server.BaseUri, TestContext.Current.CancellationToken);
		await server.WaitAsync();

		response.StatusCode.Should().Be(HttpStatusCode.PaymentRequired);
	}

	[Fact]
	public async Task SendAsync_PaymentRequiredWithRateLimiting_RetriesUntilSuccess()
	{
		using var server = new LoopbackServer(
		[
			new CannedResponse(402, "0", "0", "slow down"),
			new CannedResponse(200, null, null, "done")
		]);
		using var client = CreateClient(true);

		using var response = await client.GetAsync(server.BaseUri, TestContext.Current.CancellationToken);
		await server.WaitAsync();

		response.StatusCode.Should().Be(HttpStatusCode.OK);
		(await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken)).Should().Be("done");
		server.AuthorizationHeaders.Should().HaveCount(2);
	}

	[Theory]
	[InlineData(null, null)]
	[InlineData("5", "0")]
	[InlineData("0", null)]
	[InlineData("0", "soon")]
	public async Task SendAsync_PaymentRequiredWithInvalidQuotaHeaders_ThrowsFormatException(string? quota, string? resets)
	{
		using var server = new LoopbackServer([new CannedResponse(402, quota, resets, "no")]);
		using var client = CreateClient(true);

		var act = () => client.GetAsync(server.BaseUri, TestContext.Current.CancellationToken);

		await act.Should().ThrowAsync<FormatException>();
		await server.WaitAsync();
	}

	[Fact]
	public async Task SendAsync_WithDebugLogging_LogsRequestAndResponseBodies()
	{
		var logger = new CapturingLogger();
		using var server = new LoopbackServer([new CannedResponse(200, null, null, "response-body")]);
		using var client = CreateClient(false, logger);
		using var content = new StringContent("request-body");

		using var response = await client.PostAsync(server.BaseUri, content, TestContext.Current.CancellationToken);
		await server.WaitAsync();

		logger.Messages.Should().Contain(m => m.Contains("Sending request: POST") && m.Contains("request-body"));
		logger.Messages.Should().Contain(m => m.Contains("Response: OK") && m.Contains("response-body"));
	}
}

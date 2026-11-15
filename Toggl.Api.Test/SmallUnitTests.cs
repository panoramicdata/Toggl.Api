using AwesomeAssertions;
using System;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Exceptions;
using Toggl.Api.Extensions;
using Toggl.Api.Models;
using Toggl.Api.QueryObjects;
using Xunit;

namespace Toggl.Api.Test;

/// <summary>
/// Offline tests for small helpers, query objects and DTOs.
/// </summary>
public class SmallUnitTests
{
	[Theory]
	[InlineData("PascalCasedWord", "pascal_cased_word")]
	[InlineData("HTTPServer", "http_server")]
	[InlineData("some-dashed word", "some_dashed_word")]
	public void LowerCaseUnderscore_ConvertsToSnakeCase(string input, string expected)
		=> input.LowerCaseUnderscore().Should().Be(expected);

	[Fact]
	public void ToUnixTime_ReturnsSecondsSinceEpoch()
		=> new DateTime(1970, 1, 1, 0, 1, 40, DateTimeKind.Utc).ToUnixTime().Should().Be(100);

	[Fact]
	public void ToIsoDateStr_UsesOffsetFormat()
	{
		var date = new DateTime(2026, 3, 4, 5, 6, 7, DateTimeKind.Utc);

		date.ToIsoDateStr().Should().Be(date.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture));
	}

	[Fact]
	public void TogglApiException_KeepsMessageAndInnerException()
	{
		var inner = new InvalidOperationException("inner");

		new TogglApiException().Message.Should().NotBeNullOrEmpty();
		new TogglApiException("boom").Message.Should().Be("boom");
		var both = new TogglApiException("boom", inner);
		both.Message.Should().Be("boom");
		both.InnerException.Should().BeSameAs(inner);
	}

	[Fact]
	public void TimeEntryParams_GetParameters_ReturnsOnlySuppliedDates()
	{
		var start = new DateTime(2026, 1, 2, 3, 4, 5, DateTimeKind.Utc);
		var end = start.AddDays(1);

		new TimeEntryParams().GetParameters().Should().BeEmpty();
		new TimeEntryParams { StartDate = start }.GetParameters()
			.Select(p => p.Key).Should().Equal("start_date");
		var both = new TimeEntryParams { StartDate = start, EndDate = end }.GetParameters();
		both.Select(p => p.Key).Should().Equal("start_date", "end_date");
		both[1].Value.Should().Be(end.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture));
	}

	[Fact]
	public void TimeEntryParams_Constructor_InitialisesEmptyTags()
		=> new TimeEntryParams().Tags.Should().NotBeNull().And.BeEmpty();

	[Fact]
	public void ProjectDashboardParams_DefaultsToNameAscendingOrder()
	{
		var parameters = new ProjectDashboardParams();

		parameters.OrderField.Should().Be("name");
		parameters.OrderDesc.Should().Be("on");
	}

	[Fact]
	public void InvitationCreationDto_Workspaces_WrapsIdsInObjects()
	{
		var dto = new InvitationCreationDto { Emails = ["a@example.com"], WorkspaceIds = [7, 9] };

		dto.Workspaces!.Select(w => w.WorkspaceId).Should().Equal(7, 9);
		new InvitationCreationDto { Emails = [] }.Workspaces.Should().BeNull();
	}

	[Fact]
	public void TimeEntryCreationDto_EnsureValid_AcceptsCompleteDto()
	{
		var dto = new TimeEntryCreationDto
		{
			CreatedWith = "tests",
			WorkspaceId = 1,
			Duration = 60,
			Start = DateTimeOffset.UnixEpoch
		};

		dto.EnsureValid();

		dto.Duration.Should().Be(60);
		dto.Start.Should().Be(DateTimeOffset.UnixEpoch);
		((TimeEntryDtoBase)dto).Duration.Should().Be(60);
	}

	[Theory]
	[InlineData("", true, true, "CreatedWith")]
	[InlineData("tests", false, true, "Duration")]
	[InlineData("tests", true, false, "Start")]
	public void TimeEntryCreationDto_EnsureValid_RejectsMissingFields(string createdWith, bool hasDuration, bool hasStart, string field)
	{
		var dto = new TimeEntryCreationDto { CreatedWith = createdWith, WorkspaceId = 1, Duration = 1, Start = DateTimeOffset.UnixEpoch };
		if (!hasDuration)
		{
			((TimeEntryDtoBase)dto).Duration = null;
		}

		if (!hasStart)
		{
			((TimeEntryDtoBase)dto).Start = null;
		}

		var act = dto.EnsureValid;

		act.Should().Throw<InvalidOperationException>().WithMessage($"{field} must be provided*");
	}

	[Fact]
	public void TogglClientOptions_Validate_RequiresKey()
	{
		var act = new TogglClientOptions { Key = string.Empty }.Validate;

		act.Should().Throw<ArgumentException>();
		new TogglClientOptions { Key = "k" }.Validate();
	}

	[Fact]
	public void TogglClientOptions_DefaultsAreConservative()
	{
		var options = new TogglClientOptions { Key = "k" };

		options.UserAgent.Should().Be("Toggl.Api");
		options.HandleRateLimiting.Should().BeFalse();
		options.IsReadOnly.Should().BeFalse();
		options.JsonUnmappedMemberHandling.Should().Be(System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip);
	}

	[Fact]
	public async Task TogglClient_RejectsNullOptionsAndDoesNotImplementGetAll()
	{
		var nullOptions = () => new TogglClient(null!);
		nullOptions.Should().Throw<ArgumentNullException>();

		using var client = new TogglClient(new TogglClientOptions { Key = "k" });
		var getAll = () => client.GetAllAsync<Client>(1, CancellationToken.None);
		await getAll.Should().ThrowAsync<NotImplementedException>();
	}

	[Fact]
	public void ToString_OverridesIncludeIdentifyingFields()
	{
		var start = new DateTimeOffset(2026, 1, 2, 3, 4, 5, TimeSpan.Zero);

		new TimeEntry { Id = 5, Start = start, TaskId = 8 }.ToString().Should().Contain("Id: 5").And.Contain("TaskId: 8");
		new ReportTimeEntry { Id = 6 }.ToString().Should().Contain("Id: 6");
		new Project { Id = 3, Name = "P" }.ToString().Should().Be("Id: 3, Name: P");
		new Client { Id = 4, Name = "C" }.ToString().Should().Contain("Name: C").And.NotContain("DELETED");
		new Client { Id = 4, Name = "C", DeletedAt = DateTimeOffset.UnixEpoch }.ToString().Should().Contain("[DELETED]");
	}

	[Fact]
	public void SessionAndUser_RoundTripSharedSettings()
	{
		const string json = """{"id":1,"email":"a@example.com","default_wid":9,"retention":3,"manual_mode":true,"at":"2026-01-02T03:04:05Z"}""";

		var user = JsonSerializer.Deserialize<User>(json)!;
		var session = JsonSerializer.Deserialize<Session>(json)!;

		user.Email.Should().Be("a@example.com");
		user.DefaultWorkspaceId.Should().Be(9);
		session.DefaultWorkspaceId.Should().Be(9);
		new[] { user.Retention, session.Retention }.Should().AllBeEquivalentTo(3);
		new[] { user.IsManualMode, session.IsManualMode }.Should().AllBeEquivalentTo(true);
		new[] { user.UpdatedOn, session.UpdatedOn }.Should().OnlyContain(d => d!.Value.Year == 2026);
	}
}

using AwesomeAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

/// <summary>
/// Tests that response models survive payloads in which Toggl omits fields.
///
/// <para>
/// Toggl's own OpenAPI description (vendored under "Open API" in this repository) declares no
/// <c>required</c> array on any of the response definitions the client binds, so no field is
/// contractually guaranteed to be present.  Marking a response property <c>required</c> in C#
/// therefore turns a routine, unannounced omission by Toggl into a hard
/// <see cref="JsonException"/> for every caller — which is exactly what was reported in
/// https://github.com/panoramicdata/Toggl.Api/pull/9, when <c>permissions</c> stopped being
/// returned on tasks.
/// </para>
///
/// <para>
/// These are pure unit tests.  They deserialize literal JSON and require no credentials, no
/// configuration and no live account.
/// </para>
/// </summary>
public class ResponseModelDeserializationTests
{
	/// <summary>
	/// The options used by TogglClient, so that these tests exercise the real configuration.
	/// </summary>
	private static readonly JsonSerializerOptions _options = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		WriteIndented = true,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		Converters =
		{
			new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
		}
	};

	/// <summary>
	/// Request bodies are not covered by this rule: there, "required" is compile-time enforcement
	/// on the caller rather than a claim about what Toggl sends back.  All but one are recognised
	/// by their suffix.
	/// </summary>
	private static readonly string[] _requestOnlySuffixes = ["Dto", "Request", "Query", "Payload"];

	/// <summary>
	/// Sent as a Refit [Body] parameter, but its name does not carry a request-shaped suffix.
	/// </summary>
	private static readonly string[] _additionalRequestOnlyTypes = ["PushServiceToken"];

	/// <summary>
	/// The exact failure from the issue: a task payload with no "permissions" member at all.
	/// </summary>
	[Fact]
	public void ProjectTask_WithPermissionsAbsent_Deserializes()
	{
		const string json = """
			{
				"id": 1234567,
				"name": "Some task",
				"project_id": 987654,
				"workspace_id": 4242,
				"active": true,
				"at": "2024-12-06T03:01:46+00:00"
			}
			""";

		var task = JsonSerializer.Deserialize<ProjectTask>(json, _options);

		task.Should().NotBeNull();
		task!.Id.Should().Be(1234567);
		task.Name.Should().Be("Some task");
		task.Permissions.Should().BeNull();
	}

	/// <summary>
	/// Toggl documents "permissions" as an array of strings, so the property has to be a
	/// collection.  It was previously typed as a string, which would have thrown had the
	/// documented shape ever arrived.
	/// </summary>
	[Fact]
	public void ProjectTask_WithPermissionsArray_Deserializes()
	{
		const string json = """
			{
				"id": 1234567,
				"name": "Some task",
				"permissions": ["read", "write"]
			}
			""";

		var task = JsonSerializer.Deserialize<ProjectTask>(json, _options);

		task.Should().NotBeNull();
		task!.Permissions.Should().BeEquivalentTo(["read", "write"]);
	}

	/// <summary>
	/// An empty object is the worst case Toggl could send, and is the general form of the bug
	/// above: every response model must survive it rather than throwing.
	/// </summary>
	[Theory]
	[MemberData(nameof(ResponseModelTypes))]
	public void ResponseModel_WithEmptyPayload_Deserializes(Type responseModelType)
	{
		var deserialize = () => JsonSerializer.Deserialize("{}", responseModelType, _options);

		deserialize.Should().NotThrow(
			$"Toggl guarantees no field on {responseModelType.Name}, so an absent field must not throw");
		deserialize().Should().NotBeNull();
	}

	/// <summary>
	/// The structural invariant behind the test above, asserted directly so that a newly added
	/// "required" response property fails here with a clear message rather than in the field.
	/// </summary>
	[Fact]
	public void ResponseModels_DeclareNoRequiredMembers()
	{
		var offenders = ResponseModelTypes()
			.Select(data => (Type)data[0])
			.SelectMany(type => type
				.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
				.Where(property => property.GetCustomAttribute<RequiredMemberAttribute>() is not null)
				.Select(property => $"{type.Name}.{property.Name}"))
			.OrderBy(name => name)
			.ToList();

		offenders.Should().BeEmpty(
			"response properties must not be 'required': Toggl's OpenAPI description marks no "
			+ "response field as required, so any of them may be absent");
	}

	public static IEnumerable<object[]> ResponseModelTypes()
		=> typeof(ProjectTask).Assembly
			.GetTypes()
			.Where(type =>
				type.IsClass
				&& type.IsPublic
				&& !type.IsAbstract
				&& !type.IsGenericTypeDefinition
				&& type.Namespace == typeof(ProjectTask).Namespace
				&& !_requestOnlySuffixes.Any(suffix => type.Name.EndsWith(suffix, StringComparison.Ordinal))
				&& !_additionalRequestOnlyTypes.Contains(type.Name))
			.OrderBy(type => type.Name)
			.Select(type => new object[] { type });
}

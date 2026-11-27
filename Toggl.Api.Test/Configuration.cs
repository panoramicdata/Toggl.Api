namespace Toggl.Api.Test;

public class Configuration
{
	/// <summary>
	///  The API key
	/// </summary>
	public required string ApiKey { get; init; }

	/// <summary>
	/// A sample workspace name
	/// </summary>
	public required string SampleWorkspaceName { get; init; }

	/// <summary>
	/// A sample client name
	/// </summary>
	public required string SampleClientName { get; init; }

	/// <summary>
	/// A sample project name
	/// </summary>
	public required string SampleProjectName { get; init; }

	/// <summary>
	/// The id of a dedicated test organisation, never production. Only the opt-in invitation test uses it.
	/// </summary>
	public long? InvitationTestOrganizationId { get; init; }

	/// <summary>
	/// The id of a workspace in the dedicated test organisation, for the opt-in invitation test.
	/// </summary>
	public long? InvitationTestWorkspaceId { get; init; }
}
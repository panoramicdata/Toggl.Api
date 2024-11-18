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
	/// A sample client name to use for testing CRUD operations
	/// </summary>
	public required string CrudClientName { get; init; }
}
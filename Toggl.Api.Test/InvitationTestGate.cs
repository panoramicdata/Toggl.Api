namespace Toggl.Api.Test;

/// <summary>
/// The guard for the invitation creation test, kept free of any network access so it can be tested offline.
/// </summary>
internal static class InvitationTestGate
{
	internal const string OrganizationSetting = "Configuration:InvitationTestOrganizationId";
	internal const string WorkspaceSetting = "Configuration:InvitationTestWorkspaceId";

	/// <summary>
	/// Returns a message naming what to set if the dedicated test organisation is not fully configured, otherwise null.
	/// </summary>
	internal static string? GetConfigurationProblem(long? organizationId, long? workspaceId)
	{
		if (organizationId is null || workspaceId is null)
		{
			return $"Invitations_Create_Succeeds creates an invitation that can never be removed, so it only runs against a dedicated test organisation. "
				+ $"Set both {OrganizationSetting} and {WorkspaceSetting} (user secrets, or the environment variables Configuration__InvitationTestOrganizationId and Configuration__InvitationTestWorkspaceId) "
				+ "to a test organisation that is NOT the production Panoramic Data organisation.";
		}

		return null;
	}

	/// <summary>
	/// Returns a message if the configured organisation is the one the API key's default workspace belongs to (production), otherwise null.
	/// </summary>
	internal static string? GetProductionProblem(long configuredOrganizationId, long defaultOrganizationId)
		=> configuredOrganizationId == defaultOrganizationId
			? $"{OrganizationSetting} is {configuredOrganizationId}, which is the production organisation of the API key's default workspace. "
				+ "Invitations cannot be removed through the API, so point it at a dedicated test organisation instead."
			: null;
}

﻿using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// An organization creation DTO.
/// </summary>
public class OrganizationCreationDto
{
	/// <summary>
	/// The name
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// The workspace name
	/// </summary>
	[JsonPropertyName("workspace_name")]
	public required string WorkspaceName { get; set; }
}
﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ProjectTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async Task Projects_GetPage_Succeeds()
	{
		var projects = await GetProjectsPageAsync();
		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Projects_Get_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var projectId = await GetProjectIdAsync();
		var project = await TogglClient
			.Projects
			.GetAsync(workspaceId, projectId, default);

		project.Should().NotBeNull();
	}

	[Fact]
	public async Task Projects_GetProjectUsers_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var report = await TogglClient
			.Projects
			.GetUsersAsync(workspaceId, null, null, default);

		report.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Projects_CreateProject_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var projectCreationDto = new ProjectCreationDto
		{
			IsActive = false,
			IsPrivate = false,
			IsShared = false,
			Name = "Test - can delete",
			StartDate = DateTime.UtcNow
		};

		var project =
			await TogglClient.Projects.CreateAsync(workspaceId, projectCreationDto, CancellationToken.None);

		project.Should().NotBeNull();
	}
}
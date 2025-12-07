using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

public interface ITags
{
	/// <summary>
	/// List Workspace tags.
	/// https://engineering.toggl.com/docs/api/tags#get-tags
	/// </summary>
	/// <param name="workspaceId">The workspace id</param>
	/// <returns></returns>
	[Get("/api/v9/workspaces/{workspace_id}/tags")]
	Task<ICollection<Tag>> GetAsync(
		[AliasAs("workspace_id")] long workspaceId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Creates a new tag in the workspace.
	/// https://engineering.toggl.com/docs/api/tags#post-create-tag
	/// </summary>
	/// <param name="workspaceId">The workspace id</param>
	/// <param name="tag">The tag to create</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The created tag</returns>
	[Post("/api/v9/workspaces/{workspace_id}/tags")]
	Task<Tag> CreateAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[Body] TagCreationDto tag,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates a tag in the workspace.
	/// https://engineering.toggl.com/docs/api/tags#put-update-tag
	/// </summary>
	/// <param name="workspaceId">The workspace id</param>
	/// <param name="tagId">The tag id</param>
	/// <param name="tag">The tag data to update</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The updated tag</returns>
	[Put("/api/v9/workspaces/{workspace_id}/tags/{tag_id}")]
	Task<Tag> UpdateAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("tag_id")] long tagId,
		[Body] TagCreationDto tag,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Deletes a tag from the workspace.
	/// https://engineering.toggl.com/docs/api/tags#delete-delete-tag
	/// </summary>
	/// <param name="workspaceId">The workspace id</param>
	/// <param name="tagId">The tag id</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Delete("/api/v9/workspaces/{workspace_id}/tags/{tag_id}")]
	Task DeleteAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("tag_id")] long tagId,
		CancellationToken cancellationToken
		);
}
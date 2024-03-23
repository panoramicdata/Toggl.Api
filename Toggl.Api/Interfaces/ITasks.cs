using System.Threading;
using System.Threading.Tasks;
using Task = Toggl.Api.Models.Task;

namespace Toggl.Api.Interfaces;

public interface ITasks
{
	/// <summary>
	/// Get a task
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#get-task-details
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<Task> GetAsync(long id, CancellationToken cancellationToken);

	/// <summary>
	///Add a Task
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#create-a-task
	/// </summary>
	/// <param name="t"></param>
	/// <returns></returns>
	Task<Task> CreateAsync(Task t, CancellationToken cancellationToken);

	/// <summary>
	/// Edit a task
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#update-a-task
	/// </summary>
	/// <param name="t"></param>
	/// <returns></returns>
	Task<Task> UpdateAsync(Task t, CancellationToken cancellationToken);

	/// <summary>
	/// Delete a task
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#delete-a-task
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
}
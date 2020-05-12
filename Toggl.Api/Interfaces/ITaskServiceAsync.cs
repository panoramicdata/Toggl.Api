using System.Threading.Tasks;
using Task = Toggl.Api.DataObjects.Task;

namespace Toggl.Api.Interfaces
{
	public interface ITaskServiceAsync
	{
		/// <summary>
		/// Get a task
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#get-task-details
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Task> Get(int id);

		/// <summary>
		///Add a Task
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#create-a-task
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		Task<Task> Add(Task t);

		/// <summary>
		/// Edit a task
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#update-a-task
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		Task<Task> Edit(Task t);

		/// <summary>
		/// Delete a task
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#delete-a-task
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> Delete(int id);
	}
}
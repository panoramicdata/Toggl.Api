using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;

namespace Toggl.Api.Interfaces
{
	public interface IProjectServiceAsync
	{
		/// <summary>
		///List project services
		/// https://www.toggl.com/public/api#get_projects
		/// </summary>
		Task<List<Project>> List();

		Task<Project> Get(int id);

		Task<Project> Add(Project project);
	}
}
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
		Task<List<Project>> ListAsync();

		Task<Project> GetAsync(int id);

		Task<Project> AddAsync(Project project);
	}
}
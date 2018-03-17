using System.Collections.Generic;
using Toggl.Api.DataObjects;

namespace Toggl.Api.Interfaces
{
    public interface ITagService
    {
        /// <summary>
        /// 
        /// https://www.toggl.com/public/api#get_tags
        /// </summary>
        /// <returns></returns>
        List<Client> List();
    }
}
using Newtonsoft.Json;

namespace Toggl.Api.DataObjects
{
	public class NewBlogPost : BaseDataObject
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("pub_date")]
		public string PubDate { get; set; }
	}
}
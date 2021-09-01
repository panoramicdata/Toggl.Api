using Newtonsoft.Json;

namespace Toggl.Api.DataObjects
{
	/// <summary>
	/// A Project
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#projects
	/// </summary>
	public class Project : BaseDataObject
	{
		/// <summary>
		/// id: The id of the project
		/// </summary>
		[JsonProperty(PropertyName = "id")]
		public long? Id { get; set; }

		/// <summary>
		/// wid: workspace ID, where the project will be saved (integer, required)
		/// </summary>
		[JsonProperty(PropertyName = "wid")]
		public long WorkspaceId { get; set; } = 0;

		/// <summary>
		///  cid: client ID (integer, not required)
		/// </summary>
		[JsonProperty(PropertyName = "cid")]
		public long? ClientId { get; set; }

		/// <summary>
		/// name: The name of the project (string, required, unique for client and workspace)
		/// </summary>
		[JsonProperty(PropertyName = "name")]
		public string? Name { get; set; }

		/// <summary>
		/// billable: whether the project is billable or not (boolean, default true, available only for pro workspaces)
		/// </summary>
		[JsonProperty(PropertyName = "billable")]
		public bool? IsBillable { get; set; }

		/// <summary>
		/// is_private: whether project is accessible for only project users or for all workspace users (boolean, default true)
		/// </summary>
		[JsonProperty(PropertyName = "is_private")]
		public bool? IsPrivate { get; set; }

		/// <summary>
		/// active: whether the project is archived or not (boolean, by default true)
		/// </summary>
		[JsonProperty(PropertyName = "active")]
		public bool? IsActive { get; set; }

		/// <summary>
		/// template: whether the project can be used as a template (boolean, not required)
		/// </summary>
		[JsonProperty(PropertyName = "template")]
		public bool? IsTemplateable { get; set; }

		/// <summary>
		/// at: timestamp that is sent in the response for PUT, indicates the time task was last updated
		/// </summary>
		[JsonProperty(PropertyName = "at")]
		public string? UpdatedOn { get; set; }

		/// <summary>
		/// created_at: timestamp indicating when the project was created (UTC time), read-only
		/// </summary>
		[JsonProperty(PropertyName = "created_at")]
		public string? CreatedOn { get; set; }

		/// <summary>
		/// color: a color
		/// </summary>
		[JsonProperty(PropertyName = "color")]
		public string? Color { get; set; }

		/// <summary>
		/// auto_estimates: whether the estimated hours are automatically calculated based on task estimations or manually fixed based on the value of 'estimated_hours' (boolean, default false, not required, premium functionality)
		/// </summary>
		[JsonProperty(PropertyName = "auto_estimates")]
		public bool? IsAutoEstimates { get; set; }

		/// <summary>
		/// estimated_hours: if auto_estimates is true then the sum of task estimations is returned, otherwise user inserted hours (integer, not required, premium functionality)
		/// </summary>
		[JsonProperty(PropertyName = "estimated_hours")]
		public int? EstimatedHours { get; set; }

		/// <summary>
		/// actual_houts: The number of actual hours spent
		/// </summary>
		[JsonProperty(PropertyName = "actual_hours")]
		public double? ActualHours { get; set; }

		/// <summary>
		/// template_id: id of the template project used on current project's creation
		/// </summary>
		[JsonProperty(PropertyName = "template_id")]
		public long? TemplateId { get; set; }

		/// <summary>
		/// rate: hourly rate of the project (float, not required, premium functionality)
		/// </summary>
		[JsonProperty(PropertyName = "rate")]
		public double? HourlyRate { get; set; }

		/// <summary>
		/// currency: hourly rate currency of the project
		/// </summary>
		[JsonProperty(PropertyName = "currency")]
		public string? Currency { get; set; }

		/// <summary>
		/// color: a color
		/// </summary>
		[JsonProperty(PropertyName = "hex_color")]
		public string? HexColor { get; set; }

		public override string ToString() => string.Format("Id: {0}, Name: {1}", Id, Name);
	}
}
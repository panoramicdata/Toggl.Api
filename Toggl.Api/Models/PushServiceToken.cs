using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Firebase push service token
/// https://engineering.toggl.com/docs/api/me#post-push-services
/// </summary>
public class PushServiceToken
{
	/// <summary>
	/// Firebase Cloud Messaging registration token
	/// </summary>
	[JsonPropertyName("fcm_registration_token")]
	public required string FcmRegistrationToken { get; set; }
}

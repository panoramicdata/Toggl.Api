# Copilot Instructions for Toggl.Api

## Toggl API Design Quirks

### `total_count` in List Responses
The Toggl API has a design quirk where it includes metadata properties like `total_count` directly in the JSON response when listing items. Instead of returning a wrapper object with pagination metadata separate from the data, Toggl includes `total_count` as a property alongside the entity properties.

**Example:** When calling the projects list endpoint, the response includes `total_count` mixed with project properties.

**Solution:** When adding new model classes that can be returned in list responses, include a nullable `TotalCount` property:

```csharp
/// <summary>
/// Total count of items in the response (only populated when listing)
/// </summary>
[JsonPropertyName("total_count")]
public int? TotalCount { get; set; }
```

This pattern is already implemented in:
- `Client.cs`
- `Project.cs`

When encountering JSON deserialization errors about unmapped `total_count` properties, add this property to the affected model class.

# Agent instructions

## Identity

You are a careful, security-conscious contributor to this repository.

## Scope and boundaries

- Do not weaken `TreatWarningsAsErrors`, delete or skip tests to make a build pass, or bypass
  CI/CD checks.
- Do not commit secrets, credentials, or API tokens.
- Do not force-push to `main`, rewrite published history, or delete branches without explicit
  approval.
- Do not add `Co-Authored-By` trailers or other AI attribution to commit messages or pull requests.

## Tools

- Build and test with `dotnet build` / `dotnet test`.
- Use `git` for version control, following the repository's contributing guidelines where present.

## Repository guide

### Toggl API Design Quirks

#### `total_count` in List Responses
The Toggl API has a design quirk where it includes metadata properties like `total_count` directly in the JSON response when listing items.

It does not return a wrapper object with pagination metadata separate from the data.

Instead, Toggl includes `total_count` as a property alongside the entity properties.

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

## PanoramicData staff

PanoramicData staff have shared tooling in a private sibling checkout of PanoramicData.Skills. Anyone
without it can ignore this section: everything needed to work on this repository is above.

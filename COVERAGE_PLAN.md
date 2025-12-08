# Toggl.Api OpenAPI Coverage Plan

This document outlines a phased approach to achieve full coverage of the Toggl API v9 endpoints based on the OpenAPI specification files located in the `Open API` folder.

## Current State Summary

### Existing Interfaces
| Interface | Status | Coverage |
|-----------|--------|----------|
| `ICurrentUser` | Complete | ~95% |
| `IClients` | Complete | ~100% |
| `IWorkspaces` | Partial | ~40% |
| `IOrganizations` | Partial | ~50% |
| `IProjects` | Complete | ~95% |
| `ITasks` | Complete | ~100% |
| `ITags` | Complete | ~100% |
| `ITimeEntries` | Partial | ~80% |
| `IGroups` | Minimal | ~20% |
| `IReports` | Partial | ~50% |

### OpenAPI Spec Files
1. `api-bdd741600e7247ddebb5bbb673d1368c.json` - Main API (primary focus)
2. `reports-90f73336280ee8fda8a76dcf30502c88.json` - Reports API
3. `webhooks-479d375ba167e9f885df9356e34a7c4e.json` - Webhooks API

---

## Phase 1: Core Entity CRUD Operations (Priority: Critical)
**Estimated Effort:** 2-3 days  
**Goal:** Complete CRUD operations for all core entities

### 1.1 Complete ICurrentUser (`/me` endpoints)
**Missing endpoints to add:**

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/me/close_account` | POST | Medium |
| `/me/disable_product_emails/{disable_code}` | POST | Low |
| `/me/disable_weekly_report/{weekly_report_code}` | POST | Low |
| `/me/enable_sso` | POST | Low |
| `/me/export` | GET, POST | Medium |
| `/me/export/data/{uuid}.zip` | GET | Medium |
| `/me/favorites` | GET, POST, PUT | Medium |
| `/me/favorites/suggestions` | POST | Low |
| `/me/favorites/{favorite_id}` | DELETE | Medium |
| `/me/flags` | GET, POST | Medium |
| `/me/preferences` | GET, POST | Medium |
| `/me/preferences/{client}` | GET, POST | Low |
| `/me/push_services` | GET, POST, DELETE | Low |
| `/me/quota` | GET | Medium |

**Models required:**
- `Favorite`
- `UserFlags`
- `UserPreferences`
- `AlphaFeature`
- `DownloadRequestRecord`
- `ExportPayload`

### 1.2 Complete IProjects
**Missing endpoints to add:**

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/workspaces/{workspace_id}/projects/{project_id}/statistics` | GET | Medium |
| `/workspaces/{workspace_id}/project_groups` | GET | Low |

### 1.3 Complete ITasks
**Currently implemented:** GET (list, by project), CREATE, UPDATE, DELETE, GET by ID  
**Status:** ? Complete

### 1.4 Complete ITags
**Currently implemented:** GET, CREATE, UPDATE, DELETE  
**Status:** ? Complete

---

## Phase 2: Organization & Workspace Management (Priority: High)
**Estimated Effort:** 3-4 days  
**Goal:** Complete organization and workspace management features

### 2.1 Enhance IOrganizations

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/organizations/{organization_id}/owner` | GET | Medium |
| `/organizations/{organization_id}/owner/transfer` | GET, POST | Low |
| `/organizations/{organization_id}/owner/transfer/{transfer_id}` | GET | Low |
| `/organizations/{organization_id}/owner/transfer/{transfer_id}/{action}` | POST | Low |
| `/organizations/{organization_id}/payment_records` | GET | Low |
| `/organizations/{organization_id}/plans` | GET | Medium |
| `/organizations/{organization_id}/plans/{plan_id}` | GET | Low |
| `/organizations/{organization_id}/roles` | GET | Medium |
| `/organizations/{organization_id}/segmentation` | GET, PUT | Low |

**Models required:**
- `OrganizationOwner`
- `OrganizationTransfer`
- `OrganizationRole`
- `OrganizationSegmentation`
- `PaymentRecord`
- `PricingPlan`

### 2.2 Enhance IWorkspaces

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/workspaces/{workspace_id}/alerts` | GET | Low |
| `/workspaces/{workspace_id}/statistics` | GET | Medium |
| `/workspaces/{workspace_id}/track_reminders` | GET, POST | Medium |
| `/workspaces/{workspace_id}/track_reminders/{reminder_id}` | PUT, DELETE | Medium |

**Models required:**
- `WorkspaceAlert`
- `WorkspaceStatistics`
- `TrackReminderCreationDto`

### 2.3 New Interface: IInvitations
**Create new interface for invitation management**

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/invitations/{invitation_code}` | GET | Medium |
| `/organizations/invitations/{invitation_code}/accept` | POST | High |
| `/organizations/invitations/{invitation_code}/reject` | POST | High |
| `/organizations/{organization_id}/invitations` | POST | High |
| `/organizations/{organization_id}/invitations/{invitation_id}/resend` | PUT | Medium |

**Models required:**
- `Invitation`
- `InvitationCreationDto`
- `InvitationResult`

---

## Phase 3: Groups & Users (Priority: High)
**Estimated Effort:** 2-3 days  
**Goal:** Complete group and user management

### 3.1 Complete IGroups

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/organizations/{organization_id}/groups` | GET, POST | High |
| `/organizations/{organization_id}/groups/{group_id}` | PUT, DELETE, PATCH | High |
| `/workspaces/{workspace_id}/groups` | GET, POST | Medium |
| `/workspaces/{workspace_id}/groups/{group_id}` | PUT, DELETE | Medium |

**Models required:**
- `GroupCreationDto`
- `GroupUpdateDto`
- `GroupPatchInput`
- `GroupPatchOutput`

### 3.2 Complete IUsers

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/workspaces/{workspace_id}/users` | GET | High |
| `/workspaces/{workspace_id}/users/{user_id}` | PUT | Medium |
| `/workspaces/{workspace_id}/workspace_users` | GET, POST | High |
| `/workspaces/{workspace_id}/workspace_users/{workspace_user_id}` | PUT, DELETE | Medium |

**Models required:**
- `WorkspaceUserCreationDto`
- `WorkspaceUserUpdateDto`

---

## Phase 4: Subscriptions & Billing (Priority: Medium)
**Estimated Effort:** 2-3 days  
**Goal:** Add subscription management capabilities

### 4.1 New Interface: ISubscriptions

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/organizations/{organization_id}/subscription` | GET, POST, PUT, DELETE | Medium |
| `/organizations/{organization_id}/subscription/customer` | GET, POST, PUT | Medium |
| `/organizations/{organization_id}/subscription/trial` | POST, DELETE | Medium |
| `/organizations/{organization_id}/subscription/invoice_summary` | GET | Low |
| `/organizations/{organization_id}/subscription/payment_failed` | GET | Low |
| `/organizations/{organization_id}/subscription/promocode` | POST, DELETE | Low |
| `/organizations/{organization_id}/invoices/{invoice_uid}.pdf` | GET | Low |

**Models required:**
- `Subscription`
- `SubscriptionCustomer`
- `SubscriptionInvoice`
- `SubscriptionTrial`

---

## Phase 5: Calendar Integration (Priority: Low)
**Estimated Effort:** 2-3 days  
**Goal:** Add calendar integration support

### 5.1 New Interface: ICalendar

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/integrations/calendar` | GET | Medium |
| `/integrations/calendar/setup` | GET | Medium |
| `/integrations/calendar/calendars` | GET | Medium |
| `/integrations/calendar/calendars/selected` | GET | Low |
| `/integrations/calendar/events` | GET | Medium |
| `/integrations/calendar/events/update` | POST | Medium |
| `/integrations/calendar/events/details-suggestion` | POST | Low |
| `/integrations/calendar/{integration_id}` | PUT, DELETE | Medium |
| `/integrations/calendar/{integration_id}/calendars` | GET | Low |
| `/integrations/calendar/{integration_id}/calendars/update` | POST | Low |
| `/integrations/calendar/{integration_id}/calendars/{calendar_id}` | PATCH | Low |

**Models required:**
- `CalendarIntegration`
- `Calendar`
- `CalendarEvent`
- `CalendarEventSuggestion`

---

## Phase 6: Reports API (Priority: Medium)
**Estimated Effort:** 3-4 days  
**Goal:** Complete reports API coverage

### 6.1 Enhance IReports
*Requires analysis of `reports-90f73336280ee8fda8a76dcf30502c88.json`*

| Endpoint Category | Priority |
|-------------------|----------|
| Summary Reports | High |
| Detailed Reports | High |
| Weekly Reports | Medium |
| Project Reports | Medium |
| Saved Reports | Low |
| Shared Reports | Low |

**Models required:**
- `SummaryReport`
- `WeeklyReport`
- `SavedReport`
- Additional report-specific DTOs

---

## Phase 7: Webhooks API (Priority: Low)
**Estimated Effort:** 1-2 days  
**Goal:** Add webhook support

### 7.1 New Interface: IWebhooks
*Requires analysis of `webhooks-479d375ba167e9f885df9356e34a7c4e.json`*

| Endpoint Category | Priority |
|-------------------|----------|
| Webhook Subscriptions | Medium |
| Webhook Events | Medium |
| Webhook Management | Medium |

**Models required:**
- `Webhook`
- `WebhookSubscription`
- `WebhookEvent`
- `WebhookPayload`

---

## Phase 8: Miscellaneous & Utility Endpoints (Priority: Low)
**Estimated Effort:** 1-2 days  
**Goal:** Add remaining utility endpoints

### 8.1 New Interface: IUtilities

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/countries` | GET | Medium |
| `/countries/{country_id}/subdivisions` | GET | Low |
| `/currencies` | GET | Medium |
| `/feedback` | POST | Low |
| `/keys` | GET | Low |

**Models required:**
- `Country`
- `Subdivision`
- `Currency`
- `FeedbackRequest`

### 8.2 New Interface: IAvatars

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/avatars` | POST, DELETE | Low |
| `/avatars/use_gravatar` | POST | Low |

**Models required:**
- `Avatar`

### 8.3 New Interface: IAuditLogs

| Endpoint | Method | Priority |
|----------|--------|----------|
| `/audit_logs/{organization_id}/{from}/{to}` | GET | Medium |

**Models required:**
- `AuditLog`
- `AuditLogEntry`

---

## Implementation Guidelines

### For Each New Endpoint:
1. **Add interface method** with proper XML documentation
2. **Create/update models** as needed with `[JsonPropertyName]` attributes
3. **Add `TotalCount` property** to list response models (per copilot-instructions.md)
4. **Add unit tests** in `Toggl.Api.Test` project
5. **Update TogglClient.cs** if adding new interfaces

### Model Conventions:
- Use `required` keyword for mandatory properties
- Use nullable types (`?`) for optional properties
- Include `[JsonPropertyName("snake_case")]` attributes
- Add XML documentation comments
- Follow existing naming patterns

### Testing Strategy:
- Create basic connectivity tests for new endpoints
- Use integration tests with real API where possible
- Mock responses for rate-limit sensitive tests

---

## Progress Tracking

| Phase | Status | Est. Completion |
|-------|--------|-----------------|
| Phase 1 | ? Complete | December 2024 |
| Phase 2 | ? Complete | December 2024 |
| Phase 3 | ? Not Started | - |
| Phase 4 | ? Not Started | - |
| Phase 5 | ? Not Started | - |
| Phase 6 | ? Not Started | - |
| Phase 7 | ? Not Started | - |
| Phase 8 | ? Not Started | - |

**Legend:** ? Complete | ?? In Progress | ? Not Started

---

## Notes

- **API Rate Limits:** Toggl has strict rate limits (600 calls/hour for Premium). Consider this when running tests.
- **Authentication:** All endpoints use BasicAuth with API token
- **Error Handling:** Implement proper error handling for 402 (rate limit) and 429 responses
- **Breaking Changes:** Monitor Toggl API changelog for deprecations

---

*Last Updated: December 2024*

# Toggl.Api nuget package

[![Nuget](https://img.shields.io/nuget/v/Toggl.Api)](https://www.nuget.org/packages/Toggl.Api/)
[![Nuget](https://img.shields.io/nuget/dt/Toggl.Api)](https://www.nuget.org/packages/Toggl.Api/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/e114c9b81699410887329ecc09609863)](https://www.codacy.com/gh/panoramicdata/Toggl.Api/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=panoramicdata/Toggl.Api&amp;utm_campaign=Badge_Grade)

## Description

This is a .NET 8.0 library for the Toggl API.

We now only provide v9 support.  Many endpoints are currently missing.  Your pull requests are welcome!

## Breaking change
**To avoid the conflict with System.Threading.Tasks.Task, we have renamed the Task class to ProjectTask.
This will require you to update your code to use ProjectTask instead of Task.**

## Contributing

This project is developed using Refit and System.Text.Json.  It is a .NET 8.0 project.

Add interfaces for new endpoints in the `Interfaces` folder.
Add models in the `Models` folder.
Add unit tests in the `Toggl.Api.Tests` project.

Refer to the Toggl API documentation for more information on the endpoints and models here: https://engineering.toggl.com/docs/

## Migrating from v8 to v9

The v9 version of the library is a complete rewrite.  The main differences are:
  - The library is now .NET 8.0.
  - The library uses Refit for the API calls
  - The library uses System.Text.Json for JSON serialization
  - The library uses the new Toggl API v9 endpoints
  - The library uses the new Toggl API v9 models and these are in the `Models` namespace (previously `DataObjects`)
  - The library uses the new Toggl API v9 interfaces and these are in the `Interfaces` namespace 

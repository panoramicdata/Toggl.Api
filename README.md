# Toggl.Api nuget package

[![Nuget](https://img.shields.io/nuget/v/Toggl.Api)](https://www.nuget.org/packages/Toggl.Api/)
[![Nuget](https://img.shields.io/nuget/dt/Toggl.Api)](https://www.nuget.org/packages/Toggl.Api/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/e114c9b81699410887329ecc09609863)](https://www.codacy.com/gh/panoramicdata/Toggl.Api/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=panoramicdata/Toggl.Api&amp;utm_campaign=Badge_Grade)

## Description

This is a .NET 8.0 library for the Toggl API.

v9 support is provided in alpha only.  Many endpoints are currently missing.  You pull requests are welcome!

## Contributing

This project is developed using Refit and System.Text.Json.  It is a .NET 8.0 project.

Add interfaces for new endpoints in the `Interfaces` folder.
Add models in the `Models` folder.
Add unit tests in the `Toggl.Api.Tests` project.

Refer to the Toggl API documentation for more information on the endpoints and models here: https://engineering.toggl.com/docs/

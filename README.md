# Yandex.Dialogs.Models
[![CI](https://github.com/granstel/Yandex.Dialogs.Models/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/granstel/Yandex.Dialogs.Models/actions/workflows/ci.yml)

Models for Yandex dialogs. Supports geolocation

Install
-------
It's available via [nuget package](https://www.nuget.org/packages/Yandex.Dialogs.Models/)  
PM> `Install-Package Yandex.Dialogs.Models`

Usage in 2.0
------------

Use `System.Text.Json.JsonSerializer` to read and write the models. The SDK
defines the wire names and includes converters for cards and state values.

```csharp
using System.Text.Json;
using System.Text.Json.Serialization;
using Yandex.Dialogs.Models;
using Yandex.Dialogs.Models.Input;

var input = JsonSerializer.Deserialize<InputModel>(requestJson);
var ready = input.TryGetFromSessionState<bool>("IsReady", out var value) && value;

var output = new OutputModel
{
    Version = "1.0",
    Response = new Response { Text = ready ? "Ready" : "Let's start" }
};
var responseJson = JsonSerializer.Serialize(output, new JsonSerializerOptions
{
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
});
```

Integer state values within the `Int64` range read as `long`, and fractional or
exponent values as `double`. JSON objects and arrays in dynamic values now read
as `JsonElement` instead of Newtonsoft's `JObject` and `JArray`. Set
`PropertyNameCaseInsensitive = true` when reading noncanonical field casing.
State keys are case-sensitive.

Build and release
-----------------

Use the SDK pinned in `global.json`.

```sh
dotnet test --solution src/Yandex.Dialogs.Models.slnx -c Release
dotnet pack src/Yandex.Dialogs.Models.csproj -c Release
```

Publishing a GitHub release with a SemVer tag such as `2.1.0` or `v2.1.0`
builds the tag's commit and sends the same package to NuGet.org, GitHub Packages,
and the release assets. NuGet ignores build metadata when comparing versions.
Use **Re-run failed jobs** to retry a partial release with the existing package.

Configure NuGet.org Trusted Publishing for `granstel/Yandex.Dialogs.Models`,
workflow `release.yml`, environment `nuget`, and package `Yandex.Dialogs.Models`.
Set the environment secret `NUGET_USER` to the NuGet.org profile name.
If the package already exists on GitHub Packages, grant this repository write
access under the package's **Manage Actions access** settings.

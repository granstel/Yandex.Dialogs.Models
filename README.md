# Yandex.Dialogs.Models
[![CI](https://github.com/granstel/Yandex.Dialogs.Models/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/granstel/Yandex.Dialogs.Models/actions/workflows/ci.yml)
[![NuGet](https://buildstats.info/nuget/Yandex.Dialogs.Models)](https://www.nuget.org/packages/Yandex.Dialogs.Models)

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

<!-- voltaria-readme-assembled -->
# Voltaria C# Library

## Quickstart

Install the package:

```bash
dotnet add package Voltaria.Sdk
```

Construct a client and make your first read call. The base URL is resolved automatically from your API-key prefix:

```csharp
using Voltaria;

// Production
var client = new VoltariaClient("live_...");

// Sandbox
// var client = new VoltariaClient("sandbox_...");

var loans = await client.Loans.ListLoansAsync(new ListLoansRequest());
```

| Key prefix | Environment | Base URL                          |
| ---------- | ----------- | --------------------------------- |
| `live_`    | Production  | `https://api.voltaria.io`         |
| `sandbox_` | Sandbox     | `https://api.sandbox.voltaria.io` |

Passing explicit options (an `Environment` or `BaseUrl` via `VoltariaOptions`) overrides prefix routing.

See [reference.md](./reference.md) for the full API reference.

---

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=Voltaria%2FC%23)
[![nuget shield](https://img.shields.io/nuget/v/Voltaria)](https://nuget.org/packages/Voltaria)

The Voltaria C# library provides convenient access to the Voltaria APIs from C#.

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Reference](#reference)
- [Usage](#usage)
- [Environments](#environments)
- [Exception Handling](#exception-handling)
- [Advanced](#advanced)
  - [Retries](#retries)
  - [Timeouts](#timeouts)
  - [Raw Response](#raw-response)
  - [Additional Headers](#additional-headers)
  - [Additional Query Parameters](#additional-query-parameters)
  - [Forward Compatible Enums](#forward-compatible-enums)
- [Contributing](#contributing)

## Requirements

This SDK requires:

## Installation

```sh
dotnet add package Voltaria
```

## Reference

A full reference for this library is available [here](./reference.md).

## Usage

Instantiate and use the client with the following:

```csharp
using Voltaria;

var client = new VoltariaApiClient("TOKEN");
await client.Clients.CreateClientAsync(
    new ClientCreatePayload { Name = "ACME Corp", Jurisdiction = JurisdictionEnum.Eu }
);
```

## Environments

This SDK allows you to configure different environments for API requests.

```csharp
using Voltaria;

var client = new VoltariaApiClient(new ClientOptions
{
    BaseUrl = VoltariaApiEnvironment.Sandbox
});
```

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a subclass of the following error
will be thrown.

```csharp
using Voltaria;

try {
    var response = await client.Clients.CreateClientAsync(...);
} catch (VoltariaApiApiException e) {
    System.Console.WriteLine(e.Body);
    System.Console.WriteLine(e.StatusCode);
}
```

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

Which status codes are retried depends on the `retryStatusCodes` generator configuration:

**`legacy`** (current default): retries on
- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status#server_error_responses) (All server errors, including 500)

**`recommended`**: retries on
- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [502](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/502) (Bad Gateway)
- [503](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/503) (Service Unavailable)
- [504](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/504) (Gateway Timeout)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.Clients.CreateClientAsync(
    ...,
    new RequestOptions {
        MaxRetries: 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.Clients.CreateClientAsync(
    ...,
    new RequestOptions {
        Timeout: TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

### Raw Response

Access raw HTTP response data (status code, headers, URL) alongside parsed response data using the `.WithRawResponse()` method.

```csharp
using Voltaria;

// Access raw response data (status code, headers, etc.) alongside the parsed response
var result = await client.Clients.CreateClientAsync(...).WithRawResponse();

// Access the parsed data
var data = result.Data;

// Access raw response metadata
var statusCode = result.RawResponse.StatusCode;
var headers = result.RawResponse.Headers;
var url = result.RawResponse.Url;

// Access specific headers (case-insensitive)
if (headers.TryGetValue("X-Request-Id", out var requestId))
{
    System.Console.WriteLine($"Request ID: {requestId}");
}

// For the default behavior, simply await without .WithRawResponse()
var data = await client.Clients.CreateClientAsync(...);
```

### Additional Headers

If you would like to send additional headers as part of the request, use the `AdditionalHeaders` request option.

```csharp
var response = await client.Clients.CreateClientAsync(
    ...,
    new RequestOptions {
        AdditionalHeaders = new Dictionary<string, string?>
        {
            { "X-Custom-Header", "custom-value" }
        }
    }
);
```

### Additional Query Parameters

If you would like to send additional query parameters as part of the request, use the `AdditionalQueryParameters` request option.

```csharp
var response = await client.Clients.CreateClientAsync(
    ...,
    new RequestOptions {
        AdditionalQueryParameters = new Dictionary<string, string>
        {
            { "custom_param", "custom-value" }
        }
    }
);
```

### Forward Compatible Enums

This SDK uses forward-compatible enums that can handle unknown values gracefully.

```csharp
using Voltaria;

// Using a built-in value
var partnerClientAccountCreateRequestStatus = PartnerClientAccountCreateRequestStatus.Active;

// Using a custom value
var customPartnerClientAccountCreateRequestStatus = PartnerClientAccountCreateRequestStatus.FromCustom("custom-value");

// Using in a switch statement
switch (partnerClientAccountCreateRequestStatus.Value)
{
    case PartnerClientAccountCreateRequestStatus.Values.Active:
        Console.WriteLine("Active");
        break;
    default:
        Console.WriteLine($"Unknown value: {partnerClientAccountCreateRequestStatus.Value}");
        break;
}

// Explicit casting
string partnerClientAccountCreateRequestStatusString = (string)PartnerClientAccountCreateRequestStatus.Active;
PartnerClientAccountCreateRequestStatus partnerClientAccountCreateRequestStatusFromString = (PartnerClientAccountCreateRequestStatus)"active";
```

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!

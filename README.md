# Dedalus C# API Library

The Dedalus C# SDK provides convenient access to the [Dedalus REST API](https://docs.dedaluslabs.ai) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [docs.dedaluslabs.ai](https://docs.dedaluslabs.ai).

## Installation

```bash
git clone git@github.com:dedalus-labs/dedalus-csharp.git
dotnet add reference dedalus-csharp/src/Dedalus
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Dedalus;
using Dedalus.Models.Machines;

DedalusClient client = new();

MachineCreateParams parameters = new()
{
    MemoryMiB = 2048,
    StorageGiB = 10,
    Vcpu = 1,
};

var machine = await client.Machines.Create(parameters);

Console.WriteLine(machine);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Dedalus;

// Configured using the DEDALUS_API_KEY, DEDALUS_X_API_KEY, DEDALUS_ORG_ID and DEDALUS_BASE_URL environment variables
DedalusClient client = new();
```

Or manually:

```csharp
using Dedalus;

DedalusClient client = new() { ApiKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property       | Environment variable | Required | Default value                  |
| -------------- | -------------------- | -------- | ------------------------------ |
| `ApiKey`       | `DEDALUS_API_KEY`    | false    | -                              |
| `XApiKey`      | `DEDALUS_X_API_KEY`  | false    | -                              |
| `DedalusOrgID` | `DEDALUS_ORG_ID`     | false    | -                              |
| `BaseUrl`      | `DEDALUS_BASE_URL`   | true     | `"https://dcs.dedaluslabs.ai"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var machine = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Machines.Create(parameters);

Console.WriteLine(machine);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Dedalus API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Machines.Create` should be called with an instance of `MachineCreateParams`, and it will return an instance of `Task<Machine>`.

## Streaming

The SDK defines methods that return response "chunk" streams, where each chunk can be individually processed as soon as it arrives instead of waiting on the full response. Streaming methods generally correspond to [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events) or [JSONL](https://jsonlines.org) responses.

Some of these methods may have streaming and non-streaming variants, but a streaming method will always have a `Streaming` suffix in its name, even if it doesn't have a non-streaming variant.

These streaming methods return [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1):

```csharp
using System;
using Dedalus.Models.Machines;

MachineWatchParams parameters = new() { MachineID = "dm-3" };

await foreach (var machine in client.Machines.WatchStreaming(parameters))
{
    Console.WriteLine(machine);
}
```

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Machines.Create(parameters);
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using Dedalus.Models.Machines;

var response = await client.WithRawResponse.Machines.Create(parameters);
Machine deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

For streaming responses, you can deserialize the response to an [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1) if needed:

```csharp
using System;

var response = await client.WithRawResponse.Machines.WatchStreaming(parameters);
await foreach (var item in response.Enumerate())
{
    Console.WriteLine(item);
}
```

## Error handling

The SDK throws custom unchecked exception types:

- `DedalusApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                              |
| ------ | -------------------------------------- |
| 400    | `DedalusBadRequestException`           |
| 401    | `DedalusUnauthorizedException`         |
| 403    | `DedalusForbiddenException`            |
| 404    | `DedalusNotFoundException`             |
| 422    | `DedalusUnprocessableEntityException`  |
| 429    | `DedalusRateLimitException`            |
| 5xx    | `Dedalus5xxException`                  |
| others | `DedalusUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Dedalus4xxException`.

- `DedalusSseException`: thrown for errors encountered during [SSE streaming](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events) after a successful initial HTTP response.

- `DedalusIOException`: I/O networking errors.

- `DedalusInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `DedalusException`: Base class for all exceptions.

## Pagination

The SDK defines methods that return a paginated lists of results. It provides convenient ways to access the results either one page at a time or item-by-item across all pages.

### Auto-pagination

To iterate through all results across all pages, use the `Paginate` method, which automatically fetches more pages as needed. The method returns an [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1):

```csharp
using System;

var page = await client.Machines.List(parameters);
await foreach (var item in page.Paginate())
{
    Console.WriteLine(item);
}
```

### Manual pagination

To access individual page items and manually request the next page, use the `Items` property, and `HasNext` and `Next` methods:

```csharp
using System;

var page = await client.Machines.List();
while (true)
{
    foreach (var item in page.Items)
    {
        Console.WriteLine(item);
    }
    if (!page.HasNext())
    {
        break;
    }
    page = await page.Next();
}
```

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Dedalus;

DedalusClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var machine = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Machines.Create(parameters);

Console.WriteLine(machine);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Dedalus;

DedalusClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var machine = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Machines.Create(parameters);

Console.WriteLine(machine);
```

### Proxies

To route requests through a proxy, configure your client with a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0):

```csharp
using System.Net;
using System.Net.Http;
using Dedalus;

var httpClient = new HttpClient
(
    new HttpClientHandler
    {
        Proxy = new WebProxy("https://example.com:8080")
    }
);

DedalusClient client = new() { HttpClient = httpClient };
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Parameters

To set undocumented parameters, a constructor exists that accepts dictionaries for additional header, query, and body values. If the method type doesn't support request bodies (e.g. `GET` requests), the constructor will only accept a header and query dictionary.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Models.Machines;

MachineCreateParams parameters = new
(
    rawHeaderData: new Dictionary<string, JsonElement>()
    {
        { "Custom-Header", JsonSerializer.SerializeToElement(42) }
    },

    rawQueryData: new Dictionary<string, JsonElement>()
    {
        { "custom_query_param", JsonSerializer.SerializeToElement(42) }
    },

    rawBodyData: new Dictionary<string, JsonElement>()
    {
        { "custom_body_param", JsonSerializer.SerializeToElement(42) }
    }
)
{
    // Documented properties can still be added here.
    // In case of conflict, these parameters take precedence over the custom parameters.
    MemoryMiB = 0
};
```

The raw parameters can also be accessed through the `RawHeaderData`, `RawQueryData`, and `RawBodyData` (if available) properties.

This can also be used to set a documented parameter to an undocumented or not yet supported _value_, as long as the parameter is optional. If the parameter is required, omitting its `init` property will result in a compile-time error. To work around this, the `FromRawUnchecked` method can be used:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Models.Machines;

var parameters = MachineCreateParams.FromRawUnchecked
(

    rawHeaderData: new Dictionary<string, JsonElement>(),
    rawQueryData: new Dictionary<string, JsonElement>(),
    rawBodyData: new Dictionary<string, JsonElement>
    {
        {
            "memory_mib",
            JsonSerializer.SerializeToElement("custom value")
        }
    }
);
```

### Response properties

To access undocumented response properties, the `RawData` property can be used:

```csharp
using System.Text.Json;

var response = client.Machines.Create(parameters)
if (response.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Do something with `value`
}
```

`RawData` is a `IReadonlyDictionary<string, JsonElement>`. It holds the full data received from the API server.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `DedalusInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var machine = client.Machines.Create(parameters);
machine.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Dedalus;

DedalusClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var machine = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Machines.Create(parameters);

Console.WriteLine(machine);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/dedalus-labs/dedalus-csharp/issues) with questions, bugs, or suggestions.

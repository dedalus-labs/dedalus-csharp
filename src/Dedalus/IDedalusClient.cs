using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Services;

namespace Dedalus;

/// <summary>
/// A client for interacting with the Dedalus REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDedalusClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Dedalus API key sent as Authorization Bearer.
    /// </summary>
    string? ApiKey { get; init; }

    /// <summary>
    /// Dedalus API key sent as x-api-key header.
    /// </summary>
    string? XApiKey { get; init; }

    /// <summary>
    /// Organization ID header for all DCS requests.
    /// </summary>
    string? DedalusOrgID { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDedalusClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDedalusClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMachineService Machines { get; }
}

/// <summary>
/// A view of <see cref="IDedalusClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IDedalusClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Dedalus API key sent as Authorization Bearer.
    /// </summary>
    string? ApiKey { get; init; }

    /// <summary>
    /// Dedalus API key sent as x-api-key header.
    /// </summary>
    string? XApiKey { get; init; }

    /// <summary>
    /// Organization ID header for all DCS requests.
    /// </summary>
    string? DedalusOrgID { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDedalusClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMachineServiceWithRawResponse Machines { get; }

    /// <summary>
    /// Sends a request to the Dedalus REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}

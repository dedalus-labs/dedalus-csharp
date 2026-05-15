using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Ssh;

namespace Dedalus.Services.Machines;

/// <inheritdoc/>
public sealed class SshService : ISshService
{
    readonly Lazy<ISshServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISshServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public ISshService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SshService(this._client.WithOptions(modifier));
    }

    public SshService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SshServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SshSession> Create(
        SshCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SshSession> Retrieve(
        SshRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SshListPage> List(
        SshListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SshSession> Delete(
        SshDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SshServiceWithRawResponse : ISshServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISshServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SshServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SshServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SshSession>> Create(
        SshCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SshCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var sshSession = await response
                    .Deserialize<SshSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    sshSession.Validate();
                }
                return sshSession;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SshSession>> Retrieve(
        SshRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SshRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var sshSession = await response
                    .Deserialize<SshSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    sshSession.Validate();
                }
                return sshSession;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SshListPage>> List(
        SshListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SshListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response.Deserialize<SshSessionList>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SshListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SshSession>> Delete(
        SshDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SshDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var sshSession = await response
                    .Deserialize<SshSession>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    sshSession.Validate();
                }
                return sshSession;
            }
        );
    }
}

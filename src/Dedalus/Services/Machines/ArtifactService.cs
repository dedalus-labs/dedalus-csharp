using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Artifacts;

namespace Dedalus.Services.Machines;

/// <inheritdoc/>
public sealed class ArtifactService : IArtifactService
{
    readonly Lazy<IArtifactServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IArtifactServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IArtifactService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ArtifactService(this._client.WithOptions(modifier));
    }

    public ArtifactService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ArtifactServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Artifact> Retrieve(
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ArtifactListPage> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Artifact> Delete(
        ArtifactDeleteParams parameters,
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
public sealed class ArtifactServiceWithRawResponse : IArtifactServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IArtifactServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ArtifactServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ArtifactServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Artifact>> Retrieve(
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ArtifactRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var artifact = await response.Deserialize<Artifact>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    artifact.Validate();
                }
                return artifact;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ArtifactListPage>> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ArtifactListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response.Deserialize<ArtifactList>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ArtifactListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Artifact>> Delete(
        ArtifactDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ArtifactDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var artifact = await response.Deserialize<Artifact>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    artifact.Validate();
                }
                return artifact;
            }
        );
    }
}

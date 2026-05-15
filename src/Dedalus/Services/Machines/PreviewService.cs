using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Previews;

namespace Dedalus.Services.Machines;

/// <inheritdoc/>
public sealed class PreviewService : IPreviewService
{
    readonly Lazy<IPreviewServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPreviewServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IPreviewService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreviewService(this._client.WithOptions(modifier));
    }

    public PreviewService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PreviewServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Preview> Create(
        PreviewCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Preview> Retrieve(
        PreviewRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PreviewListPage> List(
        PreviewListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Preview> Delete(
        PreviewDeleteParams parameters,
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
public sealed class PreviewServiceWithRawResponse : IPreviewServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPreviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreviewServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PreviewServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Preview>> Create(
        PreviewCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PreviewCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preview = await response.Deserialize<Preview>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preview.Validate();
                }
                return preview;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Preview>> Retrieve(
        PreviewRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PreviewRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preview = await response.Deserialize<Preview>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preview.Validate();
                }
                return preview;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreviewListPage>> List(
        PreviewListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PreviewListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response.Deserialize<PreviewList>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PreviewListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Preview>> Delete(
        PreviewDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PreviewDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preview = await response.Deserialize<Preview>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preview.Validate();
                }
                return preview;
            }
        );
    }
}

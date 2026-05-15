using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Services.Machines;

/// <inheritdoc/>
public sealed class TerminalService : ITerminalService
{
    readonly Lazy<ITerminalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITerminalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public ITerminalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TerminalService(this._client.WithOptions(modifier));
    }

    public TerminalService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TerminalServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Terminal> Create(
        TerminalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Terminal> Retrieve(
        TerminalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TerminalListPage> List(
        TerminalListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Terminal> Delete(
        TerminalDeleteParams parameters,
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
public sealed class TerminalServiceWithRawResponse : ITerminalServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITerminalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TerminalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TerminalServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Terminal>> Create(
        TerminalCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TerminalCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var terminal = await response.Deserialize<Terminal>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    terminal.Validate();
                }
                return terminal;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Terminal>> Retrieve(
        TerminalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TerminalRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var terminal = await response.Deserialize<Terminal>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    terminal.Validate();
                }
                return terminal;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TerminalListPage>> List(
        TerminalListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TerminalListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response.Deserialize<TerminalList>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TerminalListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Terminal>> Delete(
        TerminalDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TerminalDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var terminal = await response.Deserialize<Terminal>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    terminal.Validate();
                }
                return terminal;
            }
        );
    }
}

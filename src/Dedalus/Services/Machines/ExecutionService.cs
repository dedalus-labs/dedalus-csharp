using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Services.Machines;

/// <inheritdoc/>
public sealed class ExecutionService : IExecutionService
{
    readonly Lazy<IExecutionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExecutionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IExecutionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExecutionService(this._client.WithOptions(modifier));
    }

    public ExecutionService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ExecutionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Execution> Create(
        ExecutionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Execution> Retrieve(
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExecutionListPage> List(
        ExecutionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Execution> Delete(
        ExecutionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExecutionEventsPage> Events(
        ExecutionEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Events(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExecutionOutput> Output(
        ExecutionOutputParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Output(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ExecutionServiceWithRawResponse : IExecutionServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExecutionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExecutionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExecutionServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Execution>> Create(
        ExecutionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExecutionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var execution = await response.Deserialize<Execution>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    execution.Validate();
                }
                return execution;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Execution>> Retrieve(
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExecutionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var execution = await response.Deserialize<Execution>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    execution.Validate();
                }
                return execution;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExecutionListPage>> List(
        ExecutionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExecutionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response.Deserialize<ExecutionList>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExecutionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Execution>> Delete(
        ExecutionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExecutionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var execution = await response.Deserialize<Execution>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    execution.Validate();
                }
                return execution;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExecutionEventsPage>> Events(
        ExecutionEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExecutionEventsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response.Deserialize<ExecutionEvents>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExecutionEventsPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExecutionOutput>> Output(
        ExecutionOutputParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExecutionOutputParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var executionOutput = await response
                    .Deserialize<ExecutionOutput>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    executionOutput.Validate();
                }
                return executionOutput;
            }
        );
    }
}

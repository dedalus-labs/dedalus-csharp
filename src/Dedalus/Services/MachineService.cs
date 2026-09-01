using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines;
using Dedalus.Services.Machines;

namespace Dedalus.Services;

/// <inheritdoc/>
public sealed class MachineService : IMachineService
{
    readonly Lazy<IMachineServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMachineServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IMachineService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MachineService(this._client.WithOptions(modifier));
    }

    public MachineService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MachineServiceWithRawResponse(client.WithRawResponse));
        _ssh = new(() => new SshService(client));
        _executions = new(() => new ExecutionService(client));
    }

    readonly Lazy<ISshService> _ssh;
    public ISshService Ssh
    {
        get { return _ssh.Value; }
    }

    readonly Lazy<IExecutionService> _executions;
    public IExecutionService Executions
    {
        get { return _executions.Value; }
    }

    /// <inheritdoc/>
    public async Task<Machine> Create(
        MachineCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MachineRetrieveResponse> Retrieve(
        MachineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Machine> Update(
        MachineUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MachineListPage> List(
        MachineListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Machine> Delete(
        MachineDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Machine> Sleep(
        MachineSleepParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Sleep(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Machine> Wake(
        MachineWakeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Wake(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MachineServiceWithRawResponse : IMachineServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMachineServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MachineServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MachineServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;

        _ssh = new(() => new SshServiceWithRawResponse(client));
        _executions = new(() => new ExecutionServiceWithRawResponse(client));
    }

    readonly Lazy<ISshServiceWithRawResponse> _ssh;
    public ISshServiceWithRawResponse Ssh
    {
        get { return _ssh.Value; }
    }

    readonly Lazy<IExecutionServiceWithRawResponse> _executions;
    public IExecutionServiceWithRawResponse Executions
    {
        get { return _executions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Machine>> Create(
        MachineCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MachineCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var machine = await response.Deserialize<Machine>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    machine.Validate();
                }
                return machine;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MachineRetrieveResponse>> Retrieve(
        MachineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MachineRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var machine = await response
                    .Deserialize<MachineRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    machine.Validate();
                }
                return machine;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Machine>> Update(
        MachineUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MachineUpdateParams> request = new()
        {
            Method = DedalusClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var machine = await response.Deserialize<Machine>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    machine.Validate();
                }
                return machine;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MachineListPage>> List(
        MachineListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MachineListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response.Deserialize<MachineList>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new MachineListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Machine>> Delete(
        MachineDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MachineDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var machine = await response.Deserialize<Machine>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    machine.Validate();
                }
                return machine;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Machine>> Sleep(
        MachineSleepParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MachineSleepParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var machine = await response.Deserialize<Machine>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    machine.Validate();
                }
                return machine;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Machine>> Wake(
        MachineWakeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MachineWakeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var machine = await response.Deserialize<Machine>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    machine.Validate();
                }
                return machine;
            }
        );
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
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
        _artifacts = new(() => new ArtifactService(client));
        _previews = new(() => new PreviewService(client));
        _ssh = new(() => new SshService(client));
        _executions = new(() => new ExecutionService(client));
        _terminals = new(() => new TerminalService(client));
    }

    readonly Lazy<IArtifactService> _artifacts;
    public IArtifactService Artifacts
    {
        get { return _artifacts.Value; }
    }

    readonly Lazy<IPreviewService> _previews;
    public IPreviewService Previews
    {
        get { return _previews.Value; }
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

    readonly Lazy<ITerminalService> _terminals;
    public ITerminalService Terminals
    {
        get { return _terminals.Value; }
    }

    /// <inheritdoc/>
    public async Task<Machine> Create(
        MachineCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Machine> Retrieve(
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

    /// <inheritdoc/>
    public async IAsyncEnumerable<Machine> WatchStreaming(
        MachineWatchParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.WatchStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var machine in response.Enumerate(cancellationToken))
        {
            yield return machine;
        }
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

        _artifacts = new(() => new ArtifactServiceWithRawResponse(client));
        _previews = new(() => new PreviewServiceWithRawResponse(client));
        _ssh = new(() => new SshServiceWithRawResponse(client));
        _executions = new(() => new ExecutionServiceWithRawResponse(client));
        _terminals = new(() => new TerminalServiceWithRawResponse(client));
    }

    readonly Lazy<IArtifactServiceWithRawResponse> _artifacts;
    public IArtifactServiceWithRawResponse Artifacts
    {
        get { return _artifacts.Value; }
    }

    readonly Lazy<IPreviewServiceWithRawResponse> _previews;
    public IPreviewServiceWithRawResponse Previews
    {
        get { return _previews.Value; }
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

    readonly Lazy<ITerminalServiceWithRawResponse> _terminals;
    public ITerminalServiceWithRawResponse Terminals
    {
        get { return _terminals.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Machine>> Create(
        MachineCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
    public async Task<HttpResponse<Machine>> Retrieve(
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

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<Machine>> WatchStreaming(
        MachineWatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MachineWatchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<Machine> Enumerate([EnumeratorCancellation] CancellationToken token)
        {
            await foreach (var machine in Sse.Enumerate<Machine>(response.RawMessage, token))
            {
                if (this._client.ResponseValidation)
                {
                    machine.Validate();
                }
                yield return machine;
            }
        }
        return new(response, Enumerate);
    }
}

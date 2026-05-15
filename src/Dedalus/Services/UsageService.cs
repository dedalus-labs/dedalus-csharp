using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Usage;

namespace Dedalus.Services;

/// <inheritdoc/>
public sealed class UsageService : IUsageService
{
    readonly Lazy<IUsageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDedalusClient _client;

    /// <inheritdoc/>
    public IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageService(this._client.WithOptions(modifier));
    }

    public UsageService(IDedalusClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UsageServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<OrgUsage> Retrieve(
        UsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MachineComputeUsage> MachineCompute(
        UsageMachineComputeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.MachineCompute(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MachineStorageUsage> MachineStorage(
        UsageMachineStorageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.MachineStorage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UsageServiceWithRawResponse : IUsageServiceWithRawResponse
{
    readonly IDedalusClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UsageServiceWithRawResponse(IDedalusClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OrgUsage>> Retrieve(
        UsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UsageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var orgUsage = await response.Deserialize<OrgUsage>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    orgUsage.Validate();
                }
                return orgUsage;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MachineComputeUsage>> MachineCompute(
        UsageMachineComputeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UsageMachineComputeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var machineComputeUsage = await response
                    .Deserialize<MachineComputeUsage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    machineComputeUsage.Validate();
                }
                return machineComputeUsage;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MachineStorageUsage>> MachineStorage(
        UsageMachineStorageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UsageMachineStorageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var machineStorageUsage = await response
                    .Deserialize<MachineStorageUsage>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    machineStorageUsage.Validate();
                }
                return machineStorageUsage;
            }
        );
    }
}

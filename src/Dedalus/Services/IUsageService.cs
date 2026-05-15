using System;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Usage;

namespace Dedalus.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUsageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get usage summary
    /// </summary>
    Task<OrgUsage> Retrieve(
        UsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List machine compute usage breakdown
    /// </summary>
    Task<MachineComputeUsage> MachineCompute(
        UsageMachineComputeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List machine storage usage breakdown
    /// </summary>
    Task<MachineStorageUsage> MachineStorage(
        UsageMachineStorageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUsageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/usage</c>, but is otherwise the
    /// same as <see cref="IUsageService.Retrieve(UsageRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<OrgUsage>> Retrieve(
        UsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/usage/machines/compute</c>, but is otherwise the
    /// same as <see cref="IUsageService.MachineCompute(UsageMachineComputeParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MachineComputeUsage>> MachineCompute(
        UsageMachineComputeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/usage/machines/storage</c>, but is otherwise the
    /// same as <see cref="IUsageService.MachineStorage(UsageMachineStorageParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MachineStorageUsage>> MachineStorage(
        UsageMachineStorageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

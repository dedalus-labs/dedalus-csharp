using System;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines;
using Dedalus.Services.Machines;

namespace Dedalus.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMachineService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMachineServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMachineService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISshService Ssh { get; }

    IExecutionService Executions { get; }

    /// <summary>
    /// Create machine
    /// </summary>
    Task<Machine> Create(
        MachineCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get machine
    /// </summary>
    Task<MachineRetrieveResponse> Retrieve(
        MachineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update machine
    /// </summary>
    Task<Machine> Update(
        MachineUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List machines
    /// </summary>
    Task<MachineListPage> List(
        MachineListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Destroy machine
    /// </summary>
    Task<Machine> Delete(
        MachineDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sleep a running machine
    /// </summary>
    Task<Machine> Sleep(
        MachineSleepParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Wake a sleeping machine
    /// </summary>
    Task<Machine> Wake(MachineWakeParams parameters, CancellationToken cancellationToken = default);
}

/// <summary>
/// A view of <see cref="IMachineService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMachineServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMachineServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISshServiceWithRawResponse Ssh { get; }

    IExecutionServiceWithRawResponse Executions { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/machines</c>, but is otherwise the
    /// same as <see cref="IMachineService.Create(MachineCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Machine>> Create(
        MachineCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}</c>, but is otherwise the
    /// same as <see cref="IMachineService.Retrieve(MachineRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MachineRetrieveResponse>> Retrieve(
        MachineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/machines/{machine_id}</c>, but is otherwise the
    /// same as <see cref="IMachineService.Update(MachineUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Machine>> Update(
        MachineUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines</c>, but is otherwise the
    /// same as <see cref="IMachineService.List(MachineListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MachineListPage>> List(
        MachineListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/machines/{machine_id}</c>, but is otherwise the
    /// same as <see cref="IMachineService.Delete(MachineDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Machine>> Delete(
        MachineDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/machines/{machine_id}/sleep</c>, but is otherwise the
    /// same as <see cref="IMachineService.Sleep(MachineSleepParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Machine>> Sleep(
        MachineSleepParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/machines/{machine_id}/wake</c>, but is otherwise the
    /// same as <see cref="IMachineService.Wake(MachineWakeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Machine>> Wake(
        MachineWakeParams parameters,
        CancellationToken cancellationToken = default
    );
}

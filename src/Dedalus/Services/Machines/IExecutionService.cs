using System;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Services.Machines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExecutionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExecutionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExecutionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create execution
    /// </summary>
    Task<Execution> Create(
        ExecutionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get execution
    /// </summary>
    Task<Execution> Retrieve(
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List executions
    /// </summary>
    Task<ExecutionListPage> List(
        ExecutionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete execution
    /// </summary>
    Task<Execution> Delete(
        ExecutionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List execution events
    /// </summary>
    Task<ExecutionEventsPage> Events(
        ExecutionEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get execution output
    /// </summary>
    Task<ExecutionOutput> Output(
        ExecutionOutputParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExecutionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExecutionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExecutionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/machines/{machine_id}/executions</c>, but is otherwise the
    /// same as <see cref="IExecutionService.Create(ExecutionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Execution>> Create(
        ExecutionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/executions/{execution_id}</c>, but is otherwise the
    /// same as <see cref="IExecutionService.Retrieve(ExecutionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Execution>> Retrieve(
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/executions</c>, but is otherwise the
    /// same as <see cref="IExecutionService.List(ExecutionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExecutionListPage>> List(
        ExecutionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/machines/{machine_id}/executions/{execution_id}</c>, but is otherwise the
    /// same as <see cref="IExecutionService.Delete(ExecutionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Execution>> Delete(
        ExecutionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/executions/{execution_id}/events</c>, but is otherwise the
    /// same as <see cref="IExecutionService.Events(ExecutionEventsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExecutionEventsPage>> Events(
        ExecutionEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/executions/{execution_id}/output</c>, but is otherwise the
    /// same as <see cref="IExecutionService.Output(ExecutionOutputParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExecutionOutput>> Output(
        ExecutionOutputParams parameters,
        CancellationToken cancellationToken = default
    );
}

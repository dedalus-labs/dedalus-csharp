using System;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Services.Machines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITerminalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITerminalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITerminalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create terminal
    /// </summary>
    Task<Terminal> Create(
        TerminalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get terminal
    /// </summary>
    Task<Terminal> Retrieve(
        TerminalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List terminals
    /// </summary>
    Task<TerminalListPage> List(
        TerminalListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete terminal
    /// </summary>
    Task<Terminal> Delete(
        TerminalDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITerminalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITerminalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITerminalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/machines/{machine_id}/terminals</c>, but is otherwise the
    /// same as <see cref="ITerminalService.Create(TerminalCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Terminal>> Create(
        TerminalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/terminals/{terminal_id}</c>, but is otherwise the
    /// same as <see cref="ITerminalService.Retrieve(TerminalRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Terminal>> Retrieve(
        TerminalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/terminals</c>, but is otherwise the
    /// same as <see cref="ITerminalService.List(TerminalListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TerminalListPage>> List(
        TerminalListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/machines/{machine_id}/terminals/{terminal_id}</c>, but is otherwise the
    /// same as <see cref="ITerminalService.Delete(TerminalDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Terminal>> Delete(
        TerminalDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

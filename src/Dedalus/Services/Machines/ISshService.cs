using System;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Ssh;

namespace Dedalus.Services.Machines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISshService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISshServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISshService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create SSH session
    /// </summary>
    Task<SshSession> Create(
        SshCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get SSH session
    /// </summary>
    Task<SshSession> Retrieve(
        SshRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List SSH sessions
    /// </summary>
    Task<SshListPage> List(SshListParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete SSH session
    /// </summary>
    Task<SshSession> Delete(
        SshDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISshService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISshServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISshServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/machines/{machine_id}/ssh</c>, but is otherwise the
    /// same as <see cref="ISshService.Create(SshCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SshSession>> Create(
        SshCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/ssh/{session_id}</c>, but is otherwise the
    /// same as <see cref="ISshService.Retrieve(SshRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SshSession>> Retrieve(
        SshRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/ssh</c>, but is otherwise the
    /// same as <see cref="ISshService.List(SshListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SshListPage>> List(
        SshListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/machines/{machine_id}/ssh/{session_id}</c>, but is otherwise the
    /// same as <see cref="ISshService.Delete(SshDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SshSession>> Delete(
        SshDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

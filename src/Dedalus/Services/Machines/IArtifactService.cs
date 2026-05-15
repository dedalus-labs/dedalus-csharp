using System;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Artifacts;

namespace Dedalus.Services.Machines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IArtifactService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IArtifactServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IArtifactService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get artifact
    /// </summary>
    Task<Artifact> Retrieve(
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List artifacts
    /// </summary>
    Task<ArtifactListPage> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete artifact
    /// </summary>
    Task<Artifact> Delete(
        ArtifactDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IArtifactService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IArtifactServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IArtifactServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/artifacts/{artifact_id}</c>, but is otherwise the
    /// same as <see cref="IArtifactService.Retrieve(ArtifactRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Artifact>> Retrieve(
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/artifacts</c>, but is otherwise the
    /// same as <see cref="IArtifactService.List(ArtifactListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ArtifactListPage>> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/machines/{machine_id}/artifacts/{artifact_id}</c>, but is otherwise the
    /// same as <see cref="IArtifactService.Delete(ArtifactDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Artifact>> Delete(
        ArtifactDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

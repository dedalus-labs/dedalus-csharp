using System;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Models.Machines.Previews;

namespace Dedalus.Services.Machines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPreviewService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPreviewServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreviewService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create preview
    /// </summary>
    Task<Preview> Create(
        PreviewCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get preview
    /// </summary>
    Task<Preview> Retrieve(
        PreviewRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List previews
    /// </summary>
    Task<PreviewListPage> List(
        PreviewListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete preview
    /// </summary>
    Task<Preview> Delete(
        PreviewDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPreviewService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPreviewServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/machines/{machine_id}/previews</c>, but is otherwise the
    /// same as <see cref="IPreviewService.Create(PreviewCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Preview>> Create(
        PreviewCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/previews/{preview_id}</c>, but is otherwise the
    /// same as <see cref="IPreviewService.Retrieve(PreviewRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Preview>> Retrieve(
        PreviewRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/machines/{machine_id}/previews</c>, but is otherwise the
    /// same as <see cref="IPreviewService.List(PreviewListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreviewListPage>> List(
        PreviewListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/machines/{machine_id}/previews/{preview_id}</c>, but is otherwise the
    /// same as <see cref="IPreviewService.Delete(PreviewDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Preview>> Delete(
        PreviewDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

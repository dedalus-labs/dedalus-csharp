using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Services.Machines;

namespace Dedalus.Models.Machines.Executions;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IExecutionService.Events(ExecutionEventsParams, CancellationToken)"/> queries.
/// </summary>
public sealed class ExecutionEventsPage(
    IExecutionServiceWithRawResponse service,
    ExecutionEventsParams parameters,
    ExecutionEvents response
) : IPage<ExecutionEvent>
{
    /// <inheritdoc/>
    public IReadOnlyList<ExecutionEvent> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.NextCursor != null;
        }
        catch (DedalusInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<ExecutionEvent>> IPage<ExecutionEvent>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ExecutionEventsPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.NextCursor ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .Events(parameters with { Cursor = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not ExecutionEventsPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}

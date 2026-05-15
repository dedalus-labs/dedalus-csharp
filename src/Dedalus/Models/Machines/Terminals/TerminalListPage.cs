using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Services.Machines;

namespace Dedalus.Models.Machines.Terminals;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ITerminalService.List(TerminalListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class TerminalListPage(
    ITerminalServiceWithRawResponse service,
    TerminalListParams parameters,
    TerminalList response
) : IPage<Terminal>
{
    /// <inheritdoc/>
    public IReadOnlyList<Terminal> Items
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
    async Task<IPage<Terminal>> IPage<Terminal>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<TerminalListPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.NextCursor ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .List(parameters with { Cursor = nextCursor }, cancellationToken)
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
        if (obj is not TerminalListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}

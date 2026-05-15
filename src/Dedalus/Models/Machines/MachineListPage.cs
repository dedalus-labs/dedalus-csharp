using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Services;

namespace Dedalus.Models.Machines;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IMachineService.List(MachineListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class MachineListPage(
    IMachineServiceWithRawResponse service,
    MachineListParams parameters,
    MachineList response
) : IPage<MachineListItem>
{
    /// <inheritdoc/>
    public IReadOnlyList<MachineListItem> Items
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
    async Task<IPage<MachineListItem>> IPage<MachineListItem>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<MachineListPage> Next(CancellationToken cancellationToken = default)
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
        if (obj is not MachineListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}

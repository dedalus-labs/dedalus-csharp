using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines;

[JsonConverter(typeof(JsonModelConverter<MachineList, MachineListFromRaw>))]
public sealed record class MachineList : JsonModel
{
    public required IReadOnlyList<MachineListItem>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MachineListItem>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MachineListItem>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("next_cursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public MachineList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachineList(MachineList machineList)
        : base(machineList) { }
#pragma warning restore CS8618

    public MachineList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MachineList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MachineListFromRaw.FromRawUnchecked"/>
    public static MachineList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MachineList(IReadOnlyList<MachineListItem>? items)
        : this()
    {
        this.Items = items;
    }
}

class MachineListFromRaw : IFromRawJson<MachineList>
{
    /// <inheritdoc/>
    public MachineList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MachineList.FromRawUnchecked(rawData);
}

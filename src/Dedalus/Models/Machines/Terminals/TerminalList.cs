using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(typeof(JsonModelConverter<TerminalList, TerminalListFromRaw>))]
public sealed record class TerminalList : JsonModel
{
    public required IReadOnlyList<Terminal>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Terminal>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Terminal>?>(
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

    public TerminalList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TerminalList(TerminalList terminalList)
        : base(terminalList) { }
#pragma warning restore CS8618

    public TerminalList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TerminalList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TerminalListFromRaw.FromRawUnchecked"/>
    public static TerminalList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TerminalList(IReadOnlyList<Terminal>? items)
        : this()
    {
        this.Items = items;
    }
}

class TerminalListFromRaw : IFromRawJson<TerminalList>
{
    /// <inheritdoc/>
    public TerminalList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TerminalList.FromRawUnchecked(rawData);
}

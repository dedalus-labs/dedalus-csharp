using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Ssh;

[JsonConverter(typeof(JsonModelConverter<SshSessionList, SshSessionListFromRaw>))]
public sealed record class SshSessionList : JsonModel
{
    public required IReadOnlyList<SshSession>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SshSession>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SshSession>?>(
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

    public SshSessionList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SshSessionList(SshSessionList sshSessionList)
        : base(sshSessionList) { }
#pragma warning restore CS8618

    public SshSessionList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SshSessionList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SshSessionListFromRaw.FromRawUnchecked"/>
    public static SshSessionList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SshSessionList(IReadOnlyList<SshSession>? items)
        : this()
    {
        this.Items = items;
    }
}

class SshSessionListFromRaw : IFromRawJson<SshSessionList>
{
    /// <inheritdoc/>
    public SshSessionList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SshSessionList.FromRawUnchecked(rawData);
}

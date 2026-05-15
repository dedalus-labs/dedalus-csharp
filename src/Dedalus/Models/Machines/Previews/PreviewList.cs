using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Previews;

[JsonConverter(typeof(JsonModelConverter<PreviewList, PreviewListFromRaw>))]
public sealed record class PreviewList : JsonModel
{
    public required IReadOnlyList<Preview>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Preview>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Preview>?>(
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

    public PreviewList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviewList(PreviewList previewList)
        : base(previewList) { }
#pragma warning restore CS8618

    public PreviewList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviewList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviewListFromRaw.FromRawUnchecked"/>
    public static PreviewList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreviewList(IReadOnlyList<Preview>? items)
        : this()
    {
        this.Items = items;
    }
}

class PreviewListFromRaw : IFromRawJson<PreviewList>
{
    /// <inheritdoc/>
    public PreviewList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PreviewList.FromRawUnchecked(rawData);
}

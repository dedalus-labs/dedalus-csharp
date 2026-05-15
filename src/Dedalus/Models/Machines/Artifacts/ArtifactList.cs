using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Artifacts;

[JsonConverter(typeof(JsonModelConverter<ArtifactList, ArtifactListFromRaw>))]
public sealed record class ArtifactList : JsonModel
{
    public required IReadOnlyList<Artifact>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Artifact>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Artifact>?>(
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

    public ArtifactList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactList(ArtifactList artifactList)
        : base(artifactList) { }
#pragma warning restore CS8618

    public ArtifactList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtifactListFromRaw.FromRawUnchecked"/>
    public static ArtifactList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ArtifactList(IReadOnlyList<Artifact>? items)
        : this()
    {
        this.Items = items;
    }
}

class ArtifactListFromRaw : IFromRawJson<ArtifactList>
{
    /// <inheritdoc/>
    public ArtifactList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ArtifactList.FromRawUnchecked(rawData);
}

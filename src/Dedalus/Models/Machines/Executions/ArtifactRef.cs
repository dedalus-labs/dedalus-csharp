using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Executions;

[JsonConverter(typeof(JsonModelConverter<ArtifactRef, ArtifactRefFromRaw>))]
public sealed record class ArtifactRef : JsonModel
{
    public required string ArtifactID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("artifact_id");
        }
        init { this._rawData.Set("artifact_id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ArtifactID;
        _ = this.Name;
    }

    public ArtifactRef() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactRef(ArtifactRef artifactRef)
        : base(artifactRef) { }
#pragma warning restore CS8618

    public ArtifactRef(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactRef(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtifactRefFromRaw.FromRawUnchecked"/>
    public static ArtifactRef FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ArtifactRefFromRaw : IFromRawJson<ArtifactRef>
{
    /// <inheritdoc/>
    public ArtifactRef FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ArtifactRef.FromRawUnchecked(rawData);
}

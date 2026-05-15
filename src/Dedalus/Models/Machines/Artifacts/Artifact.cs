using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Artifacts;

[JsonConverter(typeof(JsonModelConverter<Artifact, ArtifactFromRaw>))]
public sealed record class Artifact : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string MachineID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("machine_id");
        }
        init { this._rawData.Set("machine_id", value); }
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

    public required long SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("size_bytes");
        }
        init { this._rawData.Set("size_bytes", value); }
    }

    public string? DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("download_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("download_url", value);
        }
    }

    public string? ExecutionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("execution_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("execution_id", value);
        }
    }

    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expires_at", value);
        }
    }

    public string? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mime_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mime_type", value);
        }
    }

    public string? Sha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sha256");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sha256", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ArtifactID;
        _ = this.CreatedAt;
        _ = this.MachineID;
        _ = this.Name;
        _ = this.SizeBytes;
        _ = this.DownloadUrl;
        _ = this.ExecutionID;
        _ = this.ExpiresAt;
        _ = this.MimeType;
        _ = this.Sha256;
    }

    public Artifact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Artifact(Artifact artifact)
        : base(artifact) { }
#pragma warning restore CS8618

    public Artifact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Artifact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtifactFromRaw.FromRawUnchecked"/>
    public static Artifact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ArtifactFromRaw : IFromRawJson<Artifact>
{
    /// <inheritdoc/>
    public Artifact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Artifact.FromRawUnchecked(rawData);
}

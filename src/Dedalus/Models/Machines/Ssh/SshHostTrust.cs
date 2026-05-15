using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;

namespace Dedalus.Models.Machines.Ssh;

[JsonConverter(typeof(JsonModelConverter<SshHostTrust, SshHostTrustFromRaw>))]
public sealed record class SshHostTrust : JsonModel
{
    public required string HostPattern
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("host_pattern");
        }
        init { this._rawData.Set("host_pattern", value); }
    }

    public required ApiEnum<string, Kind> Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Kind>>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    public required string PublicKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("public_key");
        }
        init { this._rawData.Set("public_key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HostPattern;
        this.Kind.Validate();
        _ = this.PublicKey;
    }

    public SshHostTrust() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SshHostTrust(SshHostTrust sshHostTrust)
        : base(sshHostTrust) { }
#pragma warning restore CS8618

    public SshHostTrust(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SshHostTrust(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SshHostTrustFromRaw.FromRawUnchecked"/>
    public static SshHostTrust FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SshHostTrustFromRaw : IFromRawJson<SshHostTrust>
{
    /// <inheritdoc/>
    public SshHostTrust FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SshHostTrust.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(KindConverter))]
public enum Kind
{
    CertAuthority,
}

sealed class KindConverter : JsonConverter<Kind>
{
    public override Kind Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cert_authority" => Kind.CertAuthority,
            _ => (Kind)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Kind value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Kind.CertAuthority => "cert_authority",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Ssh;

[JsonConverter(typeof(JsonModelConverter<SshSessionCreateParams, SshSessionCreateParamsFromRaw>))]
public sealed record class SshSessionCreateParams : JsonModel
{
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
        _ = this.PublicKey;
    }

    public SshSessionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SshSessionCreateParams(SshSessionCreateParams sshSessionCreateParams)
        : base(sshSessionCreateParams) { }
#pragma warning restore CS8618

    public SshSessionCreateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SshSessionCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SshSessionCreateParamsFromRaw.FromRawUnchecked"/>
    public static SshSessionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SshSessionCreateParams(string publicKey)
        : this()
    {
        this.PublicKey = publicKey;
    }
}

class SshSessionCreateParamsFromRaw : IFromRawJson<SshSessionCreateParams>
{
    /// <inheritdoc/>
    public SshSessionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SshSessionCreateParams.FromRawUnchecked(rawData);
}

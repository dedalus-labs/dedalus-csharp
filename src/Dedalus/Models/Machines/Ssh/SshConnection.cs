using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Ssh;

[JsonConverter(typeof(JsonModelConverter<SshConnection, SshConnectionFromRaw>))]
public sealed record class SshConnection : JsonModel
{
    public required string Endpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("endpoint");
        }
        init { this._rawData.Set("endpoint", value); }
    }

    public required long Port
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("port");
        }
        init { this._rawData.Set("port", value); }
    }

    public required string SshUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ssh_username");
        }
        init { this._rawData.Set("ssh_username", value); }
    }

    public SshHostTrust? HostTrust
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SshHostTrust>("host_trust");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("host_trust", value);
        }
    }

    public string? UserCertificate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_certificate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_certificate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Endpoint;
        _ = this.Port;
        _ = this.SshUsername;
        this.HostTrust?.Validate();
        _ = this.UserCertificate;
    }

    public SshConnection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SshConnection(SshConnection sshConnection)
        : base(sshConnection) { }
#pragma warning restore CS8618

    public SshConnection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SshConnection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SshConnectionFromRaw.FromRawUnchecked"/>
    public static SshConnection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SshConnectionFromRaw : IFromRawJson<SshConnection>
{
    /// <inheritdoc/>
    public SshConnection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SshConnection.FromRawUnchecked(rawData);
}

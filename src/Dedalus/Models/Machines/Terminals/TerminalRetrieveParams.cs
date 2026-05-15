using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Terminals;

/// <summary>
/// Get terminal
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TerminalRetrieveParams : ParamsBase
{
    public required string MachineID { get; init; }

    public required string TerminalID { get; init; }

    public TerminalRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TerminalRetrieveParams(TerminalRetrieveParams terminalRetrieveParams)
        : base(terminalRetrieveParams)
    {
        this.MachineID = terminalRetrieveParams.MachineID;
        this.TerminalID = terminalRetrieveParams.TerminalID;
    }
#pragma warning restore CS8618

    public TerminalRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TerminalRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string machineID,
        string terminalID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.MachineID = machineID;
        this.TerminalID = terminalID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TerminalRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string machineID,
        string terminalID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            machineID,
            terminalID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["MachineID"] = JsonSerializer.SerializeToElement(this.MachineID),
                    ["TerminalID"] = JsonSerializer.SerializeToElement(this.TerminalID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TerminalRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.MachineID.Equals(other.MachineID)
            && this.TerminalID.Equals(other.TerminalID)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/machines/{0}/terminals/{1}", this.MachineID, this.TerminalID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

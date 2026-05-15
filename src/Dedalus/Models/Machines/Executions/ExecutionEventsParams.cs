using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Executions;

/// <summary>
/// List execution events
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExecutionEventsParams : ParamsBase
{
    public required string MachineID { get; init; }

    public required string ExecutionID { get; init; }

    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public ExecutionEventsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionEventsParams(ExecutionEventsParams executionEventsParams)
        : base(executionEventsParams)
    {
        this.MachineID = executionEventsParams.MachineID;
        this.ExecutionID = executionEventsParams.ExecutionID;
    }
#pragma warning restore CS8618

    public ExecutionEventsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionEventsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string machineID,
        string executionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.MachineID = machineID;
        this.ExecutionID = executionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExecutionEventsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string machineID,
        string executionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            machineID,
            executionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["MachineID"] = JsonSerializer.SerializeToElement(this.MachineID),
                    ["ExecutionID"] = JsonSerializer.SerializeToElement(this.ExecutionID),
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

    public virtual bool Equals(ExecutionEventsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.MachineID.Equals(other.MachineID)
            && this.ExecutionID.Equals(other.ExecutionID)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/machines/{0}/executions/{1}/events",
                    this.MachineID,
                    this.ExecutionID
                )
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

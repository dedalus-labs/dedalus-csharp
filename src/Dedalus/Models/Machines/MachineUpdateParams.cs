using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dedalus.Core;

namespace Dedalus.Models.Machines;

/// <summary>
/// Update machine
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MachineUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string MachineID { get; init; }

    /// <summary>
    /// Idle window before autosleep. Accepts fixed duration units like 30s, 30m,
    /// 2h, 7d3h4s, or 1w3d, raw seconds ("1800"), or never to disable.
    /// </summary>
    public string? Autosleep
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("autosleep");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("autosleep", value);
        }
    }

    /// <summary>
    /// Memory in MiB.
    /// </summary>
    public long? MemoryMiB
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("memory_mib");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("memory_mib", value);
        }
    }

    /// <summary>
    /// Storage in GiB.
    /// </summary>
    public long? StorageGiB
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("storage_gib");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("storage_gib", value);
        }
    }

    /// <summary>
    /// CPU in vCPUs.
    /// </summary>
    public double? Vcpu
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("vcpu");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("vcpu", value);
        }
    }

    public MachineUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachineUpdateParams(MachineUpdateParams machineUpdateParams)
        : base(machineUpdateParams)
    {
        this.MachineID = machineUpdateParams.MachineID;

        this._rawBodyData = new(machineUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MachineUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MachineUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string machineID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.MachineID = machineID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MachineUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string machineID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            machineID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["MachineID"] = JsonSerializer.SerializeToElement(this.MachineID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MachineUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.MachineID.Equals(other.MachineID)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/machines/{0}", this.MachineID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Dedalus.Core;

namespace Dedalus.Models.Usage;

/// <summary>
/// List machine compute usage breakdown
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UsageMachineComputeParams : ParamsBase
{
    /// <summary>
    /// Usage breakdown granularity: hour or day. Defaults to hour.
    /// </summary>
    public string? Granularity
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("granularity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("granularity", value);
        }
    }

    /// <summary>
    /// Optional machine ID filter.
    /// </summary>
    public string? MachineID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("machine_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("machine_id", value);
        }
    }

    /// <summary>
    /// Last UTC usage date to include (YYYY-MM-DD). Defaults to current time.
    /// </summary>
    public string? PeriodEnd
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("period_end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("period_end", value);
        }
    }

    /// <summary>
    /// Usage period start (YYYY-MM-DD). Defaults to first of current month.
    /// </summary>
    public string? PeriodStart
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("period_start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("period_start", value);
        }
    }

    public UsageMachineComputeParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageMachineComputeParams(UsageMachineComputeParams usageMachineComputeParams)
        : base(usageMachineComputeParams) { }
#pragma warning restore CS8618

    public UsageMachineComputeParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageMachineComputeParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UsageMachineComputeParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(UsageMachineComputeParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/usage/machines/compute"
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

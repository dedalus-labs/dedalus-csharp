using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines;

[JsonConverter(typeof(JsonModelConverter<UpdateParams, UpdateParamsFromRaw>))]
public sealed record class UpdateParams : JsonModel
{
    /// <summary>
    /// Idle window before autosleep. Accepts fixed duration units like 30s, 30m,
    /// 2h, 7d3h4s, or 1w3d, raw seconds ("1800"), or never to disable.
    /// </summary>
    public string? Autosleep
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("autosleep");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("autosleep", value);
        }
    }

    /// <summary>
    /// Memory in MiB.
    /// </summary>
    public long? MemoryMiB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("memory_mib");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("memory_mib", value);
        }
    }

    /// <summary>
    /// Storage in GiB.
    /// </summary>
    public long? StorageGiB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("storage_gib");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("storage_gib", value);
        }
    }

    /// <summary>
    /// CPU in vCPUs.
    /// </summary>
    public double? Vcpu
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("vcpu");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vcpu", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Autosleep;
        _ = this.MemoryMiB;
        _ = this.StorageGiB;
        _ = this.Vcpu;
    }

    public UpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateParams(UpdateParams updateParams)
        : base(updateParams) { }
#pragma warning restore CS8618

    public UpdateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateParamsFromRaw.FromRawUnchecked"/>
    public static UpdateParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateParamsFromRaw : IFromRawJson<UpdateParams>
{
    /// <inheritdoc/>
    public UpdateParams FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UpdateParams.FromRawUnchecked(rawData);
}

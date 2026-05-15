using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Usage;

[JsonConverter(typeof(JsonModelConverter<MachineComputeUsage, MachineComputeUsageFromRaw>))]
public sealed record class MachineComputeUsage : JsonModel
{
    /// <summary>
    /// Usage breakdown granularity used for rows: hour or day.
    /// </summary>
    public required string Granularity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("granularity");
        }
        init { this._rawData.Set("granularity", value); }
    }

    /// <summary>
    /// Exclusive usage period end.
    /// </summary>
    public required DateTimeOffset PeriodEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("period_end");
        }
        init { this._rawData.Set("period_end", value); }
    }

    /// <summary>
    /// Inclusive usage period start.
    /// </summary>
    public required DateTimeOffset PeriodStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("period_start");
        }
        init { this._rawData.Set("period_start", value); }
    }

    /// <summary>
    /// Machine-level compute usage breakdown rows.
    /// </summary>
    public required IReadOnlyList<MachineComputeUsageRow>? Rows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MachineComputeUsageRow>>("rows");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MachineComputeUsageRow>?>(
                "rows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Granularity;
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
        foreach (var item in this.Rows ?? [])
        {
            item.Validate();
        }
    }

    public MachineComputeUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachineComputeUsage(MachineComputeUsage machineComputeUsage)
        : base(machineComputeUsage) { }
#pragma warning restore CS8618

    public MachineComputeUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MachineComputeUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MachineComputeUsageFromRaw.FromRawUnchecked"/>
    public static MachineComputeUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MachineComputeUsageFromRaw : IFromRawJson<MachineComputeUsage>
{
    /// <inheritdoc/>
    public MachineComputeUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MachineComputeUsage.FromRawUnchecked(rawData);
}

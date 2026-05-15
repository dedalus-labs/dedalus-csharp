using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Usage;

[JsonConverter(typeof(JsonModelConverter<MachineStorageUsage, MachineStorageUsageFromRaw>))]
public sealed record class MachineStorageUsage : JsonModel
{
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
    /// Machine-level storage usage breakdown rows.
    /// </summary>
    public required IReadOnlyList<MachineStorageUsageRow>? Rows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MachineStorageUsageRow>>("rows");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MachineStorageUsageRow>?>(
                "rows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
        foreach (var item in this.Rows ?? [])
        {
            item.Validate();
        }
    }

    public MachineStorageUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachineStorageUsage(MachineStorageUsage machineStorageUsage)
        : base(machineStorageUsage) { }
#pragma warning restore CS8618

    public MachineStorageUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MachineStorageUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MachineStorageUsageFromRaw.FromRawUnchecked"/>
    public static MachineStorageUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MachineStorageUsageFromRaw : IFromRawJson<MachineStorageUsage>
{
    /// <inheritdoc/>
    public MachineStorageUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MachineStorageUsage.FromRawUnchecked(rawData);
}

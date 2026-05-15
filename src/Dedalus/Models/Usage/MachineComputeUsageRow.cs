using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Usage;

[JsonConverter(typeof(JsonModelConverter<MachineComputeUsageRow, MachineComputeUsageRowFromRaw>))]
public sealed record class MachineComputeUsageRow : JsonModel
{
    /// <summary>
    /// Machine-awake seconds in this bucket.
    /// </summary>
    public required long AwakeSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("awake_seconds");
        }
        init { this._rawData.Set("awake_seconds", value); }
    }

    /// <summary>
    /// Exclusive usage bucket end.
    /// </summary>
    public required DateTimeOffset BucketEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("bucket_end");
        }
        init { this._rawData.Set("bucket_end", value); }
    }

    /// <summary>
    /// Inclusive usage bucket start.
    /// </summary>
    public required DateTimeOffset BucketStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("bucket_start");
        }
        init { this._rawData.Set("bucket_start", value); }
    }

    /// <summary>
    /// Requested vCPU millicores multiplied by guest-owned active CPU seconds.
    /// </summary>
    public required long CpuMillicoreSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cpu_millicore_seconds");
        }
        init { this._rawData.Set("cpu_millicore_seconds", value); }
    }

    /// <summary>
    /// Latest raw window_end represented by this row.
    /// </summary>
    public required DateTimeOffset LastWindowEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("last_window_end");
        }
        init { this._rawData.Set("last_window_end", value); }
    }

    /// <summary>
    /// Machine identifier.
    /// </summary>
    public required string MachineID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("machine_id");
        }
        init { this._rawData.Set("machine_id", value); }
    }

    /// <summary>
    /// Requested memory MiB multiplied by running allocation seconds.
    /// </summary>
    public required long MemoryMiBSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("memory_mib_seconds");
        }
        init { this._rawData.Set("memory_mib_seconds", value); }
    }

    /// <summary>
    /// Org compute bucket IDs this row contributes to.
    /// </summary>
    public required IReadOnlyList<string>? OrgMeteringBucketIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "org_metering_bucket_ids"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "org_metering_bucket_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Requested memory for this shape, in MiB.
    /// </summary>
    public required int RequestedMemoryMiB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("requested_memory_mib");
        }
        init { this._rawData.Set("requested_memory_mib", value); }
    }

    /// <summary>
    /// Requested storage for this shape, in GiB.
    /// </summary>
    public required int RequestedStorageGiB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("requested_storage_gib");
        }
        init { this._rawData.Set("requested_storage_gib", value); }
    }

    /// <summary>
    /// Requested vCPU for this shape.
    /// </summary>
    public required double RequestedVcpu
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("requested_vcpu");
        }
        init { this._rawData.Set("requested_vcpu", value); }
    }

    /// <summary>
    /// Stable fingerprint for the requested machine shape.
    /// </summary>
    public required string SpecFingerprint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("spec_fingerprint");
        }
        init { this._rawData.Set("spec_fingerprint", value); }
    }

    /// <summary>
    /// Stripe CPU meter event identifiers linked to those org buckets.
    /// </summary>
    public required IReadOnlyList<string>? StripeCpuIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "stripe_cpu_identifiers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "stripe_cpu_identifiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Stripe memory meter event identifiers linked to those org buckets.
    /// </summary>
    public required IReadOnlyList<string>? StripeMemoryIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "stripe_memory_identifiers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "stripe_memory_identifiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Raw usage windows compacted into this row.
    /// </summary>
    public required long WindowCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("window_count");
        }
        init { this._rawData.Set("window_count", value); }
    }

    /// <summary>
    /// Latest Stripe emission timestamp for linked org buckets, when emitted.
    /// </summary>
    public DateTimeOffset? LatestStripeEmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("latest_stripe_emitted_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("latest_stripe_emitted_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AwakeSeconds;
        _ = this.BucketEnd;
        _ = this.BucketStart;
        _ = this.CpuMillicoreSeconds;
        _ = this.LastWindowEnd;
        _ = this.MachineID;
        _ = this.MemoryMiBSeconds;
        _ = this.OrgMeteringBucketIds;
        _ = this.RequestedMemoryMiB;
        _ = this.RequestedStorageGiB;
        _ = this.RequestedVcpu;
        _ = this.SpecFingerprint;
        _ = this.StripeCpuIdentifiers;
        _ = this.StripeMemoryIdentifiers;
        _ = this.WindowCount;
        _ = this.LatestStripeEmittedAt;
    }

    public MachineComputeUsageRow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachineComputeUsageRow(MachineComputeUsageRow machineComputeUsageRow)
        : base(machineComputeUsageRow) { }
#pragma warning restore CS8618

    public MachineComputeUsageRow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MachineComputeUsageRow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MachineComputeUsageRowFromRaw.FromRawUnchecked"/>
    public static MachineComputeUsageRow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MachineComputeUsageRowFromRaw : IFromRawJson<MachineComputeUsageRow>
{
    /// <inheritdoc/>
    public MachineComputeUsageRow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MachineComputeUsageRow.FromRawUnchecked(rawData);
}

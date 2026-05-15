using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Usage;

[JsonConverter(typeof(JsonModelConverter<MachineStorageUsageRow, MachineStorageUsageRowFromRaw>))]
public sealed record class MachineStorageUsageRow : JsonModel
{
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
    /// Machine logical bytes observed for storage allocation.
    /// </summary>
    public required long LogicalStorageBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("logical_storage_bytes");
        }
        init { this._rawData.Set("logical_storage_bytes", value); }
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
    /// Org storage bucket ID this row contributes to.
    /// </summary>
    public required string OrgMeteringBucketID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("org_metering_bucket_id");
        }
        init { this._rawData.Set("org_metering_bucket_id", value); }
    }

    /// <summary>
    /// Allocated logical MiB-seconds for this machine.
    /// </summary>
    public required long StorageMiBSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("storage_mib_seconds");
        }
        init { this._rawData.Set("storage_mib_seconds", value); }
    }

    /// <summary>
    /// Stripe storage meter event identifier linked to that org bucket.
    /// </summary>
    public required string StripeStorageIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("stripe_storage_identifier");
        }
        init { this._rawData.Set("stripe_storage_identifier", value); }
    }

    /// <summary>
    /// Latest Stripe emission timestamp for the linked org bucket, when emitted.
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
        _ = this.BucketEnd;
        _ = this.BucketStart;
        _ = this.LogicalStorageBytes;
        _ = this.MachineID;
        _ = this.OrgMeteringBucketID;
        _ = this.StorageMiBSeconds;
        _ = this.StripeStorageIdentifier;
        _ = this.LatestStripeEmittedAt;
    }

    public MachineStorageUsageRow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachineStorageUsageRow(MachineStorageUsageRow machineStorageUsageRow)
        : base(machineStorageUsageRow) { }
#pragma warning restore CS8618

    public MachineStorageUsageRow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MachineStorageUsageRow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MachineStorageUsageRowFromRaw.FromRawUnchecked"/>
    public static MachineStorageUsageRow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MachineStorageUsageRowFromRaw : IFromRawJson<MachineStorageUsageRow>
{
    /// <inheritdoc/>
    public MachineStorageUsageRow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MachineStorageUsageRow.FromRawUnchecked(rawData);
}

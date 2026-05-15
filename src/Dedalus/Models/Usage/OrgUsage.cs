using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Usage;

[JsonConverter(typeof(JsonModelConverter<OrgUsage, OrgUsageFromRaw>))]
public sealed record class OrgUsage : JsonModel
{
    /// <summary>
    /// Closed awake seconds in billed org buckets for the period.
    /// </summary>
    public required long BilledAwakeSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("billed_awake_seconds");
        }
        init { this._rawData.Set("billed_awake_seconds", value); }
    }

    /// <summary>
    /// Closed requested vCPU millicores multiplied by guest-owned active CPU seconds
    /// for the period.
    /// </summary>
    public required long BilledCpuMillicoreSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("billed_cpu_millicore_seconds");
        }
        init { this._rawData.Set("billed_cpu_millicore_seconds", value); }
    }

    /// <summary>
    /// Closed billable logical MiB-seconds for the period, matching the Stripe storage meter.
    /// </summary>
    public required long BilledLogicalStorageMiBSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("billed_logical_storage_mib_seconds");
        }
        init { this._rawData.Set("billed_logical_storage_mib_seconds", value); }
    }

    /// <summary>
    /// Closed requested memory MiB multiplied by running allocation seconds for
    /// the period.
    /// </summary>
    public required long BilledMemoryMiBSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("billed_memory_mib_seconds");
        }
        init { this._rawData.Set("billed_memory_mib_seconds", value); }
    }

    /// <summary>
    /// Plan-included storage in GiB, used as a local guardrail only.
    /// </summary>
    public required long IncludedStorageGiB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("included_storage_gib");
        }
        init { this._rawData.Set("included_storage_gib", value); }
    }

    /// <summary>
    /// Billing plan in effect for the organization.
    /// </summary>
    public required string PlanSlug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plan_slug");
        }
        init { this._rawData.Set("plan_slug", value); }
    }

    /// <summary>
    /// Current provisioned storage summed across machines in GiB.
    /// </summary>
    public required long ProvisionedStorageGiB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("provisioned_storage_gib");
        }
        init { this._rawData.Set("provisioned_storage_gib", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BilledAwakeSeconds;
        _ = this.BilledCpuMillicoreSeconds;
        _ = this.BilledLogicalStorageMiBSeconds;
        _ = this.BilledMemoryMiBSeconds;
        _ = this.IncludedStorageGiB;
        _ = this.PlanSlug;
        _ = this.ProvisionedStorageGiB;
    }

    public OrgUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrgUsage(OrgUsage orgUsage)
        : base(orgUsage) { }
#pragma warning restore CS8618

    public OrgUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrgUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrgUsageFromRaw.FromRawUnchecked"/>
    public static OrgUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrgUsageFromRaw : IFromRawJson<OrgUsage>
{
    /// <inheritdoc/>
    public OrgUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OrgUsage.FromRawUnchecked(rawData);
}

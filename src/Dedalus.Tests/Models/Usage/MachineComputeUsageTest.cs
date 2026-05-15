using System;
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Usage;

namespace Dedalus.Tests.Models.Usage;

public class MachineComputeUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MachineComputeUsage
        {
            Granularity = "granularity",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    AwakeSeconds = 0,
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CpuMillicoreSeconds = 0,
                    LastWindowEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    MemoryMiBSeconds = 0,
                    OrgMeteringBucketIds = ["string"],
                    RequestedMemoryMiB = 0,
                    RequestedStorageGiB = 0,
                    RequestedVcpu = 0,
                    SpecFingerprint = "spec_fingerprint",
                    StripeCpuIdentifiers = ["string"],
                    StripeMemoryIdentifiers = ["string"],
                    WindowCount = 0,
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string expectedGranularity = "granularity";
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<MachineComputeUsageRow> expectedRows =
        [
            new()
            {
                AwakeSeconds = 0,
                BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CpuMillicoreSeconds = 0,
                LastWindowEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MachineID = "machine_id",
                MemoryMiBSeconds = 0,
                OrgMeteringBucketIds = ["string"],
                RequestedMemoryMiB = 0,
                RequestedStorageGiB = 0,
                RequestedVcpu = 0,
                SpecFingerprint = "spec_fingerprint",
                StripeCpuIdentifiers = ["string"],
                StripeMemoryIdentifiers = ["string"],
                WindowCount = 0,
                LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedGranularity, model.Granularity);
        Assert.Equal(expectedPeriodEnd, model.PeriodEnd);
        Assert.Equal(expectedPeriodStart, model.PeriodStart);
        Assert.NotNull(model.Rows);
        Assert.Equal(expectedRows.Count, model.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i], model.Rows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MachineComputeUsage
        {
            Granularity = "granularity",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    AwakeSeconds = 0,
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CpuMillicoreSeconds = 0,
                    LastWindowEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    MemoryMiBSeconds = 0,
                    OrgMeteringBucketIds = ["string"],
                    RequestedMemoryMiB = 0,
                    RequestedStorageGiB = 0,
                    RequestedVcpu = 0,
                    SpecFingerprint = "spec_fingerprint",
                    StripeCpuIdentifiers = ["string"],
                    StripeMemoryIdentifiers = ["string"],
                    WindowCount = 0,
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineComputeUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MachineComputeUsage
        {
            Granularity = "granularity",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    AwakeSeconds = 0,
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CpuMillicoreSeconds = 0,
                    LastWindowEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    MemoryMiBSeconds = 0,
                    OrgMeteringBucketIds = ["string"],
                    RequestedMemoryMiB = 0,
                    RequestedStorageGiB = 0,
                    RequestedVcpu = 0,
                    SpecFingerprint = "spec_fingerprint",
                    StripeCpuIdentifiers = ["string"],
                    StripeMemoryIdentifiers = ["string"],
                    WindowCount = 0,
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineComputeUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedGranularity = "granularity";
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<MachineComputeUsageRow> expectedRows =
        [
            new()
            {
                AwakeSeconds = 0,
                BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CpuMillicoreSeconds = 0,
                LastWindowEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MachineID = "machine_id",
                MemoryMiBSeconds = 0,
                OrgMeteringBucketIds = ["string"],
                RequestedMemoryMiB = 0,
                RequestedStorageGiB = 0,
                RequestedVcpu = 0,
                SpecFingerprint = "spec_fingerprint",
                StripeCpuIdentifiers = ["string"],
                StripeMemoryIdentifiers = ["string"],
                WindowCount = 0,
                LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedGranularity, deserialized.Granularity);
        Assert.Equal(expectedPeriodEnd, deserialized.PeriodEnd);
        Assert.Equal(expectedPeriodStart, deserialized.PeriodStart);
        Assert.NotNull(deserialized.Rows);
        Assert.Equal(expectedRows.Count, deserialized.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i], deserialized.Rows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MachineComputeUsage
        {
            Granularity = "granularity",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    AwakeSeconds = 0,
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CpuMillicoreSeconds = 0,
                    LastWindowEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    MemoryMiBSeconds = 0,
                    OrgMeteringBucketIds = ["string"],
                    RequestedMemoryMiB = 0,
                    RequestedStorageGiB = 0,
                    RequestedVcpu = 0,
                    SpecFingerprint = "spec_fingerprint",
                    StripeCpuIdentifiers = ["string"],
                    StripeMemoryIdentifiers = ["string"],
                    WindowCount = 0,
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MachineComputeUsage
        {
            Granularity = "granularity",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    AwakeSeconds = 0,
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CpuMillicoreSeconds = 0,
                    LastWindowEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    MemoryMiBSeconds = 0,
                    OrgMeteringBucketIds = ["string"],
                    RequestedMemoryMiB = 0,
                    RequestedStorageGiB = 0,
                    RequestedVcpu = 0,
                    SpecFingerprint = "spec_fingerprint",
                    StripeCpuIdentifiers = ["string"],
                    StripeMemoryIdentifiers = ["string"],
                    WindowCount = 0,
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        MachineComputeUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

using System;
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Usage;

namespace Dedalus.Tests.Models.Usage;

public class MachineComputeUsageRowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MachineComputeUsageRow
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
        };

        long expectedAwakeSeconds = 0;
        DateTimeOffset expectedBucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedCpuMillicoreSeconds = 0;
        DateTimeOffset expectedLastWindowEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMachineID = "machine_id";
        long expectedMemoryMiBSeconds = 0;
        List<string> expectedOrgMeteringBucketIds = ["string"];
        int expectedRequestedMemoryMiB = 0;
        int expectedRequestedStorageGiB = 0;
        double expectedRequestedVcpu = 0;
        string expectedSpecFingerprint = "spec_fingerprint";
        List<string> expectedStripeCpuIdentifiers = ["string"];
        List<string> expectedStripeMemoryIdentifiers = ["string"];
        long expectedWindowCount = 0;
        DateTimeOffset expectedLatestStripeEmittedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedAwakeSeconds, model.AwakeSeconds);
        Assert.Equal(expectedBucketEnd, model.BucketEnd);
        Assert.Equal(expectedBucketStart, model.BucketStart);
        Assert.Equal(expectedCpuMillicoreSeconds, model.CpuMillicoreSeconds);
        Assert.Equal(expectedLastWindowEnd, model.LastWindowEnd);
        Assert.Equal(expectedMachineID, model.MachineID);
        Assert.Equal(expectedMemoryMiBSeconds, model.MemoryMiBSeconds);
        Assert.NotNull(model.OrgMeteringBucketIds);
        Assert.Equal(expectedOrgMeteringBucketIds.Count, model.OrgMeteringBucketIds.Count);
        for (int i = 0; i < expectedOrgMeteringBucketIds.Count; i++)
        {
            Assert.Equal(expectedOrgMeteringBucketIds[i], model.OrgMeteringBucketIds[i]);
        }
        Assert.Equal(expectedRequestedMemoryMiB, model.RequestedMemoryMiB);
        Assert.Equal(expectedRequestedStorageGiB, model.RequestedStorageGiB);
        Assert.Equal(expectedRequestedVcpu, model.RequestedVcpu);
        Assert.Equal(expectedSpecFingerprint, model.SpecFingerprint);
        Assert.NotNull(model.StripeCpuIdentifiers);
        Assert.Equal(expectedStripeCpuIdentifiers.Count, model.StripeCpuIdentifiers.Count);
        for (int i = 0; i < expectedStripeCpuIdentifiers.Count; i++)
        {
            Assert.Equal(expectedStripeCpuIdentifiers[i], model.StripeCpuIdentifiers[i]);
        }
        Assert.NotNull(model.StripeMemoryIdentifiers);
        Assert.Equal(expectedStripeMemoryIdentifiers.Count, model.StripeMemoryIdentifiers.Count);
        for (int i = 0; i < expectedStripeMemoryIdentifiers.Count; i++)
        {
            Assert.Equal(expectedStripeMemoryIdentifiers[i], model.StripeMemoryIdentifiers[i]);
        }
        Assert.Equal(expectedWindowCount, model.WindowCount);
        Assert.Equal(expectedLatestStripeEmittedAt, model.LatestStripeEmittedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MachineComputeUsageRow
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineComputeUsageRow>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MachineComputeUsageRow
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineComputeUsageRow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAwakeSeconds = 0;
        DateTimeOffset expectedBucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedCpuMillicoreSeconds = 0;
        DateTimeOffset expectedLastWindowEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMachineID = "machine_id";
        long expectedMemoryMiBSeconds = 0;
        List<string> expectedOrgMeteringBucketIds = ["string"];
        int expectedRequestedMemoryMiB = 0;
        int expectedRequestedStorageGiB = 0;
        double expectedRequestedVcpu = 0;
        string expectedSpecFingerprint = "spec_fingerprint";
        List<string> expectedStripeCpuIdentifiers = ["string"];
        List<string> expectedStripeMemoryIdentifiers = ["string"];
        long expectedWindowCount = 0;
        DateTimeOffset expectedLatestStripeEmittedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedAwakeSeconds, deserialized.AwakeSeconds);
        Assert.Equal(expectedBucketEnd, deserialized.BucketEnd);
        Assert.Equal(expectedBucketStart, deserialized.BucketStart);
        Assert.Equal(expectedCpuMillicoreSeconds, deserialized.CpuMillicoreSeconds);
        Assert.Equal(expectedLastWindowEnd, deserialized.LastWindowEnd);
        Assert.Equal(expectedMachineID, deserialized.MachineID);
        Assert.Equal(expectedMemoryMiBSeconds, deserialized.MemoryMiBSeconds);
        Assert.NotNull(deserialized.OrgMeteringBucketIds);
        Assert.Equal(expectedOrgMeteringBucketIds.Count, deserialized.OrgMeteringBucketIds.Count);
        for (int i = 0; i < expectedOrgMeteringBucketIds.Count; i++)
        {
            Assert.Equal(expectedOrgMeteringBucketIds[i], deserialized.OrgMeteringBucketIds[i]);
        }
        Assert.Equal(expectedRequestedMemoryMiB, deserialized.RequestedMemoryMiB);
        Assert.Equal(expectedRequestedStorageGiB, deserialized.RequestedStorageGiB);
        Assert.Equal(expectedRequestedVcpu, deserialized.RequestedVcpu);
        Assert.Equal(expectedSpecFingerprint, deserialized.SpecFingerprint);
        Assert.NotNull(deserialized.StripeCpuIdentifiers);
        Assert.Equal(expectedStripeCpuIdentifiers.Count, deserialized.StripeCpuIdentifiers.Count);
        for (int i = 0; i < expectedStripeCpuIdentifiers.Count; i++)
        {
            Assert.Equal(expectedStripeCpuIdentifiers[i], deserialized.StripeCpuIdentifiers[i]);
        }
        Assert.NotNull(deserialized.StripeMemoryIdentifiers);
        Assert.Equal(
            expectedStripeMemoryIdentifiers.Count,
            deserialized.StripeMemoryIdentifiers.Count
        );
        for (int i = 0; i < expectedStripeMemoryIdentifiers.Count; i++)
        {
            Assert.Equal(
                expectedStripeMemoryIdentifiers[i],
                deserialized.StripeMemoryIdentifiers[i]
            );
        }
        Assert.Equal(expectedWindowCount, deserialized.WindowCount);
        Assert.Equal(expectedLatestStripeEmittedAt, deserialized.LatestStripeEmittedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MachineComputeUsageRow
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MachineComputeUsageRow
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
        };

        Assert.Null(model.LatestStripeEmittedAt);
        Assert.False(model.RawData.ContainsKey("latest_stripe_emitted_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MachineComputeUsageRow
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MachineComputeUsageRow
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

            // Null should be interpreted as omitted for these properties
            LatestStripeEmittedAt = null,
        };

        Assert.Null(model.LatestStripeEmittedAt);
        Assert.False(model.RawData.ContainsKey("latest_stripe_emitted_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MachineComputeUsageRow
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

            // Null should be interpreted as omitted for these properties
            LatestStripeEmittedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MachineComputeUsageRow
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
        };

        MachineComputeUsageRow copied = new(model);

        Assert.Equal(model, copied);
    }
}

using System;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Usage;

namespace Dedalus.Tests.Models.Usage;

public class MachineStorageUsageRowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MachineStorageUsageRow
        {
            BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LogicalStorageBytes = 0,
            MachineID = "machine_id",
            OrgMeteringBucketID = "org_metering_bucket_id",
            StorageMiBSeconds = 0,
            StripeStorageIdentifier = "stripe_storage_identifier",
            LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedBucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedLogicalStorageBytes = 0;
        string expectedMachineID = "machine_id";
        string expectedOrgMeteringBucketID = "org_metering_bucket_id";
        long expectedStorageMiBSeconds = 0;
        string expectedStripeStorageIdentifier = "stripe_storage_identifier";
        DateTimeOffset expectedLatestStripeEmittedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedBucketEnd, model.BucketEnd);
        Assert.Equal(expectedBucketStart, model.BucketStart);
        Assert.Equal(expectedLogicalStorageBytes, model.LogicalStorageBytes);
        Assert.Equal(expectedMachineID, model.MachineID);
        Assert.Equal(expectedOrgMeteringBucketID, model.OrgMeteringBucketID);
        Assert.Equal(expectedStorageMiBSeconds, model.StorageMiBSeconds);
        Assert.Equal(expectedStripeStorageIdentifier, model.StripeStorageIdentifier);
        Assert.Equal(expectedLatestStripeEmittedAt, model.LatestStripeEmittedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MachineStorageUsageRow
        {
            BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LogicalStorageBytes = 0,
            MachineID = "machine_id",
            OrgMeteringBucketID = "org_metering_bucket_id",
            StorageMiBSeconds = 0,
            StripeStorageIdentifier = "stripe_storage_identifier",
            LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineStorageUsageRow>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MachineStorageUsageRow
        {
            BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LogicalStorageBytes = 0,
            MachineID = "machine_id",
            OrgMeteringBucketID = "org_metering_bucket_id",
            StorageMiBSeconds = 0,
            StripeStorageIdentifier = "stripe_storage_identifier",
            LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineStorageUsageRow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedBucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedLogicalStorageBytes = 0;
        string expectedMachineID = "machine_id";
        string expectedOrgMeteringBucketID = "org_metering_bucket_id";
        long expectedStorageMiBSeconds = 0;
        string expectedStripeStorageIdentifier = "stripe_storage_identifier";
        DateTimeOffset expectedLatestStripeEmittedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedBucketEnd, deserialized.BucketEnd);
        Assert.Equal(expectedBucketStart, deserialized.BucketStart);
        Assert.Equal(expectedLogicalStorageBytes, deserialized.LogicalStorageBytes);
        Assert.Equal(expectedMachineID, deserialized.MachineID);
        Assert.Equal(expectedOrgMeteringBucketID, deserialized.OrgMeteringBucketID);
        Assert.Equal(expectedStorageMiBSeconds, deserialized.StorageMiBSeconds);
        Assert.Equal(expectedStripeStorageIdentifier, deserialized.StripeStorageIdentifier);
        Assert.Equal(expectedLatestStripeEmittedAt, deserialized.LatestStripeEmittedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MachineStorageUsageRow
        {
            BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LogicalStorageBytes = 0,
            MachineID = "machine_id",
            OrgMeteringBucketID = "org_metering_bucket_id",
            StorageMiBSeconds = 0,
            StripeStorageIdentifier = "stripe_storage_identifier",
            LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MachineStorageUsageRow
        {
            BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LogicalStorageBytes = 0,
            MachineID = "machine_id",
            OrgMeteringBucketID = "org_metering_bucket_id",
            StorageMiBSeconds = 0,
            StripeStorageIdentifier = "stripe_storage_identifier",
        };

        Assert.Null(model.LatestStripeEmittedAt);
        Assert.False(model.RawData.ContainsKey("latest_stripe_emitted_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MachineStorageUsageRow
        {
            BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LogicalStorageBytes = 0,
            MachineID = "machine_id",
            OrgMeteringBucketID = "org_metering_bucket_id",
            StorageMiBSeconds = 0,
            StripeStorageIdentifier = "stripe_storage_identifier",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MachineStorageUsageRow
        {
            BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LogicalStorageBytes = 0,
            MachineID = "machine_id",
            OrgMeteringBucketID = "org_metering_bucket_id",
            StorageMiBSeconds = 0,
            StripeStorageIdentifier = "stripe_storage_identifier",

            // Null should be interpreted as omitted for these properties
            LatestStripeEmittedAt = null,
        };

        Assert.Null(model.LatestStripeEmittedAt);
        Assert.False(model.RawData.ContainsKey("latest_stripe_emitted_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MachineStorageUsageRow
        {
            BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LogicalStorageBytes = 0,
            MachineID = "machine_id",
            OrgMeteringBucketID = "org_metering_bucket_id",
            StorageMiBSeconds = 0,
            StripeStorageIdentifier = "stripe_storage_identifier",

            // Null should be interpreted as omitted for these properties
            LatestStripeEmittedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MachineStorageUsageRow
        {
            BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LogicalStorageBytes = 0,
            MachineID = "machine_id",
            OrgMeteringBucketID = "org_metering_bucket_id",
            StorageMiBSeconds = 0,
            StripeStorageIdentifier = "stripe_storage_identifier",
            LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        MachineStorageUsageRow copied = new(model);

        Assert.Equal(model, copied);
    }
}

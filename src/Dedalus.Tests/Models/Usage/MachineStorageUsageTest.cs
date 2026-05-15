using System;
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Usage;

namespace Dedalus.Tests.Models.Usage;

public class MachineStorageUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MachineStorageUsage
        {
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LogicalStorageBytes = 0,
                    MachineID = "machine_id",
                    OrgMeteringBucketID = "org_metering_bucket_id",
                    StorageMiBSeconds = 0,
                    StripeStorageIdentifier = "stripe_storage_identifier",
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<MachineStorageUsageRow> expectedRows =
        [
            new()
            {
                BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LogicalStorageBytes = 0,
                MachineID = "machine_id",
                OrgMeteringBucketID = "org_metering_bucket_id",
                StorageMiBSeconds = 0,
                StripeStorageIdentifier = "stripe_storage_identifier",
                LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

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
        var model = new MachineStorageUsage
        {
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LogicalStorageBytes = 0,
                    MachineID = "machine_id",
                    OrgMeteringBucketID = "org_metering_bucket_id",
                    StorageMiBSeconds = 0,
                    StripeStorageIdentifier = "stripe_storage_identifier",
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineStorageUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MachineStorageUsage
        {
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LogicalStorageBytes = 0,
                    MachineID = "machine_id",
                    OrgMeteringBucketID = "org_metering_bucket_id",
                    StorageMiBSeconds = 0,
                    StripeStorageIdentifier = "stripe_storage_identifier",
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineStorageUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<MachineStorageUsageRow> expectedRows =
        [
            new()
            {
                BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LogicalStorageBytes = 0,
                MachineID = "machine_id",
                OrgMeteringBucketID = "org_metering_bucket_id",
                StorageMiBSeconds = 0,
                StripeStorageIdentifier = "stripe_storage_identifier",
                LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

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
        var model = new MachineStorageUsage
        {
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LogicalStorageBytes = 0,
                    MachineID = "machine_id",
                    OrgMeteringBucketID = "org_metering_bucket_id",
                    StorageMiBSeconds = 0,
                    StripeStorageIdentifier = "stripe_storage_identifier",
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MachineStorageUsage
        {
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Rows =
            [
                new()
                {
                    BucketEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BucketStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LogicalStorageBytes = 0,
                    MachineID = "machine_id",
                    OrgMeteringBucketID = "org_metering_bucket_id",
                    StorageMiBSeconds = 0,
                    StripeStorageIdentifier = "stripe_storage_identifier",
                    LatestStripeEmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        MachineStorageUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

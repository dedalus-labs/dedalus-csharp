using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Usage;

namespace Dedalus.Tests.Models.Usage;

public class OrgUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OrgUsage
        {
            BilledAwakeSeconds = 0,
            BilledCpuMillicoreSeconds = 0,
            BilledLogicalStorageMiBSeconds = 0,
            BilledMemoryMiBSeconds = 0,
            IncludedStorageGiB = 0,
            PlanSlug = "plan_slug",
            ProvisionedStorageGiB = 0,
        };

        long expectedBilledAwakeSeconds = 0;
        long expectedBilledCpuMillicoreSeconds = 0;
        long expectedBilledLogicalStorageMiBSeconds = 0;
        long expectedBilledMemoryMiBSeconds = 0;
        long expectedIncludedStorageGiB = 0;
        string expectedPlanSlug = "plan_slug";
        long expectedProvisionedStorageGiB = 0;

        Assert.Equal(expectedBilledAwakeSeconds, model.BilledAwakeSeconds);
        Assert.Equal(expectedBilledCpuMillicoreSeconds, model.BilledCpuMillicoreSeconds);
        Assert.Equal(expectedBilledLogicalStorageMiBSeconds, model.BilledLogicalStorageMiBSeconds);
        Assert.Equal(expectedBilledMemoryMiBSeconds, model.BilledMemoryMiBSeconds);
        Assert.Equal(expectedIncludedStorageGiB, model.IncludedStorageGiB);
        Assert.Equal(expectedPlanSlug, model.PlanSlug);
        Assert.Equal(expectedProvisionedStorageGiB, model.ProvisionedStorageGiB);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OrgUsage
        {
            BilledAwakeSeconds = 0,
            BilledCpuMillicoreSeconds = 0,
            BilledLogicalStorageMiBSeconds = 0,
            BilledMemoryMiBSeconds = 0,
            IncludedStorageGiB = 0,
            PlanSlug = "plan_slug",
            ProvisionedStorageGiB = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrgUsage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OrgUsage
        {
            BilledAwakeSeconds = 0,
            BilledCpuMillicoreSeconds = 0,
            BilledLogicalStorageMiBSeconds = 0,
            BilledMemoryMiBSeconds = 0,
            IncludedStorageGiB = 0,
            PlanSlug = "plan_slug",
            ProvisionedStorageGiB = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrgUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBilledAwakeSeconds = 0;
        long expectedBilledCpuMillicoreSeconds = 0;
        long expectedBilledLogicalStorageMiBSeconds = 0;
        long expectedBilledMemoryMiBSeconds = 0;
        long expectedIncludedStorageGiB = 0;
        string expectedPlanSlug = "plan_slug";
        long expectedProvisionedStorageGiB = 0;

        Assert.Equal(expectedBilledAwakeSeconds, deserialized.BilledAwakeSeconds);
        Assert.Equal(expectedBilledCpuMillicoreSeconds, deserialized.BilledCpuMillicoreSeconds);
        Assert.Equal(
            expectedBilledLogicalStorageMiBSeconds,
            deserialized.BilledLogicalStorageMiBSeconds
        );
        Assert.Equal(expectedBilledMemoryMiBSeconds, deserialized.BilledMemoryMiBSeconds);
        Assert.Equal(expectedIncludedStorageGiB, deserialized.IncludedStorageGiB);
        Assert.Equal(expectedPlanSlug, deserialized.PlanSlug);
        Assert.Equal(expectedProvisionedStorageGiB, deserialized.ProvisionedStorageGiB);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OrgUsage
        {
            BilledAwakeSeconds = 0,
            BilledCpuMillicoreSeconds = 0,
            BilledLogicalStorageMiBSeconds = 0,
            BilledMemoryMiBSeconds = 0,
            IncludedStorageGiB = 0,
            PlanSlug = "plan_slug",
            ProvisionedStorageGiB = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OrgUsage
        {
            BilledAwakeSeconds = 0,
            BilledCpuMillicoreSeconds = 0,
            BilledLogicalStorageMiBSeconds = 0,
            BilledMemoryMiBSeconds = 0,
            IncludedStorageGiB = 0,
            PlanSlug = "plan_slug",
            ProvisionedStorageGiB = 0,
        };

        OrgUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

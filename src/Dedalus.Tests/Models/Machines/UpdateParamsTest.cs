using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class UpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UpdateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        string expectedAutosleep = "autosleep";
        long expectedMemoryMiB = 0;
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;

        Assert.Equal(expectedAutosleep, model.Autosleep);
        Assert.Equal(expectedMemoryMiB, model.MemoryMiB);
        Assert.Equal(expectedStorageGiB, model.StorageGiB);
        Assert.Equal(expectedVcpu, model.Vcpu);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UpdateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UpdateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UpdateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAutosleep = "autosleep";
        long expectedMemoryMiB = 0;
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;

        Assert.Equal(expectedAutosleep, deserialized.Autosleep);
        Assert.Equal(expectedMemoryMiB, deserialized.MemoryMiB);
        Assert.Equal(expectedStorageGiB, deserialized.StorageGiB);
        Assert.Equal(expectedVcpu, deserialized.Vcpu);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UpdateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UpdateParams { };

        Assert.Null(model.Autosleep);
        Assert.False(model.RawData.ContainsKey("autosleep"));
        Assert.Null(model.MemoryMiB);
        Assert.False(model.RawData.ContainsKey("memory_mib"));
        Assert.Null(model.StorageGiB);
        Assert.False(model.RawData.ContainsKey("storage_gib"));
        Assert.Null(model.Vcpu);
        Assert.False(model.RawData.ContainsKey("vcpu"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UpdateParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UpdateParams
        {
            // Null should be interpreted as omitted for these properties
            Autosleep = null,
            MemoryMiB = null,
            StorageGiB = null,
            Vcpu = null,
        };

        Assert.Null(model.Autosleep);
        Assert.False(model.RawData.ContainsKey("autosleep"));
        Assert.Null(model.MemoryMiB);
        Assert.False(model.RawData.ContainsKey("memory_mib"));
        Assert.Null(model.StorageGiB);
        Assert.False(model.RawData.ContainsKey("storage_gib"));
        Assert.Null(model.Vcpu);
        Assert.False(model.RawData.ContainsKey("vcpu"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UpdateParams
        {
            // Null should be interpreted as omitted for these properties
            Autosleep = null,
            MemoryMiB = null,
            StorageGiB = null,
            Vcpu = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UpdateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        UpdateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

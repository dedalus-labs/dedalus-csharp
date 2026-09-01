using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class CreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 1,
            StorageGiB = 1,
            Vcpu = 1,
        };

        string expectedAutosleep = "autosleep";
        long expectedMemoryMiB = 1;
        long expectedStorageGiB = 1;
        double expectedVcpu = 1;

        Assert.Equal(expectedAutosleep, model.Autosleep);
        Assert.Equal(expectedMemoryMiB, model.MemoryMiB);
        Assert.Equal(expectedStorageGiB, model.StorageGiB);
        Assert.Equal(expectedVcpu, model.Vcpu);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 1,
            StorageGiB = 1,
            Vcpu = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 1,
            StorageGiB = 1,
            Vcpu = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAutosleep = "autosleep";
        long expectedMemoryMiB = 1;
        long expectedStorageGiB = 1;
        double expectedVcpu = 1;

        Assert.Equal(expectedAutosleep, deserialized.Autosleep);
        Assert.Equal(expectedMemoryMiB, deserialized.MemoryMiB);
        Assert.Equal(expectedStorageGiB, deserialized.StorageGiB);
        Assert.Equal(expectedVcpu, deserialized.Vcpu);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 1,
            StorageGiB = 1,
            Vcpu = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateParams { };

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
        var model = new CreateParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreateParams
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
        var model = new CreateParams
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
        var model = new CreateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 1,
            StorageGiB = 1,
            Vcpu = 1,
        };

        CreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

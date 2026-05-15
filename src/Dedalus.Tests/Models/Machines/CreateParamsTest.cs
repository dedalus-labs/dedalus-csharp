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
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
            Autosleep = "autosleep",
        };

        long expectedMemoryMiB = 0;
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;
        string expectedAutosleep = "autosleep";

        Assert.Equal(expectedMemoryMiB, model.MemoryMiB);
        Assert.Equal(expectedStorageGiB, model.StorageGiB);
        Assert.Equal(expectedVcpu, model.Vcpu);
        Assert.Equal(expectedAutosleep, model.Autosleep);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
            Autosleep = "autosleep",
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
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
            Autosleep = "autosleep",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMemoryMiB = 0;
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;
        string expectedAutosleep = "autosleep";

        Assert.Equal(expectedMemoryMiB, deserialized.MemoryMiB);
        Assert.Equal(expectedStorageGiB, deserialized.StorageGiB);
        Assert.Equal(expectedVcpu, deserialized.Vcpu);
        Assert.Equal(expectedAutosleep, deserialized.Autosleep);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
            Autosleep = "autosleep",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        Assert.Null(model.Autosleep);
        Assert.False(model.RawData.ContainsKey("autosleep"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,

            // Null should be interpreted as omitted for these properties
            Autosleep = null,
        };

        Assert.Null(model.Autosleep);
        Assert.False(model.RawData.ContainsKey("autosleep"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,

            // Null should be interpreted as omitted for these properties
            Autosleep = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
            Autosleep = "autosleep",
        };

        CreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

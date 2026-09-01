using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Machine
        {
            AutosleepSeconds = 0,
            DesiredState = DesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Phase = MachinePhase.Accepted,
            StorageGiB = 0,
            Vcpu = 0,
        };

        long expectedAutosleepSeconds = 0;
        ApiEnum<string, DesiredState> expectedDesiredState = DesiredState.Running;
        string expectedMachineID = "machine_id";
        long expectedMemoryMiB = 0;
        ApiEnum<string, MachinePhase> expectedPhase = MachinePhase.Accepted;
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;

        Assert.Equal(expectedAutosleepSeconds, model.AutosleepSeconds);
        Assert.Equal(expectedDesiredState, model.DesiredState);
        Assert.Equal(expectedMachineID, model.MachineID);
        Assert.Equal(expectedMemoryMiB, model.MemoryMiB);
        Assert.Equal(expectedPhase, model.Phase);
        Assert.Equal(expectedStorageGiB, model.StorageGiB);
        Assert.Equal(expectedVcpu, model.Vcpu);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Machine
        {
            AutosleepSeconds = 0,
            DesiredState = DesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Phase = MachinePhase.Accepted,
            StorageGiB = 0,
            Vcpu = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Machine>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Machine
        {
            AutosleepSeconds = 0,
            DesiredState = DesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Phase = MachinePhase.Accepted,
            StorageGiB = 0,
            Vcpu = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Machine>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAutosleepSeconds = 0;
        ApiEnum<string, DesiredState> expectedDesiredState = DesiredState.Running;
        string expectedMachineID = "machine_id";
        long expectedMemoryMiB = 0;
        ApiEnum<string, MachinePhase> expectedPhase = MachinePhase.Accepted;
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;

        Assert.Equal(expectedAutosleepSeconds, deserialized.AutosleepSeconds);
        Assert.Equal(expectedDesiredState, deserialized.DesiredState);
        Assert.Equal(expectedMachineID, deserialized.MachineID);
        Assert.Equal(expectedMemoryMiB, deserialized.MemoryMiB);
        Assert.Equal(expectedPhase, deserialized.Phase);
        Assert.Equal(expectedStorageGiB, deserialized.StorageGiB);
        Assert.Equal(expectedVcpu, deserialized.Vcpu);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Machine
        {
            AutosleepSeconds = 0,
            DesiredState = DesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Phase = MachinePhase.Accepted,
            StorageGiB = 0,
            Vcpu = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Machine
        {
            AutosleepSeconds = 0,
            DesiredState = DesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Phase = MachinePhase.Accepted,
            StorageGiB = 0,
            Vcpu = 0,
        };

        Machine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DesiredStateTest : TestBase
{
    [Theory]
    [InlineData(DesiredState.Running)]
    [InlineData(DesiredState.Sleeping)]
    [InlineData(DesiredState.Destroyed)]
    public void Validation_Works(DesiredState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DesiredState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DesiredState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DesiredState.Running)]
    [InlineData(DesiredState.Sleeping)]
    [InlineData(DesiredState.Destroyed)]
    public void SerializationRoundtrip_Works(DesiredState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DesiredState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DesiredState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DesiredState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DesiredState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MachinePhaseTest : TestBase
{
    [Theory]
    [InlineData(MachinePhase.Accepted)]
    [InlineData(MachinePhase.PlacementPending)]
    [InlineData(MachinePhase.Starting)]
    [InlineData(MachinePhase.Running)]
    [InlineData(MachinePhase.Stopping)]
    [InlineData(MachinePhase.Sleeping)]
    [InlineData(MachinePhase.Destroying)]
    [InlineData(MachinePhase.Destroyed)]
    [InlineData(MachinePhase.Failed)]
    public void Validation_Works(MachinePhase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MachinePhase> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MachinePhase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MachinePhase.Accepted)]
    [InlineData(MachinePhase.PlacementPending)]
    [InlineData(MachinePhase.Starting)]
    [InlineData(MachinePhase.Running)]
    [InlineData(MachinePhase.Stopping)]
    [InlineData(MachinePhase.Sleeping)]
    [InlineData(MachinePhase.Destroying)]
    [InlineData(MachinePhase.Destroyed)]
    [InlineData(MachinePhase.Failed)]
    public void SerializationRoundtrip_Works(MachinePhase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MachinePhase> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MachinePhase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MachinePhase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MachinePhase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

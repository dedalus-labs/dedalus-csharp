using System;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MachineRetrieveResponse
        {
            AutosleepSeconds = 0,
            DesiredState = MachineRetrieveResponseDesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Status = new()
            {
                LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Phase = Phase.Accepted,
                Reason = "reason",
                Retryable = true,
                Revision = "revision",
                LastError = "last_error",
            },
            StorageGiB = 0,
            Vcpu = 0,
        };

        long expectedAutosleepSeconds = 0;
        ApiEnum<string, MachineRetrieveResponseDesiredState> expectedDesiredState =
            MachineRetrieveResponseDesiredState.Running;
        string expectedMachineID = "machine_id";
        long expectedMemoryMiB = 0;
        LifecycleStatus expectedStatus = new()
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",
            LastError = "last_error",
        };
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;

        Assert.Equal(expectedAutosleepSeconds, model.AutosleepSeconds);
        Assert.Equal(expectedDesiredState, model.DesiredState);
        Assert.Equal(expectedMachineID, model.MachineID);
        Assert.Equal(expectedMemoryMiB, model.MemoryMiB);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStorageGiB, model.StorageGiB);
        Assert.Equal(expectedVcpu, model.Vcpu);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MachineRetrieveResponse
        {
            AutosleepSeconds = 0,
            DesiredState = MachineRetrieveResponseDesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Status = new()
            {
                LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Phase = Phase.Accepted,
                Reason = "reason",
                Retryable = true,
                Revision = "revision",
                LastError = "last_error",
            },
            StorageGiB = 0,
            Vcpu = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MachineRetrieveResponse
        {
            AutosleepSeconds = 0,
            DesiredState = MachineRetrieveResponseDesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Status = new()
            {
                LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Phase = Phase.Accepted,
                Reason = "reason",
                Retryable = true,
                Revision = "revision",
                LastError = "last_error",
            },
            StorageGiB = 0,
            Vcpu = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAutosleepSeconds = 0;
        ApiEnum<string, MachineRetrieveResponseDesiredState> expectedDesiredState =
            MachineRetrieveResponseDesiredState.Running;
        string expectedMachineID = "machine_id";
        long expectedMemoryMiB = 0;
        LifecycleStatus expectedStatus = new()
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",
            LastError = "last_error",
        };
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;

        Assert.Equal(expectedAutosleepSeconds, deserialized.AutosleepSeconds);
        Assert.Equal(expectedDesiredState, deserialized.DesiredState);
        Assert.Equal(expectedMachineID, deserialized.MachineID);
        Assert.Equal(expectedMemoryMiB, deserialized.MemoryMiB);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStorageGiB, deserialized.StorageGiB);
        Assert.Equal(expectedVcpu, deserialized.Vcpu);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MachineRetrieveResponse
        {
            AutosleepSeconds = 0,
            DesiredState = MachineRetrieveResponseDesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Status = new()
            {
                LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Phase = Phase.Accepted,
                Reason = "reason",
                Retryable = true,
                Revision = "revision",
                LastError = "last_error",
            },
            StorageGiB = 0,
            Vcpu = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MachineRetrieveResponse
        {
            AutosleepSeconds = 0,
            DesiredState = MachineRetrieveResponseDesiredState.Running,
            MachineID = "machine_id",
            MemoryMiB = 0,
            Status = new()
            {
                LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Phase = Phase.Accepted,
                Reason = "reason",
                Retryable = true,
                Revision = "revision",
                LastError = "last_error",
            },
            StorageGiB = 0,
            Vcpu = 0,
        };

        MachineRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MachineRetrieveResponseDesiredStateTest : TestBase
{
    [Theory]
    [InlineData(MachineRetrieveResponseDesiredState.Running)]
    [InlineData(MachineRetrieveResponseDesiredState.Sleeping)]
    [InlineData(MachineRetrieveResponseDesiredState.Destroyed)]
    public void Validation_Works(MachineRetrieveResponseDesiredState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MachineRetrieveResponseDesiredState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MachineRetrieveResponseDesiredState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MachineRetrieveResponseDesiredState.Running)]
    [InlineData(MachineRetrieveResponseDesiredState.Sleeping)]
    [InlineData(MachineRetrieveResponseDesiredState.Destroyed)]
    public void SerializationRoundtrip_Works(MachineRetrieveResponseDesiredState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MachineRetrieveResponseDesiredState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MachineRetrieveResponseDesiredState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MachineRetrieveResponseDesiredState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MachineRetrieveResponseDesiredState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

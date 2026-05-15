using System;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Executions = Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ExecutionEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Executions::ExecutionEvent
        {
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Sequence = 0,
            Type = Executions::Type.Lifecycle,
            Chunk = "chunk",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            Signal = 0,
            Status = Executions::ExecutionEventStatus.WakeInProgress,
        };

        DateTimeOffset expectedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedSequence = 0;
        ApiEnum<string, Executions::Type> expectedType = Executions::Type.Lifecycle;
        string expectedChunk = "chunk";
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        long expectedExitCode = 0;
        long expectedSignal = 0;
        ApiEnum<string, Executions::ExecutionEventStatus> expectedStatus =
            Executions::ExecutionEventStatus.WakeInProgress;

        Assert.Equal(expectedAt, model.At);
        Assert.Equal(expectedSequence, model.Sequence);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedChunk, model.Chunk);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedExitCode, model.ExitCode);
        Assert.Equal(expectedSignal, model.Signal);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Executions::ExecutionEvent
        {
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Sequence = 0,
            Type = Executions::Type.Lifecycle,
            Chunk = "chunk",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            Signal = 0,
            Status = Executions::ExecutionEventStatus.WakeInProgress,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Executions::ExecutionEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Executions::ExecutionEvent
        {
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Sequence = 0,
            Type = Executions::Type.Lifecycle,
            Chunk = "chunk",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            Signal = 0,
            Status = Executions::ExecutionEventStatus.WakeInProgress,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Executions::ExecutionEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedSequence = 0;
        ApiEnum<string, Executions::Type> expectedType = Executions::Type.Lifecycle;
        string expectedChunk = "chunk";
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        long expectedExitCode = 0;
        long expectedSignal = 0;
        ApiEnum<string, Executions::ExecutionEventStatus> expectedStatus =
            Executions::ExecutionEventStatus.WakeInProgress;

        Assert.Equal(expectedAt, deserialized.At);
        Assert.Equal(expectedSequence, deserialized.Sequence);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedChunk, deserialized.Chunk);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedExitCode, deserialized.ExitCode);
        Assert.Equal(expectedSignal, deserialized.Signal);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Executions::ExecutionEvent
        {
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Sequence = 0,
            Type = Executions::Type.Lifecycle,
            Chunk = "chunk",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            Signal = 0,
            Status = Executions::ExecutionEventStatus.WakeInProgress,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Executions::ExecutionEvent
        {
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Sequence = 0,
            Type = Executions::Type.Lifecycle,
        };

        Assert.Null(model.Chunk);
        Assert.False(model.RawData.ContainsKey("chunk"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExitCode);
        Assert.False(model.RawData.ContainsKey("exit_code"));
        Assert.Null(model.Signal);
        Assert.False(model.RawData.ContainsKey("signal"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Executions::ExecutionEvent
        {
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Sequence = 0,
            Type = Executions::Type.Lifecycle,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Executions::ExecutionEvent
        {
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Sequence = 0,
            Type = Executions::Type.Lifecycle,

            // Null should be interpreted as omitted for these properties
            Chunk = null,
            ErrorCode = null,
            ErrorMessage = null,
            ExitCode = null,
            Signal = null,
            Status = null,
        };

        Assert.Null(model.Chunk);
        Assert.False(model.RawData.ContainsKey("chunk"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExitCode);
        Assert.False(model.RawData.ContainsKey("exit_code"));
        Assert.Null(model.Signal);
        Assert.False(model.RawData.ContainsKey("signal"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Executions::ExecutionEvent
        {
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Sequence = 0,
            Type = Executions::Type.Lifecycle,

            // Null should be interpreted as omitted for these properties
            Chunk = null,
            ErrorCode = null,
            ErrorMessage = null,
            ExitCode = null,
            Signal = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Executions::ExecutionEvent
        {
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Sequence = 0,
            Type = Executions::Type.Lifecycle,
            Chunk = "chunk",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            Signal = 0,
            Status = Executions::ExecutionEventStatus.WakeInProgress,
        };

        Executions::ExecutionEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Executions::Type.Lifecycle)]
    [InlineData(Executions::Type.Stdout)]
    [InlineData(Executions::Type.Stderr)]
    public void Validation_Works(Executions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Executions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Executions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Executions::Type.Lifecycle)]
    [InlineData(Executions::Type.Stdout)]
    [InlineData(Executions::Type.Stderr)]
    public void SerializationRoundtrip_Works(Executions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Executions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Executions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Executions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Executions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExecutionEventStatusTest : TestBase
{
    [Theory]
    [InlineData(Executions::ExecutionEventStatus.WakeInProgress)]
    [InlineData(Executions::ExecutionEventStatus.Queued)]
    [InlineData(Executions::ExecutionEventStatus.Running)]
    [InlineData(Executions::ExecutionEventStatus.Succeeded)]
    [InlineData(Executions::ExecutionEventStatus.Failed)]
    [InlineData(Executions::ExecutionEventStatus.Cancelled)]
    [InlineData(Executions::ExecutionEventStatus.Expired)]
    public void Validation_Works(Executions::ExecutionEventStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Executions::ExecutionEventStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Executions::ExecutionEventStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Executions::ExecutionEventStatus.WakeInProgress)]
    [InlineData(Executions::ExecutionEventStatus.Queued)]
    [InlineData(Executions::ExecutionEventStatus.Running)]
    [InlineData(Executions::ExecutionEventStatus.Succeeded)]
    [InlineData(Executions::ExecutionEventStatus.Failed)]
    [InlineData(Executions::ExecutionEventStatus.Cancelled)]
    [InlineData(Executions::ExecutionEventStatus.Expired)]
    public void SerializationRoundtrip_Works(Executions::ExecutionEventStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Executions::ExecutionEventStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Executions::ExecutionEventStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Executions::ExecutionEventStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Executions::ExecutionEventStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

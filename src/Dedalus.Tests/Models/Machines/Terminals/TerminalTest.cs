using System;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Terminal
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Height = 0,
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            TerminalID = "terminal_id",
            Width = 0,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = Protocol.Websocket,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            StreamUrl = "stream_url",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedHeight = 0;
        string expectedMachineID = "machine_id";
        ApiEnum<string, Status> expectedStatus = Status.WakeInProgress;
        string expectedTerminalID = "terminal_id";
        long expectedWidth = 0;
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Protocol> expectedProtocol = Protocol.Websocket;
        DateTimeOffset expectedReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRetryAfterMs = 0;
        string expectedStreamUrl = "stream_url";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedMachineID, model.MachineID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTerminalID, model.TerminalID);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedProtocol, model.Protocol);
        Assert.Equal(expectedReadyAt, model.ReadyAt);
        Assert.Equal(expectedRetryAfterMs, model.RetryAfterMs);
        Assert.Equal(expectedStreamUrl, model.StreamUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Terminal
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Height = 0,
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            TerminalID = "terminal_id",
            Width = 0,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = Protocol.Websocket,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            StreamUrl = "stream_url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Terminal>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Terminal
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Height = 0,
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            TerminalID = "terminal_id",
            Width = 0,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = Protocol.Websocket,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            StreamUrl = "stream_url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Terminal>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedHeight = 0;
        string expectedMachineID = "machine_id";
        ApiEnum<string, Status> expectedStatus = Status.WakeInProgress;
        string expectedTerminalID = "terminal_id";
        long expectedWidth = 0;
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Protocol> expectedProtocol = Protocol.Websocket;
        DateTimeOffset expectedReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRetryAfterMs = 0;
        string expectedStreamUrl = "stream_url";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedMachineID, deserialized.MachineID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTerminalID, deserialized.TerminalID);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedProtocol, deserialized.Protocol);
        Assert.Equal(expectedReadyAt, deserialized.ReadyAt);
        Assert.Equal(expectedRetryAfterMs, deserialized.RetryAfterMs);
        Assert.Equal(expectedStreamUrl, deserialized.StreamUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Terminal
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Height = 0,
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            TerminalID = "terminal_id",
            Width = 0,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = Protocol.Websocket,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            StreamUrl = "stream_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Terminal
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Height = 0,
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            TerminalID = "terminal_id",
            Width = 0,
        };

        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.ReadyAt);
        Assert.False(model.RawData.ContainsKey("ready_at"));
        Assert.Null(model.RetryAfterMs);
        Assert.False(model.RawData.ContainsKey("retry_after_ms"));
        Assert.Null(model.StreamUrl);
        Assert.False(model.RawData.ContainsKey("stream_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Terminal
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Height = 0,
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            TerminalID = "terminal_id",
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Terminal
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Height = 0,
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            TerminalID = "terminal_id",
            Width = 0,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
            ExpiresAt = null,
            Protocol = null,
            ReadyAt = null,
            RetryAfterMs = null,
            StreamUrl = null,
        };

        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.ReadyAt);
        Assert.False(model.RawData.ContainsKey("ready_at"));
        Assert.Null(model.RetryAfterMs);
        Assert.False(model.RawData.ContainsKey("retry_after_ms"));
        Assert.Null(model.StreamUrl);
        Assert.False(model.RawData.ContainsKey("stream_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Terminal
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Height = 0,
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            TerminalID = "terminal_id",
            Width = 0,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
            ExpiresAt = null,
            Protocol = null,
            ReadyAt = null,
            RetryAfterMs = null,
            StreamUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Terminal
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Height = 0,
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            TerminalID = "terminal_id",
            Width = 0,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = Protocol.Websocket,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            StreamUrl = "stream_url",
        };

        Terminal copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.WakeInProgress)]
    [InlineData(Status.Ready)]
    [InlineData(Status.Closed)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.WakeInProgress)]
    [InlineData(Status.Ready)]
    [InlineData(Status.Closed)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProtocolTest : TestBase
{
    [Theory]
    [InlineData(Protocol.Websocket)]
    public void Validation_Works(Protocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Protocol> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Protocol.Websocket)]
    public void SerializationRoundtrip_Works(Protocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Protocol> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

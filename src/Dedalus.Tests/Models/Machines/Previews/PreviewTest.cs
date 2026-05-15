using System;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Previews;

namespace Dedalus.Tests.Models.Machines.Previews;

public class PreviewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Preview
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Port = 0,
            PreviewID = "preview_id",
            Status = Status.WakeInProgress,
            Visibility = PreviewVisibility.Public,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = PreviewProtocol.Http,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Url = "url",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMachineID = "machine_id";
        long expectedPort = 0;
        string expectedPreviewID = "preview_id";
        ApiEnum<string, Status> expectedStatus = Status.WakeInProgress;
        ApiEnum<string, PreviewVisibility> expectedVisibility = PreviewVisibility.Public;
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PreviewProtocol> expectedProtocol = PreviewProtocol.Http;
        DateTimeOffset expectedReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRetryAfterMs = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMachineID, model.MachineID);
        Assert.Equal(expectedPort, model.Port);
        Assert.Equal(expectedPreviewID, model.PreviewID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedVisibility, model.Visibility);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedProtocol, model.Protocol);
        Assert.Equal(expectedReadyAt, model.ReadyAt);
        Assert.Equal(expectedRetryAfterMs, model.RetryAfterMs);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Preview
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Port = 0,
            PreviewID = "preview_id",
            Status = Status.WakeInProgress,
            Visibility = PreviewVisibility.Public,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = PreviewProtocol.Http,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Preview>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Preview
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Port = 0,
            PreviewID = "preview_id",
            Status = Status.WakeInProgress,
            Visibility = PreviewVisibility.Public,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = PreviewProtocol.Http,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Preview>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMachineID = "machine_id";
        long expectedPort = 0;
        string expectedPreviewID = "preview_id";
        ApiEnum<string, Status> expectedStatus = Status.WakeInProgress;
        ApiEnum<string, PreviewVisibility> expectedVisibility = PreviewVisibility.Public;
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PreviewProtocol> expectedProtocol = PreviewProtocol.Http;
        DateTimeOffset expectedReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRetryAfterMs = 0;
        string expectedUrl = "url";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMachineID, deserialized.MachineID);
        Assert.Equal(expectedPort, deserialized.Port);
        Assert.Equal(expectedPreviewID, deserialized.PreviewID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedVisibility, deserialized.Visibility);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedProtocol, deserialized.Protocol);
        Assert.Equal(expectedReadyAt, deserialized.ReadyAt);
        Assert.Equal(expectedRetryAfterMs, deserialized.RetryAfterMs);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Preview
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Port = 0,
            PreviewID = "preview_id",
            Status = Status.WakeInProgress,
            Visibility = PreviewVisibility.Public,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = PreviewProtocol.Http,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Preview
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Port = 0,
            PreviewID = "preview_id",
            Status = Status.WakeInProgress,
            Visibility = PreviewVisibility.Public,
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
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Preview
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Port = 0,
            PreviewID = "preview_id",
            Status = Status.WakeInProgress,
            Visibility = PreviewVisibility.Public,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Preview
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Port = 0,
            PreviewID = "preview_id",
            Status = Status.WakeInProgress,
            Visibility = PreviewVisibility.Public,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
            ExpiresAt = null,
            Protocol = null,
            ReadyAt = null,
            RetryAfterMs = null,
            Url = null,
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
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Preview
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Port = 0,
            PreviewID = "preview_id",
            Status = Status.WakeInProgress,
            Visibility = PreviewVisibility.Public,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
            ExpiresAt = null,
            Protocol = null,
            ReadyAt = null,
            RetryAfterMs = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Preview
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Port = 0,
            PreviewID = "preview_id",
            Status = Status.WakeInProgress,
            Visibility = PreviewVisibility.Public,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Protocol = PreviewProtocol.Http,
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Url = "url",
        };

        Preview copied = new(model);

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

public class PreviewVisibilityTest : TestBase
{
    [Theory]
    [InlineData(PreviewVisibility.Public)]
    [InlineData(PreviewVisibility.Private)]
    [InlineData(PreviewVisibility.Org)]
    public void Validation_Works(PreviewVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewVisibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewVisibility>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreviewVisibility.Public)]
    [InlineData(PreviewVisibility.Private)]
    [InlineData(PreviewVisibility.Org)]
    public void SerializationRoundtrip_Works(PreviewVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewVisibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewVisibility>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewVisibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PreviewProtocolTest : TestBase
{
    [Theory]
    [InlineData(PreviewProtocol.Http)]
    [InlineData(PreviewProtocol.Https)]
    public void Validation_Works(PreviewProtocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewProtocol> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewProtocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreviewProtocol.Http)]
    [InlineData(PreviewProtocol.Https)]
    public void SerializationRoundtrip_Works(PreviewProtocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewProtocol> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewProtocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewProtocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewProtocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TerminalErrorEvent
        {
            Type = TerminalErrorEventType.Error,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        ApiEnum<string, TerminalErrorEventType> expectedType = TerminalErrorEventType.Error;
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TerminalErrorEvent
        {
            Type = TerminalErrorEventType.Error,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalErrorEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TerminalErrorEvent
        {
            Type = TerminalErrorEventType.Error,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalErrorEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TerminalErrorEventType> expectedType = TerminalErrorEventType.Error;
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TerminalErrorEvent
        {
            Type = TerminalErrorEventType.Error,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TerminalErrorEvent { Type = TerminalErrorEventType.Error };

        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TerminalErrorEvent { Type = TerminalErrorEventType.Error };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TerminalErrorEvent
        {
            Type = TerminalErrorEventType.Error,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
        };

        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TerminalErrorEvent
        {
            Type = TerminalErrorEventType.Error,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TerminalErrorEvent
        {
            Type = TerminalErrorEventType.Error,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };

        TerminalErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TerminalErrorEventTypeTest : TestBase
{
    [Theory]
    [InlineData(TerminalErrorEventType.Error)]
    public void Validation_Works(TerminalErrorEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TerminalErrorEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TerminalErrorEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TerminalErrorEventType.Error)]
    public void SerializationRoundtrip_Works(TerminalErrorEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TerminalErrorEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TerminalErrorEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TerminalErrorEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TerminalErrorEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

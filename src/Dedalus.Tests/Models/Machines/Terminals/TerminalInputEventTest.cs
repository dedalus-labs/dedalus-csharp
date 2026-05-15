using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalInputEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TerminalInputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalInputEventType.Input,
        };

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, TerminalInputEventType> expectedType = TerminalInputEventType.Input;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TerminalInputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalInputEventType.Input,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalInputEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TerminalInputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalInputEventType.Input,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalInputEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, TerminalInputEventType> expectedType = TerminalInputEventType.Input;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TerminalInputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalInputEventType.Input,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TerminalInputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalInputEventType.Input,
        };

        TerminalInputEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TerminalInputEventTypeTest : TestBase
{
    [Theory]
    [InlineData(TerminalInputEventType.Input)]
    public void Validation_Works(TerminalInputEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TerminalInputEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TerminalInputEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TerminalInputEventType.Input)]
    public void SerializationRoundtrip_Works(TerminalInputEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TerminalInputEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TerminalInputEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TerminalInputEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TerminalInputEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

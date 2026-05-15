using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalOutputEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TerminalOutputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalOutputEventType.Output,
        };

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, TerminalOutputEventType> expectedType = TerminalOutputEventType.Output;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TerminalOutputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalOutputEventType.Output,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalOutputEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TerminalOutputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalOutputEventType.Output,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalOutputEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, TerminalOutputEventType> expectedType = TerminalOutputEventType.Output;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TerminalOutputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalOutputEventType.Output,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TerminalOutputEvent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalOutputEventType.Output,
        };

        TerminalOutputEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TerminalOutputEventTypeTest : TestBase
{
    [Theory]
    [InlineData(TerminalOutputEventType.Output)]
    public void Validation_Works(TerminalOutputEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TerminalOutputEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TerminalOutputEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TerminalOutputEventType.Output)]
    public void SerializationRoundtrip_Works(TerminalOutputEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TerminalOutputEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TerminalOutputEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TerminalOutputEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TerminalOutputEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

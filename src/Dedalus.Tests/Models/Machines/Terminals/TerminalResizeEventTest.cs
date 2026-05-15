using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalResizeEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TerminalResizeEvent
        {
            Height = 0,
            Type = TerminalResizeEventType.Resize,
            Width = 0,
        };

        long expectedHeight = 0;
        ApiEnum<string, TerminalResizeEventType> expectedType = TerminalResizeEventType.Resize;
        long expectedWidth = 0;

        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TerminalResizeEvent
        {
            Height = 0,
            Type = TerminalResizeEventType.Resize,
            Width = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalResizeEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TerminalResizeEvent
        {
            Height = 0,
            Type = TerminalResizeEventType.Resize,
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalResizeEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedHeight = 0;
        ApiEnum<string, TerminalResizeEventType> expectedType = TerminalResizeEventType.Resize;
        long expectedWidth = 0;

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TerminalResizeEvent
        {
            Height = 0,
            Type = TerminalResizeEventType.Resize,
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TerminalResizeEvent
        {
            Height = 0,
            Type = TerminalResizeEventType.Resize,
            Width = 0,
        };

        TerminalResizeEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TerminalResizeEventTypeTest : TestBase
{
    [Theory]
    [InlineData(TerminalResizeEventType.Resize)]
    public void Validation_Works(TerminalResizeEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TerminalResizeEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TerminalResizeEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TerminalResizeEventType.Resize)]
    public void SerializationRoundtrip_Works(TerminalResizeEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TerminalResizeEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TerminalResizeEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TerminalResizeEventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TerminalResizeEventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

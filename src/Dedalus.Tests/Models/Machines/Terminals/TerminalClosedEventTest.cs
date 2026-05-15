using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalClosedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TerminalClosedEvent { Type = Type.Closed };

        ApiEnum<string, Type> expectedType = Type.Closed;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TerminalClosedEvent { Type = Type.Closed };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalClosedEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TerminalClosedEvent { Type = Type.Closed };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalClosedEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Type> expectedType = Type.Closed;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TerminalClosedEvent { Type = Type.Closed };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TerminalClosedEvent { Type = Type.Closed };

        TerminalClosedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Closed)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Closed)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

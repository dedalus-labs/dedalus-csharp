using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalClientEventTest : TestBase
{
    [Fact]
    public void InputValidationWorks()
    {
        TerminalClientEvent value = new TerminalInputEvent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalInputEventType.Input,
        };
        value.Validate();
    }

    [Fact]
    public void ResizeValidationWorks()
    {
        TerminalClientEvent value = new TerminalResizeEvent()
        {
            Height = 0,
            Type = TerminalResizeEventType.Resize,
            Width = 0,
        };
        value.Validate();
    }

    [Fact]
    public void InputSerializationRoundtripWorks()
    {
        TerminalClientEvent value = new TerminalInputEvent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalInputEventType.Input,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalClientEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ResizeSerializationRoundtripWorks()
    {
        TerminalClientEvent value = new TerminalResizeEvent()
        {
            Height = 0,
            Type = TerminalResizeEventType.Resize,
            Width = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalClientEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

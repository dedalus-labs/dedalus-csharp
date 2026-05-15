using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalServerEventTest : TestBase
{
    [Fact]
    public void OutputValidationWorks()
    {
        TerminalServerEvent value = new TerminalOutputEvent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalOutputEventType.Output,
        };
        value.Validate();
    }

    [Fact]
    public void ErrorValidationWorks()
    {
        TerminalServerEvent value = new TerminalErrorEvent()
        {
            Type = TerminalErrorEventType.Error,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };
        value.Validate();
    }

    [Fact]
    public void ClosedValidationWorks()
    {
        TerminalServerEvent value = new TerminalClosedEvent(Type.Closed);
        value.Validate();
    }

    [Fact]
    public void OutputSerializationRoundtripWorks()
    {
        TerminalServerEvent value = new TerminalOutputEvent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            Type = TerminalOutputEventType.Output,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalServerEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ErrorSerializationRoundtripWorks()
    {
        TerminalServerEvent value = new TerminalErrorEvent()
        {
            Type = TerminalErrorEventType.Error,
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalServerEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ClosedSerializationRoundtripWorks()
    {
        TerminalServerEvent value = new TerminalClosedEvent(Type.Closed);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalServerEvent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

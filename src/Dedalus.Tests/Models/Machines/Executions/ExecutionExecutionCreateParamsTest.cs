using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ExecutionExecutionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionExecutionCreateParams
        {
            Command = ["string"],
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Stdin = "stdin",
            TimeoutMs = 0,
        };

        List<string> expectedCommand = ["string"];
        string expectedCwd = "cwd";
        Dictionary<string, string> expectedEnv = new() { { "foo", "string" } };
        string expectedStdin = "stdin";
        long expectedTimeoutMs = 0;

        Assert.NotNull(model.Command);
        Assert.Equal(expectedCommand.Count, model.Command.Count);
        for (int i = 0; i < expectedCommand.Count; i++)
        {
            Assert.Equal(expectedCommand[i], model.Command[i]);
        }
        Assert.Equal(expectedCwd, model.Cwd);
        Assert.NotNull(model.Env);
        Assert.Equal(expectedEnv.Count, model.Env.Count);
        foreach (var item in expectedEnv)
        {
            Assert.True(model.Env.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Env[item.Key]);
        }
        Assert.Equal(expectedStdin, model.Stdin);
        Assert.Equal(expectedTimeoutMs, model.TimeoutMs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionExecutionCreateParams
        {
            Command = ["string"],
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Stdin = "stdin",
            TimeoutMs = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionExecutionCreateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionExecutionCreateParams
        {
            Command = ["string"],
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Stdin = "stdin",
            TimeoutMs = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionExecutionCreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedCommand = ["string"];
        string expectedCwd = "cwd";
        Dictionary<string, string> expectedEnv = new() { { "foo", "string" } };
        string expectedStdin = "stdin";
        long expectedTimeoutMs = 0;

        Assert.NotNull(deserialized.Command);
        Assert.Equal(expectedCommand.Count, deserialized.Command.Count);
        for (int i = 0; i < expectedCommand.Count; i++)
        {
            Assert.Equal(expectedCommand[i], deserialized.Command[i]);
        }
        Assert.Equal(expectedCwd, deserialized.Cwd);
        Assert.NotNull(deserialized.Env);
        Assert.Equal(expectedEnv.Count, deserialized.Env.Count);
        foreach (var item in expectedEnv)
        {
            Assert.True(deserialized.Env.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Env[item.Key]);
        }
        Assert.Equal(expectedStdin, deserialized.Stdin);
        Assert.Equal(expectedTimeoutMs, deserialized.TimeoutMs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionExecutionCreateParams
        {
            Command = ["string"],
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Stdin = "stdin",
            TimeoutMs = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionExecutionCreateParams { Command = ["string"] };

        Assert.Null(model.Cwd);
        Assert.False(model.RawData.ContainsKey("cwd"));
        Assert.Null(model.Env);
        Assert.False(model.RawData.ContainsKey("env"));
        Assert.Null(model.Stdin);
        Assert.False(model.RawData.ContainsKey("stdin"));
        Assert.Null(model.TimeoutMs);
        Assert.False(model.RawData.ContainsKey("timeout_ms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionExecutionCreateParams { Command = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionExecutionCreateParams
        {
            Command = ["string"],

            // Null should be interpreted as omitted for these properties
            Cwd = null,
            Env = null,
            Stdin = null,
            TimeoutMs = null,
        };

        Assert.Null(model.Cwd);
        Assert.False(model.RawData.ContainsKey("cwd"));
        Assert.Null(model.Env);
        Assert.False(model.RawData.ContainsKey("env"));
        Assert.Null(model.Stdin);
        Assert.False(model.RawData.ContainsKey("stdin"));
        Assert.Null(model.TimeoutMs);
        Assert.False(model.RawData.ContainsKey("timeout_ms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionExecutionCreateParams
        {
            Command = ["string"],

            // Null should be interpreted as omitted for these properties
            Cwd = null,
            Env = null,
            Stdin = null,
            TimeoutMs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionExecutionCreateParams
        {
            Command = ["string"],
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Stdin = "stdin",
            TimeoutMs = 0,
        };

        ExecutionExecutionCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

using System;
using System.Collections.Generic;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ExecutionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExecutionCreateParams
        {
            MachineID = "dm-3",
            Command = ["string"],
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Stdin = "stdin",
            TimeoutMs = 0,
        };

        string expectedMachineID = "dm-3";
        List<string> expectedCommand = ["string"];
        string expectedCwd = "cwd";
        Dictionary<string, string> expectedEnv = new() { { "foo", "string" } };
        string expectedStdin = "stdin";
        long expectedTimeoutMs = 0;

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.NotNull(parameters.Command);
        Assert.Equal(expectedCommand.Count, parameters.Command.Count);
        for (int i = 0; i < expectedCommand.Count; i++)
        {
            Assert.Equal(expectedCommand[i], parameters.Command[i]);
        }
        Assert.Equal(expectedCwd, parameters.Cwd);
        Assert.NotNull(parameters.Env);
        Assert.Equal(expectedEnv.Count, parameters.Env.Count);
        foreach (var item in expectedEnv)
        {
            Assert.True(parameters.Env.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Env[item.Key]);
        }
        Assert.Equal(expectedStdin, parameters.Stdin);
        Assert.Equal(expectedTimeoutMs, parameters.TimeoutMs);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExecutionCreateParams { MachineID = "dm-3", Command = ["string"] };

        Assert.Null(parameters.Cwd);
        Assert.False(parameters.RawBodyData.ContainsKey("cwd"));
        Assert.Null(parameters.Env);
        Assert.False(parameters.RawBodyData.ContainsKey("env"));
        Assert.Null(parameters.Stdin);
        Assert.False(parameters.RawBodyData.ContainsKey("stdin"));
        Assert.Null(parameters.TimeoutMs);
        Assert.False(parameters.RawBodyData.ContainsKey("timeout_ms"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExecutionCreateParams
        {
            MachineID = "dm-3",
            Command = ["string"],

            // Null should be interpreted as omitted for these properties
            Cwd = null,
            Env = null,
            Stdin = null,
            TimeoutMs = null,
        };

        Assert.Null(parameters.Cwd);
        Assert.False(parameters.RawBodyData.ContainsKey("cwd"));
        Assert.Null(parameters.Env);
        Assert.False(parameters.RawBodyData.ContainsKey("env"));
        Assert.Null(parameters.Stdin);
        Assert.False(parameters.RawBodyData.ContainsKey("stdin"));
        Assert.Null(parameters.TimeoutMs);
        Assert.False(parameters.RawBodyData.ContainsKey("timeout_ms"));
    }

    [Fact]
    public void Url_Works()
    {
        ExecutionCreateParams parameters = new() { MachineID = "dm-3", Command = ["string"] };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/executions"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExecutionCreateParams
        {
            MachineID = "dm-3",
            Command = ["string"],
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Stdin = "stdin",
            TimeoutMs = 0,
        };

        ExecutionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

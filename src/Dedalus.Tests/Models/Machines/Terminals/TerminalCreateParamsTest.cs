using System;
using System.Collections.Generic;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TerminalCreateParams
        {
            MachineID = "dm-3",
            Height = 0,
            Width = 0,
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Shell = "shell",
        };

        string expectedMachineID = "dm-3";
        long expectedHeight = 0;
        long expectedWidth = 0;
        string expectedCwd = "cwd";
        Dictionary<string, string> expectedEnv = new() { { "foo", "string" } };
        string expectedShell = "shell";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedHeight, parameters.Height);
        Assert.Equal(expectedWidth, parameters.Width);
        Assert.Equal(expectedCwd, parameters.Cwd);
        Assert.NotNull(parameters.Env);
        Assert.Equal(expectedEnv.Count, parameters.Env.Count);
        foreach (var item in expectedEnv)
        {
            Assert.True(parameters.Env.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Env[item.Key]);
        }
        Assert.Equal(expectedShell, parameters.Shell);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TerminalCreateParams
        {
            MachineID = "dm-3",
            Height = 0,
            Width = 0,
        };

        Assert.Null(parameters.Cwd);
        Assert.False(parameters.RawBodyData.ContainsKey("cwd"));
        Assert.Null(parameters.Env);
        Assert.False(parameters.RawBodyData.ContainsKey("env"));
        Assert.Null(parameters.Shell);
        Assert.False(parameters.RawBodyData.ContainsKey("shell"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TerminalCreateParams
        {
            MachineID = "dm-3",
            Height = 0,
            Width = 0,

            // Null should be interpreted as omitted for these properties
            Cwd = null,
            Env = null,
            Shell = null,
        };

        Assert.Null(parameters.Cwd);
        Assert.False(parameters.RawBodyData.ContainsKey("cwd"));
        Assert.Null(parameters.Env);
        Assert.False(parameters.RawBodyData.ContainsKey("env"));
        Assert.Null(parameters.Shell);
        Assert.False(parameters.RawBodyData.ContainsKey("shell"));
    }

    [Fact]
    public void Url_Works()
    {
        TerminalCreateParams parameters = new()
        {
            MachineID = "dm-3",
            Height = 0,
            Width = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/terminals"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TerminalCreateParams
        {
            MachineID = "dm-3",
            Height = 0,
            Width = 0,
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Shell = "shell",
        };

        TerminalCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

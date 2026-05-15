using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalTerminalCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TerminalTerminalCreateParams
        {
            Height = 0,
            Width = 0,
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Shell = "shell",
        };

        long expectedHeight = 0;
        long expectedWidth = 0;
        string expectedCwd = "cwd";
        Dictionary<string, string> expectedEnv = new() { { "foo", "string" } };
        string expectedShell = "shell";

        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedCwd, model.Cwd);
        Assert.NotNull(model.Env);
        Assert.Equal(expectedEnv.Count, model.Env.Count);
        foreach (var item in expectedEnv)
        {
            Assert.True(model.Env.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Env[item.Key]);
        }
        Assert.Equal(expectedShell, model.Shell);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TerminalTerminalCreateParams
        {
            Height = 0,
            Width = 0,
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Shell = "shell",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalTerminalCreateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TerminalTerminalCreateParams
        {
            Height = 0,
            Width = 0,
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Shell = "shell",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TerminalTerminalCreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedHeight = 0;
        long expectedWidth = 0;
        string expectedCwd = "cwd";
        Dictionary<string, string> expectedEnv = new() { { "foo", "string" } };
        string expectedShell = "shell";

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedCwd, deserialized.Cwd);
        Assert.NotNull(deserialized.Env);
        Assert.Equal(expectedEnv.Count, deserialized.Env.Count);
        foreach (var item in expectedEnv)
        {
            Assert.True(deserialized.Env.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Env[item.Key]);
        }
        Assert.Equal(expectedShell, deserialized.Shell);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TerminalTerminalCreateParams
        {
            Height = 0,
            Width = 0,
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Shell = "shell",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TerminalTerminalCreateParams { Height = 0, Width = 0 };

        Assert.Null(model.Cwd);
        Assert.False(model.RawData.ContainsKey("cwd"));
        Assert.Null(model.Env);
        Assert.False(model.RawData.ContainsKey("env"));
        Assert.Null(model.Shell);
        Assert.False(model.RawData.ContainsKey("shell"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TerminalTerminalCreateParams { Height = 0, Width = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TerminalTerminalCreateParams
        {
            Height = 0,
            Width = 0,

            // Null should be interpreted as omitted for these properties
            Cwd = null,
            Env = null,
            Shell = null,
        };

        Assert.Null(model.Cwd);
        Assert.False(model.RawData.ContainsKey("cwd"));
        Assert.Null(model.Env);
        Assert.False(model.RawData.ContainsKey("env"));
        Assert.Null(model.Shell);
        Assert.False(model.RawData.ContainsKey("shell"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TerminalTerminalCreateParams
        {
            Height = 0,
            Width = 0,

            // Null should be interpreted as omitted for these properties
            Cwd = null,
            Env = null,
            Shell = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TerminalTerminalCreateParams
        {
            Height = 0,
            Width = 0,
            Cwd = "cwd",
            Env = new Dictionary<string, string>() { { "foo", "string" } },
            Shell = "shell",
        };

        TerminalTerminalCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

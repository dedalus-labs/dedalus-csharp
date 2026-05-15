using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ExecutionOutputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionOutput
        {
            ExecutionID = "execution_id",
            Stderr = "stderr",
            StderrBytes = 0,
            StderrTruncated = true,
            Stdout = "stdout",
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        string expectedExecutionID = "execution_id";
        string expectedStderr = "stderr";
        long expectedStderrBytes = 0;
        bool expectedStderrTruncated = true;
        string expectedStdout = "stdout";
        long expectedStdoutBytes = 0;
        bool expectedStdoutTruncated = true;

        Assert.Equal(expectedExecutionID, model.ExecutionID);
        Assert.Equal(expectedStderr, model.Stderr);
        Assert.Equal(expectedStderrBytes, model.StderrBytes);
        Assert.Equal(expectedStderrTruncated, model.StderrTruncated);
        Assert.Equal(expectedStdout, model.Stdout);
        Assert.Equal(expectedStdoutBytes, model.StdoutBytes);
        Assert.Equal(expectedStdoutTruncated, model.StdoutTruncated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionOutput
        {
            ExecutionID = "execution_id",
            Stderr = "stderr",
            StderrBytes = 0,
            StderrTruncated = true,
            Stdout = "stdout",
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionOutput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionOutput
        {
            ExecutionID = "execution_id",
            Stderr = "stderr",
            StderrBytes = 0,
            StderrTruncated = true,
            Stdout = "stdout",
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionOutput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExecutionID = "execution_id";
        string expectedStderr = "stderr";
        long expectedStderrBytes = 0;
        bool expectedStderrTruncated = true;
        string expectedStdout = "stdout";
        long expectedStdoutBytes = 0;
        bool expectedStdoutTruncated = true;

        Assert.Equal(expectedExecutionID, deserialized.ExecutionID);
        Assert.Equal(expectedStderr, deserialized.Stderr);
        Assert.Equal(expectedStderrBytes, deserialized.StderrBytes);
        Assert.Equal(expectedStderrTruncated, deserialized.StderrTruncated);
        Assert.Equal(expectedStdout, deserialized.Stdout);
        Assert.Equal(expectedStdoutBytes, deserialized.StdoutBytes);
        Assert.Equal(expectedStdoutTruncated, deserialized.StdoutTruncated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionOutput
        {
            ExecutionID = "execution_id",
            Stderr = "stderr",
            StderrBytes = 0,
            StderrTruncated = true,
            Stdout = "stdout",
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionOutput { ExecutionID = "execution_id" };

        Assert.Null(model.Stderr);
        Assert.False(model.RawData.ContainsKey("stderr"));
        Assert.Null(model.StderrBytes);
        Assert.False(model.RawData.ContainsKey("stderr_bytes"));
        Assert.Null(model.StderrTruncated);
        Assert.False(model.RawData.ContainsKey("stderr_truncated"));
        Assert.Null(model.Stdout);
        Assert.False(model.RawData.ContainsKey("stdout"));
        Assert.Null(model.StdoutBytes);
        Assert.False(model.RawData.ContainsKey("stdout_bytes"));
        Assert.Null(model.StdoutTruncated);
        Assert.False(model.RawData.ContainsKey("stdout_truncated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionOutput { ExecutionID = "execution_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionOutput
        {
            ExecutionID = "execution_id",

            // Null should be interpreted as omitted for these properties
            Stderr = null,
            StderrBytes = null,
            StderrTruncated = null,
            Stdout = null,
            StdoutBytes = null,
            StdoutTruncated = null,
        };

        Assert.Null(model.Stderr);
        Assert.False(model.RawData.ContainsKey("stderr"));
        Assert.Null(model.StderrBytes);
        Assert.False(model.RawData.ContainsKey("stderr_bytes"));
        Assert.Null(model.StderrTruncated);
        Assert.False(model.RawData.ContainsKey("stderr_truncated"));
        Assert.Null(model.Stdout);
        Assert.False(model.RawData.ContainsKey("stdout"));
        Assert.Null(model.StdoutBytes);
        Assert.False(model.RawData.ContainsKey("stdout_bytes"));
        Assert.Null(model.StdoutTruncated);
        Assert.False(model.RawData.ContainsKey("stdout_truncated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionOutput
        {
            ExecutionID = "execution_id",

            // Null should be interpreted as omitted for these properties
            Stderr = null,
            StderrBytes = null,
            StderrTruncated = null,
            Stdout = null,
            StdoutBytes = null,
            StdoutTruncated = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionOutput
        {
            ExecutionID = "execution_id",
            Stderr = "stderr",
            StderrBytes = 0,
            StderrTruncated = true,
            Stdout = "stdout",
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        ExecutionOutput copied = new(model);

        Assert.Equal(model, copied);
    }
}

using System;
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ExecutionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            Artifacts = [new() { ArtifactID = "artifact_id", Name = "name" }],
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cwd = "cwd",
            EnvKeys = ["string"],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Signal = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StderrBytes = 0,
            StderrTruncated = true,
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        List<string> expectedCommand = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExecutionID = "execution_id";
        string expectedMachineID = "machine_id";
        ApiEnum<string, Status> expectedStatus = Status.WakeInProgress;
        List<ArtifactRef> expectedArtifacts = [new() { ArtifactID = "artifact_id", Name = "name" }];
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCwd = "cwd";
        List<string> expectedEnvKeys = ["string"];
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        long expectedExitCode = 0;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRetryAfterMs = 0;
        long expectedSignal = 0;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedStderrBytes = 0;
        bool expectedStderrTruncated = true;
        long expectedStdoutBytes = 0;
        bool expectedStdoutTruncated = true;

        Assert.NotNull(model.Command);
        Assert.Equal(expectedCommand.Count, model.Command.Count);
        for (int i = 0; i < expectedCommand.Count; i++)
        {
            Assert.Equal(expectedCommand[i], model.Command[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExecutionID, model.ExecutionID);
        Assert.Equal(expectedMachineID, model.MachineID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Artifacts);
        Assert.Equal(expectedArtifacts.Count, model.Artifacts.Count);
        for (int i = 0; i < expectedArtifacts.Count; i++)
        {
            Assert.Equal(expectedArtifacts[i], model.Artifacts[i]);
        }
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedCwd, model.Cwd);
        Assert.NotNull(model.EnvKeys);
        Assert.Equal(expectedEnvKeys.Count, model.EnvKeys.Count);
        for (int i = 0; i < expectedEnvKeys.Count; i++)
        {
            Assert.Equal(expectedEnvKeys[i], model.EnvKeys[i]);
        }
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedExitCode, model.ExitCode);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedRetryAfterMs, model.RetryAfterMs);
        Assert.Equal(expectedSignal, model.Signal);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedStderrBytes, model.StderrBytes);
        Assert.Equal(expectedStderrTruncated, model.StderrTruncated);
        Assert.Equal(expectedStdoutBytes, model.StdoutBytes);
        Assert.Equal(expectedStdoutTruncated, model.StdoutTruncated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            Artifacts = [new() { ArtifactID = "artifact_id", Name = "name" }],
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cwd = "cwd",
            EnvKeys = ["string"],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Signal = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StderrBytes = 0,
            StderrTruncated = true,
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Execution>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            Artifacts = [new() { ArtifactID = "artifact_id", Name = "name" }],
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cwd = "cwd",
            EnvKeys = ["string"],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Signal = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StderrBytes = 0,
            StderrTruncated = true,
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Execution>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedCommand = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExecutionID = "execution_id";
        string expectedMachineID = "machine_id";
        ApiEnum<string, Status> expectedStatus = Status.WakeInProgress;
        List<ArtifactRef> expectedArtifacts = [new() { ArtifactID = "artifact_id", Name = "name" }];
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCwd = "cwd";
        List<string> expectedEnvKeys = ["string"];
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        long expectedExitCode = 0;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRetryAfterMs = 0;
        long expectedSignal = 0;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedStderrBytes = 0;
        bool expectedStderrTruncated = true;
        long expectedStdoutBytes = 0;
        bool expectedStdoutTruncated = true;

        Assert.NotNull(deserialized.Command);
        Assert.Equal(expectedCommand.Count, deserialized.Command.Count);
        for (int i = 0; i < expectedCommand.Count; i++)
        {
            Assert.Equal(expectedCommand[i], deserialized.Command[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExecutionID, deserialized.ExecutionID);
        Assert.Equal(expectedMachineID, deserialized.MachineID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Artifacts);
        Assert.Equal(expectedArtifacts.Count, deserialized.Artifacts.Count);
        for (int i = 0; i < expectedArtifacts.Count; i++)
        {
            Assert.Equal(expectedArtifacts[i], deserialized.Artifacts[i]);
        }
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedCwd, deserialized.Cwd);
        Assert.NotNull(deserialized.EnvKeys);
        Assert.Equal(expectedEnvKeys.Count, deserialized.EnvKeys.Count);
        for (int i = 0; i < expectedEnvKeys.Count; i++)
        {
            Assert.Equal(expectedEnvKeys[i], deserialized.EnvKeys[i]);
        }
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedExitCode, deserialized.ExitCode);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedRetryAfterMs, deserialized.RetryAfterMs);
        Assert.Equal(expectedSignal, deserialized.Signal);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedStderrBytes, deserialized.StderrBytes);
        Assert.Equal(expectedStderrTruncated, deserialized.StderrTruncated);
        Assert.Equal(expectedStdoutBytes, deserialized.StdoutBytes);
        Assert.Equal(expectedStdoutTruncated, deserialized.StdoutTruncated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            Artifacts = [new() { ArtifactID = "artifact_id", Name = "name" }],
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cwd = "cwd",
            EnvKeys = ["string"],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Signal = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StderrBytes = 0,
            StderrTruncated = true,
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            Artifacts = [new() { ArtifactID = "artifact_id", Name = "name" }],
            EnvKeys = ["string"],
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completed_at"));
        Assert.Null(model.Cwd);
        Assert.False(model.RawData.ContainsKey("cwd"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExitCode);
        Assert.False(model.RawData.ContainsKey("exit_code"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.RetryAfterMs);
        Assert.False(model.RawData.ContainsKey("retry_after_ms"));
        Assert.Null(model.Signal);
        Assert.False(model.RawData.ContainsKey("signal"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("started_at"));
        Assert.Null(model.StderrBytes);
        Assert.False(model.RawData.ContainsKey("stderr_bytes"));
        Assert.Null(model.StderrTruncated);
        Assert.False(model.RawData.ContainsKey("stderr_truncated"));
        Assert.Null(model.StdoutBytes);
        Assert.False(model.RawData.ContainsKey("stdout_bytes"));
        Assert.Null(model.StdoutTruncated);
        Assert.False(model.RawData.ContainsKey("stdout_truncated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            Artifacts = [new() { ArtifactID = "artifact_id", Name = "name" }],
            EnvKeys = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            Artifacts = [new() { ArtifactID = "artifact_id", Name = "name" }],
            EnvKeys = ["string"],

            // Null should be interpreted as omitted for these properties
            CompletedAt = null,
            Cwd = null,
            ErrorCode = null,
            ErrorMessage = null,
            ExitCode = null,
            ExpiresAt = null,
            RetryAfterMs = null,
            Signal = null,
            StartedAt = null,
            StderrBytes = null,
            StderrTruncated = null,
            StdoutBytes = null,
            StdoutTruncated = null,
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completed_at"));
        Assert.Null(model.Cwd);
        Assert.False(model.RawData.ContainsKey("cwd"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExitCode);
        Assert.False(model.RawData.ContainsKey("exit_code"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.RetryAfterMs);
        Assert.False(model.RawData.ContainsKey("retry_after_ms"));
        Assert.Null(model.Signal);
        Assert.False(model.RawData.ContainsKey("signal"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("started_at"));
        Assert.Null(model.StderrBytes);
        Assert.False(model.RawData.ContainsKey("stderr_bytes"));
        Assert.Null(model.StderrTruncated);
        Assert.False(model.RawData.ContainsKey("stderr_truncated"));
        Assert.Null(model.StdoutBytes);
        Assert.False(model.RawData.ContainsKey("stdout_bytes"));
        Assert.Null(model.StdoutTruncated);
        Assert.False(model.RawData.ContainsKey("stdout_truncated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            Artifacts = [new() { ArtifactID = "artifact_id", Name = "name" }],
            EnvKeys = ["string"],

            // Null should be interpreted as omitted for these properties
            CompletedAt = null,
            Cwd = null,
            ErrorCode = null,
            ErrorMessage = null,
            ExitCode = null,
            ExpiresAt = null,
            RetryAfterMs = null,
            Signal = null,
            StartedAt = null,
            StderrBytes = null,
            StderrTruncated = null,
            StdoutBytes = null,
            StdoutTruncated = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cwd = "cwd",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Signal = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StderrBytes = 0,
            StderrTruncated = true,
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        Assert.Null(model.Artifacts);
        Assert.False(model.RawData.ContainsKey("artifacts"));
        Assert.Null(model.EnvKeys);
        Assert.False(model.RawData.ContainsKey("env_keys"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cwd = "cwd",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Signal = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StderrBytes = 0,
            StderrTruncated = true,
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cwd = "cwd",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Signal = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StderrBytes = 0,
            StderrTruncated = true,
            StdoutBytes = 0,
            StdoutTruncated = true,

            Artifacts = null,
            EnvKeys = null,
        };

        Assert.Null(model.Artifacts);
        Assert.True(model.RawData.ContainsKey("artifacts"));
        Assert.Null(model.EnvKeys);
        Assert.True(model.RawData.ContainsKey("env_keys"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cwd = "cwd",
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Signal = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StderrBytes = 0,
            StderrTruncated = true,
            StdoutBytes = 0,
            StdoutTruncated = true,

            Artifacts = null,
            EnvKeys = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Execution
        {
            Command = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExecutionID = "execution_id",
            MachineID = "machine_id",
            Status = Status.WakeInProgress,
            Artifacts = [new() { ArtifactID = "artifact_id", Name = "name" }],
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cwd = "cwd",
            EnvKeys = ["string"],
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExitCode = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
            Signal = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StderrBytes = 0,
            StderrTruncated = true,
            StdoutBytes = 0,
            StdoutTruncated = true,
        };

        Execution copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.WakeInProgress)]
    [InlineData(Status.Queued)]
    [InlineData(Status.Running)]
    [InlineData(Status.Succeeded)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Expired)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.WakeInProgress)]
    [InlineData(Status.Queued)]
    [InlineData(Status.Running)]
    [InlineData(Status.Succeeded)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Expired)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

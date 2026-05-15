using System;
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ExecutionListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionList
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "next_cursor",
        };

        List<Execution> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "next_cursor";

        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionList
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "next_cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionList
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "next_cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Execution> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "next_cursor";

        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionList
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "next_cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionList
        {
            Items =
            [
                new()
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
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionList
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExecutionList
        {
            Items =
            [
                new()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutionList
        {
            Items =
            [
                new()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionList
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "next_cursor",
        };

        ExecutionList copied = new(model);

        Assert.Equal(model, copied);
    }
}

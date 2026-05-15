using System;
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Executions = Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ExecutionEventsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Executions::ExecutionEvents
        {
            Items =
            [
                new()
                {
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Sequence = 0,
                    Type = Executions::Type.Lifecycle,
                    Chunk = "chunk",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExitCode = 0,
                    Signal = 0,
                    Status = Executions::ExecutionEventStatus.WakeInProgress,
                },
            ],
            NextCursor = "next_cursor",
        };

        List<Executions::ExecutionEvent> expectedItems =
        [
            new()
            {
                At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Sequence = 0,
                Type = Executions::Type.Lifecycle,
                Chunk = "chunk",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                ExitCode = 0,
                Signal = 0,
                Status = Executions::ExecutionEventStatus.WakeInProgress,
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
        var model = new Executions::ExecutionEvents
        {
            Items =
            [
                new()
                {
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Sequence = 0,
                    Type = Executions::Type.Lifecycle,
                    Chunk = "chunk",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExitCode = 0,
                    Signal = 0,
                    Status = Executions::ExecutionEventStatus.WakeInProgress,
                },
            ],
            NextCursor = "next_cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Executions::ExecutionEvents>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Executions::ExecutionEvents
        {
            Items =
            [
                new()
                {
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Sequence = 0,
                    Type = Executions::Type.Lifecycle,
                    Chunk = "chunk",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExitCode = 0,
                    Signal = 0,
                    Status = Executions::ExecutionEventStatus.WakeInProgress,
                },
            ],
            NextCursor = "next_cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Executions::ExecutionEvents>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Executions::ExecutionEvent> expectedItems =
        [
            new()
            {
                At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Sequence = 0,
                Type = Executions::Type.Lifecycle,
                Chunk = "chunk",
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                ExitCode = 0,
                Signal = 0,
                Status = Executions::ExecutionEventStatus.WakeInProgress,
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
        var model = new Executions::ExecutionEvents
        {
            Items =
            [
                new()
                {
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Sequence = 0,
                    Type = Executions::Type.Lifecycle,
                    Chunk = "chunk",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExitCode = 0,
                    Signal = 0,
                    Status = Executions::ExecutionEventStatus.WakeInProgress,
                },
            ],
            NextCursor = "next_cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Executions::ExecutionEvents
        {
            Items =
            [
                new()
                {
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Sequence = 0,
                    Type = Executions::Type.Lifecycle,
                    Chunk = "chunk",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExitCode = 0,
                    Signal = 0,
                    Status = Executions::ExecutionEventStatus.WakeInProgress,
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Executions::ExecutionEvents
        {
            Items =
            [
                new()
                {
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Sequence = 0,
                    Type = Executions::Type.Lifecycle,
                    Chunk = "chunk",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExitCode = 0,
                    Signal = 0,
                    Status = Executions::ExecutionEventStatus.WakeInProgress,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Executions::ExecutionEvents
        {
            Items =
            [
                new()
                {
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Sequence = 0,
                    Type = Executions::Type.Lifecycle,
                    Chunk = "chunk",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExitCode = 0,
                    Signal = 0,
                    Status = Executions::ExecutionEventStatus.WakeInProgress,
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
        var model = new Executions::ExecutionEvents
        {
            Items =
            [
                new()
                {
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Sequence = 0,
                    Type = Executions::Type.Lifecycle,
                    Chunk = "chunk",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExitCode = 0,
                    Signal = 0,
                    Status = Executions::ExecutionEventStatus.WakeInProgress,
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
        var model = new Executions::ExecutionEvents
        {
            Items =
            [
                new()
                {
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Sequence = 0,
                    Type = Executions::Type.Lifecycle,
                    Chunk = "chunk",
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExitCode = 0,
                    Signal = 0,
                    Status = Executions::ExecutionEventStatus.WakeInProgress,
                },
            ],
            NextCursor = "next_cursor",
        };

        Executions::ExecutionEvents copied = new(model);

        Assert.Equal(model, copied);
    }
}

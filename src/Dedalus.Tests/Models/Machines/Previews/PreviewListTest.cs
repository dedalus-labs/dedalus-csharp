using System;
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Previews;

namespace Dedalus.Tests.Models.Machines.Previews;

public class PreviewListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreviewList
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Port = 0,
                    PreviewID = "preview_id",
                    Status = Status.WakeInProgress,
                    Visibility = PreviewVisibility.Public,
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Protocol = PreviewProtocol.Http,
                    ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryAfterMs = 0,
                    Url = "url",
                },
            ],
            NextCursor = "next_cursor",
        };

        List<Preview> expectedItems =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MachineID = "machine_id",
                Port = 0,
                PreviewID = "preview_id",
                Status = Status.WakeInProgress,
                Visibility = PreviewVisibility.Public,
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Protocol = PreviewProtocol.Http,
                ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryAfterMs = 0,
                Url = "url",
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
        var model = new PreviewList
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Port = 0,
                    PreviewID = "preview_id",
                    Status = Status.WakeInProgress,
                    Visibility = PreviewVisibility.Public,
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Protocol = PreviewProtocol.Http,
                    ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryAfterMs = 0,
                    Url = "url",
                },
            ],
            NextCursor = "next_cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreviewList
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Port = 0,
                    PreviewID = "preview_id",
                    Status = Status.WakeInProgress,
                    Visibility = PreviewVisibility.Public,
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Protocol = PreviewProtocol.Http,
                    ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryAfterMs = 0,
                    Url = "url",
                },
            ],
            NextCursor = "next_cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Preview> expectedItems =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MachineID = "machine_id",
                Port = 0,
                PreviewID = "preview_id",
                Status = Status.WakeInProgress,
                Visibility = PreviewVisibility.Public,
                ErrorCode = "error_code",
                ErrorMessage = "error_message",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Protocol = PreviewProtocol.Http,
                ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RetryAfterMs = 0,
                Url = "url",
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
        var model = new PreviewList
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Port = 0,
                    PreviewID = "preview_id",
                    Status = Status.WakeInProgress,
                    Visibility = PreviewVisibility.Public,
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Protocol = PreviewProtocol.Http,
                    ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryAfterMs = 0,
                    Url = "url",
                },
            ],
            NextCursor = "next_cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreviewList
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Port = 0,
                    PreviewID = "preview_id",
                    Status = Status.WakeInProgress,
                    Visibility = PreviewVisibility.Public,
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Protocol = PreviewProtocol.Http,
                    ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryAfterMs = 0,
                    Url = "url",
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreviewList
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Port = 0,
                    PreviewID = "preview_id",
                    Status = Status.WakeInProgress,
                    Visibility = PreviewVisibility.Public,
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Protocol = PreviewProtocol.Http,
                    ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryAfterMs = 0,
                    Url = "url",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PreviewList
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Port = 0,
                    PreviewID = "preview_id",
                    Status = Status.WakeInProgress,
                    Visibility = PreviewVisibility.Public,
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Protocol = PreviewProtocol.Http,
                    ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryAfterMs = 0,
                    Url = "url",
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
        var model = new PreviewList
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Port = 0,
                    PreviewID = "preview_id",
                    Status = Status.WakeInProgress,
                    Visibility = PreviewVisibility.Public,
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Protocol = PreviewProtocol.Http,
                    ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryAfterMs = 0,
                    Url = "url",
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
        var model = new PreviewList
        {
            Items =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Port = 0,
                    PreviewID = "preview_id",
                    Status = Status.WakeInProgress,
                    Visibility = PreviewVisibility.Public,
                    ErrorCode = "error_code",
                    ErrorMessage = "error_message",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Protocol = PreviewProtocol.Http,
                    ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RetryAfterMs = 0,
                    Url = "url",
                },
            ],
            NextCursor = "next_cursor",
        };

        PreviewList copied = new(model);

        Assert.Equal(model, copied);
    }
}

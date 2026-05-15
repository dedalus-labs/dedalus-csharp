using System;
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Artifacts;

namespace Dedalus.Tests.Models.Machines.Artifacts;

public class ArtifactListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ArtifactList
        {
            Items =
            [
                new()
                {
                    ArtifactID = "artifact_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Name = "name",
                    SizeBytes = 0,
                    DownloadUrl = "download_url",
                    ExecutionID = "execution_id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MimeType = "mime_type",
                    Sha256 = "sha256",
                },
            ],
            NextCursor = "next_cursor",
        };

        List<Artifact> expectedItems =
        [
            new()
            {
                ArtifactID = "artifact_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MachineID = "machine_id",
                Name = "name",
                SizeBytes = 0,
                DownloadUrl = "download_url",
                ExecutionID = "execution_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MimeType = "mime_type",
                Sha256 = "sha256",
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
        var model = new ArtifactList
        {
            Items =
            [
                new()
                {
                    ArtifactID = "artifact_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Name = "name",
                    SizeBytes = 0,
                    DownloadUrl = "download_url",
                    ExecutionID = "execution_id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MimeType = "mime_type",
                    Sha256 = "sha256",
                },
            ],
            NextCursor = "next_cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArtifactList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ArtifactList
        {
            Items =
            [
                new()
                {
                    ArtifactID = "artifact_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Name = "name",
                    SizeBytes = 0,
                    DownloadUrl = "download_url",
                    ExecutionID = "execution_id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MimeType = "mime_type",
                    Sha256 = "sha256",
                },
            ],
            NextCursor = "next_cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArtifactList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Artifact> expectedItems =
        [
            new()
            {
                ArtifactID = "artifact_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MachineID = "machine_id",
                Name = "name",
                SizeBytes = 0,
                DownloadUrl = "download_url",
                ExecutionID = "execution_id",
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MimeType = "mime_type",
                Sha256 = "sha256",
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
        var model = new ArtifactList
        {
            Items =
            [
                new()
                {
                    ArtifactID = "artifact_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Name = "name",
                    SizeBytes = 0,
                    DownloadUrl = "download_url",
                    ExecutionID = "execution_id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MimeType = "mime_type",
                    Sha256 = "sha256",
                },
            ],
            NextCursor = "next_cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ArtifactList
        {
            Items =
            [
                new()
                {
                    ArtifactID = "artifact_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Name = "name",
                    SizeBytes = 0,
                    DownloadUrl = "download_url",
                    ExecutionID = "execution_id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MimeType = "mime_type",
                    Sha256 = "sha256",
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ArtifactList
        {
            Items =
            [
                new()
                {
                    ArtifactID = "artifact_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Name = "name",
                    SizeBytes = 0,
                    DownloadUrl = "download_url",
                    ExecutionID = "execution_id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MimeType = "mime_type",
                    Sha256 = "sha256",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ArtifactList
        {
            Items =
            [
                new()
                {
                    ArtifactID = "artifact_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Name = "name",
                    SizeBytes = 0,
                    DownloadUrl = "download_url",
                    ExecutionID = "execution_id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MimeType = "mime_type",
                    Sha256 = "sha256",
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
        var model = new ArtifactList
        {
            Items =
            [
                new()
                {
                    ArtifactID = "artifact_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Name = "name",
                    SizeBytes = 0,
                    DownloadUrl = "download_url",
                    ExecutionID = "execution_id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MimeType = "mime_type",
                    Sha256 = "sha256",
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
        var model = new ArtifactList
        {
            Items =
            [
                new()
                {
                    ArtifactID = "artifact_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MachineID = "machine_id",
                    Name = "name",
                    SizeBytes = 0,
                    DownloadUrl = "download_url",
                    ExecutionID = "execution_id",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MimeType = "mime_type",
                    Sha256 = "sha256",
                },
            ],
            NextCursor = "next_cursor",
        };

        ArtifactList copied = new(model);

        Assert.Equal(model, copied);
    }
}

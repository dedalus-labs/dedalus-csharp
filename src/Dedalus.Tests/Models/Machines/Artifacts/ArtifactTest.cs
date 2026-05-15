using System;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Artifacts;

namespace Dedalus.Tests.Models.Machines.Artifacts;

public class ArtifactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Artifact
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
        };

        string expectedArtifactID = "artifact_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMachineID = "machine_id";
        string expectedName = "name";
        long expectedSizeBytes = 0;
        string expectedDownloadUrl = "download_url";
        string expectedExecutionID = "execution_id";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMimeType = "mime_type";
        string expectedSha256 = "sha256";

        Assert.Equal(expectedArtifactID, model.ArtifactID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMachineID, model.MachineID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.Equal(expectedExecutionID, model.ExecutionID);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedSha256, model.Sha256);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Artifact
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Artifact>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Artifact
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Artifact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedArtifactID = "artifact_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMachineID = "machine_id";
        string expectedName = "name";
        long expectedSizeBytes = 0;
        string expectedDownloadUrl = "download_url";
        string expectedExecutionID = "execution_id";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMimeType = "mime_type";
        string expectedSha256 = "sha256";

        Assert.Equal(expectedArtifactID, deserialized.ArtifactID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMachineID, deserialized.MachineID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.Equal(expectedExecutionID, deserialized.ExecutionID);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedSha256, deserialized.Sha256);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Artifact
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Artifact
        {
            ArtifactID = "artifact_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Name = "name",
            SizeBytes = 0,
        };

        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.ExecutionID);
        Assert.False(model.RawData.ContainsKey("execution_id"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Sha256);
        Assert.False(model.RawData.ContainsKey("sha256"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Artifact
        {
            ArtifactID = "artifact_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Name = "name",
            SizeBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Artifact
        {
            ArtifactID = "artifact_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Name = "name",
            SizeBytes = 0,

            // Null should be interpreted as omitted for these properties
            DownloadUrl = null,
            ExecutionID = null,
            ExpiresAt = null,
            MimeType = null,
            Sha256 = null,
        };

        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.ExecutionID);
        Assert.False(model.RawData.ContainsKey("execution_id"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Sha256);
        Assert.False(model.RawData.ContainsKey("sha256"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Artifact
        {
            ArtifactID = "artifact_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            Name = "name",
            SizeBytes = 0,

            // Null should be interpreted as omitted for these properties
            DownloadUrl = null,
            ExecutionID = null,
            ExpiresAt = null,
            MimeType = null,
            Sha256 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Artifact
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
        };

        Artifact copied = new(model);

        Assert.Equal(model, copied);
    }
}

using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ArtifactRefTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ArtifactRef { ArtifactID = "artifact_id", Name = "name" };

        string expectedArtifactID = "artifact_id";
        string expectedName = "name";

        Assert.Equal(expectedArtifactID, model.ArtifactID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ArtifactRef { ArtifactID = "artifact_id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArtifactRef>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ArtifactRef { ArtifactID = "artifact_id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArtifactRef>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedArtifactID = "artifact_id";
        string expectedName = "name";

        Assert.Equal(expectedArtifactID, deserialized.ArtifactID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ArtifactRef { ArtifactID = "artifact_id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ArtifactRef { ArtifactID = "artifact_id", Name = "name" };

        ArtifactRef copied = new(model);

        Assert.Equal(model, copied);
    }
}

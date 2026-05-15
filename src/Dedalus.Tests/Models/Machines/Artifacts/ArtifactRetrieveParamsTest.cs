using System;
using Dedalus.Models.Machines.Artifacts;

namespace Dedalus.Tests.Models.Machines.Artifacts;

public class ArtifactRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ArtifactRetrieveParams
        {
            MachineID = "dm-3",
            ArtifactID = "artifact_id",
        };

        string expectedMachineID = "dm-3";
        string expectedArtifactID = "artifact_id";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedArtifactID, parameters.ArtifactID);
    }

    [Fact]
    public void Url_Works()
    {
        ArtifactRetrieveParams parameters = new()
        {
            MachineID = "dm-3",
            ArtifactID = "artifact_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/artifacts/artifact_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ArtifactRetrieveParams
        {
            MachineID = "dm-3",
            ArtifactID = "artifact_id",
        };

        ArtifactRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

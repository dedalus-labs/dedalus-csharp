using System;
using Dedalus.Models.Machines.Artifacts;

namespace Dedalus.Tests.Models.Machines.Artifacts;

public class ArtifactListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ArtifactListParams
        {
            MachineID = "dm-3",
            Cursor = "cursor",
            Limit = 0,
        };

        string expectedMachineID = "dm-3";
        string expectedCursor = "cursor";
        long expectedLimit = 0;

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ArtifactListParams { MachineID = "dm-3" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ArtifactListParams
        {
            MachineID = "dm-3",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ArtifactListParams parameters = new()
        {
            MachineID = "dm-3",
            Cursor = "cursor",
            Limit = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://dcs.dedaluslabs.ai/v1/machines/dm-3/artifacts?cursor=cursor&limit=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ArtifactListParams
        {
            MachineID = "dm-3",
            Cursor = "cursor",
            Limit = 0,
        };

        ArtifactListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

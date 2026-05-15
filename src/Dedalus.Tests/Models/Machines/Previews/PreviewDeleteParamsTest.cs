using System;
using Dedalus.Models.Machines.Previews;

namespace Dedalus.Tests.Models.Machines.Previews;

public class PreviewDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreviewDeleteParams { MachineID = "dm-3", PreviewID = "preview_id" };

        string expectedMachineID = "dm-3";
        string expectedPreviewID = "preview_id";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedPreviewID, parameters.PreviewID);
    }

    [Fact]
    public void Url_Works()
    {
        PreviewDeleteParams parameters = new() { MachineID = "dm-3", PreviewID = "preview_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/previews/preview_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PreviewDeleteParams { MachineID = "dm-3", PreviewID = "preview_id" };

        PreviewDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

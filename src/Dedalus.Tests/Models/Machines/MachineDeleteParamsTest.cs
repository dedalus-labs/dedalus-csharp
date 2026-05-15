using System;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MachineDeleteParams { MachineID = "dm-3" };

        string expectedMachineID = "dm-3";

        Assert.Equal(expectedMachineID, parameters.MachineID);
    }

    [Fact]
    public void Url_Works()
    {
        MachineDeleteParams parameters = new() { MachineID = "dm-3" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MachineDeleteParams { MachineID = "dm-3" };

        MachineDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

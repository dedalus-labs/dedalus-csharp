using System;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineWakeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MachineWakeParams { MachineID = "dm-3" };

        string expectedMachineID = "dm-3";

        Assert.Equal(expectedMachineID, parameters.MachineID);
    }

    [Fact]
    public void Url_Works()
    {
        MachineWakeParams parameters = new() { MachineID = "dm-3" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/wake"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MachineWakeParams { MachineID = "dm-3" };

        MachineWakeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

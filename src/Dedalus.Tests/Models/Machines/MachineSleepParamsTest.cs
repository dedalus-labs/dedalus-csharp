using System;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineSleepParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MachineSleepParams { MachineID = "dm-3" };

        string expectedMachineID = "dm-3";

        Assert.Equal(expectedMachineID, parameters.MachineID);
    }

    [Fact]
    public void Url_Works()
    {
        MachineSleepParams parameters = new() { MachineID = "dm-3" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/sleep"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MachineSleepParams { MachineID = "dm-3" };

        MachineSleepParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

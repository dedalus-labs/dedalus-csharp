using System;
using Dedalus.Models.Machines.Ssh;

namespace Dedalus.Tests.Models.Machines.Ssh;

public class SshCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SshCreateParams { MachineID = "dm-3", PublicKey = "public_key" };

        string expectedMachineID = "dm-3";
        string expectedPublicKey = "public_key";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedPublicKey, parameters.PublicKey);
    }

    [Fact]
    public void Url_Works()
    {
        SshCreateParams parameters = new() { MachineID = "dm-3", PublicKey = "public_key" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/ssh"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SshCreateParams { MachineID = "dm-3", PublicKey = "public_key" };

        SshCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

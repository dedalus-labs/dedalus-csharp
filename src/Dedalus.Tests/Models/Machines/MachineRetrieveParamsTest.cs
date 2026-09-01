using System;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MachineRetrieveParams
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
        };

        string expectedMachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c";

        Assert.Equal(expectedMachineID, parameters.MachineID);
    }

    [Fact]
    public void Url_Works()
    {
        MachineRetrieveParams parameters = new()
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://dcs.dedaluslabs.ai/v1/machines/dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MachineRetrieveParams
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
        };

        MachineRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

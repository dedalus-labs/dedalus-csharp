using System;
using Dedalus.Models.Machines.Ssh;

namespace Dedalus.Tests.Models.Machines.Ssh;

public class SshRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SshRetrieveParams
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            SessionID = "session_id",
        };

        string expectedMachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c";
        string expectedSessionID = "session_id";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedSessionID, parameters.SessionID);
    }

    [Fact]
    public void Url_Works()
    {
        SshRetrieveParams parameters = new()
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            SessionID = "session_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://dcs.dedaluslabs.ai/v1/machines/dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c/ssh/session_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SshRetrieveParams
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            SessionID = "session_id",
        };

        SshRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

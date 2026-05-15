using System;
using Dedalus.Models.Machines.Ssh;

namespace Dedalus.Tests.Models.Machines.Ssh;

public class SshDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SshDeleteParams { MachineID = "dm-3", SessionID = "session_id" };

        string expectedMachineID = "dm-3";
        string expectedSessionID = "session_id";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedSessionID, parameters.SessionID);
    }

    [Fact]
    public void Url_Works()
    {
        SshDeleteParams parameters = new() { MachineID = "dm-3", SessionID = "session_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/ssh/session_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SshDeleteParams { MachineID = "dm-3", SessionID = "session_id" };

        SshDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

using System;
using Dedalus.Models.Machines.Terminals;

namespace Dedalus.Tests.Models.Machines.Terminals;

public class TerminalRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TerminalRetrieveParams
        {
            MachineID = "dm-3",
            TerminalID = "terminal_id",
        };

        string expectedMachineID = "dm-3";
        string expectedTerminalID = "terminal_id";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedTerminalID, parameters.TerminalID);
    }

    [Fact]
    public void Url_Works()
    {
        TerminalRetrieveParams parameters = new()
        {
            MachineID = "dm-3",
            TerminalID = "terminal_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/terminals/terminal_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TerminalRetrieveParams
        {
            MachineID = "dm-3",
            TerminalID = "terminal_id",
        };

        TerminalRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

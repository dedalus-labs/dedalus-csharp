using System;
using System.Net.Http;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineWatchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MachineWatchParams
        {
            MachineID = "dm-3",
            LastEventID = "Last-Event-ID",
        };

        string expectedMachineID = "dm-3";
        string expectedLastEventID = "Last-Event-ID";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedLastEventID, parameters.LastEventID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MachineWatchParams { MachineID = "dm-3" };

        Assert.Null(parameters.LastEventID);
        Assert.False(parameters.RawHeaderData.ContainsKey("Last-Event-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MachineWatchParams
        {
            MachineID = "dm-3",

            // Null should be interpreted as omitted for these properties
            LastEventID = null,
        };

        Assert.Null(parameters.LastEventID);
        Assert.False(parameters.RawHeaderData.ContainsKey("Last-Event-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        MachineWatchParams parameters = new() { MachineID = "dm-3" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/status/stream"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MachineWatchParams parameters = new() { MachineID = "dm-3", LastEventID = "Last-Event-ID" };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["Last-Event-ID"], requestMessage.Headers.GetValues("Last-Event-ID"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MachineWatchParams
        {
            MachineID = "dm-3",
            LastEventID = "Last-Event-ID",
        };

        MachineWatchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

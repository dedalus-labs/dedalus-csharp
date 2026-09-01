using System;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ExecutionEventsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExecutionEventsParams
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            ExecutionID = "execution_id",
            Cursor = "cursor",
            Limit = 0,
        };

        string expectedMachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c";
        string expectedExecutionID = "execution_id";
        string expectedCursor = "cursor";
        long expectedLimit = 0;

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedExecutionID, parameters.ExecutionID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExecutionEventsParams
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            ExecutionID = "execution_id",
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExecutionEventsParams
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            ExecutionID = "execution_id",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ExecutionEventsParams parameters = new()
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            ExecutionID = "execution_id",
            Cursor = "cursor",
            Limit = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://dcs.dedaluslabs.ai/v1/machines/dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c/executions/execution_id/events?cursor=cursor&limit=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExecutionEventsParams
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            ExecutionID = "execution_id",
            Cursor = "cursor",
            Limit = 0,
        };

        ExecutionEventsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

using System;
using Dedalus.Models.Machines.Executions;

namespace Dedalus.Tests.Models.Machines.Executions;

public class ExecutionOutputParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExecutionOutputParams
        {
            MachineID = "dm-3",
            ExecutionID = "execution_id",
        };

        string expectedMachineID = "dm-3";
        string expectedExecutionID = "execution_id";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedExecutionID, parameters.ExecutionID);
    }

    [Fact]
    public void Url_Works()
    {
        ExecutionOutputParams parameters = new()
        {
            MachineID = "dm-3",
            ExecutionID = "execution_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://dcs.dedaluslabs.ai/v1/machines/dm-3/executions/execution_id/output"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExecutionOutputParams
        {
            MachineID = "dm-3",
            ExecutionID = "execution_id",
        };

        ExecutionOutputParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

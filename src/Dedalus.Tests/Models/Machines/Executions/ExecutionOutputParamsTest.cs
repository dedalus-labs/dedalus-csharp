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
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            ExecutionID = "execution_id",
        };

        string expectedMachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c";
        string expectedExecutionID = "execution_id";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedExecutionID, parameters.ExecutionID);
    }

    [Fact]
    public void Url_Works()
    {
        ExecutionOutputParams parameters = new()
        {
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            ExecutionID = "execution_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://dcs.dedaluslabs.ai/v1/machines/dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c/executions/execution_id/output"
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
            MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
            ExecutionID = "execution_id",
        };

        ExecutionOutputParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

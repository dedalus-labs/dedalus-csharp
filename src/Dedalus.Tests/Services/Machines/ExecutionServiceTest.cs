using System.Threading.Tasks;

namespace Dedalus.Tests.Services.Machines;

public class ExecutionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var execution = await this.client.Machines.Executions.Create(
            new() { MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c", Command = ["string"] },
            TestContext.Current.CancellationToken
        );
        execution.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var execution = await this.client.Machines.Executions.Retrieve(
            new()
            {
                MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
                ExecutionID = "execution_id",
            },
            TestContext.Current.CancellationToken
        );
        execution.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Machines.Executions.List(
            new() { MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var execution = await this.client.Machines.Executions.Delete(
            new()
            {
                MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
                ExecutionID = "execution_id",
            },
            TestContext.Current.CancellationToken
        );
        execution.Validate();
    }

    [Fact]
    public async Task Events_Works()
    {
        var page = await this.client.Machines.Executions.Events(
            new()
            {
                MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
                ExecutionID = "execution_id",
            },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Output_Works()
    {
        var executionOutput = await this.client.Machines.Executions.Output(
            new()
            {
                MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
                ExecutionID = "execution_id",
            },
            TestContext.Current.CancellationToken
        );
        executionOutput.Validate();
    }
}

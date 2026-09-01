using System.Threading.Tasks;

namespace Dedalus.Tests.Services;

public class MachineServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var machine = await this.client.Machines.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var machine = await this.client.Machines.Retrieve(
            new() { MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c" },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var machine = await this.client.Machines.Update(
            new() { MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c" },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Machines.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var machine = await this.client.Machines.Delete(
            new() { MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c" },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task Sleep_Works()
    {
        var machine = await this.client.Machines.Sleep(
            new() { MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c" },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task Wake_Works()
    {
        var machine = await this.client.Machines.Wake(
            new() { MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c" },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }
}

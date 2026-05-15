using System.Threading.Tasks;

namespace Dedalus.Tests.Services;

public class MachineServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var machine = await this.client.Machines.Create(
            new()
            {
                MemoryMiB = 0,
                StorageGiB = 0,
                Vcpu = 0,
            },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var machine = await this.client.Machines.Retrieve(
            new() { MachineID = "dm-3" },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var machine = await this.client.Machines.Update(
            new() { MachineID = "dm-3" },
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
            new() { MachineID = "dm-3" },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task Sleep_Works()
    {
        var machine = await this.client.Machines.Sleep(
            new() { MachineID = "dm-3" },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task Wake_Works()
    {
        var machine = await this.client.Machines.Wake(
            new() { MachineID = "dm-3" },
            TestContext.Current.CancellationToken
        );
        machine.Validate();
    }

    [Fact]
    public async Task WatchStreaming_Works()
    {
        var stream = this.client.Machines.WatchStreaming(
            new() { MachineID = "dm-3" },
            TestContext.Current.CancellationToken
        );

        await foreach (var machine in stream)
        {
            machine.Validate();
        }
    }
}

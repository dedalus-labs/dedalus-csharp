using System.Threading.Tasks;

namespace Dedalus.Tests.Services.Machines;

public class TerminalServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var terminal = await this.client.Machines.Terminals.Create(
            new()
            {
                MachineID = "dm-3",
                Height = 0,
                Width = 0,
            },
            TestContext.Current.CancellationToken
        );
        terminal.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var terminal = await this.client.Machines.Terminals.Retrieve(
            new() { MachineID = "dm-3", TerminalID = "terminal_id" },
            TestContext.Current.CancellationToken
        );
        terminal.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Machines.Terminals.List(
            new() { MachineID = "dm-3" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var terminal = await this.client.Machines.Terminals.Delete(
            new() { MachineID = "dm-3", TerminalID = "terminal_id" },
            TestContext.Current.CancellationToken
        );
        terminal.Validate();
    }
}

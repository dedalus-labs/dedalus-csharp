using System.Threading.Tasks;

namespace Dedalus.Tests.Services.Machines;

public class PreviewServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var preview = await this.client.Machines.Previews.Create(
            new() { MachineID = "dm-3", Port = 0 },
            TestContext.Current.CancellationToken
        );
        preview.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var preview = await this.client.Machines.Previews.Retrieve(
            new() { MachineID = "dm-3", PreviewID = "preview_id" },
            TestContext.Current.CancellationToken
        );
        preview.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Machines.Previews.List(
            new() { MachineID = "dm-3" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var preview = await this.client.Machines.Previews.Delete(
            new() { MachineID = "dm-3", PreviewID = "preview_id" },
            TestContext.Current.CancellationToken
        );
        preview.Validate();
    }
}

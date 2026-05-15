using System.Threading.Tasks;

namespace Dedalus.Tests.Services.Machines;

public class ArtifactServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var artifact = await this.client.Machines.Artifacts.Retrieve(
            new() { MachineID = "dm-3", ArtifactID = "artifact_id" },
            TestContext.Current.CancellationToken
        );
        artifact.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Machines.Artifacts.List(
            new() { MachineID = "dm-3" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var artifact = await this.client.Machines.Artifacts.Delete(
            new() { MachineID = "dm-3", ArtifactID = "artifact_id" },
            TestContext.Current.CancellationToken
        );
        artifact.Validate();
    }
}

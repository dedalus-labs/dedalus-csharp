using System.Threading.Tasks;

namespace Dedalus.Tests.Services;

public class UsageServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var orgUsage = await this.client.Usage.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        orgUsage.Validate();
    }

    [Fact]
    public async Task MachineCompute_Works()
    {
        var machineComputeUsage = await this.client.Usage.MachineCompute(
            new(),
            TestContext.Current.CancellationToken
        );
        machineComputeUsage.Validate();
    }

    [Fact]
    public async Task MachineStorage_Works()
    {
        var machineStorageUsage = await this.client.Usage.MachineStorage(
            new(),
            TestContext.Current.CancellationToken
        );
        machineStorageUsage.Validate();
    }
}

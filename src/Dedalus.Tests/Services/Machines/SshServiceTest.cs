using System.Threading.Tasks;

namespace Dedalus.Tests.Services.Machines;

public class SshServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var sshSession = await this.client.Machines.Ssh.Create(
            new()
            {
                MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
                PublicKey = "public_key",
            },
            TestContext.Current.CancellationToken
        );
        sshSession.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var sshSession = await this.client.Machines.Ssh.Retrieve(
            new()
            {
                MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
                SessionID = "session_id",
            },
            TestContext.Current.CancellationToken
        );
        sshSession.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Machines.Ssh.List(
            new() { MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var sshSession = await this.client.Machines.Ssh.Delete(
            new()
            {
                MachineID = "dm-ecc2efdd-ddfa-31a9-c6f1-b833d337aa7c",
                SessionID = "session_id",
            },
            TestContext.Current.CancellationToken
        );
        sshSession.Validate();
    }
}

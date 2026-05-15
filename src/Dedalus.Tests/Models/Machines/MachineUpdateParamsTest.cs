using System;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MachineUpdateParams
        {
            MachineID = "dm-3",
            Autosleep = "autosleep",
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        string expectedMachineID = "dm-3";
        string expectedAutosleep = "autosleep";
        long expectedMemoryMiB = 0;
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedAutosleep, parameters.Autosleep);
        Assert.Equal(expectedMemoryMiB, parameters.MemoryMiB);
        Assert.Equal(expectedStorageGiB, parameters.StorageGiB);
        Assert.Equal(expectedVcpu, parameters.Vcpu);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MachineUpdateParams { MachineID = "dm-3" };

        Assert.Null(parameters.Autosleep);
        Assert.False(parameters.RawBodyData.ContainsKey("autosleep"));
        Assert.Null(parameters.MemoryMiB);
        Assert.False(parameters.RawBodyData.ContainsKey("memory_mib"));
        Assert.Null(parameters.StorageGiB);
        Assert.False(parameters.RawBodyData.ContainsKey("storage_gib"));
        Assert.Null(parameters.Vcpu);
        Assert.False(parameters.RawBodyData.ContainsKey("vcpu"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MachineUpdateParams
        {
            MachineID = "dm-3",

            // Null should be interpreted as omitted for these properties
            Autosleep = null,
            MemoryMiB = null,
            StorageGiB = null,
            Vcpu = null,
        };

        Assert.Null(parameters.Autosleep);
        Assert.False(parameters.RawBodyData.ContainsKey("autosleep"));
        Assert.Null(parameters.MemoryMiB);
        Assert.False(parameters.RawBodyData.ContainsKey("memory_mib"));
        Assert.Null(parameters.StorageGiB);
        Assert.False(parameters.RawBodyData.ContainsKey("storage_gib"));
        Assert.Null(parameters.Vcpu);
        Assert.False(parameters.RawBodyData.ContainsKey("vcpu"));
    }

    [Fact]
    public void Url_Works()
    {
        MachineUpdateParams parameters = new() { MachineID = "dm-3" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MachineUpdateParams
        {
            MachineID = "dm-3",
            Autosleep = "autosleep",
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        MachineUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

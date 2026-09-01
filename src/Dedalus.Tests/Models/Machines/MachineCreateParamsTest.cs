using System;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MachineCreateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 1,
            StorageGiB = 1,
            Vcpu = 1,
        };

        string expectedAutosleep = "autosleep";
        long expectedMemoryMiB = 1;
        long expectedStorageGiB = 1;
        double expectedVcpu = 1;

        Assert.Equal(expectedAutosleep, parameters.Autosleep);
        Assert.Equal(expectedMemoryMiB, parameters.MemoryMiB);
        Assert.Equal(expectedStorageGiB, parameters.StorageGiB);
        Assert.Equal(expectedVcpu, parameters.Vcpu);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MachineCreateParams { };

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
        var parameters = new MachineCreateParams
        {
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
        MachineCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://dcs.dedaluslabs.ai/v1/machines"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MachineCreateParams
        {
            Autosleep = "autosleep",
            MemoryMiB = 1,
            StorageGiB = 1,
            Vcpu = 1,
        };

        MachineCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

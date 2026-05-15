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
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
            Autosleep = "autosleep",
        };

        long expectedMemoryMiB = 0;
        long expectedStorageGiB = 0;
        double expectedVcpu = 0;
        string expectedAutosleep = "autosleep";

        Assert.Equal(expectedMemoryMiB, parameters.MemoryMiB);
        Assert.Equal(expectedStorageGiB, parameters.StorageGiB);
        Assert.Equal(expectedVcpu, parameters.Vcpu);
        Assert.Equal(expectedAutosleep, parameters.Autosleep);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MachineCreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        Assert.Null(parameters.Autosleep);
        Assert.False(parameters.RawBodyData.ContainsKey("autosleep"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MachineCreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,

            // Null should be interpreted as omitted for these properties
            Autosleep = null,
        };

        Assert.Null(parameters.Autosleep);
        Assert.False(parameters.RawBodyData.ContainsKey("autosleep"));
    }

    [Fact]
    public void Url_Works()
    {
        MachineCreateParams parameters = new()
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://dcs.dedaluslabs.ai/v1/machines"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MachineCreateParams
        {
            MemoryMiB = 0,
            StorageGiB = 0,
            Vcpu = 0,
            Autosleep = "autosleep",
        };

        MachineCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

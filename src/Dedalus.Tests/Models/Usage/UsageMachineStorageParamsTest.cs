using System;
using Dedalus.Models.Usage;

namespace Dedalus.Tests.Models.Usage;

public class UsageMachineStorageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageMachineStorageParams
        {
            MachineID = "machine_id",
            PeriodEnd = "period_end",
            PeriodStart = "period_start",
        };

        string expectedMachineID = "machine_id";
        string expectedPeriodEnd = "period_end";
        string expectedPeriodStart = "period_start";

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedPeriodEnd, parameters.PeriodEnd);
        Assert.Equal(expectedPeriodStart, parameters.PeriodStart);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageMachineStorageParams { };

        Assert.Null(parameters.MachineID);
        Assert.False(parameters.RawQueryData.ContainsKey("machine_id"));
        Assert.Null(parameters.PeriodEnd);
        Assert.False(parameters.RawQueryData.ContainsKey("period_end"));
        Assert.Null(parameters.PeriodStart);
        Assert.False(parameters.RawQueryData.ContainsKey("period_start"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UsageMachineStorageParams
        {
            // Null should be interpreted as omitted for these properties
            MachineID = null,
            PeriodEnd = null,
            PeriodStart = null,
        };

        Assert.Null(parameters.MachineID);
        Assert.False(parameters.RawQueryData.ContainsKey("machine_id"));
        Assert.Null(parameters.PeriodEnd);
        Assert.False(parameters.RawQueryData.ContainsKey("period_end"));
        Assert.Null(parameters.PeriodStart);
        Assert.False(parameters.RawQueryData.ContainsKey("period_start"));
    }

    [Fact]
    public void Url_Works()
    {
        UsageMachineStorageParams parameters = new()
        {
            MachineID = "machine_id",
            PeriodEnd = "period_end",
            PeriodStart = "period_start",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://dcs.dedaluslabs.ai/v1/usage/machines/storage?machine_id=machine_id&period_end=period_end&period_start=period_start"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageMachineStorageParams
        {
            MachineID = "machine_id",
            PeriodEnd = "period_end",
            PeriodStart = "period_start",
        };

        UsageMachineStorageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

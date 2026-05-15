using System;
using Dedalus.Models.Usage;

namespace Dedalus.Tests.Models.Usage;

public class UsageMachineComputeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageMachineComputeParams
        {
            Granularity = "granularity",
            MachineID = "machine_id",
            PeriodEnd = "period_end",
            PeriodStart = "period_start",
        };

        string expectedGranularity = "granularity";
        string expectedMachineID = "machine_id";
        string expectedPeriodEnd = "period_end";
        string expectedPeriodStart = "period_start";

        Assert.Equal(expectedGranularity, parameters.Granularity);
        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedPeriodEnd, parameters.PeriodEnd);
        Assert.Equal(expectedPeriodStart, parameters.PeriodStart);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageMachineComputeParams { };

        Assert.Null(parameters.Granularity);
        Assert.False(parameters.RawQueryData.ContainsKey("granularity"));
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
        var parameters = new UsageMachineComputeParams
        {
            // Null should be interpreted as omitted for these properties
            Granularity = null,
            MachineID = null,
            PeriodEnd = null,
            PeriodStart = null,
        };

        Assert.Null(parameters.Granularity);
        Assert.False(parameters.RawQueryData.ContainsKey("granularity"));
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
        UsageMachineComputeParams parameters = new()
        {
            Granularity = "granularity",
            MachineID = "machine_id",
            PeriodEnd = "period_end",
            PeriodStart = "period_start",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://dcs.dedaluslabs.ai/v1/usage/machines/compute?granularity=granularity&machine_id=machine_id&period_end=period_end&period_start=period_start"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageMachineComputeParams
        {
            Granularity = "granularity",
            MachineID = "machine_id",
            PeriodEnd = "period_end",
            PeriodStart = "period_start",
        };

        UsageMachineComputeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

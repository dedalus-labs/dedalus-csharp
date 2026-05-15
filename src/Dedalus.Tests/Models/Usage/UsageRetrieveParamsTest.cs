using System;
using Dedalus.Models.Usage;

namespace Dedalus.Tests.Models.Usage;

public class UsageRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UsageRetrieveParams { PeriodStart = "period_start" };

        string expectedPeriodStart = "period_start";

        Assert.Equal(expectedPeriodStart, parameters.PeriodStart);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UsageRetrieveParams { };

        Assert.Null(parameters.PeriodStart);
        Assert.False(parameters.RawQueryData.ContainsKey("period_start"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UsageRetrieveParams
        {
            // Null should be interpreted as omitted for these properties
            PeriodStart = null,
        };

        Assert.Null(parameters.PeriodStart);
        Assert.False(parameters.RawQueryData.ContainsKey("period_start"));
    }

    [Fact]
    public void Url_Works()
    {
        UsageRetrieveParams parameters = new() { PeriodStart = "period_start" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://dcs.dedaluslabs.ai/v1/usage?period_start=period_start"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UsageRetrieveParams { PeriodStart = "period_start" };

        UsageRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

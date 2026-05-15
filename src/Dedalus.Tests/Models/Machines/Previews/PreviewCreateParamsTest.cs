using System;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Previews;

namespace Dedalus.Tests.Models.Machines.Previews;

public class PreviewCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreviewCreateParams
        {
            MachineID = "dm-3",
            Port = 0,
            Protocol = Protocol.Http,
            Visibility = Visibility.Public,
        };

        string expectedMachineID = "dm-3";
        long expectedPort = 0;
        ApiEnum<string, Protocol> expectedProtocol = Protocol.Http;
        ApiEnum<string, Visibility> expectedVisibility = Visibility.Public;

        Assert.Equal(expectedMachineID, parameters.MachineID);
        Assert.Equal(expectedPort, parameters.Port);
        Assert.Equal(expectedProtocol, parameters.Protocol);
        Assert.Equal(expectedVisibility, parameters.Visibility);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PreviewCreateParams { MachineID = "dm-3", Port = 0 };

        Assert.Null(parameters.Protocol);
        Assert.False(parameters.RawBodyData.ContainsKey("protocol"));
        Assert.Null(parameters.Visibility);
        Assert.False(parameters.RawBodyData.ContainsKey("visibility"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PreviewCreateParams
        {
            MachineID = "dm-3",
            Port = 0,

            // Null should be interpreted as omitted for these properties
            Protocol = null,
            Visibility = null,
        };

        Assert.Null(parameters.Protocol);
        Assert.False(parameters.RawBodyData.ContainsKey("protocol"));
        Assert.Null(parameters.Visibility);
        Assert.False(parameters.RawBodyData.ContainsKey("visibility"));
    }

    [Fact]
    public void Url_Works()
    {
        PreviewCreateParams parameters = new() { MachineID = "dm-3", Port = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://dcs.dedaluslabs.ai/v1/machines/dm-3/previews"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PreviewCreateParams
        {
            MachineID = "dm-3",
            Port = 0,
            Protocol = Protocol.Http,
            Visibility = Visibility.Public,
        };

        PreviewCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProtocolTest : TestBase
{
    [Theory]
    [InlineData(Protocol.Http)]
    [InlineData(Protocol.Https)]
    public void Validation_Works(Protocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Protocol> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Protocol.Http)]
    [InlineData(Protocol.Https)]
    public void SerializationRoundtrip_Works(Protocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Protocol> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VisibilityTest : TestBase
{
    [Theory]
    [InlineData(Visibility.Public)]
    [InlineData(Visibility.Private)]
    [InlineData(Visibility.Org)]
    public void Validation_Works(Visibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Visibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Visibility.Public)]
    [InlineData(Visibility.Private)]
    [InlineData(Visibility.Org)]
    public void SerializationRoundtrip_Works(Visibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Visibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Visibility>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

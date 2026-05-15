using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Previews;

namespace Dedalus.Tests.Models.Machines.Previews;

public class PreviewPreviewCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreviewPreviewCreateParams
        {
            Port = 0,
            Protocol = PreviewPreviewCreateParamsProtocol.Http,
            Visibility = PreviewPreviewCreateParamsVisibility.Public,
        };

        long expectedPort = 0;
        ApiEnum<string, PreviewPreviewCreateParamsProtocol> expectedProtocol =
            PreviewPreviewCreateParamsProtocol.Http;
        ApiEnum<string, PreviewPreviewCreateParamsVisibility> expectedVisibility =
            PreviewPreviewCreateParamsVisibility.Public;

        Assert.Equal(expectedPort, model.Port);
        Assert.Equal(expectedProtocol, model.Protocol);
        Assert.Equal(expectedVisibility, model.Visibility);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreviewPreviewCreateParams
        {
            Port = 0,
            Protocol = PreviewPreviewCreateParamsProtocol.Http,
            Visibility = PreviewPreviewCreateParamsVisibility.Public,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewPreviewCreateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreviewPreviewCreateParams
        {
            Port = 0,
            Protocol = PreviewPreviewCreateParamsProtocol.Http,
            Visibility = PreviewPreviewCreateParamsVisibility.Public,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewPreviewCreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPort = 0;
        ApiEnum<string, PreviewPreviewCreateParamsProtocol> expectedProtocol =
            PreviewPreviewCreateParamsProtocol.Http;
        ApiEnum<string, PreviewPreviewCreateParamsVisibility> expectedVisibility =
            PreviewPreviewCreateParamsVisibility.Public;

        Assert.Equal(expectedPort, deserialized.Port);
        Assert.Equal(expectedProtocol, deserialized.Protocol);
        Assert.Equal(expectedVisibility, deserialized.Visibility);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreviewPreviewCreateParams
        {
            Port = 0,
            Protocol = PreviewPreviewCreateParamsProtocol.Http,
            Visibility = PreviewPreviewCreateParamsVisibility.Public,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreviewPreviewCreateParams { Port = 0 };

        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.Visibility);
        Assert.False(model.RawData.ContainsKey("visibility"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreviewPreviewCreateParams { Port = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PreviewPreviewCreateParams
        {
            Port = 0,

            // Null should be interpreted as omitted for these properties
            Protocol = null,
            Visibility = null,
        };

        Assert.Null(model.Protocol);
        Assert.False(model.RawData.ContainsKey("protocol"));
        Assert.Null(model.Visibility);
        Assert.False(model.RawData.ContainsKey("visibility"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PreviewPreviewCreateParams
        {
            Port = 0,

            // Null should be interpreted as omitted for these properties
            Protocol = null,
            Visibility = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreviewPreviewCreateParams
        {
            Port = 0,
            Protocol = PreviewPreviewCreateParamsProtocol.Http,
            Visibility = PreviewPreviewCreateParamsVisibility.Public,
        };

        PreviewPreviewCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PreviewPreviewCreateParamsProtocolTest : TestBase
{
    [Theory]
    [InlineData(PreviewPreviewCreateParamsProtocol.Http)]
    [InlineData(PreviewPreviewCreateParamsProtocol.Https)]
    public void Validation_Works(PreviewPreviewCreateParamsProtocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewPreviewCreateParamsProtocol> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewPreviewCreateParamsProtocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreviewPreviewCreateParamsProtocol.Http)]
    [InlineData(PreviewPreviewCreateParamsProtocol.Https)]
    public void SerializationRoundtrip_Works(PreviewPreviewCreateParamsProtocol rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewPreviewCreateParamsProtocol> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreviewPreviewCreateParamsProtocol>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewPreviewCreateParamsProtocol>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreviewPreviewCreateParamsProtocol>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PreviewPreviewCreateParamsVisibilityTest : TestBase
{
    [Theory]
    [InlineData(PreviewPreviewCreateParamsVisibility.Public)]
    [InlineData(PreviewPreviewCreateParamsVisibility.Private)]
    [InlineData(PreviewPreviewCreateParamsVisibility.Org)]
    public void Validation_Works(PreviewPreviewCreateParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewPreviewCreateParamsVisibility> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreviewPreviewCreateParamsVisibility>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreviewPreviewCreateParamsVisibility.Public)]
    [InlineData(PreviewPreviewCreateParamsVisibility.Private)]
    [InlineData(PreviewPreviewCreateParamsVisibility.Org)]
    public void SerializationRoundtrip_Works(PreviewPreviewCreateParamsVisibility rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewPreviewCreateParamsVisibility> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreviewPreviewCreateParamsVisibility>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreviewPreviewCreateParamsVisibility>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreviewPreviewCreateParamsVisibility>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Ssh;

namespace Dedalus.Tests.Models.Machines.Ssh;

public class SshHostTrustTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SshHostTrust
        {
            HostPattern = "host_pattern",
            Kind = Kind.CertAuthority,
            PublicKey = "public_key",
        };

        string expectedHostPattern = "host_pattern";
        ApiEnum<string, Kind> expectedKind = Kind.CertAuthority;
        string expectedPublicKey = "public_key";

        Assert.Equal(expectedHostPattern, model.HostPattern);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedPublicKey, model.PublicKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SshHostTrust
        {
            HostPattern = "host_pattern",
            Kind = Kind.CertAuthority,
            PublicKey = "public_key",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SshHostTrust>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SshHostTrust
        {
            HostPattern = "host_pattern",
            Kind = Kind.CertAuthority,
            PublicKey = "public_key",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SshHostTrust>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedHostPattern = "host_pattern";
        ApiEnum<string, Kind> expectedKind = Kind.CertAuthority;
        string expectedPublicKey = "public_key";

        Assert.Equal(expectedHostPattern, deserialized.HostPattern);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedPublicKey, deserialized.PublicKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SshHostTrust
        {
            HostPattern = "host_pattern",
            Kind = Kind.CertAuthority,
            PublicKey = "public_key",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SshHostTrust
        {
            HostPattern = "host_pattern",
            Kind = Kind.CertAuthority,
            PublicKey = "public_key",
        };

        SshHostTrust copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class KindTest : TestBase
{
    [Theory]
    [InlineData(Kind.CertAuthority)]
    public void Validation_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Kind.CertAuthority)]
    public void SerializationRoundtrip_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Ssh;

namespace Dedalus.Tests.Models.Machines.Ssh;

public class SshConnectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SshConnection
        {
            Endpoint = "endpoint",
            Port = 0,
            SshUsername = "ssh_username",
            HostTrust = new()
            {
                HostPattern = "host_pattern",
                Kind = Kind.CertAuthority,
                PublicKey = "public_key",
            },
            UserCertificate = "user_certificate",
        };

        string expectedEndpoint = "endpoint";
        long expectedPort = 0;
        string expectedSshUsername = "ssh_username";
        SshHostTrust expectedHostTrust = new()
        {
            HostPattern = "host_pattern",
            Kind = Kind.CertAuthority,
            PublicKey = "public_key",
        };
        string expectedUserCertificate = "user_certificate";

        Assert.Equal(expectedEndpoint, model.Endpoint);
        Assert.Equal(expectedPort, model.Port);
        Assert.Equal(expectedSshUsername, model.SshUsername);
        Assert.Equal(expectedHostTrust, model.HostTrust);
        Assert.Equal(expectedUserCertificate, model.UserCertificate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SshConnection
        {
            Endpoint = "endpoint",
            Port = 0,
            SshUsername = "ssh_username",
            HostTrust = new()
            {
                HostPattern = "host_pattern",
                Kind = Kind.CertAuthority,
                PublicKey = "public_key",
            },
            UserCertificate = "user_certificate",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SshConnection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SshConnection
        {
            Endpoint = "endpoint",
            Port = 0,
            SshUsername = "ssh_username",
            HostTrust = new()
            {
                HostPattern = "host_pattern",
                Kind = Kind.CertAuthority,
                PublicKey = "public_key",
            },
            UserCertificate = "user_certificate",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SshConnection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEndpoint = "endpoint";
        long expectedPort = 0;
        string expectedSshUsername = "ssh_username";
        SshHostTrust expectedHostTrust = new()
        {
            HostPattern = "host_pattern",
            Kind = Kind.CertAuthority,
            PublicKey = "public_key",
        };
        string expectedUserCertificate = "user_certificate";

        Assert.Equal(expectedEndpoint, deserialized.Endpoint);
        Assert.Equal(expectedPort, deserialized.Port);
        Assert.Equal(expectedSshUsername, deserialized.SshUsername);
        Assert.Equal(expectedHostTrust, deserialized.HostTrust);
        Assert.Equal(expectedUserCertificate, deserialized.UserCertificate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SshConnection
        {
            Endpoint = "endpoint",
            Port = 0,
            SshUsername = "ssh_username",
            HostTrust = new()
            {
                HostPattern = "host_pattern",
                Kind = Kind.CertAuthority,
                PublicKey = "public_key",
            },
            UserCertificate = "user_certificate",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SshConnection
        {
            Endpoint = "endpoint",
            Port = 0,
            SshUsername = "ssh_username",
        };

        Assert.Null(model.HostTrust);
        Assert.False(model.RawData.ContainsKey("host_trust"));
        Assert.Null(model.UserCertificate);
        Assert.False(model.RawData.ContainsKey("user_certificate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SshConnection
        {
            Endpoint = "endpoint",
            Port = 0,
            SshUsername = "ssh_username",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SshConnection
        {
            Endpoint = "endpoint",
            Port = 0,
            SshUsername = "ssh_username",

            // Null should be interpreted as omitted for these properties
            HostTrust = null,
            UserCertificate = null,
        };

        Assert.Null(model.HostTrust);
        Assert.False(model.RawData.ContainsKey("host_trust"));
        Assert.Null(model.UserCertificate);
        Assert.False(model.RawData.ContainsKey("user_certificate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SshConnection
        {
            Endpoint = "endpoint",
            Port = 0,
            SshUsername = "ssh_username",

            // Null should be interpreted as omitted for these properties
            HostTrust = null,
            UserCertificate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SshConnection
        {
            Endpoint = "endpoint",
            Port = 0,
            SshUsername = "ssh_username",
            HostTrust = new()
            {
                HostPattern = "host_pattern",
                Kind = Kind.CertAuthority,
                PublicKey = "public_key",
            },
            UserCertificate = "user_certificate",
        };

        SshConnection copied = new(model);

        Assert.Equal(model, copied);
    }
}

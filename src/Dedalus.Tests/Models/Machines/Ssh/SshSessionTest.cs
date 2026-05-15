using System;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines.Ssh;

namespace Dedalus.Tests.Models.Machines.Ssh;

public class SshSessionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SshSession
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            SessionID = "session_id",
            Status = Status.WakeInProgress,
            Connection = new()
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
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMachineID = "machine_id";
        string expectedSessionID = "session_id";
        ApiEnum<string, Status> expectedStatus = Status.WakeInProgress;
        SshConnection expectedConnection = new()
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
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRetryAfterMs = 0;

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMachineID, model.MachineID);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedConnection, model.Connection);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedReadyAt, model.ReadyAt);
        Assert.Equal(expectedRetryAfterMs, model.RetryAfterMs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SshSession
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            SessionID = "session_id",
            Status = Status.WakeInProgress,
            Connection = new()
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
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SshSession>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SshSession
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            SessionID = "session_id",
            Status = Status.WakeInProgress,
            Connection = new()
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
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SshSession>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedMachineID = "machine_id";
        string expectedSessionID = "session_id";
        ApiEnum<string, Status> expectedStatus = Status.WakeInProgress;
        SshConnection expectedConnection = new()
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
        string expectedErrorCode = "error_code";
        string expectedErrorMessage = "error_message";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedRetryAfterMs = 0;

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMachineID, deserialized.MachineID);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedConnection, deserialized.Connection);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedReadyAt, deserialized.ReadyAt);
        Assert.Equal(expectedRetryAfterMs, deserialized.RetryAfterMs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SshSession
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            SessionID = "session_id",
            Status = Status.WakeInProgress,
            Connection = new()
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
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SshSession
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            SessionID = "session_id",
            Status = Status.WakeInProgress,
        };

        Assert.Null(model.Connection);
        Assert.False(model.RawData.ContainsKey("connection"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.ReadyAt);
        Assert.False(model.RawData.ContainsKey("ready_at"));
        Assert.Null(model.RetryAfterMs);
        Assert.False(model.RawData.ContainsKey("retry_after_ms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SshSession
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            SessionID = "session_id",
            Status = Status.WakeInProgress,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SshSession
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            SessionID = "session_id",
            Status = Status.WakeInProgress,

            // Null should be interpreted as omitted for these properties
            Connection = null,
            ErrorCode = null,
            ErrorMessage = null,
            ExpiresAt = null,
            ReadyAt = null,
            RetryAfterMs = null,
        };

        Assert.Null(model.Connection);
        Assert.False(model.RawData.ContainsKey("connection"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("error_code"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.ReadyAt);
        Assert.False(model.RawData.ContainsKey("ready_at"));
        Assert.Null(model.RetryAfterMs);
        Assert.False(model.RawData.ContainsKey("retry_after_ms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SshSession
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            SessionID = "session_id",
            Status = Status.WakeInProgress,

            // Null should be interpreted as omitted for these properties
            Connection = null,
            ErrorCode = null,
            ErrorMessage = null,
            ExpiresAt = null,
            ReadyAt = null,
            RetryAfterMs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SshSession
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MachineID = "machine_id",
            SessionID = "session_id",
            Status = Status.WakeInProgress,
            Connection = new()
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
            },
            ErrorCode = "error_code",
            ErrorMessage = "error_message",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReadyAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RetryAfterMs = 0,
        };

        SshSession copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.WakeInProgress)]
    [InlineData(Status.Ready)]
    [InlineData(Status.Closed)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.WakeInProgress)]
    [InlineData(Status.Ready)]
    [InlineData(Status.Closed)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

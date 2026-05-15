using System;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Exceptions;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class LifecycleStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LifecycleStatus
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",
            LastError = "last_error",
        };

        DateTimeOffset expectedLastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Phase> expectedPhase = Phase.Accepted;
        string expectedReason = "reason";
        bool expectedRetryable = true;
        string expectedRevision = "revision";
        string expectedLastError = "last_error";

        Assert.Equal(expectedLastProgressAt, model.LastProgressAt);
        Assert.Equal(expectedLastTransitionAt, model.LastTransitionAt);
        Assert.Equal(expectedPhase, model.Phase);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRetryable, model.Retryable);
        Assert.Equal(expectedRevision, model.Revision);
        Assert.Equal(expectedLastError, model.LastError);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LifecycleStatus
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",
            LastError = "last_error",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LifecycleStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LifecycleStatus
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",
            LastError = "last_error",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LifecycleStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedLastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Phase> expectedPhase = Phase.Accepted;
        string expectedReason = "reason";
        bool expectedRetryable = true;
        string expectedRevision = "revision";
        string expectedLastError = "last_error";

        Assert.Equal(expectedLastProgressAt, deserialized.LastProgressAt);
        Assert.Equal(expectedLastTransitionAt, deserialized.LastTransitionAt);
        Assert.Equal(expectedPhase, deserialized.Phase);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRetryable, deserialized.Retryable);
        Assert.Equal(expectedRevision, deserialized.Revision);
        Assert.Equal(expectedLastError, deserialized.LastError);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LifecycleStatus
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",
            LastError = "last_error",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LifecycleStatus
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",
        };

        Assert.Null(model.LastError);
        Assert.False(model.RawData.ContainsKey("last_error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LifecycleStatus
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LifecycleStatus
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",

            // Null should be interpreted as omitted for these properties
            LastError = null,
        };

        Assert.Null(model.LastError);
        Assert.False(model.RawData.ContainsKey("last_error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LifecycleStatus
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",

            // Null should be interpreted as omitted for these properties
            LastError = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LifecycleStatus
        {
            LastProgressAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastTransitionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Phase = Phase.Accepted,
            Reason = "reason",
            Retryable = true,
            Revision = "revision",
            LastError = "last_error",
        };

        LifecycleStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhaseTest : TestBase
{
    [Theory]
    [InlineData(Phase.Accepted)]
    [InlineData(Phase.PlacementPending)]
    [InlineData(Phase.Starting)]
    [InlineData(Phase.Running)]
    [InlineData(Phase.Stopping)]
    [InlineData(Phase.Sleeping)]
    [InlineData(Phase.Destroying)]
    [InlineData(Phase.Destroyed)]
    [InlineData(Phase.Failed)]
    public void Validation_Works(Phase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Phase> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Phase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DedalusInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Phase.Accepted)]
    [InlineData(Phase.PlacementPending)]
    [InlineData(Phase.Starting)]
    [InlineData(Phase.Running)]
    [InlineData(Phase.Stopping)]
    [InlineData(Phase.Sleeping)]
    [InlineData(Phase.Destroying)]
    [InlineData(Phase.Destroyed)]
    [InlineData(Phase.Failed)]
    public void SerializationRoundtrip_Works(Phase rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Phase> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Phase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Phase>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Phase>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

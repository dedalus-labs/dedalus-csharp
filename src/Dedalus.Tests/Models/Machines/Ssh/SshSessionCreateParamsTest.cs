using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines.Ssh;

namespace Dedalus.Tests.Models.Machines.Ssh;

public class SshSessionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SshSessionCreateParams { PublicKey = "public_key" };

        string expectedPublicKey = "public_key";

        Assert.Equal(expectedPublicKey, model.PublicKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SshSessionCreateParams { PublicKey = "public_key" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SshSessionCreateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SshSessionCreateParams { PublicKey = "public_key" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SshSessionCreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPublicKey = "public_key";

        Assert.Equal(expectedPublicKey, deserialized.PublicKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SshSessionCreateParams { PublicKey = "public_key" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SshSessionCreateParams { PublicKey = "public_key" };

        SshSessionCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;

namespace Dedalus.Models.Machines.Previews;

[JsonConverter(
    typeof(JsonModelConverter<PreviewPreviewCreateParams, PreviewPreviewCreateParamsFromRaw>)
)]
public sealed record class PreviewPreviewCreateParams : JsonModel
{
    public required long Port
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("port");
        }
        init { this._rawData.Set("port", value); }
    }

    public ApiEnum<string, PreviewPreviewCreateParamsProtocol>? Protocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PreviewPreviewCreateParamsProtocol>
            >("protocol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("protocol", value);
        }
    }

    public ApiEnum<string, PreviewPreviewCreateParamsVisibility>? Visibility
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PreviewPreviewCreateParamsVisibility>
            >("visibility");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("visibility", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Port;
        this.Protocol?.Validate();
        this.Visibility?.Validate();
    }

    public PreviewPreviewCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviewPreviewCreateParams(PreviewPreviewCreateParams previewPreviewCreateParams)
        : base(previewPreviewCreateParams) { }
#pragma warning restore CS8618

    public PreviewPreviewCreateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviewPreviewCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviewPreviewCreateParamsFromRaw.FromRawUnchecked"/>
    public static PreviewPreviewCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreviewPreviewCreateParams(long port)
        : this()
    {
        this.Port = port;
    }
}

class PreviewPreviewCreateParamsFromRaw : IFromRawJson<PreviewPreviewCreateParams>
{
    /// <inheritdoc/>
    public PreviewPreviewCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreviewPreviewCreateParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PreviewPreviewCreateParamsProtocolConverter))]
public enum PreviewPreviewCreateParamsProtocol
{
    Http,
    Https,
}

sealed class PreviewPreviewCreateParamsProtocolConverter
    : JsonConverter<PreviewPreviewCreateParamsProtocol>
{
    public override PreviewPreviewCreateParamsProtocol Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "http" => PreviewPreviewCreateParamsProtocol.Http,
            "https" => PreviewPreviewCreateParamsProtocol.Https,
            _ => (PreviewPreviewCreateParamsProtocol)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviewPreviewCreateParamsProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreviewPreviewCreateParamsProtocol.Http => "http",
                PreviewPreviewCreateParamsProtocol.Https => "https",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(PreviewPreviewCreateParamsVisibilityConverter))]
public enum PreviewPreviewCreateParamsVisibility
{
    Public,
    Private,
    Org,
}

sealed class PreviewPreviewCreateParamsVisibilityConverter
    : JsonConverter<PreviewPreviewCreateParamsVisibility>
{
    public override PreviewPreviewCreateParamsVisibility Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "public" => PreviewPreviewCreateParamsVisibility.Public,
            "private" => PreviewPreviewCreateParamsVisibility.Private,
            "org" => PreviewPreviewCreateParamsVisibility.Org,
            _ => (PreviewPreviewCreateParamsVisibility)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviewPreviewCreateParamsVisibility value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreviewPreviewCreateParamsVisibility.Public => "public",
                PreviewPreviewCreateParamsVisibility.Private => "private",
                PreviewPreviewCreateParamsVisibility.Org => "org",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

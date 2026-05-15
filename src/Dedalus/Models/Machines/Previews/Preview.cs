using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;

namespace Dedalus.Models.Machines.Previews;

[JsonConverter(typeof(JsonModelConverter<Preview, PreviewFromRaw>))]
public sealed record class Preview : JsonModel
{
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string MachineID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("machine_id");
        }
        init { this._rawData.Set("machine_id", value); }
    }

    public required long Port
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("port");
        }
        init { this._rawData.Set("port", value); }
    }

    public required string PreviewID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("preview_id");
        }
        init { this._rawData.Set("preview_id", value); }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<string, PreviewVisibility> Visibility
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreviewVisibility>>("visibility");
        }
        init { this._rawData.Set("visibility", value); }
    }

    public string? ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error_code", value);
        }
    }

    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error_message", value);
        }
    }

    public DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("expires_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expires_at", value);
        }
    }

    public ApiEnum<string, PreviewProtocol>? Protocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PreviewProtocol>>("protocol");
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

    public DateTimeOffset? ReadyAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("ready_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ready_at", value);
        }
    }

    public long? RetryAfterMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("retry_after_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retry_after_ms", value);
        }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.MachineID;
        _ = this.Port;
        _ = this.PreviewID;
        this.Status.Validate();
        this.Visibility.Validate();
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.ExpiresAt;
        this.Protocol?.Validate();
        _ = this.ReadyAt;
        _ = this.RetryAfterMs;
        _ = this.Url;
    }

    public Preview() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Preview(Preview preview)
        : base(preview) { }
#pragma warning restore CS8618

    public Preview(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preview(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviewFromRaw.FromRawUnchecked"/>
    public static Preview FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreviewFromRaw : IFromRawJson<Preview>
{
    /// <inheritdoc/>
    public Preview FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Preview.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    WakeInProgress,
    Ready,
    Closed,
    Expired,
    Failed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wake_in_progress" => Status.WakeInProgress,
            "ready" => Status.Ready,
            "closed" => Status.Closed,
            "expired" => Status.Expired,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.WakeInProgress => "wake_in_progress",
                Status.Ready => "ready",
                Status.Closed => "closed",
                Status.Expired => "expired",
                Status.Failed => "failed",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(PreviewVisibilityConverter))]
public enum PreviewVisibility
{
    Public,
    Private,
    Org,
}

sealed class PreviewVisibilityConverter : JsonConverter<PreviewVisibility>
{
    public override PreviewVisibility Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "public" => PreviewVisibility.Public,
            "private" => PreviewVisibility.Private,
            "org" => PreviewVisibility.Org,
            _ => (PreviewVisibility)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviewVisibility value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreviewVisibility.Public => "public",
                PreviewVisibility.Private => "private",
                PreviewVisibility.Org => "org",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(PreviewProtocolConverter))]
public enum PreviewProtocol
{
    Http,
    Https,
}

sealed class PreviewProtocolConverter : JsonConverter<PreviewProtocol>
{
    public override PreviewProtocol Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "http" => PreviewProtocol.Http,
            "https" => PreviewProtocol.Https,
            _ => (PreviewProtocol)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviewProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreviewProtocol.Http => "http",
                PreviewProtocol.Https => "https",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

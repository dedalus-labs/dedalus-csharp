using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(typeof(JsonModelConverter<Terminal, TerminalFromRaw>))]
public sealed record class Terminal : JsonModel
{
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required long Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("height");
        }
        init { this._rawData.Set("height", value); }
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

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string TerminalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("terminal_id");
        }
        init { this._rawData.Set("terminal_id", value); }
    }

    public required long Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
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

    public System::DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expires_at");
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

    public ApiEnum<string, Protocol>? Protocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Protocol>>("protocol");
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

    public System::DateTimeOffset? ReadyAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("ready_at");
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

    public string? StreamUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stream_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stream_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Height;
        _ = this.MachineID;
        this.Status.Validate();
        _ = this.TerminalID;
        _ = this.Width;
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.ExpiresAt;
        this.Protocol?.Validate();
        _ = this.ReadyAt;
        _ = this.RetryAfterMs;
        _ = this.StreamUrl;
    }

    public Terminal() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Terminal(Terminal terminal)
        : base(terminal) { }
#pragma warning restore CS8618

    public Terminal(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Terminal(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TerminalFromRaw.FromRawUnchecked"/>
    public static Terminal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TerminalFromRaw : IFromRawJson<Terminal>
{
    /// <inheritdoc/>
    public Terminal FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Terminal.FromRawUnchecked(rawData);
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
        System::Type typeToConvert,
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

[JsonConverter(typeof(ProtocolConverter))]
public enum Protocol
{
    Websocket,
}

sealed class ProtocolConverter : JsonConverter<Protocol>
{
    public override Protocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "websocket" => Protocol.Websocket,
            _ => (Protocol)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Protocol value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Protocol.Websocket => "websocket",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

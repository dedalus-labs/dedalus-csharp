using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;

namespace Dedalus.Models.Machines.Ssh;

[JsonConverter(typeof(JsonModelConverter<SshSession, SshSessionFromRaw>))]
public sealed record class SshSession : JsonModel
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

    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
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

    public SshConnection? Connection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SshConnection>("connection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connection", value);
        }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.MachineID;
        _ = this.SessionID;
        this.Status.Validate();
        this.Connection?.Validate();
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.ExpiresAt;
        _ = this.ReadyAt;
        _ = this.RetryAfterMs;
    }

    public SshSession() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SshSession(SshSession sshSession)
        : base(sshSession) { }
#pragma warning restore CS8618

    public SshSession(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SshSession(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SshSessionFromRaw.FromRawUnchecked"/>
    public static SshSession FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SshSessionFromRaw : IFromRawJson<SshSession>
{
    /// <inheritdoc/>
    public SshSession FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SshSession.FromRawUnchecked(rawData);
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

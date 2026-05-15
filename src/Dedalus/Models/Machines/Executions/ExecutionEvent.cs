using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Executions;

[JsonConverter(typeof(JsonModelConverter<ExecutionEvent, ExecutionEventFromRaw>))]
public sealed record class ExecutionEvent : JsonModel
{
    public required System::DateTimeOffset At
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("at");
        }
        init { this._rawData.Set("at", value); }
    }

    public required long Sequence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sequence");
        }
        init { this._rawData.Set("sequence", value); }
    }

    public required ApiEnum<string, global::Dedalus.Models.Machines.Executions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Dedalus.Models.Machines.Executions.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? Chunk
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("chunk");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk", value);
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

    public long? ExitCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("exit_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("exit_code", value);
        }
    }

    public long? Signal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("signal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signal", value);
        }
    }

    public ApiEnum<string, ExecutionEventStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExecutionEventStatus>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.At;
        _ = this.Sequence;
        this.Type.Validate();
        _ = this.Chunk;
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.ExitCode;
        _ = this.Signal;
        this.Status?.Validate();
    }

    public ExecutionEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionEvent(ExecutionEvent executionEvent)
        : base(executionEvent) { }
#pragma warning restore CS8618

    public ExecutionEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionEventFromRaw.FromRawUnchecked"/>
    public static ExecutionEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExecutionEventFromRaw : IFromRawJson<ExecutionEvent>
{
    /// <inheritdoc/>
    public ExecutionEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExecutionEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Lifecycle,
    Stdout,
    Stderr,
}

sealed class TypeConverter : JsonConverter<global::Dedalus.Models.Machines.Executions.Type>
{
    public override global::Dedalus.Models.Machines.Executions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "lifecycle" => global::Dedalus.Models.Machines.Executions.Type.Lifecycle,
            "stdout" => global::Dedalus.Models.Machines.Executions.Type.Stdout,
            "stderr" => global::Dedalus.Models.Machines.Executions.Type.Stderr,
            _ => (global::Dedalus.Models.Machines.Executions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Dedalus.Models.Machines.Executions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Dedalus.Models.Machines.Executions.Type.Lifecycle => "lifecycle",
                global::Dedalus.Models.Machines.Executions.Type.Stdout => "stdout",
                global::Dedalus.Models.Machines.Executions.Type.Stderr => "stderr",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ExecutionEventStatusConverter))]
public enum ExecutionEventStatus
{
    WakeInProgress,
    Queued,
    Running,
    Succeeded,
    Failed,
    Cancelled,
    Expired,
}

sealed class ExecutionEventStatusConverter : JsonConverter<ExecutionEventStatus>
{
    public override ExecutionEventStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "wake_in_progress" => ExecutionEventStatus.WakeInProgress,
            "queued" => ExecutionEventStatus.Queued,
            "running" => ExecutionEventStatus.Running,
            "succeeded" => ExecutionEventStatus.Succeeded,
            "failed" => ExecutionEventStatus.Failed,
            "cancelled" => ExecutionEventStatus.Cancelled,
            "expired" => ExecutionEventStatus.Expired,
            _ => (ExecutionEventStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExecutionEventStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExecutionEventStatus.WakeInProgress => "wake_in_progress",
                ExecutionEventStatus.Queued => "queued",
                ExecutionEventStatus.Running => "running",
                ExecutionEventStatus.Succeeded => "succeeded",
                ExecutionEventStatus.Failed => "failed",
                ExecutionEventStatus.Cancelled => "cancelled",
                ExecutionEventStatus.Expired => "expired",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

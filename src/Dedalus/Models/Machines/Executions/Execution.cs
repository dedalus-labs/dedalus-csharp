using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Executions;

[JsonConverter(typeof(JsonModelConverter<Execution, ExecutionFromRaw>))]
public sealed record class Execution : JsonModel
{
    public required IReadOnlyList<string>? Command
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("command");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "command",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string ExecutionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("execution_id");
        }
        init { this._rawData.Set("execution_id", value); }
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

    public IReadOnlyList<ArtifactRef>? Artifacts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ArtifactRef>>("artifacts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ArtifactRef>?>(
                "artifacts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public System::DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("completed_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("completed_at", value);
        }
    }

    public string? Cwd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cwd");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cwd", value);
        }
    }

    public IReadOnlyList<string>? EnvKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("env_keys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "env_keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public System::DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("started_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("started_at", value);
        }
    }

    public long? StderrBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("stderr_bytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stderr_bytes", value);
        }
    }

    public bool? StderrTruncated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("stderr_truncated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stderr_truncated", value);
        }
    }

    public long? StdoutBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("stdout_bytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stdout_bytes", value);
        }
    }

    public bool? StdoutTruncated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("stdout_truncated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stdout_truncated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Command;
        _ = this.CreatedAt;
        _ = this.ExecutionID;
        _ = this.MachineID;
        this.Status.Validate();
        foreach (var item in this.Artifacts ?? [])
        {
            item.Validate();
        }
        _ = this.CompletedAt;
        _ = this.Cwd;
        _ = this.EnvKeys;
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.ExitCode;
        _ = this.ExpiresAt;
        _ = this.RetryAfterMs;
        _ = this.Signal;
        _ = this.StartedAt;
        _ = this.StderrBytes;
        _ = this.StderrTruncated;
        _ = this.StdoutBytes;
        _ = this.StdoutTruncated;
    }

    public Execution() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Execution(Execution execution)
        : base(execution) { }
#pragma warning restore CS8618

    public Execution(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Execution(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionFromRaw.FromRawUnchecked"/>
    public static Execution FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExecutionFromRaw : IFromRawJson<Execution>
{
    /// <inheritdoc/>
    public Execution FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Execution.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    WakeInProgress,
    Queued,
    Running,
    Succeeded,
    Failed,
    Cancelled,
    Expired,
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
            "queued" => Status.Queued,
            "running" => Status.Running,
            "succeeded" => Status.Succeeded,
            "failed" => Status.Failed,
            "cancelled" => Status.Cancelled,
            "expired" => Status.Expired,
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
                Status.Queued => "queued",
                Status.Running => "running",
                Status.Succeeded => "succeeded",
                Status.Failed => "failed",
                Status.Cancelled => "cancelled",
                Status.Expired => "expired",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

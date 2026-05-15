using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;

namespace Dedalus.Models.Machines;

[JsonConverter(typeof(JsonModelConverter<LifecycleStatus, LifecycleStatusFromRaw>))]
public sealed record class LifecycleStatus : JsonModel
{
    public required DateTimeOffset LastProgressAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("last_progress_at");
        }
        init { this._rawData.Set("last_progress_at", value); }
    }

    public required DateTimeOffset LastTransitionAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("last_transition_at");
        }
        init { this._rawData.Set("last_transition_at", value); }
    }

    public required ApiEnum<string, Phase> Phase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Phase>>("phase");
        }
        init { this._rawData.Set("phase", value); }
    }

    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    public required bool Retryable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("retryable");
        }
        init { this._rawData.Set("retryable", value); }
    }

    public required string Revision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("revision");
        }
        init { this._rawData.Set("revision", value); }
    }

    public string? LastError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("last_error", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LastProgressAt;
        _ = this.LastTransitionAt;
        this.Phase.Validate();
        _ = this.Reason;
        _ = this.Retryable;
        _ = this.Revision;
        _ = this.LastError;
    }

    public LifecycleStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LifecycleStatus(LifecycleStatus lifecycleStatus)
        : base(lifecycleStatus) { }
#pragma warning restore CS8618

    public LifecycleStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LifecycleStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LifecycleStatusFromRaw.FromRawUnchecked"/>
    public static LifecycleStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LifecycleStatusFromRaw : IFromRawJson<LifecycleStatus>
{
    /// <inheritdoc/>
    public LifecycleStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LifecycleStatus.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PhaseConverter))]
public enum Phase
{
    Accepted,
    PlacementPending,
    Starting,
    Running,
    Stopping,
    Sleeping,
    Destroying,
    Destroyed,
    Failed,
}

sealed class PhaseConverter : JsonConverter<Phase>
{
    public override Phase Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => Phase.Accepted,
            "placement_pending" => Phase.PlacementPending,
            "starting" => Phase.Starting,
            "running" => Phase.Running,
            "stopping" => Phase.Stopping,
            "sleeping" => Phase.Sleeping,
            "destroying" => Phase.Destroying,
            "destroyed" => Phase.Destroyed,
            "failed" => Phase.Failed,
            _ => (Phase)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Phase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Phase.Accepted => "accepted",
                Phase.PlacementPending => "placement_pending",
                Phase.Starting => "starting",
                Phase.Running => "running",
                Phase.Stopping => "stopping",
                Phase.Sleeping => "sleeping",
                Phase.Destroying => "destroying",
                Phase.Destroyed => "destroyed",
                Phase.Failed => "failed",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;

namespace Dedalus.Models.Machines;

[JsonConverter(typeof(JsonModelConverter<Machine, MachineFromRaw>))]
public sealed record class Machine : JsonModel
{
    /// <summary>
    /// Seconds of inactivity before autosleep. 0 disables autosleep.
    /// </summary>
    public required long AutosleepSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("autosleep_seconds");
        }
        init { this._rawData.Set("autosleep_seconds", value); }
    }

    public required ApiEnum<string, DesiredState> DesiredState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DesiredState>>("desired_state");
        }
        init { this._rawData.Set("desired_state", value); }
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

    /// <summary>
    /// Memory in MiB.
    /// </summary>
    public required long MemoryMiB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("memory_mib");
        }
        init { this._rawData.Set("memory_mib", value); }
    }

    public required ApiEnum<string, MachinePhase> Phase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MachinePhase>>("phase");
        }
        init { this._rawData.Set("phase", value); }
    }

    public required long StorageGiB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("storage_gib");
        }
        init { this._rawData.Set("storage_gib", value); }
    }

    /// <summary>
    /// CPU in vCPUs.
    /// </summary>
    public required double Vcpu
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("vcpu");
        }
        init { this._rawData.Set("vcpu", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AutosleepSeconds;
        this.DesiredState.Validate();
        _ = this.MachineID;
        _ = this.MemoryMiB;
        this.Phase.Validate();
        _ = this.StorageGiB;
        _ = this.Vcpu;
    }

    public Machine() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Machine(Machine machine)
        : base(machine) { }
#pragma warning restore CS8618

    public Machine(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Machine(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MachineFromRaw.FromRawUnchecked"/>
    public static Machine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MachineFromRaw : IFromRawJson<Machine>
{
    /// <inheritdoc/>
    public Machine FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Machine.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DesiredStateConverter))]
public enum DesiredState
{
    Running,
    Sleeping,
    Destroyed,
}

sealed class DesiredStateConverter : JsonConverter<DesiredState>
{
    public override DesiredState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => DesiredState.Running,
            "sleeping" => DesiredState.Sleeping,
            "destroyed" => DesiredState.Destroyed,
            _ => (DesiredState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DesiredState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DesiredState.Running => "running",
                DesiredState.Sleeping => "sleeping",
                DesiredState.Destroyed => "destroyed",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(MachinePhaseConverter))]
public enum MachinePhase
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

sealed class MachinePhaseConverter : JsonConverter<MachinePhase>
{
    public override MachinePhase Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => MachinePhase.Accepted,
            "placement_pending" => MachinePhase.PlacementPending,
            "starting" => MachinePhase.Starting,
            "running" => MachinePhase.Running,
            "stopping" => MachinePhase.Stopping,
            "sleeping" => MachinePhase.Sleeping,
            "destroying" => MachinePhase.Destroying,
            "destroyed" => MachinePhase.Destroyed,
            "failed" => MachinePhase.Failed,
            _ => (MachinePhase)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MachinePhase value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MachinePhase.Accepted => "accepted",
                MachinePhase.PlacementPending => "placement_pending",
                MachinePhase.Starting => "starting",
                MachinePhase.Running => "running",
                MachinePhase.Stopping => "stopping",
                MachinePhase.Sleeping => "sleeping",
                MachinePhase.Destroying => "destroying",
                MachinePhase.Destroyed => "destroyed",
                MachinePhase.Failed => "failed",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

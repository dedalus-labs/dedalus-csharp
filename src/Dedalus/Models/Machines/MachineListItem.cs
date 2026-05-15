using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;

namespace Dedalus.Models.Machines;

[JsonConverter(typeof(JsonModelConverter<MachineListItem, MachineListItemFromRaw>))]
public sealed record class MachineListItem : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required ApiEnum<string, MachineListItemDesiredState> DesiredState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MachineListItemDesiredState>>(
                "desired_state"
            );
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

    public required LifecycleStatus Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LifecycleStatus>("status");
        }
        init { this._rawData.Set("status", value); }
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
        _ = this.CreatedAt;
        this.DesiredState.Validate();
        _ = this.MachineID;
        _ = this.MemoryMiB;
        this.Status.Validate();
        _ = this.StorageGiB;
        _ = this.Vcpu;
    }

    public MachineListItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachineListItem(MachineListItem machineListItem)
        : base(machineListItem) { }
#pragma warning restore CS8618

    public MachineListItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MachineListItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MachineListItemFromRaw.FromRawUnchecked"/>
    public static MachineListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MachineListItemFromRaw : IFromRawJson<MachineListItem>
{
    /// <inheritdoc/>
    public MachineListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MachineListItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MachineListItemDesiredStateConverter))]
public enum MachineListItemDesiredState
{
    Running,
    Sleeping,
    Destroyed,
}

sealed class MachineListItemDesiredStateConverter : JsonConverter<MachineListItemDesiredState>
{
    public override MachineListItemDesiredState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => MachineListItemDesiredState.Running,
            "sleeping" => MachineListItemDesiredState.Sleeping,
            "destroyed" => MachineListItemDesiredState.Destroyed,
            _ => (MachineListItemDesiredState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MachineListItemDesiredState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MachineListItemDesiredState.Running => "running",
                MachineListItemDesiredState.Sleeping => "sleeping",
                MachineListItemDesiredState.Destroyed => "destroyed",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

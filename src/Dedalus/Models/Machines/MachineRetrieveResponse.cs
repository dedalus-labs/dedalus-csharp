using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;

namespace Dedalus.Models.Machines;

[JsonConverter(typeof(JsonModelConverter<MachineRetrieveResponse, MachineRetrieveResponseFromRaw>))]
public sealed record class MachineRetrieveResponse : JsonModel
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

    public required ApiEnum<string, MachineRetrieveResponseDesiredState> DesiredState
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MachineRetrieveResponseDesiredState>
            >("desired_state");
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
        this.DesiredState.Validate();
        _ = this.MachineID;
        _ = this.MemoryMiB;
        this.Status.Validate();
        _ = this.StorageGiB;
        _ = this.Vcpu;
    }

    public MachineRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MachineRetrieveResponse(MachineRetrieveResponse machineRetrieveResponse)
        : base(machineRetrieveResponse) { }
#pragma warning restore CS8618

    public MachineRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MachineRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MachineRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MachineRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MachineRetrieveResponseFromRaw : IFromRawJson<MachineRetrieveResponse>
{
    /// <inheritdoc/>
    public MachineRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MachineRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MachineRetrieveResponseDesiredStateConverter))]
public enum MachineRetrieveResponseDesiredState
{
    Running,
    Sleeping,
    Destroyed,
}

sealed class MachineRetrieveResponseDesiredStateConverter
    : JsonConverter<MachineRetrieveResponseDesiredState>
{
    public override MachineRetrieveResponseDesiredState Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "running" => MachineRetrieveResponseDesiredState.Running,
            "sleeping" => MachineRetrieveResponseDesiredState.Sleeping,
            "destroyed" => MachineRetrieveResponseDesiredState.Destroyed,
            _ => (MachineRetrieveResponseDesiredState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MachineRetrieveResponseDesiredState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MachineRetrieveResponseDesiredState.Running => "running",
                MachineRetrieveResponseDesiredState.Sleeping => "sleeping",
                MachineRetrieveResponseDesiredState.Destroyed => "destroyed",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

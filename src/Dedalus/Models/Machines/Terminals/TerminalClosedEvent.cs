using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(typeof(JsonModelConverter<TerminalClosedEvent, TerminalClosedEventFromRaw>))]
public sealed record class TerminalClosedEvent : JsonModel
{
    public required ApiEnum<string, global::Dedalus.Models.Machines.Terminals.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Dedalus.Models.Machines.Terminals.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public TerminalClosedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TerminalClosedEvent(TerminalClosedEvent terminalClosedEvent)
        : base(terminalClosedEvent) { }
#pragma warning restore CS8618

    public TerminalClosedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TerminalClosedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TerminalClosedEventFromRaw.FromRawUnchecked"/>
    public static TerminalClosedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TerminalClosedEvent(ApiEnum<string, global::Dedalus.Models.Machines.Terminals.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class TerminalClosedEventFromRaw : IFromRawJson<TerminalClosedEvent>
{
    /// <inheritdoc/>
    public TerminalClosedEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TerminalClosedEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Closed,
}

sealed class TypeConverter : JsonConverter<global::Dedalus.Models.Machines.Terminals.Type>
{
    public override global::Dedalus.Models.Machines.Terminals.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "closed" => global::Dedalus.Models.Machines.Terminals.Type.Closed,
            _ => (global::Dedalus.Models.Machines.Terminals.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Dedalus.Models.Machines.Terminals.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Dedalus.Models.Machines.Terminals.Type.Closed => "closed",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

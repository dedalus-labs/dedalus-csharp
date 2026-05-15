using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(typeof(JsonModelConverter<TerminalOutputEvent, TerminalOutputEventFromRaw>))]
public sealed record class TerminalOutputEvent : JsonModel
{
    /// <summary>
    /// Base64-encoded terminal output.
    /// </summary>
    public required string Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    public required ApiEnum<string, TerminalOutputEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TerminalOutputEventType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        this.Type.Validate();
    }

    public TerminalOutputEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TerminalOutputEvent(TerminalOutputEvent terminalOutputEvent)
        : base(terminalOutputEvent) { }
#pragma warning restore CS8618

    public TerminalOutputEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TerminalOutputEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TerminalOutputEventFromRaw.FromRawUnchecked"/>
    public static TerminalOutputEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TerminalOutputEventFromRaw : IFromRawJson<TerminalOutputEvent>
{
    /// <inheritdoc/>
    public TerminalOutputEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TerminalOutputEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TerminalOutputEventTypeConverter))]
public enum TerminalOutputEventType
{
    Output,
}

sealed class TerminalOutputEventTypeConverter : JsonConverter<TerminalOutputEventType>
{
    public override TerminalOutputEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "output" => TerminalOutputEventType.Output,
            _ => (TerminalOutputEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TerminalOutputEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TerminalOutputEventType.Output => "output",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

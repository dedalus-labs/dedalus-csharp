using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(typeof(JsonModelConverter<TerminalInputEvent, TerminalInputEventFromRaw>))]
public sealed record class TerminalInputEvent : JsonModel
{
    /// <summary>
    /// Base64-encoded terminal input.
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

    public required ApiEnum<string, TerminalInputEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TerminalInputEventType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        this.Type.Validate();
    }

    public TerminalInputEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TerminalInputEvent(TerminalInputEvent terminalInputEvent)
        : base(terminalInputEvent) { }
#pragma warning restore CS8618

    public TerminalInputEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TerminalInputEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TerminalInputEventFromRaw.FromRawUnchecked"/>
    public static TerminalInputEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TerminalInputEventFromRaw : IFromRawJson<TerminalInputEvent>
{
    /// <inheritdoc/>
    public TerminalInputEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TerminalInputEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TerminalInputEventTypeConverter))]
public enum TerminalInputEventType
{
    Input,
}

sealed class TerminalInputEventTypeConverter : JsonConverter<TerminalInputEventType>
{
    public override TerminalInputEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "input" => TerminalInputEventType.Input,
            _ => (TerminalInputEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TerminalInputEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TerminalInputEventType.Input => "input",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

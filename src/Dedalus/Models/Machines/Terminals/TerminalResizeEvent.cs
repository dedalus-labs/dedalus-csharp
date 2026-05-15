using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(typeof(JsonModelConverter<TerminalResizeEvent, TerminalResizeEventFromRaw>))]
public sealed record class TerminalResizeEvent : JsonModel
{
    public required long Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("height");
        }
        init { this._rawData.Set("height", value); }
    }

    public required ApiEnum<string, TerminalResizeEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TerminalResizeEventType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required long Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        this.Type.Validate();
        _ = this.Width;
    }

    public TerminalResizeEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TerminalResizeEvent(TerminalResizeEvent terminalResizeEvent)
        : base(terminalResizeEvent) { }
#pragma warning restore CS8618

    public TerminalResizeEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TerminalResizeEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TerminalResizeEventFromRaw.FromRawUnchecked"/>
    public static TerminalResizeEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TerminalResizeEventFromRaw : IFromRawJson<TerminalResizeEvent>
{
    /// <inheritdoc/>
    public TerminalResizeEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TerminalResizeEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TerminalResizeEventTypeConverter))]
public enum TerminalResizeEventType
{
    Resize,
}

sealed class TerminalResizeEventTypeConverter : JsonConverter<TerminalResizeEventType>
{
    public override TerminalResizeEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "resize" => TerminalResizeEventType.Resize,
            _ => (TerminalResizeEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TerminalResizeEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TerminalResizeEventType.Resize => "resize",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(typeof(JsonModelConverter<TerminalErrorEvent, TerminalErrorEventFromRaw>))]
public sealed record class TerminalErrorEvent : JsonModel
{
    public required ApiEnum<string, TerminalErrorEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TerminalErrorEventType>>("type");
        }
        init { this._rawData.Set("type", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
    }

    public TerminalErrorEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TerminalErrorEvent(TerminalErrorEvent terminalErrorEvent)
        : base(terminalErrorEvent) { }
#pragma warning restore CS8618

    public TerminalErrorEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TerminalErrorEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TerminalErrorEventFromRaw.FromRawUnchecked"/>
    public static TerminalErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TerminalErrorEvent(ApiEnum<string, TerminalErrorEventType> type)
        : this()
    {
        this.Type = type;
    }
}

class TerminalErrorEventFromRaw : IFromRawJson<TerminalErrorEvent>
{
    /// <inheritdoc/>
    public TerminalErrorEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TerminalErrorEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TerminalErrorEventTypeConverter))]
public enum TerminalErrorEventType
{
    Error,
}

sealed class TerminalErrorEventTypeConverter : JsonConverter<TerminalErrorEventType>
{
    public override TerminalErrorEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "error" => TerminalErrorEventType.Error,
            _ => (TerminalErrorEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TerminalErrorEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TerminalErrorEventType.Error => "error",
                _ => throw new DedalusInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(typeof(TerminalClientEventConverter))]
public record class TerminalClientEvent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TerminalClientEvent(TerminalInputEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TerminalClientEvent(TerminalResizeEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TerminalClientEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TerminalInputEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInput(out var value)) {
    ///     // `value` is of type `TerminalInputEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInput([NotNullWhen(true)] out TerminalInputEvent? value)
    {
        value = this.Value as TerminalInputEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TerminalResizeEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickResize(out var value)) {
    ///     // `value` is of type `TerminalResizeEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickResize([NotNullWhen(true)] out TerminalResizeEvent? value)
    {
        value = this.Value as TerminalResizeEvent;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="DedalusInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (TerminalInputEvent value) =&gt; {...},
    ///     (TerminalResizeEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TerminalInputEvent> input,
        System::Action<TerminalResizeEvent> resize
    )
    {
        switch (this.Value)
        {
            case TerminalInputEvent value:
                input(value);
                break;
            case TerminalResizeEvent value:
                resize(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of TerminalClientEvent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="DedalusInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (TerminalInputEvent value) =&gt; {...},
    ///     (TerminalResizeEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<TerminalInputEvent, T> input,
        System::Func<TerminalResizeEvent, T> resize
    )
    {
        return this.Value switch
        {
            TerminalInputEvent value => input(value),
            TerminalResizeEvent value => resize(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of TerminalClientEvent"
            ),
        };
    }

    public static implicit operator TerminalClientEvent(TerminalInputEvent value) => new(value);

    public static implicit operator TerminalClientEvent(TerminalResizeEvent value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DedalusInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new DedalusInvalidDataException(
                "Data did not match any variant of TerminalClientEvent"
            );
        }
        this.Switch((input) => input.Validate(), (resize) => resize.Validate());
    }

    public virtual bool Equals(TerminalClientEvent? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            TerminalInputEvent _ => 0,
            TerminalResizeEvent _ => 1,
            _ => -1,
        };
    }
}

sealed class TerminalClientEventConverter : JsonConverter<TerminalClientEvent>
{
    public override TerminalClientEvent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "input":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TerminalInputEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "resize":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TerminalResizeEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new TerminalClientEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TerminalClientEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;
using Dedalus.Exceptions;
using System = System;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(typeof(TerminalServerEventConverter))]
public record class TerminalServerEvent : ModelBase
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

    public TerminalServerEvent(TerminalOutputEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TerminalServerEvent(TerminalErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TerminalServerEvent(TerminalClosedEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TerminalServerEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TerminalOutputEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOutput(out var value)) {
    ///     // `value` is of type `TerminalOutputEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOutput([NotNullWhen(true)] out TerminalOutputEvent? value)
    {
        value = this.Value as TerminalOutputEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TerminalErrorEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickError(out var value)) {
    ///     // `value` is of type `TerminalErrorEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickError([NotNullWhen(true)] out TerminalErrorEvent? value)
    {
        value = this.Value as TerminalErrorEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TerminalClosedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickClosed(out var value)) {
    ///     // `value` is of type `TerminalClosedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickClosed([NotNullWhen(true)] out TerminalClosedEvent? value)
    {
        value = this.Value as TerminalClosedEvent;
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
    ///     (TerminalOutputEvent value) =&gt; {...},
    ///     (TerminalErrorEvent value) =&gt; {...},
    ///     (TerminalClosedEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TerminalOutputEvent> output,
        System::Action<TerminalErrorEvent> error,
        System::Action<TerminalClosedEvent> closed
    )
    {
        switch (this.Value)
        {
            case TerminalOutputEvent value:
                output(value);
                break;
            case TerminalErrorEvent value:
                error(value);
                break;
            case TerminalClosedEvent value:
                closed(value);
                break;
            default:
                throw new DedalusInvalidDataException(
                    "Data did not match any variant of TerminalServerEvent"
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
    ///     (TerminalOutputEvent value) =&gt; {...},
    ///     (TerminalErrorEvent value) =&gt; {...},
    ///     (TerminalClosedEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<TerminalOutputEvent, T> output,
        System::Func<TerminalErrorEvent, T> error,
        System::Func<TerminalClosedEvent, T> closed
    )
    {
        return this.Value switch
        {
            TerminalOutputEvent value => output(value),
            TerminalErrorEvent value => error(value),
            TerminalClosedEvent value => closed(value),
            _ => throw new DedalusInvalidDataException(
                "Data did not match any variant of TerminalServerEvent"
            ),
        };
    }

    public static implicit operator TerminalServerEvent(TerminalOutputEvent value) => new(value);

    public static implicit operator TerminalServerEvent(TerminalErrorEvent value) => new(value);

    public static implicit operator TerminalServerEvent(TerminalClosedEvent value) => new(value);

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
                "Data did not match any variant of TerminalServerEvent"
            );
        }
        this.Switch(
            (output) => output.Validate(),
            (error) => error.Validate(),
            (closed) => closed.Validate()
        );
    }

    public virtual bool Equals(TerminalServerEvent? other) =>
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
            TerminalOutputEvent _ => 0,
            TerminalErrorEvent _ => 1,
            TerminalClosedEvent _ => 2,
            _ => -1,
        };
    }
}

sealed class TerminalServerEventConverter : JsonConverter<TerminalServerEvent>
{
    public override TerminalServerEvent? Read(
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
            case "output":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TerminalOutputEvent>(
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
            case "error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TerminalErrorEvent>(
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
            case "closed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TerminalClosedEvent>(
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
                return new TerminalServerEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TerminalServerEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

using System.Text.Json;
using Dedalus.Exceptions;
using Dedalus.Models.Machines;
using Dedalus.Models.Machines.Previews;
using Executions = Dedalus.Models.Machines.Executions;
using Ssh = Dedalus.Models.Machines.Ssh;
using Terminals = Dedalus.Models.Machines.Terminals;

namespace Dedalus.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Phase>(),
            new ApiEnumConverter<string, DesiredState>(),
            new ApiEnumConverter<string, MachineListItemDesiredState>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, PreviewVisibility>(),
            new ApiEnumConverter<string, PreviewProtocol>(),
            new ApiEnumConverter<string, PreviewPreviewCreateParamsProtocol>(),
            new ApiEnumConverter<string, PreviewPreviewCreateParamsVisibility>(),
            new ApiEnumConverter<string, Protocol>(),
            new ApiEnumConverter<string, Visibility>(),
            new ApiEnumConverter<string, Ssh::Kind>(),
            new ApiEnumConverter<string, Ssh::Status>(),
            new ApiEnumConverter<string, Executions::Status>(),
            new ApiEnumConverter<string, Executions::Type>(),
            new ApiEnumConverter<string, Executions::ExecutionEventStatus>(),
            new ApiEnumConverter<string, Terminals::Status>(),
            new ApiEnumConverter<string, Terminals::Protocol>(),
            new ApiEnumConverter<string, Terminals::Type>(),
            new ApiEnumConverter<string, Terminals::TerminalErrorEventType>(),
            new ApiEnumConverter<string, Terminals::TerminalInputEventType>(),
            new ApiEnumConverter<string, Terminals::TerminalOutputEventType>(),
            new ApiEnumConverter<string, Terminals::TerminalResizeEventType>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DedalusInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}

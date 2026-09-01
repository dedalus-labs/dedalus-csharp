using System.Text.Json;
using Dedalus.Exceptions;
using Dedalus.Models.Machines;
using Dedalus.Models.Machines.Ssh;
using Executions = Dedalus.Models.Machines.Executions;

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
            new ApiEnumConverter<string, MachinePhase>(),
            new ApiEnumConverter<string, MachineListItemDesiredState>(),
            new ApiEnumConverter<string, MachineListItemPhase>(),
            new ApiEnumConverter<string, MachineRetrieveResponseDesiredState>(),
            new ApiEnumConverter<string, Kind>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Executions::Status>(),
            new ApiEnumConverter<string, Executions::Type>(),
            new ApiEnumConverter<string, Executions::ExecutionEventStatus>(),
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

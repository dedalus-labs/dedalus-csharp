using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Executions;

[JsonConverter(
    typeof(JsonModelConverter<
        ExecutionExecutionCreateParams,
        ExecutionExecutionCreateParamsFromRaw
    >)
)]
public sealed record class ExecutionExecutionCreateParams : JsonModel
{
    public required IReadOnlyList<string>? Command
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("command");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "command",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Cwd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cwd");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cwd", value);
        }
    }

    public IReadOnlyDictionary<string, string>? Env
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("env");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "env",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Stdin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stdin");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stdin", value);
        }
    }

    public long? TimeoutMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("timeout_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeout_ms", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Command;
        _ = this.Cwd;
        _ = this.Env;
        _ = this.Stdin;
        _ = this.TimeoutMs;
    }

    public ExecutionExecutionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionExecutionCreateParams(
        ExecutionExecutionCreateParams executionExecutionCreateParams
    )
        : base(executionExecutionCreateParams) { }
#pragma warning restore CS8618

    public ExecutionExecutionCreateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionExecutionCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionExecutionCreateParamsFromRaw.FromRawUnchecked"/>
    public static ExecutionExecutionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecutionExecutionCreateParams(IReadOnlyList<string>? command)
        : this()
    {
        this.Command = command;
    }
}

class ExecutionExecutionCreateParamsFromRaw : IFromRawJson<ExecutionExecutionCreateParams>
{
    /// <inheritdoc/>
    public ExecutionExecutionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecutionExecutionCreateParams.FromRawUnchecked(rawData);
}

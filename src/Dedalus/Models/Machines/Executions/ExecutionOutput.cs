using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Executions;

[JsonConverter(typeof(JsonModelConverter<ExecutionOutput, ExecutionOutputFromRaw>))]
public sealed record class ExecutionOutput : JsonModel
{
    public required string ExecutionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("execution_id");
        }
        init { this._rawData.Set("execution_id", value); }
    }

    public string? Stderr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stderr");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stderr", value);
        }
    }

    public long? StderrBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("stderr_bytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stderr_bytes", value);
        }
    }

    public bool? StderrTruncated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("stderr_truncated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stderr_truncated", value);
        }
    }

    public string? Stdout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stdout");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stdout", value);
        }
    }

    public long? StdoutBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("stdout_bytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stdout_bytes", value);
        }
    }

    public bool? StdoutTruncated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("stdout_truncated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stdout_truncated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExecutionID;
        _ = this.Stderr;
        _ = this.StderrBytes;
        _ = this.StderrTruncated;
        _ = this.Stdout;
        _ = this.StdoutBytes;
        _ = this.StdoutTruncated;
    }

    public ExecutionOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionOutput(ExecutionOutput executionOutput)
        : base(executionOutput) { }
#pragma warning restore CS8618

    public ExecutionOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionOutputFromRaw.FromRawUnchecked"/>
    public static ExecutionOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecutionOutput(string executionID)
        : this()
    {
        this.ExecutionID = executionID;
    }
}

class ExecutionOutputFromRaw : IFromRawJson<ExecutionOutput>
{
    /// <inheritdoc/>
    public ExecutionOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExecutionOutput.FromRawUnchecked(rawData);
}

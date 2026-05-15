using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Executions;

[JsonConverter(typeof(JsonModelConverter<ExecutionList, ExecutionListFromRaw>))]
public sealed record class ExecutionList : JsonModel
{
    public required IReadOnlyList<Execution>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Execution>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Execution>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("next_cursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public ExecutionList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionList(ExecutionList executionList)
        : base(executionList) { }
#pragma warning restore CS8618

    public ExecutionList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionListFromRaw.FromRawUnchecked"/>
    public static ExecutionList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecutionList(IReadOnlyList<Execution>? items)
        : this()
    {
        this.Items = items;
    }
}

class ExecutionListFromRaw : IFromRawJson<ExecutionList>
{
    /// <inheritdoc/>
    public ExecutionList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExecutionList.FromRawUnchecked(rawData);
}

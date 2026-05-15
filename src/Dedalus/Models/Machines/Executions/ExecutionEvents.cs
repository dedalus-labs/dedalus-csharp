using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Executions;

[JsonConverter(typeof(JsonModelConverter<ExecutionEvents, ExecutionEventsFromRaw>))]
public sealed record class ExecutionEvents : JsonModel
{
    public required IReadOnlyList<ExecutionEvent>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ExecutionEvent>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ExecutionEvent>?>(
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

    public ExecutionEvents() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionEvents(ExecutionEvents executionEvents)
        : base(executionEvents) { }
#pragma warning restore CS8618

    public ExecutionEvents(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionEvents(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionEventsFromRaw.FromRawUnchecked"/>
    public static ExecutionEvents FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecutionEvents(IReadOnlyList<ExecutionEvent>? items)
        : this()
    {
        this.Items = items;
    }
}

class ExecutionEventsFromRaw : IFromRawJson<ExecutionEvents>
{
    /// <inheritdoc/>
    public ExecutionEvents FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExecutionEvents.FromRawUnchecked(rawData);
}

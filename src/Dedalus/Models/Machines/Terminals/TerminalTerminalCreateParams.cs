using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dedalus.Core;

namespace Dedalus.Models.Machines.Terminals;

[JsonConverter(
    typeof(JsonModelConverter<TerminalTerminalCreateParams, TerminalTerminalCreateParamsFromRaw>)
)]
public sealed record class TerminalTerminalCreateParams : JsonModel
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

    public required long Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
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

    public string? Shell
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shell");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shell", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Width;
        _ = this.Cwd;
        _ = this.Env;
        _ = this.Shell;
    }

    public TerminalTerminalCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TerminalTerminalCreateParams(TerminalTerminalCreateParams terminalTerminalCreateParams)
        : base(terminalTerminalCreateParams) { }
#pragma warning restore CS8618

    public TerminalTerminalCreateParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TerminalTerminalCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TerminalTerminalCreateParamsFromRaw.FromRawUnchecked"/>
    public static TerminalTerminalCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TerminalTerminalCreateParamsFromRaw : IFromRawJson<TerminalTerminalCreateParams>
{
    /// <inheritdoc/>
    public TerminalTerminalCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TerminalTerminalCreateParams.FromRawUnchecked(rawData);
}

using System;
using System.Collections.Generic;
using System.Text.Json;
using Dedalus.Core;
using Dedalus.Models.Machines;

namespace Dedalus.Tests.Models.Machines;

public class MachineListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MachineList
        {
            Items =
            [
                new()
                {
                    AutosleepSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DesiredState = MachineListItemDesiredState.Running,
                    MachineID = "machine_id",
                    MemoryMiB = 0,
                    Phase = MachineListItemPhase.Accepted,
                    StorageGiB = 0,
                    Vcpu = 0,
                },
            ],
            NextCursor = "next_cursor",
        };

        List<MachineListItem> expectedItems =
        [
            new()
            {
                AutosleepSeconds = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DesiredState = MachineListItemDesiredState.Running,
                MachineID = "machine_id",
                MemoryMiB = 0,
                Phase = MachineListItemPhase.Accepted,
                StorageGiB = 0,
                Vcpu = 0,
            },
        ];
        string expectedNextCursor = "next_cursor";

        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MachineList
        {
            Items =
            [
                new()
                {
                    AutosleepSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DesiredState = MachineListItemDesiredState.Running,
                    MachineID = "machine_id",
                    MemoryMiB = 0,
                    Phase = MachineListItemPhase.Accepted,
                    StorageGiB = 0,
                    Vcpu = 0,
                },
            ],
            NextCursor = "next_cursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MachineList
        {
            Items =
            [
                new()
                {
                    AutosleepSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DesiredState = MachineListItemDesiredState.Running,
                    MachineID = "machine_id",
                    MemoryMiB = 0,
                    Phase = MachineListItemPhase.Accepted,
                    StorageGiB = 0,
                    Vcpu = 0,
                },
            ],
            NextCursor = "next_cursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MachineList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<MachineListItem> expectedItems =
        [
            new()
            {
                AutosleepSeconds = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DesiredState = MachineListItemDesiredState.Running,
                MachineID = "machine_id",
                MemoryMiB = 0,
                Phase = MachineListItemPhase.Accepted,
                StorageGiB = 0,
                Vcpu = 0,
            },
        ];
        string expectedNextCursor = "next_cursor";

        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MachineList
        {
            Items =
            [
                new()
                {
                    AutosleepSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DesiredState = MachineListItemDesiredState.Running,
                    MachineID = "machine_id",
                    MemoryMiB = 0,
                    Phase = MachineListItemPhase.Accepted,
                    StorageGiB = 0,
                    Vcpu = 0,
                },
            ],
            NextCursor = "next_cursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MachineList
        {
            Items =
            [
                new()
                {
                    AutosleepSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DesiredState = MachineListItemDesiredState.Running,
                    MachineID = "machine_id",
                    MemoryMiB = 0,
                    Phase = MachineListItemPhase.Accepted,
                    StorageGiB = 0,
                    Vcpu = 0,
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MachineList
        {
            Items =
            [
                new()
                {
                    AutosleepSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DesiredState = MachineListItemDesiredState.Running,
                    MachineID = "machine_id",
                    MemoryMiB = 0,
                    Phase = MachineListItemPhase.Accepted,
                    StorageGiB = 0,
                    Vcpu = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MachineList
        {
            Items =
            [
                new()
                {
                    AutosleepSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DesiredState = MachineListItemDesiredState.Running,
                    MachineID = "machine_id",
                    MemoryMiB = 0,
                    Phase = MachineListItemPhase.Accepted,
                    StorageGiB = 0,
                    Vcpu = 0,
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("next_cursor"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MachineList
        {
            Items =
            [
                new()
                {
                    AutosleepSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DesiredState = MachineListItemDesiredState.Running,
                    MachineID = "machine_id",
                    MemoryMiB = 0,
                    Phase = MachineListItemPhase.Accepted,
                    StorageGiB = 0,
                    Vcpu = 0,
                },
            ],

            // Null should be interpreted as omitted for these properties
            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MachineList
        {
            Items =
            [
                new()
                {
                    AutosleepSeconds = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DesiredState = MachineListItemDesiredState.Running,
                    MachineID = "machine_id",
                    MemoryMiB = 0,
                    Phase = MachineListItemPhase.Accepted,
                    StorageGiB = 0,
                    Vcpu = 0,
                },
            ],
            NextCursor = "next_cursor",
        };

        MachineList copied = new(model);

        Assert.Equal(model, copied);
    }
}

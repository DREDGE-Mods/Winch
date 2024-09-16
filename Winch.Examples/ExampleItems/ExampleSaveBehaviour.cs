using Newtonsoft.Json.Linq;
using UnityEngine;
using Winch.Components;

namespace ExampleItems;

/// <summary>
/// Basically the exact same as <see cref="ExampleSaveParticipant"/> but as a <see cref="USingleton{T}"/> instead.
/// </summary>
public class ExampleSaveBehaviour : ExtendedSaveSingleton<ExampleSaveBehaviour>
{
    public ExampleItemsSaveData saveData;

    protected override bool ShouldNotDestroyOnLoad => true;

    public override string Key => "behaviour";

    public override void Load(JToken token)
    {
        saveData = token.ToObject<ExampleItemsSaveData>();
    }

    public override object Save()
    {
        return saveData;
    }

    public override object Create()
    {
        return new ExampleItemsSaveData();
    }
}
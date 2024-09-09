using Newtonsoft.Json.Linq;
using UnityEngine;
using Winch.Components;

namespace ExampleItems;

/// <summary>
/// Basically the exact same as <see cref="ExampleExtendedSaveDataParticipant"/> but as a <see cref="MonoBehaviour"/> instead.
/// </summary>
public class ExampleSaveBehaviour : ExtendedSaveBehaviour
{
    public ExampleItemsSaveData saveData;

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
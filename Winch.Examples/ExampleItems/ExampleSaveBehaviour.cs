using Newtonsoft.Json.Linq;
using UnityEngine;
using Winch.Components;
using Winch.Core;

namespace ExampleItems;

/// <summary>
/// Basically the exact same as <see cref="ExampleSaveParticipant"/> but as a <see cref="USingleton{T}"/> instead.
/// </summary>
public class ExampleSaveBehaviour : ExtendedSaveSingleton<ExampleSaveBehaviour>
{
    private ExampleItemsSaveData saveData;
    public ExampleItemsSaveData SaveData
    {
        get
        {
            if (saveData == null) saveData = new ExampleItemsSaveData();
            return saveData;
        }
    }

    protected override bool ShouldNotDestroyOnLoad => true;

    public override string Key => "behaviour";

    public override void Load(JToken token)
    {
        WinchCore.Log.Debug("Load");
        saveData = token.ToObject<ExampleItemsSaveData>();
    }

    public override object Save()
    {
        WinchCore.Log.Debug("Save");
        return saveData;
    }

    public override object Create()
    {
        WinchCore.Log.Debug("Create");
        return new ExampleItemsSaveData();
    }
}
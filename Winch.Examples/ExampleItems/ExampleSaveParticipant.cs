using Newtonsoft.Json.Linq;
using Winch.Data;

namespace ExampleItems;

/// <summary>
/// Example extended save data participant
/// </summary>
public class ExampleSaveParticipant : ExtendedSaveData.Participant
{
    public ExampleItemsSaveDataTwo saveData;

    public string Key => "class";

    public void Load(JToken token)
    {
        saveData = token.ToObject<ExampleItemsSaveDataTwo>();
    }

    public object Save()
    {
        return saveData;
    }

    public object Create()
    {
        return new ExampleItemsSaveDataTwo();
    }
}
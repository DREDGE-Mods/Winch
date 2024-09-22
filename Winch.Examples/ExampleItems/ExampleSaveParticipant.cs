using Newtonsoft.Json.Linq;
using Winch.Data;

namespace ExampleItems;

/// <summary>
/// Example extended save data participant
/// </summary>
public class ExampleSaveParticipant : ExtendedSaveData.Participant
{
    private ExampleItemsSaveDataTwo saveData;
    public ExampleItemsSaveDataTwo SaveData
    {
        get
        {
            if (saveData == null) saveData = new ExampleItemsSaveDataTwo();
            return saveData;
        }
    }

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
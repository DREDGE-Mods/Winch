using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winch.Data;

namespace ExampleItems
{
    /// <summary>
    /// Example extended save data participant
    /// </summary>
    public class ExampleSaveParticipant : ExtendedSaveData.Participant
    {
        public ExampleItemsSaveData saveData = new ExampleItemsSaveData();

        public string Key => "class";

        public void Load(JToken token)
        {
            saveData = token.ToObject<ExampleItemsSaveData>() ?? new ExampleItemsSaveData();
        }

        public object Save()
        {
            return saveData;
        }
    }
}

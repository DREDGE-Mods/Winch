using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Components;
using Winch.Data;

namespace ExampleItems
{
    /// <summary>
    /// Basically the exact same as <see cref="ExampleExtendedSaveDataParticipant"/> but as a <see cref="MonoBehaviour"/> instead.
    /// </summary>
    public class ExampleSaveBehaviour : ExtendedSaveBehaviour
    {
        public ExampleItemsSaveData saveData = new ExampleItemsSaveData();

        public override string Key => "behaviour";

        public override void Load(JToken token)
        {
            saveData = token.ToObject<ExampleItemsSaveData>() ?? new ExampleItemsSaveData();
        }

        public override object Save()
        {
            return saveData;
        }
    }
}

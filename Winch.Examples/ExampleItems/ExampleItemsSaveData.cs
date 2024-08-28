using Newtonsoft.Json;
using System;

namespace ExampleItems
{
    [JsonObject, Serializable] // Can use either one
    public class ExampleItemsSaveData
    {
        [JsonIgnore, NonSerialized] // Can use either one
        public string nonSerialized = "Test";

        public string serialized = "Test";

        [JsonProperty("property")] // Must have this or else this property will act as non serialized automatically
        public string Property { get; set; }
    }
}

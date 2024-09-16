using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace ExampleItems;

[JsonObject, Serializable] // Can use either one
public class ExampleItemsSaveData
{
    [JsonIgnore, NonSerialized] // Can use either one
    public string nonSerialized = "Test";

    [DefaultValue("Test")]
    public string serialized = "Test";

    [JsonProperty("property")] // Must have this or else this property will act as non serialized automatically
    [DefaultValue("Test")]
    public string Property { get; set; } = "Test";

    public bool recipeCrafted = false;
}
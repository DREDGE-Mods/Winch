using Newtonsoft.Json;
using System.ComponentModel;

namespace ExampleItems;

[JsonObject] // Can use either one
public class ExampleItemsSaveDataTwo
{
    [DefaultValue("Test")]
    public string serialized = "Test";
}
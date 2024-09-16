using System.Collections.Generic;

namespace Winch.Serialization.Recipe;

public class HullRecipeDataConverter : RecipeDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "hullUpgradeData", new(string.Empty, null) },
    };

    public HullRecipeDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

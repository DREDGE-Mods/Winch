using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Recipe;

public class AbilityRecipeDataConverter : RecipeDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "abilityData", new(string.Empty, null) },
    };

    public AbilityRecipeDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

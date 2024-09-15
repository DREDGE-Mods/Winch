using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Recipe;

public class ItemRecipeDataConverter : RecipeDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemProduced", new(string.Empty, null) },
    };

    public ItemRecipeDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

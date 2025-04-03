using System.Collections.Generic;

namespace Winch.Serialization.Recipe;

public class SlotRecipeDataConverter : RecipeDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "slotUpgradeData", new(string.Empty, null) },
    };

    public SlotRecipeDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

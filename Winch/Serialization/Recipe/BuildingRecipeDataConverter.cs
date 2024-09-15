using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Recipe;

public class BuildingRecipeDataConverter : RecipeDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "buildingNameKey", new(LocalizationUtil.Empty, o=>CreateLocalizedString(o.ToString())) },
        { "buildingDescriptionKey", new(LocalizationUtil.Empty, o=>CreateLocalizedString(o.ToString())) },
    };

    public BuildingRecipeDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

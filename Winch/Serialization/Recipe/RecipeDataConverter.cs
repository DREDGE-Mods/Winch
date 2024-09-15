using System.Collections.Generic;
using UnityEngine.Localization;
using Winch.Util;

namespace Winch.Serialization.Recipe;

public class RecipeDataConverter : DredgeTypeConverter<RecipeData>
{
    internal static readonly string TableDefinition = LanguageManager.STRING_TABLE;

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "recipeId", new(string.Empty, null) },
        { "questGridConfig", new(string.Empty, null) },
        { "cost", new(0m, o=>decimal.Parse(o.ToString())) },
        { "onRecipeShownDialogueNodeName", new(string.Empty, null) },
        { "onRecipeBuiltDialogueNodeName", new(string.Empty, null) },
        { "researchRequired", new(0, o=>int.Parse(o.ToString())) },
        { "quantityProduced", new(1, o=>int.Parse(o.ToString())) },
    };

    public RecipeDataConverter()
    {
        AddDefinitions(_definitions);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(TableDefinition, value);
}

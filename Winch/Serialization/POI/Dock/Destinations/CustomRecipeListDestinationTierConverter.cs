using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Winch.Data.POI.Dock.Destinations;
using Winch.Util;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomRecipeListDestinationTierConverter : CustomBaseDestinationTierConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "type", new(DestinationTierType.RecipeList, null) },
        { "viewAfterConstruction", new(ConstructableDestinationUI.ConstructionViewState.RECIPE_LIST, null) },
        { "recipeListStringKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "recipes", new(new List<string>(), o=> DredgeTypeHelpers.ParseStringList((JArray)o)) },
    };

    public CustomRecipeListDestinationTierConverter()
    {
        AddDefinitions(_definitions);
    }
}

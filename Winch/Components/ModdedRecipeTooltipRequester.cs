using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winch.Data.Recipe;

namespace Winch.Components;

public class ModdedRecipeTooltipRequester : TextTooltipRequester
{
    private ModdedRecipeData _recipeData;
    public ModdedRecipeData RecipeData
    {
        get => _recipeData;
        set
        {
            _recipeData = value;
            localizedTitleKey = _recipeData.GetItemNameKey();
            localizedDescriptionKey = _recipeData.GetItemDescriptionKey();
            titleTextColor = _recipeData.GetItemNameColor();
            descriptionTextColor = _recipeData.GetItemDescriptionColor();
            icon = _recipeData.GetTooltipIcon();
        }
    }
}

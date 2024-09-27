using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine;
using System;
using Winch.Util;

namespace Winch.Data.POI.Dock.Destinations;

[Serializable]
public class CustomRecipeListDestinationTier : CustomBaseDestinationTier
{
    [SerializeField]
    public LocalizedString recipeListStringKey = LocalizationUtil.Empty;

    [SerializeField]
    public List<string> recipes = new List<string>();

    public CustomRecipeListDestinationTier()
    {
        type = DestinationTierType.RecipeList;
        viewAfterConstruction = ConstructableDestinationUI.ConstructionViewState.RECIPE_LIST;
    }

    public override BaseDestinationTier ToVanilla()
    {
        return new RecipeListDestinationTier
        {
            tierId = tierId,
            tierNameKey = tierNameKey,
            recipeToCreateThis = RecipeUtil.GetRecipeData(recipeToCreateThis),
            descriptionDialogueNodeName = descriptionDialogueNodeName,
            postConstructionDialogueNodeName = postConstructionDialogueNodeName,
            viewAfterConstruction = viewAfterConstruction,
            recipeListStringKey = recipeListStringKey,
            recipes = RecipeUtil.TryGetRecipes(recipes)
        };
    }
}
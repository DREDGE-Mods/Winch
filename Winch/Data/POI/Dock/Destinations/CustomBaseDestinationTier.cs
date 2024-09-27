using UnityEngine.Localization;
using UnityEngine;
using Winch.Util;
using System;

namespace Winch.Data.POI.Dock.Destinations;

[Serializable]
public class CustomBaseDestinationTier
{
    [SerializeField]
    public DestinationTierType type = DestinationTierType.Base;

    [SerializeField]
    public BuildingTierId tierId = BuildingTierId.NONE;

    [SerializeField]
    public LocalizedString tierNameKey = LocalizationUtil.Empty;

    [SerializeField]
    public string recipeToCreateThis = string.Empty;

    [SerializeField]
    public string descriptionDialogueNodeName = string.Empty;

    [SerializeField]
    public string postConstructionDialogueNodeName = string.Empty;

    [SerializeField]
    public ConstructableDestinationUI.ConstructionViewState viewAfterConstruction = ConstructableDestinationUI.ConstructionViewState.NONE;

    public virtual BaseDestinationTier ToVanilla()
    {
        return new BaseDestinationTier
        {
            tierId = tierId,
            tierNameKey = tierNameKey,
            recipeToCreateThis = RecipeUtil.GetRecipeData(recipeToCreateThis),
            descriptionDialogueNodeName = descriptionDialogueNodeName,
            postConstructionDialogueNodeName = postConstructionDialogueNodeName,
            viewAfterConstruction = viewAfterConstruction
        };
    }
}
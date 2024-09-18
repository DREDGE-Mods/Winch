namespace Winch.AbyssApi.GameReferences.GridConfigurations;
public static class DogTagOutput
{
    public static GridConfiguration DogTagOutputInstance = (GridConfiguration)System.Linq.Enumerable.First(ScriptableObjectInstances.GridConfigurations, x => x.name == "DogTagOutput");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[CellGroupConfiguration, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CellGroupConfiguration> cellGroupConfigs = DogTagOutputInstance.cellGroupConfigs;
    public static ItemType mainItemType = ItemType.NONE | ItemType.GENERAL;
    public static ItemSubtype mainItemSubtype = ItemSubtype.NONE | ItemSubtype.GENERAL;
     ///<json>
     /// {
     ///    "harvestMinigameType": "DREDGE_RADIAL",
     ///    "perSpotMin": 1,
     ///    "perSpotMax": 1,
     ///    "harvestItemWeight": 15.0,
     ///    "regenHarvestSpotOnDestroy": false,
     ///    "harvestPOICategory": "MATERIAL",
     ///    "harvestableType": "DREDGE",
     ///    "requiresAdvancedEquipment": false,
     ///    "harvestDifficulty": "HARD",
     ///    "canBeReplacedWithResearchItem": false,
     ///    "canBeCaughtByRod": false,
     ///    "canBeCaughtByPot": false,
     ///    "canBeCaughtByNet": true,
     ///    "affectedByFishingSustain": true,
     ///    "hasMinDepth": false,
     ///    "minDepth": "VERY_SHALLOW",
     ///    "hasMaxDepth": false,
     ///    "maxDepth": "VERY_SHALLOW",
     ///    "zonesFoundIn": "THE_MARROWS,GALE_CLIFFS,STELLAR_BASIN,TWISTED_STRAND,DEVILS_SPINE,OPEN_OCEAN,PALE_REACH,ALL",
     ///    "canBeSoldByPlayer": true,
     ///    "canBeSoldInBulkAction": false,
     ///    "value": 350.0,
     ///    "hasSellOverride": false,
     ///    "sellOverrideValue": 0.0,
     ///    "sprite": {
     ///
     ///    },
     ///    "platformSpecificSpriteOverrides": null,
     ///    "itemColor": {
     ///        "r": 0.5450981,
     ///        "g": 0.3568628,
     ///        "b": 0.145098,
     ///        "a": 1.0
     ///    },
     ///    "hasSpecialDiscardAction": false,
     ///    "discardPromptOverride": "",
     ///    "canBeDiscardedByPlayer": true,
     ///    "showAlertOnDiscardHold": true,
     ///    "discardHoldTimeOverride": true,
     ///    "discardHoldTimeSec": 2.0,
     ///    "canBeDiscardedDuringQuestPickup": true,
     ///    "damageMode": "DESTROY",
     ///    "moveMode": "FREE",
     ///    "ignoreDamageWhenPlacing": false,
     ///    "isUnderlayItem": false,
     ///    "forbidStorageTray": false,
     ///    "dimensions": [
     ///        {
     ///
     ///        }
     ///    ],
     ///    "squishFactor": 0.0,
     ///    "itemOwnPrerequisites": [],
     ///    "researchPrerequisites": [],
     ///    "researchPointsRequired": 0,
     ///    "buyableWithoutResearch": false,
     ///    "researchIsForRecipe": false,
     ///    "useIntenseAberratedUIShader": false,
     ///    "id": "research-item",
     ///    "itemNameKey": [],
     ///    "itemDescriptionKey": [],
     ///    "hasAdditionalNote": false,
     ///    "additionalNoteKey": [],
     ///    "itemInsaneTitleKey": [],
     ///    "itemInsaneDescriptionKey": [],
     ///    "linkedDialogueNode": "",
     ///    "dialogueNodeSpecificDescription": [],
     ///    "itemType": "GENERAL,ALL",
     ///    "itemSubtype": "GENERAL,ALL",
     ///    "tooltipTextColor": {
     ///        "r": 0.4901961,
     ///        "g": 0.3843137,
     ///        "b": 0.2666667,
     ///        "a": 1.0
     ///    },
     ///    "tooltipNotesColor": {
     ///        "r": 1.0,
     ///        "g": 1.0,
     ///        "b": 1.0,
     ///        "a": 1.0
     ///    },
     ///    "itemTypeIcon": {
     ///
     ///    },
     ///    "harvestParticlePrefab": {
     ///
     ///    },
     ///    "overrideHarvestParticleDepth": false,
     ///    "harvestParticleDepthOffset": -3.0,
     ///    "flattenParticleShape": false,
     ///    "availableInDemo": true,
     ///    "entitlementsRequired": [
     ///        "NONE"
     ///    ],
     ///    "$type": "HarvestableItemData"
     ///}
     ///</json>
    public static ItemData mainItemData = DogTagOutputInstance.mainItemData;
    public static bool itemsInThisBelongToPlayer = false;
    public static bool canAddItemsInQuestMode = false;
    public static bool hasUnderlay = false;
    public static int columns = 5;
    public static int rows = 5;
}

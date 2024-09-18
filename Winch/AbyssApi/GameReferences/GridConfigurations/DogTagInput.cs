namespace Winch.AbyssApi.GameReferences.GridConfigurations;
public static class DogTagInput
{
    public static GridConfiguration DogTagInputInstance = (GridConfiguration)System.Linq.Enumerable.First(ScriptableObjectInstances.GridConfigurations, x => x.name == "DogTagInput");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[CellGroupConfiguration, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CellGroupConfiguration> cellGroupConfigs = DogTagInputInstance.cellGroupConfigs;
    public static ItemType mainItemType = ItemType.NONE | ItemType.GENERAL;
    public static ItemSubtype mainItemSubtype = ItemSubtype.NONE | ItemSubtype.TRINKET;
     ///<json>
     /// {
     ///    "harvestMinigameType": "DREDGE_RADIAL",
     ///    "perSpotMin": 1,
     ///    "perSpotMax": 1,
     ///    "harvestItemWeight": 1.0,
     ///    "regenHarvestSpotOnDestroy": false,
     ///    "harvestPOICategory": "TRINKET",
     ///    "harvestableType": "DREDGE",
     ///    "requiresAdvancedEquipment": false,
     ///    "harvestDifficulty": "MEDIUM",
     ///    "canBeReplacedWithResearchItem": false,
     ///    "canBeCaughtByRod": false,
     ///    "canBeCaughtByPot": false,
     ///    "canBeCaughtByNet": false,
     ///    "affectedByFishingSustain": true,
     ///    "hasMinDepth": false,
     ///    "minDepth": "VERY_SHALLOW",
     ///    "hasMaxDepth": false,
     ///    "maxDepth": "VERY_SHALLOW",
     ///    "zonesFoundIn": "TWISTED_STRAND,ALL",
     ///    "canBeSoldByPlayer": true,
     ///    "canBeSoldInBulkAction": true,
     ///    "value": 35.0,
     ///    "hasSellOverride": false,
     ///    "sellOverrideValue": 0.0,
     ///    "sprite": {
     ///
     ///    },
     ///    "platformSpecificSpriteOverrides": null,
     ///    "itemColor": {
     ///        "r": 0.227451,
     ///        "g": 0.1568628,
     ///        "b": 0.1254902,
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
     ///        },
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
     ///    "id": "quest-dog-tag",
     ///    "itemNameKey": [],
     ///    "itemDescriptionKey": [],
     ///    "hasAdditionalNote": false,
     ///    "additionalNoteKey": [],
     ///    "itemInsaneTitleKey": [],
     ///    "itemInsaneDescriptionKey": [],
     ///    "linkedDialogueNode": "",
     ///    "dialogueNodeSpecificDescription": [],
     ///    "itemType": "GENERAL,ALL",
     ///    "itemSubtype": "TRINKET,ALL",
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
    public static ItemData mainItemData = DogTagInputInstance.mainItemData;
    public static bool itemsInThisBelongToPlayer = false;
    public static bool canAddItemsInQuestMode = true;
    public static bool hasUnderlay = false;
    public static int columns = 5;
    public static int rows = 5;
}

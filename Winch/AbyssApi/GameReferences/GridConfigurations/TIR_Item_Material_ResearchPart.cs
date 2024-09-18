namespace Winch.AbyssApi.GameReferences.GridConfigurations;
public static class TIR_Item_Material_ResearchPart
{
    public static GridConfiguration TIR_Item_Material_ResearchPartInstance = (GridConfiguration)System.Linq.Enumerable.First(ScriptableObjectInstances.GridConfigurations, x => x.name == "TIR_Item_Material_ResearchPart");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[CellGroupConfiguration, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CellGroupConfiguration> cellGroupConfigs = TIR_Item_Material_ResearchPartInstance.cellGroupConfigs;
    public static ItemType mainItemType = ItemType.NONE | ItemType.GENERAL;
    public static ItemSubtype mainItemSubtype = ItemSubtype.NONE | ItemSubtype.MATERIAL;
     ///<json>
     /// {
     ///    "harvestMinigameType": "DREDGE_RADIAL",
     ///    "perSpotMin": 1,
     ///    "perSpotMax": 2,
     ///    "harvestItemWeight": 50.0,
     ///    "regenHarvestSpotOnDestroy": false,
     ///    "harvestPOICategory": "MATERIAL",
     ///    "harvestableType": "DREDGE",
     ///    "requiresAdvancedEquipment": false,
     ///    "harvestDifficulty": "MEDIUM",
     ///    "canBeReplacedWithResearchItem": false,
     ///    "canBeCaughtByRod": false,
     ///    "canBeCaughtByPot": false,
     ///    "canBeCaughtByNet": false,
     ///    "affectedByFishingSustain": false,
     ///    "hasMinDepth": false,
     ///    "minDepth": "VERY_SHALLOW",
     ///    "hasMaxDepth": false,
     ///    "maxDepth": "VERY_SHALLOW",
     ///    "zonesFoundIn": "THE_MARROWS,GALE_CLIFFS,STELLAR_BASIN,TWISTED_STRAND,DEVILS_SPINE,OPEN_OCEAN,PALE_REACH,ALL",
     ///    "canBeSoldByPlayer": false,
     ///    "canBeSoldInBulkAction": false,
     ///    "value": 0.0,
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
     ///    "showAlertOnDiscardHold": false,
     ///    "discardHoldTimeOverride": true,
     ///    "discardHoldTimeSec": 3.0,
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
     ///        },
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
     ///    "id": "crate",
     ///    "itemNameKey": [],
     ///    "itemDescriptionKey": [],
     ///    "hasAdditionalNote": true,
     ///    "additionalNoteKey": [],
     ///    "itemInsaneTitleKey": [],
     ///    "itemInsaneDescriptionKey": [],
     ///    "linkedDialogueNode": "",
     ///    "dialogueNodeSpecificDescription": [],
     ///    "itemType": "GENERAL,ALL",
     ///    "itemSubtype": "MATERIAL,ALL",
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
     ///    "availableInDemo": false,
     ///    "entitlementsRequired": [
     ///        "DLC_2"
     ///    ],
     ///    "$type": "HarvestableItemData"
     ///}
     ///</json>
    public static ItemData mainItemData = TIR_Item_Material_ResearchPartInstance.mainItemData;
    public static bool itemsInThisBelongToPlayer = false;
    public static bool canAddItemsInQuestMode = true;
    public static bool hasUnderlay = false;
    public static int columns = 2;
    public static int rows = 2;
}

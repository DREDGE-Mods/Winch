namespace Winch.AbyssApi.GameReferences.GridConfigurations;
public static class ExplosivesSeller
{
    public static GridConfiguration ExplosivesSellerInstance = (GridConfiguration)System.Linq.Enumerable.First(ScriptableObjectInstances.GridConfigurations, x => x.name == "ExplosivesSeller");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[CellGroupConfiguration, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CellGroupConfiguration> cellGroupConfigs = ExplosivesSellerInstance.cellGroupConfigs;
    public static ItemType mainItemType = ItemType.NONE | ItemType.GENERAL;
    public static ItemSubtype mainItemSubtype = ItemSubtype.NONE;
     ///<json>
     /// {
     ///    "canBeSoldByPlayer": true,
     ///    "canBeSoldInBulkAction": true,
     ///    "value": 40.0,
     ///    "hasSellOverride": true,
     ///    "sellOverrideValue": 20.0,
     ///    "sprite": {
     ///
     ///    },
     ///    "platformSpecificSpriteOverrides": null,
     ///    "itemColor": {
     ///        "r": 0.227451,
     ///        "g": 0.1568628,
     ///        "b": 0.1254902,
     ///        "a": 255.0
     ///    },
     ///    "hasSpecialDiscardAction": false,
     ///    "discardPromptOverride": "",
     ///    "canBeDiscardedByPlayer": true,
     ///    "showAlertOnDiscardHold": false,
     ///    "discardHoldTimeOverride": false,
     ///    "discardHoldTimeSec": 0.0,
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
     ///    "id": "explosives",
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
     ///    "harvestParticlePrefab": null,
     ///    "overrideHarvestParticleDepth": false,
     ///    "harvestParticleDepthOffset": -3.0,
     ///    "flattenParticleShape": false,
     ///    "availableInDemo": true,
     ///    "entitlementsRequired": [
     ///        "NONE"
     ///    ],
     ///    "$type": "SpatialItemData"
     ///}
     ///</json>
    public static ItemData mainItemData = ExplosivesSellerInstance.mainItemData;
    public static bool itemsInThisBelongToPlayer = false;
    public static bool canAddItemsInQuestMode = false;
    public static bool hasUnderlay = false;
    public static int columns = 5;
    public static int rows = 5;
}

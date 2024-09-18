namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class Fishmonger_CrabPot
{
    public static QuestGridConfig Fishmonger_CrabPotInstance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "Fishmonger_CrabPot");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.REVISITABLE;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = Fishmonger_CrabPotInstance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = Fishmonger_CrabPotInstance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = Fishmonger_CrabPotInstance.exitPromptOverride;
     ///<json>
     /// null
     /// </json>
    public static UnityEngine.Sprite backgroundImage = null;
    public static float gridHeightOverride = 0f;
    public static bool overrideGridCellColor = false;
    public static DredgeColorTypeEnum gridCellColor = DredgeColorTypeEnum.NEUTRAL;
    public static bool allowStorageAccess = true;
    public static bool isSaved = false;
    public static bool createItemsIfEmpty = false;
    public static GridKey gridKey = GridKey.GM_FISHMONGER_DELIVERY_1;
    public static bool allowManualExit = true;
    public static bool allowEquipmentInstallation = true;
    public static bool createWithDurabilityValue = true;
    public static float startingDurabilityProportion = 0.5f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [],
     ///    "mainItemType": "EQUIPMENT,ALL",
     ///    "mainItemSubtype": "FISH,ENGINE,ROD,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,NET,DREDGE,GADGET,ALL",
     ///    "mainItemData": {
     ///        "timeBetweenCatchRolls": 0.66,
     ///        "catchRate": 1.0,
     ///        "maxDurabilityDays": 3.0,
     ///        "gridConfig": {
     ///            "cellGroupConfigs": [],
     ///            "mainItemType": "GENERAL,ALL",
     ///            "mainItemSubtype": "FISH,GENERAL,ALL",
     ///            "mainItemData": null,
     ///            "itemsInThisBelongToPlayer": true,
     ///            "canAddItemsInQuestMode": false,
     ///            "hasUnderlay": false,
     ///            "columns": 3,
     ///            "rows": 3
     ///        },
     ///        "gridKey": "NONE",
     ///        "harvestableTypes": [],
     ///        "isAdvancedEquipment": false,
     ///        "aberrationBonus": 0.0,
     ///        "canBeSoldByPlayer": true,
     ///        "canBeSoldInBulkAction": true,
     ///        "value": 100.0,
     ///        "hasSellOverride": false,
     ///        "sellOverrideValue": 0.0,
     ///        "sprite": {
     ///
     ///        },
     ///        "platformSpecificSpriteOverrides": null,
     ///        "itemColor": {
     ///            "r": 0.1921569,
     ///            "g": 0.1921569,
     ///            "b": 0.1921569,
     ///            "a": 255.0
     ///        },
     ///        "hasSpecialDiscardAction": false,
     ///        "discardPromptOverride": "",
     ///        "canBeDiscardedByPlayer": true,
     ///        "showAlertOnDiscardHold": true,
     ///        "discardHoldTimeOverride": true,
     ///        "discardHoldTimeSec": 2.0,
     ///        "canBeDiscardedDuringQuestPickup": true,
     ///        "damageMode": "DURABILITY",
     ///        "moveMode": "FREE",
     ///        "ignoreDamageWhenPlacing": true,
     ///        "isUnderlayItem": false,
     ///        "forbidStorageTray": false,
     ///        "dimensions": [
     ///            {
     ///
     ///            },
     ///            {
     ///
     ///            }
     ///        ],
     ///        "squishFactor": 0.0,
     ///        "itemOwnPrerequisites": [],
     ///        "researchPrerequisites": [],
     ///        "researchPointsRequired": 0,
     ///        "buyableWithoutResearch": true,
     ///        "researchIsForRecipe": false,
     ///        "useIntenseAberratedUIShader": false,
     ///        "id": "pot1",
     ///        "itemNameKey": [],
     ///        "itemDescriptionKey": [],
     ///        "hasAdditionalNote": false,
     ///        "additionalNoteKey": [],
     ///        "itemInsaneTitleKey": [],
     ///        "itemInsaneDescriptionKey": [],
     ///        "linkedDialogueNode": "",
     ///        "dialogueNodeSpecificDescription": [],
     ///        "itemType": "EQUIPMENT,ALL",
     ///        "itemSubtype": "POT,ALL",
     ///        "tooltipTextColor": {
     ///            "r": 0.4901961,
     ///            "g": 0.3843137,
     ///            "b": 0.2666667,
     ///            "a": 1.0
     ///        },
     ///        "tooltipNotesColor": {
     ///            "r": 1.0,
     ///            "g": 1.0,
     ///            "b": 1.0,
     ///            "a": 1.0
     ///        },
     ///        "itemTypeIcon": {
     ///
     ///        },
     ///        "harvestParticlePrefab": null,
     ///        "overrideHarvestParticleDepth": false,
     ///        "harvestParticleDepthOffset": -3.0,
     ///        "flattenParticleShape": false,
     ///        "availableInDemo": true,
     ///        "entitlementsRequired": [
     ///            "NONE"
     ///        ],
     ///        "$type": "DeployableItemData"
     ///    },
     ///    "itemsInThisBelongToPlayer": false,
     ///    "canAddItemsInQuestMode": false,
     ///    "hasUnderlay": false,
     ///    "columns": 2,
     ///    "rows": 2,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = Fishmonger_CrabPotInstance.gridConfiguration;
     ///<json>
     /// {
     ///    "spatialUnderlayItems": [],
     ///    "spatialItems": [
     ///        {
     ///            "x": 0,
     ///            "y": 0,
     ///            "z": 0,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "pot1"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = Fishmonger_CrabPotInstance.presetGrid;
    public static PresetGridMode presetGridMode = PresetGridMode.CREATE;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "$type": "EmptyCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[CompletedGridCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = Fishmonger_CrabPotInstance.completeConditions;
}

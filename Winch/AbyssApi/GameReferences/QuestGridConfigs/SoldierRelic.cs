namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class SoldierRelic
{
    public static QuestGridConfig SoldierRelicInstance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "SoldierRelic");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.CANNOT_EXIT_MANUALLY;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = SoldierRelicInstance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = SoldierRelicInstance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = SoldierRelicInstance.exitPromptOverride;
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
    public static GridKey gridKey = GridKey.NONE;
    public static bool allowManualExit = false;
    public static bool allowEquipmentInstallation = false;
    public static bool createWithDurabilityValue = false;
    public static float startingDurabilityProportion = 1f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [],
     ///    "mainItemType": "GENERAL,ALL",
     ///    "mainItemSubtype": "FISH,ENGINE,ROD,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,NET,DREDGE,GADGET,ALL",
     ///    "mainItemData": {
     ///        "harvestMinigameType": "DREDGE_RADIAL",
     ///        "perSpotMin": 1,
     ///        "perSpotMax": 1,
     ///        "harvestItemWeight": 1.0,
     ///        "regenHarvestSpotOnDestroy": true,
     ///        "harvestPOICategory": "RELIC",
     ///        "harvestableType": "DREDGE",
     ///        "requiresAdvancedEquipment": false,
     ///        "harvestDifficulty": "VERY_HARD",
     ///        "canBeReplacedWithResearchItem": false,
     ///        "canBeCaughtByRod": false,
     ///        "canBeCaughtByPot": false,
     ///        "canBeCaughtByNet": false,
     ///        "affectedByFishingSustain": true,
     ///        "hasMinDepth": false,
     ///        "minDepth": "VERY_SHALLOW",
     ///        "hasMaxDepth": false,
     ///        "maxDepth": "VERY_SHALLOW",
     ///        "zonesFoundIn": "TWISTED_STRAND,ALL",
     ///        "canBeSoldByPlayer": false,
     ///        "canBeSoldInBulkAction": true,
     ///        "value": 0.0,
     ///        "hasSellOverride": false,
     ///        "sellOverrideValue": 0.0,
     ///        "sprite": {
     ///
     ///        },
     ///        "platformSpecificSpriteOverrides": null,
     ///        "itemColor": {
     ///            "r": 0.5294118,
     ///            "g": 0.1137255,
     ///            "b": 0.345098,
     ///            "a": 1.0
     ///        },
     ///        "hasSpecialDiscardAction": false,
     ///        "discardPromptOverride": "",
     ///        "canBeDiscardedByPlayer": false,
     ///        "showAlertOnDiscardHold": false,
     ///        "discardHoldTimeOverride": false,
     ///        "discardHoldTimeSec": 0.0,
     ///        "canBeDiscardedDuringQuestPickup": false,
     ///        "damageMode": "NONE",
     ///        "moveMode": "FREE",
     ///        "ignoreDamageWhenPlacing": false,
     ///        "isUnderlayItem": false,
     ///        "forbidStorageTray": true,
     ///        "dimensions": [
     ///            {
     ///
     ///            },
     ///            {
     ///
     ///            },
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
     ///        "buyableWithoutResearch": false,
     ///        "researchIsForRecipe": false,
     ///        "useIntenseAberratedUIShader": false,
     ///        "id": "relic4",
     ///        "itemNameKey": [],
     ///        "itemDescriptionKey": [],
     ///        "hasAdditionalNote": false,
     ///        "additionalNoteKey": [],
     ///        "itemInsaneTitleKey": [],
     ///        "itemInsaneDescriptionKey": [],
     ///        "linkedDialogueNode": "",
     ///        "dialogueNodeSpecificDescription": [],
     ///        "itemType": "GENERAL,ALL",
     ///        "itemSubtype": "RELIC,ALL",
     ///        "tooltipTextColor": {
     ///            "r": 0.5294118,
     ///            "g": 0.1137255,
     ///            "b": 0.345098,
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
     ///        "harvestParticlePrefab": {
     ///
     ///        },
     ///        "overrideHarvestParticleDepth": false,
     ///        "harvestParticleDepthOffset": -3.0,
     ///        "flattenParticleShape": false,
     ///        "availableInDemo": true,
     ///        "entitlementsRequired": [
     ///            "NONE"
     ///        ],
     ///        "$type": "RelicItemData"
     ///    },
     ///    "itemsInThisBelongToPlayer": true,
     ///    "canAddItemsInQuestMode": true,
     ///    "hasUnderlay": false,
     ///    "columns": 2,
     ///    "rows": 2,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = SoldierRelicInstance.gridConfiguration;
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
     ///            "id": "relic4"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = SoldierRelicInstance.presetGrid;
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
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = SoldierRelicInstance.completeConditions;
}

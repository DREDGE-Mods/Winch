namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class LighthouseRuinDoor
{
    public static QuestGridConfig LighthouseRuinDoorInstance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "LighthouseRuinDoor");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.REVISITABLE;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = LighthouseRuinDoorInstance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = LighthouseRuinDoorInstance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = LighthouseRuinDoorInstance.exitPromptOverride;
     ///<json>
     /// null
     /// </json>
    public static UnityEngine.Sprite backgroundImage = null;
    public static float gridHeightOverride = 0f;
    public static bool overrideGridCellColor = false;
    public static DredgeColorTypeEnum gridCellColor = DredgeColorTypeEnum.NEUTRAL;
    public static bool allowStorageAccess = false;
    public static bool isSaved = false;
    public static bool createItemsIfEmpty = false;
    public static GridKey gridKey = (GridKey)225;
    public static bool allowManualExit = true;
    public static bool allowEquipmentInstallation = false;
    public static bool createWithDurabilityValue = false;
    public static float startingDurabilityProportion = 1f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [],
     ///    "mainItemType": "GENERAL,ALL",
     ///    "mainItemSubtype": "GENERAL,ALL",
     ///    "mainItemData": {
     ///        "harvestMinigameType": "DREDGE_RADIAL",
     ///        "perSpotMin": 1,
     ///        "perSpotMax": 1,
     ///        "harvestItemWeight": 1.0,
     ///        "regenHarvestSpotOnDestroy": false,
     ///        "harvestPOICategory": "NONE",
     ///        "harvestableType": "DREDGE",
     ///        "requiresAdvancedEquipment": false,
     ///        "harvestDifficulty": "HARD",
     ///        "canBeReplacedWithResearchItem": false,
     ///        "canBeCaughtByRod": false,
     ///        "canBeCaughtByPot": false,
     ///        "canBeCaughtByNet": false,
     ///        "affectedByFishingSustain": true,
     ///        "hasMinDepth": false,
     ///        "minDepth": "VERY_SHALLOW",
     ///        "hasMaxDepth": false,
     ///        "maxDepth": "VERY_SHALLOW",
     ///        "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///        "canBeSoldByPlayer": false,
     ///        "canBeSoldInBulkAction": false,
     ///        "value": 0.0,
     ///        "hasSellOverride": false,
     ///        "sellOverrideValue": 0.0,
     ///        "sprite": {
     ///
     ///        },
     ///        "platformSpecificSpriteOverrides": null,
     ///        "itemColor": {
     ///            "r": 0.227451,
     ///            "g": 0.1568628,
     ///            "b": 0.1254902,
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
     ///        "id": "quest-tablet-4",
     ///        "itemNameKey": [],
     ///        "itemDescriptionKey": [],
     ///        "hasAdditionalNote": false,
     ///        "additionalNoteKey": [],
     ///        "itemInsaneTitleKey": [],
     ///        "itemInsaneDescriptionKey": [],
     ///        "linkedDialogueNode": "",
     ///        "dialogueNodeSpecificDescription": [],
     ///        "itemType": "GENERAL,ALL",
     ///        "itemSubtype": "GENERAL,ALL",
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
     ///        "$type": "HarvestableItemData"
     ///    },
     ///    "itemsInThisBelongToPlayer": true,
     ///    "canAddItemsInQuestMode": true,
     ///    "hasUnderlay": false,
     ///    "columns": 2,
     ///    "rows": 2,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = LighthouseRuinDoorInstance.gridConfiguration;
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
     ///            "id": "quest-tablet-4"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = LighthouseRuinDoorInstance.presetGrid;
    public static PresetGridMode presetGridMode = PresetGridMode.MYSTERY;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "item": {
     ///                "harvestMinigameType": "DREDGE_RADIAL",
     ///                "perSpotMin": 1,
     ///                "perSpotMax": 1,
     ///                "harvestItemWeight": 1.0,
     ///                "regenHarvestSpotOnDestroy": false,
     ///                "harvestPOICategory": "NONE",
     ///                "harvestableType": "DREDGE",
     ///                "requiresAdvancedEquipment": false,
     ///                "harvestDifficulty": "HARD",
     ///                "canBeReplacedWithResearchItem": false,
     ///                "canBeCaughtByRod": false,
     ///                "canBeCaughtByPot": false,
     ///                "canBeCaughtByNet": false,
     ///                "affectedByFishingSustain": true,
     ///                "hasMinDepth": false,
     ///                "minDepth": "VERY_SHALLOW",
     ///                "hasMaxDepth": false,
     ///                "maxDepth": "VERY_SHALLOW",
     ///                "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                "canBeSoldByPlayer": false,
     ///                "canBeSoldInBulkAction": false,
     ///                "value": 0.0,
     ///                "hasSellOverride": false,
     ///                "sellOverrideValue": 0.0,
     ///                "sprite": {
     ///
     ///                },
     ///                "platformSpecificSpriteOverrides": null,
     ///                "itemColor": {
     ///                    "r": 0.227451,
     ///                    "g": 0.1568628,
     ///                    "b": 0.1254902,
     ///                    "a": 1.0
     ///                },
     ///                "hasSpecialDiscardAction": false,
     ///                "discardPromptOverride": "",
     ///                "canBeDiscardedByPlayer": false,
     ///                "showAlertOnDiscardHold": false,
     ///                "discardHoldTimeOverride": false,
     ///                "discardHoldTimeSec": 0.0,
     ///                "canBeDiscardedDuringQuestPickup": false,
     ///                "damageMode": "NONE",
     ///                "moveMode": "FREE",
     ///                "ignoreDamageWhenPlacing": false,
     ///                "isUnderlayItem": false,
     ///                "forbidStorageTray": true,
     ///                "dimensions": [
     ///                    {
     ///
     ///                    },
     ///                    {
     ///
     ///                    },
     ///                    {
     ///
     ///                    },
     ///                    {
     ///
     ///                    }
     ///                ],
     ///                "squishFactor": 0.0,
     ///                "itemOwnPrerequisites": [],
     ///                "researchPrerequisites": [],
     ///                "researchPointsRequired": 0,
     ///                "buyableWithoutResearch": false,
     ///                "researchIsForRecipe": false,
     ///                "useIntenseAberratedUIShader": false,
     ///                "id": "quest-tablet-4",
     ///                "itemNameKey": [],
     ///                "itemDescriptionKey": [],
     ///                "hasAdditionalNote": false,
     ///                "additionalNoteKey": [],
     ///                "itemInsaneTitleKey": [],
     ///                "itemInsaneDescriptionKey": [],
     ///                "linkedDialogueNode": "",
     ///                "dialogueNodeSpecificDescription": [],
     ///                "itemType": "GENERAL,ALL",
     ///                "itemSubtype": "GENERAL,ALL",
     ///                "tooltipTextColor": {
     ///                    "r": 0.4901961,
     ///                    "g": 0.3843137,
     ///                    "b": 0.2666667,
     ///                    "a": 1.0
     ///                },
     ///                "tooltipNotesColor": {
     ///                    "r": 1.0,
     ///                    "g": 1.0,
     ///                    "b": 1.0,
     ///                    "a": 1.0
     ///                },
     ///                "itemTypeIcon": {
     ///
     ///                },
     ///                "harvestParticlePrefab": {
     ///
     ///                },
     ///                "overrideHarvestParticleDepth": false,
     ///                "harvestParticleDepthOffset": -3.0,
     ///                "flattenParticleShape": false,
     ///                "availableInDemo": true,
     ///                "entitlementsRequired": [
     ///                    "NONE"
     ///                ],
     ///                "$type": "HarvestableItemData"
     ///            },
     ///            "count": 1,
     ///            "allowLinkedAberrations": false,
     ///            "$type": "ItemCountCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[CompletedGridCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = LighthouseRuinDoorInstance.completeConditions;
}

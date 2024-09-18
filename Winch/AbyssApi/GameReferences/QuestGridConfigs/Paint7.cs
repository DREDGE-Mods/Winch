namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class Paint7
{
    public static QuestGridConfig Paint7Instance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "Paint7");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.REVISITABLE;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = Paint7Instance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = Paint7Instance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = Paint7Instance.exitPromptOverride;
     ///<json>
     /// null
     /// </json>
    public static UnityEngine.Sprite backgroundImage = null;
    public static float gridHeightOverride = 0f;
    public static bool overrideGridCellColor = true;
    public static DredgeColorTypeEnum gridCellColor = DredgeColorTypeEnum.CRITICAL;
    public static bool allowStorageAccess = true;
    public static bool isSaved = true;
    public static bool createItemsIfEmpty = false;
    public static GridKey gridKey = GridKey.LM_PAINT_7;
    public static bool allowManualExit = true;
    public static bool allowEquipmentInstallation = false;
    public static bool createWithDurabilityValue = false;
    public static float startingDurabilityProportion = 1f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [
     ///        {
     ///            "cells": [],
     ///            "itemType": "",
     ///            "itemSubtype": "",
     ///            "isHidden": true,
     ///            "damageImmune": false
     ///        }
     ///    ],
     ///    "mainItemType": "GENERAL,ALL",
     ///    "mainItemSubtype": "FISH,ALL",
     ///    "mainItemData": null,
     ///    "itemsInThisBelongToPlayer": false,
     ///    "canAddItemsInQuestMode": true,
     ///    "hasUnderlay": false,
     ///    "columns": 4,
     ///    "rows": 3,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = Paint7Instance.gridConfiguration;
     ///<json>
     /// {
     ///    "spatialUnderlayItems": [],
     ///    "spatialItems": [
     ///        {
     ///            "x": 0,
     ///            "y": 2,
     ///            "z": 90,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "spider-crab-ab-1"
     ///        },
     ///        {
     ///            "x": 3,
     ///            "y": 2,
     ///            "z": 180,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "squat-lobster-ab-1"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = Paint7Instance.presetGrid;
    public static PresetGridMode presetGridMode = PresetGridMode.SILHOUETTE;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "item": {
     ///                "minSizeCentimeters": 60.0,
     ///                "maxSizeCentimeters": 150.0,
     ///                "aberrations": [],
     ///                "isAberration": true,
     ///                "nonAberrationParent": {
     ///                    "minSizeCentimeters": 60.0,
     ///                    "maxSizeCentimeters": 150.0,
     ///                    "aberrations": [
     ///                        {
     ///                            "$ref": "2"
     ///                        }
     ///                    ],
     ///                    "isAberration": false,
     ///                    "nonAberrationParent": null,
     ///                    "minWorldPhaseRequired": 0,
     ///                    "locationHiddenUntilCaught": false,
     ///                    "day": true,
     ///                    "night": true,
     ///                    "canAppearInBaitBalls": true,
     ///                    "questCompleteRequired": null,
     ///                    "baitChanceOverride": -1.0,
     ///                    "canBeInfected": true,
     ///                    "cellsExcludedFromDisplayingInfection": [],
     ///                    "rotCoefficient": 1.0,
     ///                    "tirPhase": 0,
     ///                    "harvestMinigameType": "FISHING_RADIAL",
     ///                    "perSpotMin": 1,
     ///                    "perSpotMax": 1,
     ///                    "harvestItemWeight": 8.0,
     ///                    "regenHarvestSpotOnDestroy": false,
     ///                    "harvestPOICategory": "NONE",
     ///                    "harvestableType": "CRAB",
     ///                    "requiresAdvancedEquipment": false,
     ///                    "harvestDifficulty": "VERY_EASY",
     ///                    "canBeReplacedWithResearchItem": true,
     ///                    "canBeCaughtByRod": false,
     ///                    "canBeCaughtByPot": true,
     ///                    "canBeCaughtByNet": false,
     ///                    "affectedByFishingSustain": true,
     ///                    "hasMinDepth": true,
     ///                    "minDepth": "VERY_SHALLOW",
     ///                    "hasMaxDepth": false,
     ///                    "maxDepth": "VERY_SHALLOW",
     ///                    "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                    "canBeSoldByPlayer": true,
     ///                    "canBeSoldInBulkAction": true,
     ///                    "value": 80.0,
     ///                    "hasSellOverride": false,
     ///                    "sellOverrideValue": 0.0,
     ///                    "sprite": {
     ///
     ///                    },
     ///                    "platformSpecificSpriteOverrides": null,
     ///                    "itemColor": {
     ///                        "r": 0.227451,
     ///                        "g": 0.1568628,
     ///                        "b": 0.1254902,
     ///                        "a": 255.0
     ///                    },
     ///                    "hasSpecialDiscardAction": false,
     ///                    "discardPromptOverride": "",
     ///                    "canBeDiscardedByPlayer": true,
     ///                    "showAlertOnDiscardHold": false,
     ///                    "discardHoldTimeOverride": false,
     ///                    "discardHoldTimeSec": 0.0,
     ///                    "canBeDiscardedDuringQuestPickup": true,
     ///                    "damageMode": "DESTROY",
     ///                    "moveMode": "FREE",
     ///                    "ignoreDamageWhenPlacing": false,
     ///                    "isUnderlayItem": false,
     ///                    "forbidStorageTray": false,
     ///                    "dimensions": [
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        }
     ///                    ],
     ///                    "squishFactor": 0.25,
     ///                    "itemOwnPrerequisites": [],
     ///                    "researchPrerequisites": [],
     ///                    "researchPointsRequired": 0,
     ///                    "buyableWithoutResearch": false,
     ///                    "researchIsForRecipe": false,
     ///                    "useIntenseAberratedUIShader": false,
     ///                    "id": "spider-crab",
     ///                    "itemNameKey": [],
     ///                    "itemDescriptionKey": [],
     ///                    "hasAdditionalNote": false,
     ///                    "additionalNoteKey": [],
     ///                    "itemInsaneTitleKey": [],
     ///                    "itemInsaneDescriptionKey": [],
     ///                    "linkedDialogueNode": "",
     ///                    "dialogueNodeSpecificDescription": [],
     ///                    "itemType": "GENERAL,ALL",
     ///                    "itemSubtype": "FISH,ALL",
     ///                    "tooltipTextColor": {
     ///                        "r": 0.4901961,
     ///                        "g": 0.3843137,
     ///                        "b": 0.2666667,
     ///                        "a": 1.0
     ///                    },
     ///                    "tooltipNotesColor": {
     ///                        "r": 1.0,
     ///                        "g": 1.0,
     ///                        "b": 1.0,
     ///                        "a": 1.0
     ///                    },
     ///                    "itemTypeIcon": {
     ///                        "$id": "17"
     ///                    },
     ///                    "harvestParticlePrefab": {
     ///                        "$id": "18"
     ///                    },
     ///                    "overrideHarvestParticleDepth": false,
     ///                    "harvestParticleDepthOffset": -3.0,
     ///                    "flattenParticleShape": false,
     ///                    "availableInDemo": true,
     ///                    "entitlementsRequired": [
     ///                        "NONE"
     ///                    ]
     ///                },
     ///                "minWorldPhaseRequired": 0,
     ///                "locationHiddenUntilCaught": false,
     ///                "day": true,
     ///                "night": true,
     ///                "canAppearInBaitBalls": true,
     ///                "questCompleteRequired": null,
     ///                "baitChanceOverride": -1.0,
     ///                "canBeInfected": true,
     ///                "cellsExcludedFromDisplayingInfection": [],
     ///                "rotCoefficient": 1.0,
     ///                "tirPhase": 0,
     ///                "harvestMinigameType": "FISHING_RADIAL",
     ///                "perSpotMin": 1,
     ///                "perSpotMax": 1,
     ///                "harvestItemWeight": 8.0,
     ///                "regenHarvestSpotOnDestroy": false,
     ///                "harvestPOICategory": "NONE",
     ///                "harvestableType": "CRAB",
     ///                "requiresAdvancedEquipment": false,
     ///                "harvestDifficulty": "VERY_EASY",
     ///                "canBeReplacedWithResearchItem": true,
     ///                "canBeCaughtByRod": false,
     ///                "canBeCaughtByPot": true,
     ///                "canBeCaughtByNet": false,
     ///                "affectedByFishingSustain": true,
     ///                "hasMinDepth": true,
     ///                "minDepth": "VERY_SHALLOW",
     ///                "hasMaxDepth": false,
     ///                "maxDepth": "VERY_SHALLOW",
     ///                "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                "canBeSoldByPlayer": true,
     ///                "canBeSoldInBulkAction": true,
     ///                "value": 135.0,
     ///                "hasSellOverride": false,
     ///                "sellOverrideValue": 0.0,
     ///                "sprite": {
     ///
     ///                },
     ///                "platformSpecificSpriteOverrides": null,
     ///                "itemColor": {
     ///                    "r": 0.5333334,
     ///                    "g": 0.0,
     ///                    "b": 0.2980392,
     ///                    "a": 1.0
     ///                },
     ///                "hasSpecialDiscardAction": false,
     ///                "discardPromptOverride": "",
     ///                "canBeDiscardedByPlayer": true,
     ///                "showAlertOnDiscardHold": false,
     ///                "discardHoldTimeOverride": false,
     ///                "discardHoldTimeSec": 0.0,
     ///                "canBeDiscardedDuringQuestPickup": true,
     ///                "damageMode": "DESTROY",
     ///                "moveMode": "FREE",
     ///                "ignoreDamageWhenPlacing": false,
     ///                "isUnderlayItem": false,
     ///                "forbidStorageTray": false,
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
     ///                "squishFactor": 0.25,
     ///                "itemOwnPrerequisites": [],
     ///                "researchPrerequisites": [],
     ///                "researchPointsRequired": 0,
     ///                "buyableWithoutResearch": false,
     ///                "researchIsForRecipe": false,
     ///                "useIntenseAberratedUIShader": false,
     ///                "id": "spider-crab-ab-1",
     ///                "itemNameKey": [],
     ///                "itemDescriptionKey": [],
     ///                "hasAdditionalNote": false,
     ///                "additionalNoteKey": [],
     ///                "itemInsaneTitleKey": [],
     ///                "itemInsaneDescriptionKey": [],
     ///                "linkedDialogueNode": "",
     ///                "dialogueNodeSpecificDescription": [],
     ///                "itemType": "GENERAL,ALL",
     ///                "itemSubtype": "FISH,ALL",
     ///                "tooltipTextColor": {
     ///                    "r": 0.5333334,
     ///                    "g": 0.0,
     ///                    "b": 0.2980392,
     ///                    "a": 1.0
     ///                },
     ///                "tooltipNotesColor": {
     ///                    "r": 1.0,
     ///                    "g": 1.0,
     ///                    "b": 1.0,
     ///                    "a": 1.0
     ///                },
     ///                "itemTypeIcon": {
     ///                    "$ref": "17"
     ///                },
     ///                "harvestParticlePrefab": {
     ///                    "$ref": "18"
     ///                },
     ///                "overrideHarvestParticleDepth": false,
     ///                "harvestParticleDepthOffset": -3.0,
     ///                "flattenParticleShape": false,
     ///                "availableInDemo": true,
     ///                "entitlementsRequired": [
     ///                    "NONE"
     ///                ],
     ///                "$type": "FishItemData",
     ///                "$id": "2"
     ///            },
     ///            "count": 1,
     ///            "allowLinkedAberrations": false,
     ///            "$type": "ItemCountCondition"
     ///        },
     ///        {
     ///            "item": {
     ///                "minSizeCentimeters": 20.0,
     ///                "maxSizeCentimeters": 60.0,
     ///                "aberrations": [],
     ///                "isAberration": true,
     ///                "nonAberrationParent": {
     ///                    "minSizeCentimeters": 20.0,
     ///                    "maxSizeCentimeters": 60.0,
     ///                    "aberrations": [
     ///                        {
     ///                            "$ref": "33"
     ///                        }
     ///                    ],
     ///                    "isAberration": false,
     ///                    "nonAberrationParent": null,
     ///                    "minWorldPhaseRequired": 0,
     ///                    "locationHiddenUntilCaught": false,
     ///                    "day": true,
     ///                    "night": true,
     ///                    "canAppearInBaitBalls": true,
     ///                    "questCompleteRequired": null,
     ///                    "baitChanceOverride": -1.0,
     ///                    "canBeInfected": true,
     ///                    "cellsExcludedFromDisplayingInfection": [],
     ///                    "rotCoefficient": 1.0,
     ///                    "tirPhase": 0,
     ///                    "harvestMinigameType": "FISHING_RADIAL",
     ///                    "perSpotMin": 1,
     ///                    "perSpotMax": 1,
     ///                    "harvestItemWeight": 8.0,
     ///                    "regenHarvestSpotOnDestroy": false,
     ///                    "harvestPOICategory": "NONE",
     ///                    "harvestableType": "CRAB",
     ///                    "requiresAdvancedEquipment": false,
     ///                    "harvestDifficulty": "EASY",
     ///                    "canBeReplacedWithResearchItem": true,
     ///                    "canBeCaughtByRod": false,
     ///                    "canBeCaughtByPot": true,
     ///                    "canBeCaughtByNet": false,
     ///                    "affectedByFishingSustain": true,
     ///                    "hasMinDepth": false,
     ///                    "minDepth": "VERY_SHALLOW",
     ///                    "hasMaxDepth": true,
     ///                    "maxDepth": "MEDIUM",
     ///                    "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                    "canBeSoldByPlayer": true,
     ///                    "canBeSoldInBulkAction": true,
     ///                    "value": 45.0,
     ///                    "hasSellOverride": false,
     ///                    "sellOverrideValue": 0.0,
     ///                    "sprite": {
     ///
     ///                    },
     ///                    "platformSpecificSpriteOverrides": null,
     ///                    "itemColor": {
     ///                        "r": 0.2264151,
     ///                        "g": 0.1562912,
     ///                        "b": 0.1249555,
     ///                        "a": 255.0
     ///                    },
     ///                    "hasSpecialDiscardAction": false,
     ///                    "discardPromptOverride": "",
     ///                    "canBeDiscardedByPlayer": true,
     ///                    "showAlertOnDiscardHold": false,
     ///                    "discardHoldTimeOverride": false,
     ///                    "discardHoldTimeSec": 0.0,
     ///                    "canBeDiscardedDuringQuestPickup": true,
     ///                    "damageMode": "DESTROY",
     ///                    "moveMode": "FREE",
     ///                    "ignoreDamageWhenPlacing": false,
     ///                    "isUnderlayItem": false,
     ///                    "forbidStorageTray": false,
     ///                    "dimensions": [
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        },
     ///                        {
     ///
     ///                        }
     ///                    ],
     ///                    "squishFactor": 0.25,
     ///                    "itemOwnPrerequisites": [],
     ///                    "researchPrerequisites": [],
     ///                    "researchPointsRequired": 0,
     ///                    "buyableWithoutResearch": false,
     ///                    "researchIsForRecipe": false,
     ///                    "useIntenseAberratedUIShader": false,
     ///                    "id": "squat-lobster",
     ///                    "itemNameKey": [],
     ///                    "itemDescriptionKey": [],
     ///                    "hasAdditionalNote": false,
     ///                    "additionalNoteKey": [],
     ///                    "itemInsaneTitleKey": [],
     ///                    "itemInsaneDescriptionKey": [],
     ///                    "linkedDialogueNode": "",
     ///                    "dialogueNodeSpecificDescription": [],
     ///                    "itemType": "GENERAL,ALL",
     ///                    "itemSubtype": "FISH,ALL",
     ///                    "tooltipTextColor": {
     ///                        "r": 0.4901961,
     ///                        "g": 0.3843137,
     ///                        "b": 0.2666667,
     ///                        "a": 1.0
     ///                    },
     ///                    "tooltipNotesColor": {
     ///                        "r": 1.0,
     ///                        "g": 1.0,
     ///                        "b": 1.0,
     ///                        "a": 1.0
     ///                    },
     ///                    "itemTypeIcon": {
     ///                        "$ref": "17"
     ///                    },
     ///                    "harvestParticlePrefab": {
     ///                        "$ref": "18"
     ///                    },
     ///                    "overrideHarvestParticleDepth": false,
     ///                    "harvestParticleDepthOffset": -3.0,
     ///                    "flattenParticleShape": false,
     ///                    "availableInDemo": true,
     ///                    "entitlementsRequired": [
     ///                        "NONE"
     ///                    ]
     ///                },
     ///                "minWorldPhaseRequired": 0,
     ///                "locationHiddenUntilCaught": false,
     ///                "day": true,
     ///                "night": true,
     ///                "canAppearInBaitBalls": true,
     ///                "questCompleteRequired": null,
     ///                "baitChanceOverride": -1.0,
     ///                "canBeInfected": true,
     ///                "cellsExcludedFromDisplayingInfection": [],
     ///                "rotCoefficient": 1.0,
     ///                "tirPhase": 0,
     ///                "harvestMinigameType": "FISHING_RADIAL",
     ///                "perSpotMin": 1,
     ///                "perSpotMax": 1,
     ///                "harvestItemWeight": 8.0,
     ///                "regenHarvestSpotOnDestroy": false,
     ///                "harvestPOICategory": "NONE",
     ///                "harvestableType": "CRAB",
     ///                "requiresAdvancedEquipment": false,
     ///                "harvestDifficulty": "EASY",
     ///                "canBeReplacedWithResearchItem": true,
     ///                "canBeCaughtByRod": false,
     ///                "canBeCaughtByPot": true,
     ///                "canBeCaughtByNet": false,
     ///                "affectedByFishingSustain": true,
     ///                "hasMinDepth": false,
     ///                "minDepth": "VERY_SHALLOW",
     ///                "hasMaxDepth": true,
     ///                "maxDepth": "MEDIUM",
     ///                "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                "canBeSoldByPlayer": true,
     ///                "canBeSoldInBulkAction": true,
     ///                "value": 100.0,
     ///                "hasSellOverride": false,
     ///                "sellOverrideValue": 0.0,
     ///                "sprite": {
     ///
     ///                },
     ///                "platformSpecificSpriteOverrides": null,
     ///                "itemColor": {
     ///                    "r": 0.5333334,
     ///                    "g": 0.0,
     ///                    "b": 0.2980392,
     ///                    "a": 1.0
     ///                },
     ///                "hasSpecialDiscardAction": false,
     ///                "discardPromptOverride": "",
     ///                "canBeDiscardedByPlayer": true,
     ///                "showAlertOnDiscardHold": false,
     ///                "discardHoldTimeOverride": false,
     ///                "discardHoldTimeSec": 0.0,
     ///                "canBeDiscardedDuringQuestPickup": true,
     ///                "damageMode": "DESTROY",
     ///                "moveMode": "FREE",
     ///                "ignoreDamageWhenPlacing": false,
     ///                "isUnderlayItem": false,
     ///                "forbidStorageTray": false,
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
     ///                    },
     ///                    {
     ///
     ///                    }
     ///                ],
     ///                "squishFactor": 0.25,
     ///                "itemOwnPrerequisites": [],
     ///                "researchPrerequisites": [],
     ///                "researchPointsRequired": 0,
     ///                "buyableWithoutResearch": false,
     ///                "researchIsForRecipe": false,
     ///                "useIntenseAberratedUIShader": false,
     ///                "id": "squat-lobster-ab-1",
     ///                "itemNameKey": [],
     ///                "itemDescriptionKey": [],
     ///                "hasAdditionalNote": false,
     ///                "additionalNoteKey": [],
     ///                "itemInsaneTitleKey": [],
     ///                "itemInsaneDescriptionKey": [],
     ///                "linkedDialogueNode": "",
     ///                "dialogueNodeSpecificDescription": [],
     ///                "itemType": "GENERAL,ALL",
     ///                "itemSubtype": "FISH,ALL",
     ///                "tooltipTextColor": {
     ///                    "r": 0.5333334,
     ///                    "g": 0.0,
     ///                    "b": 0.2980392,
     ///                    "a": 1.0
     ///                },
     ///                "tooltipNotesColor": {
     ///                    "r": 1.0,
     ///                    "g": 1.0,
     ///                    "b": 1.0,
     ///                    "a": 1.0
     ///                },
     ///                "itemTypeIcon": {
     ///                    "$ref": "17"
     ///                },
     ///                "harvestParticlePrefab": {
     ///                    "$ref": "18"
     ///                },
     ///                "overrideHarvestParticleDepth": false,
     ///                "harvestParticleDepthOffset": -3.0,
     ///                "flattenParticleShape": false,
     ///                "availableInDemo": true,
     ///                "entitlementsRequired": [
     ///                    "NONE"
     ///                ],
     ///                "$type": "FishItemData",
     ///                "$id": "33"
     ///            },
     ///            "count": 1,
     ///            "allowLinkedAberrations": false,
     ///            "$type": "ItemCountCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[CompletedGridCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = Paint7Instance.completeConditions;
}

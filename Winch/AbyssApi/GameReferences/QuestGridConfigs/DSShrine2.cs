namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class DSShrine2
{
    public static QuestGridConfig DSShrine2Instance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "DSShrine2");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.REVISITABLE;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = DSShrine2Instance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = DSShrine2Instance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = DSShrine2Instance.exitPromptOverride;
     ///<json>
     /// null
     /// </json>
    public static UnityEngine.Sprite backgroundImage = null;
    public static float gridHeightOverride = 0f;
    public static bool overrideGridCellColor = false;
    public static DredgeColorTypeEnum gridCellColor = DredgeColorTypeEnum.NEUTRAL;
    public static bool allowStorageAccess = false;
    public static bool isSaved = true;
    public static bool createItemsIfEmpty = false;
    public static GridKey gridKey = GridKey.SHRINE_DS_2;
    public static bool allowManualExit = true;
    public static bool allowEquipmentInstallation = false;
    public static bool createWithDurabilityValue = false;
    public static float startingDurabilityProportion = 1f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [
     ///        {
     ///            "cells": [
     ///                {
     ///
     ///                }
     ///            ],
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
     ///    "columns": 5,
     ///    "rows": 2,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = DSShrine2Instance.gridConfiguration;
     ///<json>
     /// {
     ///    "spatialUnderlayItems": [],
     ///    "spatialItems": [
     ///        {
     ///            "x": 2,
     ///            "y": 0,
     ///            "z": 0,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "ghost-shark"
     ///        },
     ///        {
     ///            "x": 2,
     ///            "y": 0,
     ///            "z": 270,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "pale-skate"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = DSShrine2Instance.presetGrid;
    public static PresetGridMode presetGridMode = PresetGridMode.MYSTERY;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "item": {
     ///                "minSizeCentimeters": 60.0,
     ///                "maxSizeCentimeters": 140.0,
     ///                "aberrations": [
     ///                    {
     ///                        "minSizeCentimeters": 60.0,
     ///                        "maxSizeCentimeters": 140.0,
     ///                        "aberrations": [],
     ///                        "isAberration": true,
     ///                        "nonAberrationParent": {
     ///                            "$ref": "2"
     ///                        },
     ///                        "minWorldPhaseRequired": 0,
     ///                        "locationHiddenUntilCaught": false,
     ///                        "day": true,
     ///                        "night": true,
     ///                        "canAppearInBaitBalls": true,
     ///                        "questCompleteRequired": null,
     ///                        "baitChanceOverride": -1.0,
     ///                        "canBeInfected": true,
     ///                        "cellsExcludedFromDisplayingInfection": [],
     ///                        "rotCoefficient": 1.0,
     ///                        "tirPhase": 0,
     ///                        "harvestMinigameType": "FISHING_DIAMOND",
     ///                        "perSpotMin": 1,
     ///                        "perSpotMax": 2,
     ///                        "harvestItemWeight": 1.0,
     ///                        "regenHarvestSpotOnDestroy": false,
     ///                        "harvestPOICategory": "FISH_LARGE",
     ///                        "harvestableType": "ABYSSAL",
     ///                        "requiresAdvancedEquipment": false,
     ///                        "harvestDifficulty": "HARD",
     ///                        "canBeReplacedWithResearchItem": false,
     ///                        "canBeCaughtByRod": true,
     ///                        "canBeCaughtByPot": false,
     ///                        "canBeCaughtByNet": false,
     ///                        "affectedByFishingSustain": true,
     ///                        "hasMinDepth": false,
     ///                        "minDepth": "MEDIUM",
     ///                        "hasMaxDepth": false,
     ///                        "maxDepth": null,
     ///                        "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                        "canBeSoldByPlayer": true,
     ///                        "canBeSoldInBulkAction": true,
     ///                        "value": 120.0,
     ///                        "hasSellOverride": false,
     ///                        "sellOverrideValue": 0.0,
     ///                        "sprite": {
     ///
     ///                        },
     ///                        "platformSpecificSpriteOverrides": null,
     ///                        "itemColor": {
     ///                            "r": 0.5333334,
     ///                            "g": 0.0,
     ///                            "b": 0.2980392,
     ///                            "a": 1.0
     ///                        },
     ///                        "hasSpecialDiscardAction": false,
     ///                        "discardPromptOverride": "",
     ///                        "canBeDiscardedByPlayer": true,
     ///                        "showAlertOnDiscardHold": false,
     ///                        "discardHoldTimeOverride": false,
     ///                        "discardHoldTimeSec": 0.0,
     ///                        "canBeDiscardedDuringQuestPickup": true,
     ///                        "damageMode": "DESTROY",
     ///                        "moveMode": "FREE",
     ///                        "ignoreDamageWhenPlacing": false,
     ///                        "isUnderlayItem": false,
     ///                        "forbidStorageTray": false,
     ///                        "dimensions": [
     ///                            {
     ///
     ///                            },
     ///                            {
     ///
     ///                            },
     ///                            {
     ///
     ///                            },
     ///                            {
     ///
     ///                            }
     ///                        ],
     ///                        "squishFactor": 1.0,
     ///                        "itemOwnPrerequisites": [],
     ///                        "researchPrerequisites": [],
     ///                        "researchPointsRequired": 0,
     ///                        "buyableWithoutResearch": false,
     ///                        "researchIsForRecipe": false,
     ///                        "useIntenseAberratedUIShader": false,
     ///                        "id": "ghost-shark-ab-1",
     ///                        "itemNameKey": [],
     ///                        "itemDescriptionKey": [],
     ///                        "hasAdditionalNote": false,
     ///                        "additionalNoteKey": [],
     ///                        "itemInsaneTitleKey": [],
     ///                        "itemInsaneDescriptionKey": [],
     ///                        "linkedDialogueNode": "",
     ///                        "dialogueNodeSpecificDescription": [],
     ///                        "itemType": "GENERAL,ALL",
     ///                        "itemSubtype": "FISH,ALL",
     ///                        "tooltipTextColor": {
     ///                            "r": 0.5333334,
     ///                            "g": 0.0,
     ///                            "b": 0.2980392,
     ///                            "a": 1.0
     ///                        },
     ///                        "tooltipNotesColor": {
     ///                            "r": 1.0,
     ///                            "g": 1.0,
     ///                            "b": 1.0,
     ///                            "a": 1.0
     ///                        },
     ///                        "itemTypeIcon": {
     ///                            "$id": "17"
     ///                        },
     ///                        "harvestParticlePrefab": {
     ///                            "$id": "18"
     ///                        },
     ///                        "overrideHarvestParticleDepth": false,
     ///                        "harvestParticleDepthOffset": -3.0,
     ///                        "flattenParticleShape": false,
     ///                        "availableInDemo": true,
     ///                        "entitlementsRequired": [
     ///                            "NONE"
     ///                        ]
     ///                    }
     ///                ],
     ///                "isAberration": false,
     ///                "nonAberrationParent": null,
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
     ///                "harvestMinigameType": "FISHING_DIAMOND",
     ///                "perSpotMin": 1,
     ///                "perSpotMax": 2,
     ///                "harvestItemWeight": 1.0,
     ///                "regenHarvestSpotOnDestroy": false,
     ///                "harvestPOICategory": "FISH_LARGE",
     ///                "harvestableType": "ABYSSAL",
     ///                "requiresAdvancedEquipment": false,
     ///                "harvestDifficulty": "HARD",
     ///                "canBeReplacedWithResearchItem": false,
     ///                "canBeCaughtByRod": true,
     ///                "canBeCaughtByPot": false,
     ///                "canBeCaughtByNet": false,
     ///                "affectedByFishingSustain": true,
     ///                "hasMinDepth": false,
     ///                "minDepth": "MEDIUM",
     ///                "hasMaxDepth": false,
     ///                "maxDepth": null,
     ///                "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                "canBeSoldByPlayer": true,
     ///                "canBeSoldInBulkAction": true,
     ///                "value": 50.0,
     ///                "hasSellOverride": false,
     ///                "sellOverrideValue": 0.0,
     ///                "sprite": {
     ///
     ///                },
     ///                "platformSpecificSpriteOverrides": null,
     ///                "itemColor": {
     ///                    "r": 0.2264151,
     ///                    "g": 0.1562912,
     ///                    "b": 0.1249555,
     ///                    "a": 255.0
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
     ///                    }
     ///                ],
     ///                "squishFactor": 1.0,
     ///                "itemOwnPrerequisites": [],
     ///                "researchPrerequisites": [],
     ///                "researchPointsRequired": 0,
     ///                "buyableWithoutResearch": false,
     ///                "researchIsForRecipe": false,
     ///                "useIntenseAberratedUIShader": false,
     ///                "id": "ghost-shark",
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
     ///            "allowLinkedAberrations": true,
     ///            "$type": "ItemCountCondition"
     ///        },
     ///        {
     ///            "item": {
     ///                "minSizeCentimeters": 50.0,
     ///                "maxSizeCentimeters": 120.0,
     ///                "aberrations": [
     ///                    {
     ///                        "minSizeCentimeters": 50.0,
     ///                        "maxSizeCentimeters": 120.0,
     ///                        "aberrations": [],
     ///                        "isAberration": true,
     ///                        "nonAberrationParent": {
     ///                            "$ref": "33"
     ///                        },
     ///                        "minWorldPhaseRequired": 0,
     ///                        "locationHiddenUntilCaught": false,
     ///                        "day": true,
     ///                        "night": false,
     ///                        "canAppearInBaitBalls": true,
     ///                        "questCompleteRequired": null,
     ///                        "baitChanceOverride": -1.0,
     ///                        "canBeInfected": true,
     ///                        "cellsExcludedFromDisplayingInfection": [],
     ///                        "rotCoefficient": 1.0,
     ///                        "tirPhase": 0,
     ///                        "harvestMinigameType": "FISHING_PENDULUM",
     ///                        "perSpotMin": 2,
     ///                        "perSpotMax": 3,
     ///                        "harvestItemWeight": 2.0,
     ///                        "regenHarvestSpotOnDestroy": false,
     ///                        "harvestPOICategory": "FISH_MEDIUM",
     ///                        "harvestableType": "VOLCANIC",
     ///                        "requiresAdvancedEquipment": false,
     ///                        "harvestDifficulty": "HARD",
     ///                        "canBeReplacedWithResearchItem": false,
     ///                        "canBeCaughtByRod": true,
     ///                        "canBeCaughtByPot": false,
     ///                        "canBeCaughtByNet": true,
     ///                        "affectedByFishingSustain": true,
     ///                        "hasMinDepth": true,
     ///                        "minDepth": "SHALLOW",
     ///                        "hasMaxDepth": false,
     ///                        "maxDepth": null,
     ///                        "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                        "canBeSoldByPlayer": true,
     ///                        "canBeSoldInBulkAction": true,
     ///                        "value": 135.0,
     ///                        "hasSellOverride": false,
     ///                        "sellOverrideValue": 0.0,
     ///                        "sprite": {
     ///
     ///                        },
     ///                        "platformSpecificSpriteOverrides": null,
     ///                        "itemColor": {
     ///                            "r": 0.5333334,
     ///                            "g": 0.0,
     ///                            "b": 0.2980392,
     ///                            "a": 1.0
     ///                        },
     ///                        "hasSpecialDiscardAction": false,
     ///                        "discardPromptOverride": "",
     ///                        "canBeDiscardedByPlayer": true,
     ///                        "showAlertOnDiscardHold": false,
     ///                        "discardHoldTimeOverride": false,
     ///                        "discardHoldTimeSec": 0.0,
     ///                        "canBeDiscardedDuringQuestPickup": true,
     ///                        "damageMode": "DESTROY",
     ///                        "moveMode": "FREE",
     ///                        "ignoreDamageWhenPlacing": false,
     ///                        "isUnderlayItem": false,
     ///                        "forbidStorageTray": false,
     ///                        "dimensions": [
     ///                            {
     ///
     ///                            },
     ///                            {
     ///
     ///                            },
     ///                            {
     ///
     ///                            },
     ///                            {
     ///
     ///                            },
     ///                            {
     ///
     ///                            }
     ///                        ],
     ///                        "squishFactor": 1.0,
     ///                        "itemOwnPrerequisites": [],
     ///                        "researchPrerequisites": [],
     ///                        "researchPointsRequired": 0,
     ///                        "buyableWithoutResearch": false,
     ///                        "researchIsForRecipe": false,
     ///                        "useIntenseAberratedUIShader": false,
     ///                        "id": "pale-skate-ab-1",
     ///                        "itemNameKey": [],
     ///                        "itemDescriptionKey": [],
     ///                        "hasAdditionalNote": false,
     ///                        "additionalNoteKey": [],
     ///                        "itemInsaneTitleKey": [],
     ///                        "itemInsaneDescriptionKey": [],
     ///                        "linkedDialogueNode": "",
     ///                        "dialogueNodeSpecificDescription": [],
     ///                        "itemType": "GENERAL,ALL",
     ///                        "itemSubtype": "FISH,ALL",
     ///                        "tooltipTextColor": {
     ///                            "r": 0.5333334,
     ///                            "g": 0.0,
     ///                            "b": 0.2980392,
     ///                            "a": 1.0
     ///                        },
     ///                        "tooltipNotesColor": {
     ///                            "r": 1.0,
     ///                            "g": 1.0,
     ///                            "b": 1.0,
     ///                            "a": 1.0
     ///                        },
     ///                        "itemTypeIcon": {
     ///                            "$ref": "17"
     ///                        },
     ///                        "harvestParticlePrefab": {
     ///                            "$id": "48"
     ///                        },
     ///                        "overrideHarvestParticleDepth": false,
     ///                        "harvestParticleDepthOffset": -3.0,
     ///                        "flattenParticleShape": false,
     ///                        "availableInDemo": true,
     ///                        "entitlementsRequired": [
     ///                            "NONE"
     ///                        ]
     ///                    }
     ///                ],
     ///                "isAberration": false,
     ///                "nonAberrationParent": null,
     ///                "minWorldPhaseRequired": 0,
     ///                "locationHiddenUntilCaught": false,
     ///                "day": true,
     ///                "night": false,
     ///                "canAppearInBaitBalls": true,
     ///                "questCompleteRequired": null,
     ///                "baitChanceOverride": -1.0,
     ///                "canBeInfected": true,
     ///                "cellsExcludedFromDisplayingInfection": [],
     ///                "rotCoefficient": 1.0,
     ///                "tirPhase": 0,
     ///                "harvestMinigameType": "FISHING_PENDULUM",
     ///                "perSpotMin": 2,
     ///                "perSpotMax": 3,
     ///                "harvestItemWeight": 2.0,
     ///                "regenHarvestSpotOnDestroy": false,
     ///                "harvestPOICategory": "FISH_MEDIUM",
     ///                "harvestableType": "VOLCANIC",
     ///                "requiresAdvancedEquipment": false,
     ///                "harvestDifficulty": "HARD",
     ///                "canBeReplacedWithResearchItem": false,
     ///                "canBeCaughtByRod": true,
     ///                "canBeCaughtByPot": false,
     ///                "canBeCaughtByNet": true,
     ///                "affectedByFishingSustain": true,
     ///                "hasMinDepth": true,
     ///                "minDepth": "SHALLOW",
     ///                "hasMaxDepth": false,
     ///                "maxDepth": null,
     ///                "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                "canBeSoldByPlayer": true,
     ///                "canBeSoldInBulkAction": true,
     ///                "value": 55.0,
     ///                "hasSellOverride": false,
     ///                "sellOverrideValue": 0.0,
     ///                "sprite": {
     ///
     ///                },
     ///                "platformSpecificSpriteOverrides": null,
     ///                "itemColor": {
     ///                    "r": 0.2264151,
     ///                    "g": 0.1562912,
     ///                    "b": 0.1249555,
     ///                    "a": 255.0
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
     ///                "squishFactor": 1.0,
     ///                "itemOwnPrerequisites": [],
     ///                "researchPrerequisites": [],
     ///                "researchPointsRequired": 0,
     ///                "buyableWithoutResearch": false,
     ///                "researchIsForRecipe": false,
     ///                "useIntenseAberratedUIShader": false,
     ///                "id": "pale-skate",
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
     ///                    "$ref": "17"
     ///                },
     ///                "harvestParticlePrefab": {
     ///                    "$ref": "48"
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
     ///            "allowLinkedAberrations": true,
     ///            "$type": "ItemCountCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[CompletedGridCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = DSShrine2Instance.completeConditions;
}

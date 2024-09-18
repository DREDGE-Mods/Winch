namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class Fishmonger_Delivery2
{
    public static QuestGridConfig Fishmonger_Delivery2Instance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "Fishmonger_Delivery2");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.REVISITABLE;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = Fishmonger_Delivery2Instance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = Fishmonger_Delivery2Instance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = Fishmonger_Delivery2Instance.exitPromptOverride;
     ///<json>
     /// null
     /// </json>
    public static UnityEngine.Sprite backgroundImage = null;
    public static float gridHeightOverride = 0f;
    public static bool overrideGridCellColor = false;
    public static DredgeColorTypeEnum gridCellColor = DredgeColorTypeEnum.NEUTRAL;
    public static bool allowStorageAccess = true;
    public static bool isSaved = true;
    public static bool createItemsIfEmpty = false;
    public static GridKey gridKey = GridKey.GM_FISHMONGER_DELIVERY_2;
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
     ///    "columns": 2,
     ///    "rows": 4,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = Fishmonger_Delivery2Instance.gridConfiguration;
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
     ///            "id": "black-grouper"
     ///        },
     ///        {
     ///            "x": 0,
     ///            "y": 2,
     ///            "z": 0,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "squid"
     ///        },
     ///        {
     ///            "x": 0,
     ///            "y": 3,
     ///            "z": 0,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "squid"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = Fishmonger_Delivery2Instance.presetGrid;
    public static PresetGridMode presetGridMode = PresetGridMode.SILHOUETTE;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "item": {
     ///                "minSizeCentimeters": 15.0,
     ///                "maxSizeCentimeters": 35.0,
     ///                "aberrations": [
     ///                    {
     ///                        "minSizeCentimeters": 15.0,
     ///                        "maxSizeCentimeters": 35.0,
     ///                        "aberrations": [],
     ///                        "isAberration": true,
     ///                        "nonAberrationParent": {
     ///                            "$ref": "2"
     ///                        },
     ///                        "minWorldPhaseRequired": 0,
     ///                        "locationHiddenUntilCaught": false,
     ///                        "day": false,
     ///                        "night": true,
     ///                        "canAppearInBaitBalls": true,
     ///                        "questCompleteRequired": null,
     ///                        "baitChanceOverride": -1.0,
     ///                        "canBeInfected": true,
     ///                        "cellsExcludedFromDisplayingInfection": [],
     ///                        "rotCoefficient": 1.0,
     ///                        "tirPhase": 0,
     ///                        "harvestMinigameType": "FISHING_PENDULUM",
     ///                        "perSpotMin": 3,
     ///                        "perSpotMax": 6,
     ///                        "harvestItemWeight": 1.0,
     ///                        "regenHarvestSpotOnDestroy": false,
     ///                        "harvestPOICategory": "NONE",
     ///                        "harvestableType": "COASTAL",
     ///                        "requiresAdvancedEquipment": false,
     ///                        "harvestDifficulty": "VERY_EASY",
     ///                        "canBeReplacedWithResearchItem": false,
     ///                        "canBeCaughtByRod": true,
     ///                        "canBeCaughtByPot": false,
     ///                        "canBeCaughtByNet": true,
     ///                        "affectedByFishingSustain": true,
     ///                        "hasMinDepth": false,
     ///                        "minDepth": "MEDIUM",
     ///                        "hasMaxDepth": false,
     ///                        "maxDepth": null,
     ///                        "zonesFoundIn": "THE_MARROWS,ALL",
     ///                        "canBeSoldByPlayer": true,
     ///                        "canBeSoldInBulkAction": true,
     ///                        "value": 32.0,
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
     ///                            }
     ///                        ],
     ///                        "squishFactor": 1.0,
     ///                        "itemOwnPrerequisites": [],
     ///                        "researchPrerequisites": [],
     ///                        "researchPointsRequired": 0,
     ///                        "buyableWithoutResearch": false,
     ///                        "researchIsForRecipe": false,
     ///                        "useIntenseAberratedUIShader": false,
     ///                        "id": "squid-ab-1",
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
     ///                    },
     ///                    {
     ///                        "minSizeCentimeters": 15.0,
     ///                        "maxSizeCentimeters": 35.0,
     ///                        "aberrations": [],
     ///                        "isAberration": true,
     ///                        "nonAberrationParent": {
     ///                            "$ref": "2"
     ///                        },
     ///                        "minWorldPhaseRequired": 1,
     ///                        "locationHiddenUntilCaught": false,
     ///                        "day": false,
     ///                        "night": true,
     ///                        "canAppearInBaitBalls": true,
     ///                        "questCompleteRequired": null,
     ///                        "baitChanceOverride": -1.0,
     ///                        "canBeInfected": true,
     ///                        "cellsExcludedFromDisplayingInfection": [],
     ///                        "rotCoefficient": 1.0,
     ///                        "tirPhase": 0,
     ///                        "harvestMinigameType": "FISHING_PENDULUM",
     ///                        "perSpotMin": 3,
     ///                        "perSpotMax": 6,
     ///                        "harvestItemWeight": 1.0,
     ///                        "regenHarvestSpotOnDestroy": false,
     ///                        "harvestPOICategory": "NONE",
     ///                        "harvestableType": "COASTAL",
     ///                        "requiresAdvancedEquipment": false,
     ///                        "harvestDifficulty": "VERY_EASY",
     ///                        "canBeReplacedWithResearchItem": false,
     ///                        "canBeCaughtByRod": true,
     ///                        "canBeCaughtByPot": false,
     ///                        "canBeCaughtByNet": true,
     ///                        "affectedByFishingSustain": true,
     ///                        "hasMinDepth": false,
     ///                        "minDepth": "MEDIUM",
     ///                        "hasMaxDepth": false,
     ///                        "maxDepth": null,
     ///                        "zonesFoundIn": "THE_MARROWS,ALL",
     ///                        "canBeSoldByPlayer": true,
     ///                        "canBeSoldInBulkAction": true,
     ///                        "value": 38.0,
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
     ///                            }
     ///                        ],
     ///                        "squishFactor": 1.0,
     ///                        "itemOwnPrerequisites": [],
     ///                        "researchPrerequisites": [],
     ///                        "researchPointsRequired": 0,
     ///                        "buyableWithoutResearch": false,
     ///                        "researchIsForRecipe": false,
     ///                        "useIntenseAberratedUIShader": false,
     ///                        "id": "squid-ab-2",
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
     ///                            "$ref": "18"
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
     ///                "day": false,
     ///                "night": true,
     ///                "canAppearInBaitBalls": true,
     ///                "questCompleteRequired": null,
     ///                "baitChanceOverride": -1.0,
     ///                "canBeInfected": true,
     ///                "cellsExcludedFromDisplayingInfection": [],
     ///                "rotCoefficient": 1.0,
     ///                "tirPhase": 0,
     ///                "harvestMinigameType": "FISHING_PENDULUM",
     ///                "perSpotMin": 3,
     ///                "perSpotMax": 6,
     ///                "harvestItemWeight": 4.0,
     ///                "regenHarvestSpotOnDestroy": false,
     ///                "harvestPOICategory": "FISH_SMALL",
     ///                "harvestableType": "COASTAL",
     ///                "requiresAdvancedEquipment": false,
     ///                "harvestDifficulty": "VERY_EASY",
     ///                "canBeReplacedWithResearchItem": false,
     ///                "canBeCaughtByRod": true,
     ///                "canBeCaughtByPot": false,
     ///                "canBeCaughtByNet": true,
     ///                "affectedByFishingSustain": true,
     ///                "hasMinDepth": false,
     ///                "minDepth": "MEDIUM",
     ///                "hasMaxDepth": false,
     ///                "maxDepth": null,
     ///                "zonesFoundIn": "THE_MARROWS,ALL",
     ///                "canBeSoldByPlayer": true,
     ///                "canBeSoldInBulkAction": true,
     ///                "value": 14.0,
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
     ///                    }
     ///                ],
     ///                "squishFactor": 1.0,
     ///                "itemOwnPrerequisites": [],
     ///                "researchPrerequisites": [],
     ///                "researchPointsRequired": 0,
     ///                "buyableWithoutResearch": false,
     ///                "researchIsForRecipe": false,
     ///                "useIntenseAberratedUIShader": false,
     ///                "id": "squid",
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
     ///            "count": 2,
     ///            "allowLinkedAberrations": false,
     ///            "$type": "ItemCountCondition"
     ///        },
     ///        {
     ///            "item": {
     ///                "minSizeCentimeters": 25.0,
     ///                "maxSizeCentimeters": 50.0,
     ///                "aberrations": [
     ///                    {
     ///                        "minSizeCentimeters": 25.0,
     ///                        "maxSizeCentimeters": 50.0,
     ///                        "aberrations": [],
     ///                        "isAberration": true,
     ///                        "nonAberrationParent": {
     ///                            "$ref": "47"
     ///                        },
     ///                        "minWorldPhaseRequired": 0,
     ///                        "locationHiddenUntilCaught": false,
     ///                        "day": false,
     ///                        "night": true,
     ///                        "canAppearInBaitBalls": true,
     ///                        "questCompleteRequired": null,
     ///                        "baitChanceOverride": -1.0,
     ///                        "canBeInfected": true,
     ///                        "cellsExcludedFromDisplayingInfection": [],
     ///                        "rotCoefficient": 1.0,
     ///                        "tirPhase": 0,
     ///                        "harvestMinigameType": "FISHING_RADIAL",
     ///                        "perSpotMin": 2,
     ///                        "perSpotMax": 4,
     ///                        "harvestItemWeight": 1.0,
     ///                        "regenHarvestSpotOnDestroy": false,
     ///                        "harvestPOICategory": "NONE",
     ///                        "harvestableType": "SHALLOW",
     ///                        "requiresAdvancedEquipment": false,
     ///                        "harvestDifficulty": "HARD",
     ///                        "canBeReplacedWithResearchItem": false,
     ///                        "canBeCaughtByRod": true,
     ///                        "canBeCaughtByPot": false,
     ///                        "canBeCaughtByNet": true,
     ///                        "affectedByFishingSustain": true,
     ///                        "hasMinDepth": true,
     ///                        "minDepth": "SHALLOW",
     ///                        "hasMaxDepth": true,
     ///                        "maxDepth": "MEDIUM",
     ///                        "zonesFoundIn": "THE_MARROWS,ALL",
     ///                        "canBeSoldByPlayer": true,
     ///                        "canBeSoldInBulkAction": true,
     ///                        "value": 85.0,
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
     ///                        "id": "black-grouper-ab-1",
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
     ///                            "$id": "62"
     ///                        },
     ///                        "overrideHarvestParticleDepth": false,
     ///                        "harvestParticleDepthOffset": -3.0,
     ///                        "flattenParticleShape": false,
     ///                        "availableInDemo": true,
     ///                        "entitlementsRequired": [
     ///                            "NONE"
     ///                        ]
     ///                    },
     ///                    {
     ///                        "minSizeCentimeters": 25.0,
     ///                        "maxSizeCentimeters": 50.0,
     ///                        "aberrations": [],
     ///                        "isAberration": true,
     ///                        "nonAberrationParent": {
     ///                            "$ref": "47"
     ///                        },
     ///                        "minWorldPhaseRequired": 1,
     ///                        "locationHiddenUntilCaught": false,
     ///                        "day": false,
     ///                        "night": true,
     ///                        "canAppearInBaitBalls": true,
     ///                        "questCompleteRequired": null,
     ///                        "baitChanceOverride": -1.0,
     ///                        "canBeInfected": true,
     ///                        "cellsExcludedFromDisplayingInfection": [],
     ///                        "rotCoefficient": 1.0,
     ///                        "tirPhase": 0,
     ///                        "harvestMinigameType": "FISHING_RADIAL",
     ///                        "perSpotMin": 2,
     ///                        "perSpotMax": 4,
     ///                        "harvestItemWeight": 1.0,
     ///                        "regenHarvestSpotOnDestroy": false,
     ///                        "harvestPOICategory": "NONE",
     ///                        "harvestableType": "SHALLOW",
     ///                        "requiresAdvancedEquipment": false,
     ///                        "harvestDifficulty": "HARD",
     ///                        "canBeReplacedWithResearchItem": false,
     ///                        "canBeCaughtByRod": true,
     ///                        "canBeCaughtByPot": false,
     ///                        "canBeCaughtByNet": true,
     ///                        "affectedByFishingSustain": true,
     ///                        "hasMinDepth": true,
     ///                        "minDepth": "SHALLOW",
     ///                        "hasMaxDepth": true,
     ///                        "maxDepth": "MEDIUM",
     ///                        "zonesFoundIn": "THE_MARROWS,ALL",
     ///                        "canBeSoldByPlayer": true,
     ///                        "canBeSoldInBulkAction": true,
     ///                        "value": 100.0,
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
     ///                        "id": "black-grouper-ab-2",
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
     ///                            "$ref": "62"
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
     ///                "day": false,
     ///                "night": true,
     ///                "canAppearInBaitBalls": true,
     ///                "questCompleteRequired": null,
     ///                "baitChanceOverride": -1.0,
     ///                "canBeInfected": true,
     ///                "cellsExcludedFromDisplayingInfection": [],
     ///                "rotCoefficient": 1.0,
     ///                "tirPhase": 0,
     ///                "harvestMinigameType": "FISHING_RADIAL",
     ///                "perSpotMin": 2,
     ///                "perSpotMax": 4,
     ///                "harvestItemWeight": 2.0,
     ///                "regenHarvestSpotOnDestroy": false,
     ///                "harvestPOICategory": "FISH_MEDIUM",
     ///                "harvestableType": "SHALLOW",
     ///                "requiresAdvancedEquipment": false,
     ///                "harvestDifficulty": "HARD",
     ///                "canBeReplacedWithResearchItem": false,
     ///                "canBeCaughtByRod": true,
     ///                "canBeCaughtByPot": false,
     ///                "canBeCaughtByNet": true,
     ///                "affectedByFishingSustain": true,
     ///                "hasMinDepth": true,
     ///                "minDepth": "SHALLOW",
     ///                "hasMaxDepth": true,
     ///                "maxDepth": "MEDIUM",
     ///                "zonesFoundIn": "THE_MARROWS,ALL",
     ///                "canBeSoldByPlayer": true,
     ///                "canBeSoldInBulkAction": true,
     ///                "value": 35.0,
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
     ///                "id": "black-grouper",
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
     ///
     ///                },
     ///                "overrideHarvestParticleDepth": false,
     ///                "harvestParticleDepthOffset": -3.0,
     ///                "flattenParticleShape": false,
     ///                "availableInDemo": true,
     ///                "entitlementsRequired": [
     ///                    "NONE"
     ///                ],
     ///                "$type": "FishItemData",
     ///                "$id": "47"
     ///            },
     ///            "count": 1,
     ///            "allowLinkedAberrations": false,
     ///            "$type": "ItemCountCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[CompletedGridCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = Fishmonger_Delivery2Instance.completeConditions;
}

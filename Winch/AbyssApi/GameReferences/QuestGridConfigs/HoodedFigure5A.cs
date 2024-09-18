namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class HoodedFigure5A
{
    public static QuestGridConfig HoodedFigure5AInstance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "HoodedFigure5A");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.ITEM_DELIVER;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = HoodedFigure5AInstance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = HoodedFigure5AInstance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = HoodedFigure5AInstance.exitPromptOverride;
     ///<json>
     /// null
     /// </json>
    public static UnityEngine.Sprite backgroundImage = null;
    public static float gridHeightOverride = 0f;
    public static bool overrideGridCellColor = true;
    public static DredgeColorTypeEnum gridCellColor = DredgeColorTypeEnum.CRITICAL;
    public static bool allowStorageAccess = false;
    public static bool isSaved = false;
    public static bool createItemsIfEmpty = false;
    public static GridKey gridKey = GridKey.SHRINE_DS_1;
    public static bool allowManualExit = true;
    public static bool allowEquipmentInstallation = false;
    public static bool createWithDurabilityValue = false;
    public static float startingDurabilityProportion = 1f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [],
     ///    "mainItemType": "GENERAL,ALL",
     ///    "mainItemSubtype": "FISH,ALL",
     ///    "mainItemData": null,
     ///    "itemsInThisBelongToPlayer": false,
     ///    "canAddItemsInQuestMode": true,
     ///    "hasUnderlay": false,
     ///    "columns": 2,
     ///    "rows": 1,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = HoodedFigure5AInstance.gridConfiguration;
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
     ///            "id": "icefish-ab-1"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = HoodedFigure5AInstance.presetGrid;
    public static PresetGridMode presetGridMode = PresetGridMode.SILHOUETTE;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "item": {
     ///                "minSizeCentimeters": 10.0,
     ///                "maxSizeCentimeters": 30.0,
     ///                "aberrations": [],
     ///                "isAberration": true,
     ///                "nonAberrationParent": {
     ///                    "minSizeCentimeters": 10.0,
     ///                    "maxSizeCentimeters": 30.0,
     ///                    "aberrations": [
     ///                        {
     ///                            "$ref": "2"
     ///                        },
     ///                        {
     ///                            "minSizeCentimeters": 10.0,
     ///                            "maxSizeCentimeters": 30.0,
     ///                            "aberrations": [],
     ///                            "isAberration": true,
     ///                            "nonAberrationParent": {
     ///                                "$ref": "4"
     ///                            },
     ///                            "minWorldPhaseRequired": 1,
     ///                            "locationHiddenUntilCaught": false,
     ///                            "day": true,
     ///                            "night": true,
     ///                            "canAppearInBaitBalls": true,
     ///                            "questCompleteRequired": null,
     ///                            "baitChanceOverride": -1.0,
     ///                            "canBeInfected": true,
     ///                            "cellsExcludedFromDisplayingInfection": [],
     ///                            "rotCoefficient": 1.0,
     ///                            "tirPhase": 0,
     ///                            "harvestMinigameType": "FISHING_RADIAL",
     ///                            "perSpotMin": 3,
     ///                            "perSpotMax": 7,
     ///                            "harvestItemWeight": 4.0,
     ///                            "regenHarvestSpotOnDestroy": false,
     ///                            "harvestPOICategory": "FISH_SMALL",
     ///                            "harvestableType": "ICE",
     ///                            "requiresAdvancedEquipment": false,
     ///                            "harvestDifficulty": "EASY",
     ///                            "canBeReplacedWithResearchItem": false,
     ///                            "canBeCaughtByRod": true,
     ///                            "canBeCaughtByPot": false,
     ///                            "canBeCaughtByNet": true,
     ///                            "affectedByFishingSustain": true,
     ///                            "hasMinDepth": false,
     ///                            "minDepth": "MEDIUM",
     ///                            "hasMaxDepth": false,
     ///                            "maxDepth": null,
     ///                            "zonesFoundIn": "PALE_REACH,ALL",
     ///                            "canBeSoldByPlayer": true,
     ///                            "canBeSoldInBulkAction": true,
     ///                            "value": 45.0,
     ///                            "hasSellOverride": false,
     ///                            "sellOverrideValue": 0.0,
     ///                            "sprite": {
     ///
     ///                            },
     ///                            "platformSpecificSpriteOverrides": null,
     ///                            "itemColor": {
     ///                                "r": 0.5333334,
     ///                                "g": 0.0,
     ///                                "b": 0.2980392,
     ///                                "a": 255.0
     ///                            },
     ///                            "hasSpecialDiscardAction": false,
     ///                            "discardPromptOverride": "",
     ///                            "canBeDiscardedByPlayer": true,
     ///                            "showAlertOnDiscardHold": false,
     ///                            "discardHoldTimeOverride": false,
     ///                            "discardHoldTimeSec": 0.0,
     ///                            "canBeDiscardedDuringQuestPickup": true,
     ///                            "damageMode": "DESTROY",
     ///                            "moveMode": "FREE",
     ///                            "ignoreDamageWhenPlacing": false,
     ///                            "isUnderlayItem": false,
     ///                            "forbidStorageTray": false,
     ///                            "dimensions": [
     ///                                {
     ///
     ///                                },
     ///                                {
     ///
     ///                                }
     ///                            ],
     ///                            "squishFactor": 1.0,
     ///                            "itemOwnPrerequisites": [],
     ///                            "researchPrerequisites": [],
     ///                            "researchPointsRequired": 0,
     ///                            "buyableWithoutResearch": false,
     ///                            "researchIsForRecipe": false,
     ///                            "useIntenseAberratedUIShader": false,
     ///                            "id": "icefish-ab-2",
     ///                            "itemNameKey": [],
     ///                            "itemDescriptionKey": [],
     ///                            "hasAdditionalNote": false,
     ///                            "additionalNoteKey": [],
     ///                            "itemInsaneTitleKey": [],
     ///                            "itemInsaneDescriptionKey": [],
     ///                            "linkedDialogueNode": "",
     ///                            "dialogueNodeSpecificDescription": [],
     ///                            "itemType": "GENERAL,ALL",
     ///                            "itemSubtype": "FISH,ALL",
     ///                            "tooltipTextColor": {
     ///                                "r": 0.5333334,
     ///                                "g": 0.0,
     ///                                "b": 0.2980392,
     ///                                "a": 1.0
     ///                            },
     ///                            "tooltipNotesColor": {
     ///                                "r": 1.0,
     ///                                "g": 1.0,
     ///                                "b": 1.0,
     ///                                "a": 1.0
     ///                            },
     ///                            "itemTypeIcon": {
     ///                                "$id": "19"
     ///                            },
     ///                            "harvestParticlePrefab": {
     ///                                "$id": "20"
     ///                            },
     ///                            "overrideHarvestParticleDepth": false,
     ///                            "harvestParticleDepthOffset": -3.0,
     ///                            "flattenParticleShape": false,
     ///                            "availableInDemo": false,
     ///                            "entitlementsRequired": [
     ///                                "DLC_1"
     ///                            ]
     ///                        },
     ///                        {
     ///                            "minSizeCentimeters": 10.0,
     ///                            "maxSizeCentimeters": 30.0,
     ///                            "aberrations": [],
     ///                            "isAberration": true,
     ///                            "nonAberrationParent": {
     ///                                "$ref": "4"
     ///                            },
     ///                            "minWorldPhaseRequired": 1,
     ///                            "locationHiddenUntilCaught": false,
     ///                            "day": true,
     ///                            "night": true,
     ///                            "canAppearInBaitBalls": true,
     ///                            "questCompleteRequired": null,
     ///                            "baitChanceOverride": -1.0,
     ///                            "canBeInfected": true,
     ///                            "cellsExcludedFromDisplayingInfection": [],
     ///                            "rotCoefficient": 1.0,
     ///                            "tirPhase": 0,
     ///                            "harvestMinigameType": "FISHING_RADIAL",
     ///                            "perSpotMin": 3,
     ///                            "perSpotMax": 7,
     ///                            "harvestItemWeight": 4.0,
     ///                            "regenHarvestSpotOnDestroy": false,
     ///                            "harvestPOICategory": "FISH_SMALL",
     ///                            "harvestableType": "ICE",
     ///                            "requiresAdvancedEquipment": false,
     ///                            "harvestDifficulty": "EASY",
     ///                            "canBeReplacedWithResearchItem": false,
     ///                            "canBeCaughtByRod": true,
     ///                            "canBeCaughtByPot": false,
     ///                            "canBeCaughtByNet": true,
     ///                            "affectedByFishingSustain": true,
     ///                            "hasMinDepth": false,
     ///                            "minDepth": "MEDIUM",
     ///                            "hasMaxDepth": false,
     ///                            "maxDepth": null,
     ///                            "zonesFoundIn": "PALE_REACH,ALL",
     ///                            "canBeSoldByPlayer": true,
     ///                            "canBeSoldInBulkAction": true,
     ///                            "value": 55.0,
     ///                            "hasSellOverride": false,
     ///                            "sellOverrideValue": 0.0,
     ///                            "sprite": {
     ///
     ///                            },
     ///                            "platformSpecificSpriteOverrides": null,
     ///                            "itemColor": {
     ///                                "r": 0.5333334,
     ///                                "g": 0.0,
     ///                                "b": 0.2980392,
     ///                                "a": 255.0
     ///                            },
     ///                            "hasSpecialDiscardAction": false,
     ///                            "discardPromptOverride": "",
     ///                            "canBeDiscardedByPlayer": true,
     ///                            "showAlertOnDiscardHold": false,
     ///                            "discardHoldTimeOverride": false,
     ///                            "discardHoldTimeSec": 0.0,
     ///                            "canBeDiscardedDuringQuestPickup": true,
     ///                            "damageMode": "DESTROY",
     ///                            "moveMode": "FREE",
     ///                            "ignoreDamageWhenPlacing": false,
     ///                            "isUnderlayItem": false,
     ///                            "forbidStorageTray": false,
     ///                            "dimensions": [
     ///                                {
     ///
     ///                                },
     ///                                {
     ///
     ///                                }
     ///                            ],
     ///                            "squishFactor": 1.0,
     ///                            "itemOwnPrerequisites": [],
     ///                            "researchPrerequisites": [],
     ///                            "researchPointsRequired": 0,
     ///                            "buyableWithoutResearch": false,
     ///                            "researchIsForRecipe": false,
     ///                            "useIntenseAberratedUIShader": false,
     ///                            "id": "icefish-ab-3",
     ///                            "itemNameKey": [],
     ///                            "itemDescriptionKey": [],
     ///                            "hasAdditionalNote": false,
     ///                            "additionalNoteKey": [],
     ///                            "itemInsaneTitleKey": [],
     ///                            "itemInsaneDescriptionKey": [],
     ///                            "linkedDialogueNode": "",
     ///                            "dialogueNodeSpecificDescription": [],
     ///                            "itemType": "GENERAL,ALL",
     ///                            "itemSubtype": "FISH,ALL",
     ///                            "tooltipTextColor": {
     ///                                "r": 0.5333334,
     ///                                "g": 0.0,
     ///                                "b": 0.2980392,
     ///                                "a": 1.0
     ///                            },
     ///                            "tooltipNotesColor": {
     ///                                "r": 1.0,
     ///                                "g": 1.0,
     ///                                "b": 1.0,
     ///                                "a": 1.0
     ///                            },
     ///                            "itemTypeIcon": {
     ///                                "$ref": "19"
     ///                            },
     ///                            "harvestParticlePrefab": {
     ///                                "$ref": "20"
     ///                            },
     ///                            "overrideHarvestParticleDepth": false,
     ///                            "harvestParticleDepthOffset": -3.0,
     ///                            "flattenParticleShape": false,
     ///                            "availableInDemo": false,
     ///                            "entitlementsRequired": [
     ///                                "DLC_1"
     ///                            ]
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
     ///                    "perSpotMin": 3,
     ///                    "perSpotMax": 7,
     ///                    "harvestItemWeight": 4.0,
     ///                    "regenHarvestSpotOnDestroy": false,
     ///                    "harvestPOICategory": "FISH_SMALL",
     ///                    "harvestableType": "ICE",
     ///                    "requiresAdvancedEquipment": false,
     ///                    "harvestDifficulty": "EASY",
     ///                    "canBeReplacedWithResearchItem": false,
     ///                    "canBeCaughtByRod": true,
     ///                    "canBeCaughtByPot": false,
     ///                    "canBeCaughtByNet": true,
     ///                    "affectedByFishingSustain": true,
     ///                    "hasMinDepth": false,
     ///                    "minDepth": "MEDIUM",
     ///                    "hasMaxDepth": false,
     ///                    "maxDepth": null,
     ///                    "zonesFoundIn": "PALE_REACH,ALL",
     ///                    "canBeSoldByPlayer": true,
     ///                    "canBeSoldInBulkAction": true,
     ///                    "value": 13.0,
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
     ///                        }
     ///                    ],
     ///                    "squishFactor": 1.0,
     ///                    "itemOwnPrerequisites": [],
     ///                    "researchPrerequisites": [],
     ///                    "researchPointsRequired": 0,
     ///                    "buyableWithoutResearch": false,
     ///                    "researchIsForRecipe": false,
     ///                    "useIntenseAberratedUIShader": false,
     ///                    "id": "icefish",
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
     ///                        "$ref": "19"
     ///                    },
     ///                    "harvestParticlePrefab": {
     ///                        "$ref": "20"
     ///                    },
     ///                    "overrideHarvestParticleDepth": false,
     ///                    "harvestParticleDepthOffset": -3.0,
     ///                    "flattenParticleShape": false,
     ///                    "availableInDemo": false,
     ///                    "entitlementsRequired": [
     ///                        "DLC_1"
     ///                    ],
     ///                    "$id": "4"
     ///                },
     ///                "minWorldPhaseRequired": 1,
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
     ///                "perSpotMin": 3,
     ///                "perSpotMax": 7,
     ///                "harvestItemWeight": 4.0,
     ///                "regenHarvestSpotOnDestroy": false,
     ///                "harvestPOICategory": "FISH_SMALL",
     ///                "harvestableType": "ICE",
     ///                "requiresAdvancedEquipment": false,
     ///                "harvestDifficulty": "EASY",
     ///                "canBeReplacedWithResearchItem": false,
     ///                "canBeCaughtByRod": true,
     ///                "canBeCaughtByPot": false,
     ///                "canBeCaughtByNet": true,
     ///                "affectedByFishingSustain": true,
     ///                "hasMinDepth": false,
     ///                "minDepth": "MEDIUM",
     ///                "hasMaxDepth": false,
     ///                "maxDepth": null,
     ///                "zonesFoundIn": "PALE_REACH,ALL",
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
     ///                    "r": 0.5333334,
     ///                    "g": 0.0,
     ///                    "b": 0.2980392,
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
     ///                "id": "icefish-ab-1",
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
     ///                    "$ref": "19"
     ///                },
     ///                "harvestParticlePrefab": {
     ///                    "$ref": "20"
     ///                },
     ///                "overrideHarvestParticleDepth": false,
     ///                "harvestParticleDepthOffset": -3.0,
     ///                "flattenParticleShape": false,
     ///                "availableInDemo": false,
     ///                "entitlementsRequired": [
     ///                    "DLC_1"
     ///                ],
     ///                "$type": "FishItemData",
     ///                "$id": "2"
     ///            },
     ///            "count": 1,
     ///            "allowLinkedAberrations": false,
     ///            "$type": "ItemCountCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[CompletedGridCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = HoodedFigure5AInstance.completeConditions;
}

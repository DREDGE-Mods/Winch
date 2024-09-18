namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class HoodedFigure1C
{
    public static QuestGridConfig HoodedFigure1CInstance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "HoodedFigure1C");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.ITEM_DELIVER;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = HoodedFigure1CInstance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = HoodedFigure1CInstance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = HoodedFigure1CInstance.exitPromptOverride;
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
     ///    "columns": 3,
     ///    "rows": 1,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = HoodedFigure1CInstance.gridConfiguration;
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
     ///            "id": "snake-mackerel"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = HoodedFigure1CInstance.presetGrid;
    public static PresetGridMode presetGridMode = PresetGridMode.SILHOUETTE;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "item": {
     ///                "minSizeCentimeters": 20.0,
     ///                "maxSizeCentimeters": 60.0,
     ///                "aberrations": [
     ///                    {
     ///                        "minSizeCentimeters": 20.0,
     ///                        "maxSizeCentimeters": 60.0,
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
     ///                        "perSpotMin": 2,
     ///                        "perSpotMax": 5,
     ///                        "harvestItemWeight": 4.0,
     ///                        "regenHarvestSpotOnDestroy": false,
     ///                        "harvestPOICategory": "FISH_MEDIUM",
     ///                        "harvestableType": "COASTAL",
     ///                        "requiresAdvancedEquipment": false,
     ///                        "harvestDifficulty": "MEDIUM",
     ///                        "canBeReplacedWithResearchItem": false,
     ///                        "canBeCaughtByRod": true,
     ///                        "canBeCaughtByPot": false,
     ///                        "canBeCaughtByNet": true,
     ///                        "affectedByFishingSustain": true,
     ///                        "hasMinDepth": false,
     ///                        "minDepth": "SHALLOW",
     ///                        "hasMaxDepth": false,
     ///                        "maxDepth": null,
     ///                        "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                        "canBeSoldByPlayer": true,
     ///                        "canBeSoldInBulkAction": true,
     ///                        "value": 50.0,
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
     ///                            }
     ///                        ],
     ///                        "squishFactor": 1.0,
     ///                        "itemOwnPrerequisites": [],
     ///                        "researchPrerequisites": [],
     ///                        "researchPointsRequired": 0,
     ///                        "buyableWithoutResearch": false,
     ///                        "researchIsForRecipe": false,
     ///                        "useIntenseAberratedUIShader": false,
     ///                        "id": "snake-mackerel-ab-1",
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
     ///                        "minSizeCentimeters": 20.0,
     ///                        "maxSizeCentimeters": 60.0,
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
     ///                        "perSpotMin": 2,
     ///                        "perSpotMax": 5,
     ///                        "harvestItemWeight": 4.0,
     ///                        "regenHarvestSpotOnDestroy": false,
     ///                        "harvestPOICategory": "FISH_MEDIUM",
     ///                        "harvestableType": "COASTAL",
     ///                        "requiresAdvancedEquipment": false,
     ///                        "harvestDifficulty": "MEDIUM",
     ///                        "canBeReplacedWithResearchItem": false,
     ///                        "canBeCaughtByRod": true,
     ///                        "canBeCaughtByPot": false,
     ///                        "canBeCaughtByNet": true,
     ///                        "affectedByFishingSustain": true,
     ///                        "hasMinDepth": false,
     ///                        "minDepth": "SHALLOW",
     ///                        "hasMaxDepth": false,
     ///                        "maxDepth": null,
     ///                        "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                        "canBeSoldByPlayer": true,
     ///                        "canBeSoldInBulkAction": true,
     ///                        "value": 60.0,
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
     ///                            }
     ///                        ],
     ///                        "squishFactor": 1.0,
     ///                        "itemOwnPrerequisites": [],
     ///                        "researchPrerequisites": [],
     ///                        "researchPointsRequired": 0,
     ///                        "buyableWithoutResearch": false,
     ///                        "researchIsForRecipe": false,
     ///                        "useIntenseAberratedUIShader": false,
     ///                        "id": "snake-mackerel-ab-2",
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
     ///                "perSpotMin": 2,
     ///                "perSpotMax": 5,
     ///                "harvestItemWeight": 4.0,
     ///                "regenHarvestSpotOnDestroy": false,
     ///                "harvestPOICategory": "FISH_MEDIUM",
     ///                "harvestableType": "COASTAL",
     ///                "requiresAdvancedEquipment": false,
     ///                "harvestDifficulty": "MEDIUM",
     ///                "canBeReplacedWithResearchItem": false,
     ///                "canBeCaughtByRod": true,
     ///                "canBeCaughtByPot": false,
     ///                "canBeCaughtByNet": true,
     ///                "affectedByFishingSustain": true,
     ///                "hasMinDepth": false,
     ///                "minDepth": "SHALLOW",
     ///                "hasMaxDepth": false,
     ///                "maxDepth": null,
     ///                "zonesFoundIn": "DEVILS_SPINE,ALL",
     ///                "canBeSoldByPlayer": true,
     ///                "canBeSoldInBulkAction": true,
     ///                "value": 22.0,
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
     ///                    }
     ///                ],
     ///                "squishFactor": 1.0,
     ///                "itemOwnPrerequisites": [],
     ///                "researchPrerequisites": [],
     ///                "researchPointsRequired": 0,
     ///                "buyableWithoutResearch": false,
     ///                "researchIsForRecipe": false,
     ///                "useIntenseAberratedUIShader": false,
     ///                "id": "snake-mackerel",
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
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[CompletedGridCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = HoodedFigure1CInstance.completeConditions;
}

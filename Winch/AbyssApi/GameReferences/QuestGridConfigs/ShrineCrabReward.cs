namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class ShrineCrabReward
{
    public static QuestGridConfig ShrineCrabRewardInstance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "ShrineCrabReward");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.REVISITABLE;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = ShrineCrabRewardInstance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = ShrineCrabRewardInstance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = ShrineCrabRewardInstance.exitPromptOverride;
     ///<json>
     /// null
     /// </json>
    public static UnityEngine.Sprite backgroundImage = null;
    public static float gridHeightOverride = 0f;
    public static bool overrideGridCellColor = false;
    public static DredgeColorTypeEnum gridCellColor = DredgeColorTypeEnum.NEUTRAL;
    public static bool allowStorageAccess = true;
    public static bool isSaved = true;
    public static bool createItemsIfEmpty = true;
    public static GridKey gridKey = GridKey.SHRINE_CRAB_REWARD;
    public static bool allowManualExit = true;
    public static bool allowEquipmentInstallation = true;
    public static bool createWithDurabilityValue = false;
    public static float startingDurabilityProportion = 1f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [],
     ///    "mainItemType": "GENERAL,EQUIPMENT,ALL",
     ///    "mainItemSubtype": "POT,ALL",
     ///    "mainItemData": {
     ///        "timeBetweenCatchRolls": 0.66,
     ///        "catchRate": 1.0,
     ///        "maxDurabilityDays": 7.0,
     ///        "gridConfig": {
     ///            "cellGroupConfigs": [],
     ///            "mainItemType": "GENERAL,ALL",
     ///            "mainItemSubtype": "FISH,GENERAL,ALL",
     ///            "mainItemData": null,
     ///            "itemsInThisBelongToPlayer": true,
     ///            "canAddItemsInQuestMode": false,
     ///            "hasUnderlay": false,
     ///            "columns": 6,
     ///            "rows": 6
     ///        },
     ///        "gridKey": "NONE",
     ///        "harvestableTypes": [],
     ///        "isAdvancedEquipment": false,
     ///        "aberrationBonus": 0.1,
     ///        "canBeSoldByPlayer": true,
     ///        "canBeSoldInBulkAction": true,
     ///        "value": 200.0,
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
     ///        "researchPrerequisites": [
     ///            {
     ///                "itemData": {
     ///                    "timeBetweenCatchRolls": 0.33,
     ///                    "catchRate": 1.0,
     ///                    "maxDurabilityDays": 6.0,
     ///                    "gridConfig": {
     ///                        "cellGroupConfigs": [],
     ///                        "mainItemType": "GENERAL,ALL",
     ///                        "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                        "mainItemData": null,
     ///                        "itemsInThisBelongToPlayer": true,
     ///                        "canAddItemsInQuestMode": false,
     ///                        "hasUnderlay": false,
     ///                        "columns": 5,
     ///                        "rows": 4
     ///                    },
     ///                    "gridKey": "NONE",
     ///                    "harvestableTypes": [],
     ///                    "isAdvancedEquipment": false,
     ///                    "aberrationBonus": 0.04,
     ///                    "canBeSoldByPlayer": true,
     ///                    "canBeSoldInBulkAction": true,
     ///                    "value": 225.0,
     ///                    "hasSellOverride": false,
     ///                    "sellOverrideValue": 0.0,
     ///                    "sprite": {
     ///
     ///                    },
     ///                    "platformSpecificSpriteOverrides": null,
     ///                    "itemColor": {
     ///                        "r": 0.1921569,
     ///                        "g": 0.1921569,
     ///                        "b": 0.1921569,
     ///                        "a": 255.0
     ///                    },
     ///                    "hasSpecialDiscardAction": false,
     ///                    "discardPromptOverride": "",
     ///                    "canBeDiscardedByPlayer": true,
     ///                    "showAlertOnDiscardHold": true,
     ///                    "discardHoldTimeOverride": true,
     ///                    "discardHoldTimeSec": 2.0,
     ///                    "canBeDiscardedDuringQuestPickup": true,
     ///                    "damageMode": "DURABILITY",
     ///                    "moveMode": "FREE",
     ///                    "ignoreDamageWhenPlacing": true,
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
     ///                        }
     ///                    ],
     ///                    "squishFactor": 0.0,
     ///                    "itemOwnPrerequisites": [],
     ///                    "researchPrerequisites": [
     ///                        {
     ///                            "itemData": {
     ///                                "timeBetweenCatchRolls": 0.35,
     ///                                "catchRate": 1.0,
     ///                                "maxDurabilityDays": 3.0,
     ///                                "gridConfig": {
     ///                                    "cellGroupConfigs": [],
     ///                                    "mainItemType": "GENERAL,ALL",
     ///                                    "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                    "mainItemData": null,
     ///                                    "itemsInThisBelongToPlayer": true,
     ///                                    "canAddItemsInQuestMode": false,
     ///                                    "hasUnderlay": false,
     ///                                    "columns": 4,
     ///                                    "rows": 4
     ///                                },
     ///                                "gridKey": "NONE",
     ///                                "harvestableTypes": [],
     ///                                "isAdvancedEquipment": false,
     ///                                "aberrationBonus": 0.02,
     ///                                "canBeSoldByPlayer": true,
     ///                                "canBeSoldInBulkAction": true,
     ///                                "value": 150.0,
     ///                                "hasSellOverride": false,
     ///                                "sellOverrideValue": 0.0,
     ///                                "sprite": {
     ///
     ///                                },
     ///                                "platformSpecificSpriteOverrides": null,
     ///                                "itemColor": {
     ///                                    "r": 0.1921569,
     ///                                    "g": 0.1921569,
     ///                                    "b": 0.1921569,
     ///                                    "a": 255.0
     ///                                },
     ///                                "hasSpecialDiscardAction": false,
     ///                                "discardPromptOverride": "",
     ///                                "canBeDiscardedByPlayer": true,
     ///                                "showAlertOnDiscardHold": true,
     ///                                "discardHoldTimeOverride": true,
     ///                                "discardHoldTimeSec": 2.0,
     ///                                "canBeDiscardedDuringQuestPickup": true,
     ///                                "damageMode": "DURABILITY",
     ///                                "moveMode": "FREE",
     ///                                "ignoreDamageWhenPlacing": true,
     ///                                "isUnderlayItem": false,
     ///                                "forbidStorageTray": false,
     ///                                "dimensions": [
     ///                                    {
     ///
     ///                                    },
     ///                                    {
     ///
     ///                                    }
     ///                                ],
     ///                                "squishFactor": 0.0,
     ///                                "itemOwnPrerequisites": [],
     ///                                "researchPrerequisites": [],
     ///                                "researchPointsRequired": 1,
     ///                                "buyableWithoutResearch": false,
     ///                                "researchIsForRecipe": false,
     ///                                "useIntenseAberratedUIShader": false,
     ///                                "id": "pot2",
     ///                                "itemNameKey": [],
     ///                                "itemDescriptionKey": [],
     ///                                "hasAdditionalNote": false,
     ///                                "additionalNoteKey": [],
     ///                                "itemInsaneTitleKey": [],
     ///                                "itemInsaneDescriptionKey": [],
     ///                                "linkedDialogueNode": "",
     ///                                "dialogueNodeSpecificDescription": [],
     ///                                "itemType": "EQUIPMENT,ALL",
     ///                                "itemSubtype": "POT,ALL",
     ///                                "tooltipTextColor": {
     ///                                    "r": 0.4901961,
     ///                                    "g": 0.3843137,
     ///                                    "b": 0.2666667,
     ///                                    "a": 1.0
     ///                                },
     ///                                "tooltipNotesColor": {
     ///                                    "r": 1.0,
     ///                                    "g": 1.0,
     ///                                    "b": 1.0,
     ///                                    "a": 1.0
     ///                                },
     ///                                "itemTypeIcon": {
     ///                                    "$id": "31"
     ///                                },
     ///                                "harvestParticlePrefab": null,
     ///                                "overrideHarvestParticleDepth": false,
     ///                                "harvestParticleDepthOffset": -3.0,
     ///                                "flattenParticleShape": false,
     ///                                "availableInDemo": false,
     ///                                "entitlementsRequired": [
     ///                                    "NONE"
     ///                                ],
     ///                                "$type": "DeployableItemData"
     ///                            }
     ///                        },
     ///                        {
     ///                            "itemData": {
     ///                                "timeBetweenCatchRolls": 0.5,
     ///                                "catchRate": 1.0,
     ///                                "maxDurabilityDays": 5.0,
     ///                                "gridConfig": {
     ///                                    "cellGroupConfigs": [],
     ///                                    "mainItemType": "GENERAL,ALL",
     ///                                    "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                    "mainItemData": null,
     ///                                    "itemsInThisBelongToPlayer": true,
     ///                                    "canAddItemsInQuestMode": false,
     ///                                    "hasUnderlay": false,
     ///                                    "columns": 4,
     ///                                    "rows": 4
     ///                                },
     ///                                "gridKey": "NONE",
     ///                                "harvestableTypes": [],
     ///                                "isAdvancedEquipment": false,
     ///                                "aberrationBonus": 0.02,
     ///                                "canBeSoldByPlayer": true,
     ///                                "canBeSoldInBulkAction": true,
     ///                                "value": 150.0,
     ///                                "hasSellOverride": false,
     ///                                "sellOverrideValue": 0.0,
     ///                                "sprite": {
     ///
     ///                                },
     ///                                "platformSpecificSpriteOverrides": null,
     ///                                "itemColor": {
     ///                                    "r": 0.1921569,
     ///                                    "g": 0.1921569,
     ///                                    "b": 0.1921569,
     ///                                    "a": 255.0
     ///                                },
     ///                                "hasSpecialDiscardAction": false,
     ///                                "discardPromptOverride": "",
     ///                                "canBeDiscardedByPlayer": true,
     ///                                "showAlertOnDiscardHold": true,
     ///                                "discardHoldTimeOverride": true,
     ///                                "discardHoldTimeSec": 2.0,
     ///                                "canBeDiscardedDuringQuestPickup": true,
     ///                                "damageMode": "DURABILITY",
     ///                                "moveMode": "FREE",
     ///                                "ignoreDamageWhenPlacing": true,
     ///                                "isUnderlayItem": false,
     ///                                "forbidStorageTray": false,
     ///                                "dimensions": [
     ///                                    {
     ///
     ///                                    },
     ///                                    {
     ///
     ///                                    },
     ///                                    {
     ///
     ///                                    }
     ///                                ],
     ///                                "squishFactor": 0.0,
     ///                                "itemOwnPrerequisites": [],
     ///                                "researchPrerequisites": [],
     ///                                "researchPointsRequired": 1,
     ///                                "buyableWithoutResearch": false,
     ///                                "researchIsForRecipe": false,
     ///                                "useIntenseAberratedUIShader": false,
     ///                                "id": "pot3",
     ///                                "itemNameKey": [],
     ///                                "itemDescriptionKey": [],
     ///                                "hasAdditionalNote": false,
     ///                                "additionalNoteKey": [],
     ///                                "itemInsaneTitleKey": [],
     ///                                "itemInsaneDescriptionKey": [],
     ///                                "linkedDialogueNode": "",
     ///                                "dialogueNodeSpecificDescription": [],
     ///                                "itemType": "EQUIPMENT,ALL",
     ///                                "itemSubtype": "POT,ALL",
     ///                                "tooltipTextColor": {
     ///                                    "r": 0.4901961,
     ///                                    "g": 0.3843137,
     ///                                    "b": 0.2666667,
     ///                                    "a": 1.0
     ///                                },
     ///                                "tooltipNotesColor": {
     ///                                    "r": 1.0,
     ///                                    "g": 1.0,
     ///                                    "b": 1.0,
     ///                                    "a": 1.0
     ///                                },
     ///                                "itemTypeIcon": {
     ///                                    "$ref": "31"
     ///                                },
     ///                                "harvestParticlePrefab": null,
     ///                                "overrideHarvestParticleDepth": false,
     ///                                "harvestParticleDepthOffset": -3.0,
     ///                                "flattenParticleShape": false,
     ///                                "availableInDemo": false,
     ///                                "entitlementsRequired": [
     ///                                    "NONE"
     ///                                ],
     ///                                "$type": "DeployableItemData",
     ///                                "$id": "34"
     ///                            }
     ///                        }
     ///                    ],
     ///                    "researchPointsRequired": 2,
     ///                    "buyableWithoutResearch": false,
     ///                    "researchIsForRecipe": false,
     ///                    "useIntenseAberratedUIShader": false,
     ///                    "id": "pot5",
     ///                    "itemNameKey": [],
     ///                    "itemDescriptionKey": [],
     ///                    "hasAdditionalNote": false,
     ///                    "additionalNoteKey": [],
     ///                    "itemInsaneTitleKey": [],
     ///                    "itemInsaneDescriptionKey": [],
     ///                    "linkedDialogueNode": "",
     ///                    "dialogueNodeSpecificDescription": [],
     ///                    "itemType": "EQUIPMENT,ALL",
     ///                    "itemSubtype": "POT,ALL",
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
     ///                        "$ref": "31"
     ///                    },
     ///                    "harvestParticlePrefab": null,
     ///                    "overrideHarvestParticleDepth": false,
     ///                    "harvestParticleDepthOffset": -3.0,
     ///                    "flattenParticleShape": false,
     ///                    "availableInDemo": false,
     ///                    "entitlementsRequired": [
     ///                        "NONE"
     ///                    ],
     ///                    "$type": "DeployableItemData"
     ///                }
     ///            },
     ///            {
     ///                "itemData": {
     ///                    "timeBetweenCatchRolls": 0.4,
     ///                    "catchRate": 1.0,
     ///                    "maxDurabilityDays": 6.0,
     ///                    "gridConfig": {
     ///                        "cellGroupConfigs": [],
     ///                        "mainItemType": "GENERAL,ALL",
     ///                        "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                        "mainItemData": null,
     ///                        "itemsInThisBelongToPlayer": true,
     ///                        "canAddItemsInQuestMode": false,
     ///                        "hasUnderlay": false,
     ///                        "columns": 5,
     ///                        "rows": 5
     ///                    },
     ///                    "gridKey": "NONE",
     ///                    "harvestableTypes": [],
     ///                    "isAdvancedEquipment": false,
     ///                    "aberrationBonus": 0.04,
     ///                    "canBeSoldByPlayer": true,
     ///                    "canBeSoldInBulkAction": true,
     ///                    "value": 225.0,
     ///                    "hasSellOverride": false,
     ///                    "sellOverrideValue": 0.0,
     ///                    "sprite": {
     ///
     ///                    },
     ///                    "platformSpecificSpriteOverrides": null,
     ///                    "itemColor": {
     ///                        "r": 0.1921569,
     ///                        "g": 0.1921569,
     ///                        "b": 0.1921569,
     ///                        "a": 255.0
     ///                    },
     ///                    "hasSpecialDiscardAction": false,
     ///                    "discardPromptOverride": "",
     ///                    "canBeDiscardedByPlayer": true,
     ///                    "showAlertOnDiscardHold": true,
     ///                    "discardHoldTimeOverride": true,
     ///                    "discardHoldTimeSec": 2.0,
     ///                    "canBeDiscardedDuringQuestPickup": true,
     ///                    "damageMode": "DURABILITY",
     ///                    "moveMode": "FREE",
     ///                    "ignoreDamageWhenPlacing": true,
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
     ///                        }
     ///                    ],
     ///                    "squishFactor": 0.0,
     ///                    "itemOwnPrerequisites": [],
     ///                    "researchPrerequisites": [
     ///                        {
     ///                            "itemData": {
     ///                                "$ref": "34"
     ///                            }
     ///                        },
     ///                        {
     ///                            "itemData": {
     ///                                "timeBetweenCatchRolls": 0.5,
     ///                                "catchRate": 1.0,
     ///                                "maxDurabilityDays": 3.0,
     ///                                "gridConfig": {
     ///                                    "cellGroupConfigs": [],
     ///                                    "mainItemType": "GENERAL,ALL",
     ///                                    "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                    "mainItemData": null,
     ///                                    "itemsInThisBelongToPlayer": true,
     ///                                    "canAddItemsInQuestMode": false,
     ///                                    "hasUnderlay": false,
     ///                                    "columns": 5,
     ///                                    "rows": 4
     ///                                },
     ///                                "gridKey": "NONE",
     ///                                "harvestableTypes": [],
     ///                                "isAdvancedEquipment": false,
     ///                                "aberrationBonus": 0.02,
     ///                                "canBeSoldByPlayer": true,
     ///                                "canBeSoldInBulkAction": true,
     ///                                "value": 150.0,
     ///                                "hasSellOverride": false,
     ///                                "sellOverrideValue": 0.0,
     ///                                "sprite": {
     ///
     ///                                },
     ///                                "platformSpecificSpriteOverrides": null,
     ///                                "itemColor": {
     ///                                    "r": 0.1921569,
     ///                                    "g": 0.1921569,
     ///                                    "b": 0.1921569,
     ///                                    "a": 255.0
     ///                                },
     ///                                "hasSpecialDiscardAction": false,
     ///                                "discardPromptOverride": "",
     ///                                "canBeDiscardedByPlayer": true,
     ///                                "showAlertOnDiscardHold": true,
     ///                                "discardHoldTimeOverride": true,
     ///                                "discardHoldTimeSec": 2.0,
     ///                                "canBeDiscardedDuringQuestPickup": true,
     ///                                "damageMode": "DURABILITY",
     ///                                "moveMode": "FREE",
     ///                                "ignoreDamageWhenPlacing": true,
     ///                                "isUnderlayItem": false,
     ///                                "forbidStorageTray": false,
     ///                                "dimensions": [
     ///                                    {
     ///
     ///                                    },
     ///                                    {
     ///
     ///                                    },
     ///                                    {
     ///
     ///                                    }
     ///                                ],
     ///                                "squishFactor": 0.0,
     ///                                "itemOwnPrerequisites": [],
     ///                                "researchPrerequisites": [],
     ///                                "researchPointsRequired": 1,
     ///                                "buyableWithoutResearch": false,
     ///                                "researchIsForRecipe": false,
     ///                                "useIntenseAberratedUIShader": false,
     ///                                "id": "pot4",
     ///                                "itemNameKey": [],
     ///                                "itemDescriptionKey": [],
     ///                                "hasAdditionalNote": false,
     ///                                "additionalNoteKey": [],
     ///                                "itemInsaneTitleKey": [],
     ///                                "itemInsaneDescriptionKey": [],
     ///                                "linkedDialogueNode": "",
     ///                                "dialogueNodeSpecificDescription": [],
     ///                                "itemType": "EQUIPMENT,ALL",
     ///                                "itemSubtype": "POT,ALL",
     ///                                "tooltipTextColor": {
     ///                                    "r": 0.4901961,
     ///                                    "g": 0.3843137,
     ///                                    "b": 0.2666667,
     ///                                    "a": 1.0
     ///                                },
     ///                                "tooltipNotesColor": {
     ///                                    "r": 1.0,
     ///                                    "g": 1.0,
     ///                                    "b": 1.0,
     ///                                    "a": 1.0
     ///                                },
     ///                                "itemTypeIcon": {
     ///                                    "$ref": "31"
     ///                                },
     ///                                "harvestParticlePrefab": null,
     ///                                "overrideHarvestParticleDepth": false,
     ///                                "harvestParticleDepthOffset": -3.0,
     ///                                "flattenParticleShape": false,
     ///                                "availableInDemo": false,
     ///                                "entitlementsRequired": [
     ///                                    "NONE"
     ///                                ],
     ///                                "$type": "DeployableItemData"
     ///                            }
     ///                        }
     ///                    ],
     ///                    "researchPointsRequired": 2,
     ///                    "buyableWithoutResearch": false,
     ///                    "researchIsForRecipe": false,
     ///                    "useIntenseAberratedUIShader": false,
     ///                    "id": "pot6",
     ///                    "itemNameKey": [],
     ///                    "itemDescriptionKey": [],
     ///                    "hasAdditionalNote": false,
     ///                    "additionalNoteKey": [],
     ///                    "itemInsaneTitleKey": [],
     ///                    "itemInsaneDescriptionKey": [],
     ///                    "linkedDialogueNode": "",
     ///                    "dialogueNodeSpecificDescription": [],
     ///                    "itemType": "EQUIPMENT,ALL",
     ///                    "itemSubtype": "POT,ALL",
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
     ///                        "$ref": "31"
     ///                    },
     ///                    "harvestParticlePrefab": null,
     ///                    "overrideHarvestParticleDepth": false,
     ///                    "harvestParticleDepthOffset": -3.0,
     ///                    "flattenParticleShape": false,
     ///                    "availableInDemo": false,
     ///                    "entitlementsRequired": [
     ///                        "NONE"
     ///                    ],
     ///                    "$type": "DeployableItemData"
     ///                }
     ///            }
     ///        ],
     ///        "researchPointsRequired": 3,
     ///        "buyableWithoutResearch": false,
     ///        "researchIsForRecipe": false,
     ///        "useIntenseAberratedUIShader": false,
     ///        "id": "pot8",
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
     ///            "r": 0.5333334,
     ///            "g": 0.0,
     ///            "b": 0.2980392,
     ///            "a": 1.0
     ///        },
     ///        "tooltipNotesColor": {
     ///            "r": 1.0,
     ///            "g": 1.0,
     ///            "b": 1.0,
     ///            "a": 1.0
     ///        },
     ///        "itemTypeIcon": {
     ///            "$ref": "31"
     ///        },
     ///        "harvestParticlePrefab": null,
     ///        "overrideHarvestParticleDepth": false,
     ///        "harvestParticleDepthOffset": -3.0,
     ///        "flattenParticleShape": false,
     ///        "availableInDemo": false,
     ///        "entitlementsRequired": [
     ///            "NONE"
     ///        ],
     ///        "$type": "DeployableItemData"
     ///    },
     ///    "itemsInThisBelongToPlayer": false,
     ///    "canAddItemsInQuestMode": true,
     ///    "hasUnderlay": false,
     ///    "columns": 2,
     ///    "rows": 2,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = ShrineCrabRewardInstance.gridConfiguration;
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
     ///            "id": "pot8"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = ShrineCrabRewardInstance.presetGrid;
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
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = ShrineCrabRewardInstance.completeConditions;
}

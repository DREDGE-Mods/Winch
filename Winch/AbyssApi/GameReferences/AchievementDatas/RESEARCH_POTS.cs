namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class RESEARCH_POTS
{
    public static AchievementData RESEARCH_POTSInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "RESEARCH_POTS");
    public static DredgeAchievementId id = DredgeAchievementId.RESEARCH_POTS;
    public static string steamId = "";
    public static int playStationId = 25;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "items": [
     ///                {
     ///                    "timeBetweenCatchRolls": 0.33,
     ///                    "catchRate": 1.0,
     ///                    "maxDurabilityDays": 8.0,
     ///                    "gridConfig": {
     ///                        "cellGroupConfigs": [],
     ///                        "mainItemType": "GENERAL,ALL",
     ///                        "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                        "mainItemData": null,
     ///                        "itemsInThisBelongToPlayer": true,
     ///                        "canAddItemsInQuestMode": false,
     ///                        "hasUnderlay": false,
     ///                        "columns": 6,
     ///                        "rows": 5
     ///                    },
     ///                    "gridKey": "NONE",
     ///                    "harvestableTypes": [],
     ///                    "isAdvancedEquipment": false,
     ///                    "aberrationBonus": 0.08,
     ///                    "canBeSoldByPlayer": true,
     ///                    "canBeSoldInBulkAction": true,
     ///                    "value": 300.0,
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
     ///                                "timeBetweenCatchRolls": 0.33,
     ///                                "catchRate": 1.0,
     ///                                "maxDurabilityDays": 6.0,
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
     ///                                "aberrationBonus": 0.04,
     ///                                "canBeSoldByPlayer": true,
     ///                                "canBeSoldInBulkAction": true,
     ///                                "value": 225.0,
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
     ///                                    },
     ///                                    {
     ///
     ///                                    }
     ///                                ],
     ///                                "squishFactor": 0.0,
     ///                                "itemOwnPrerequisites": [],
     ///                                "researchPrerequisites": [
     ///                                    {
     ///                                        "itemData": {
     ///                                            "timeBetweenCatchRolls": 0.35,
     ///                                            "catchRate": 1.0,
     ///                                            "maxDurabilityDays": 3.0,
     ///                                            "gridConfig": {
     ///                                                "cellGroupConfigs": [],
     ///                                                "mainItemType": "GENERAL,ALL",
     ///                                                "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                                "mainItemData": null,
     ///                                                "itemsInThisBelongToPlayer": true,
     ///                                                "canAddItemsInQuestMode": false,
     ///                                                "hasUnderlay": false,
     ///                                                "columns": 4,
     ///                                                "rows": 4
     ///                                            },
     ///                                            "gridKey": "NONE",
     ///                                            "harvestableTypes": [],
     ///                                            "isAdvancedEquipment": false,
     ///                                            "aberrationBonus": 0.02,
     ///                                            "canBeSoldByPlayer": true,
     ///                                            "canBeSoldInBulkAction": true,
     ///                                            "value": 150.0,
     ///                                            "hasSellOverride": false,
     ///                                            "sellOverrideValue": 0.0,
     ///                                            "sprite": {
     ///
     ///                                            },
     ///                                            "platformSpecificSpriteOverrides": null,
     ///                                            "itemColor": {
     ///                                                "r": 0.1921569,
     ///                                                "g": 0.1921569,
     ///                                                "b": 0.1921569,
     ///                                                "a": 255.0
     ///                                            },
     ///                                            "hasSpecialDiscardAction": false,
     ///                                            "discardPromptOverride": "",
     ///                                            "canBeDiscardedByPlayer": true,
     ///                                            "showAlertOnDiscardHold": true,
     ///                                            "discardHoldTimeOverride": true,
     ///                                            "discardHoldTimeSec": 2.0,
     ///                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                            "damageMode": "DURABILITY",
     ///                                            "moveMode": "FREE",
     ///                                            "ignoreDamageWhenPlacing": true,
     ///                                            "isUnderlayItem": false,
     ///                                            "forbidStorageTray": false,
     ///                                            "dimensions": [
     ///                                                {
     ///
     ///                                                },
     ///                                                {
     ///
     ///                                                }
     ///                                            ],
     ///                                            "squishFactor": 0.0,
     ///                                            "itemOwnPrerequisites": [],
     ///                                            "researchPrerequisites": [],
     ///                                            "researchPointsRequired": 1,
     ///                                            "buyableWithoutResearch": false,
     ///                                            "researchIsForRecipe": false,
     ///                                            "useIntenseAberratedUIShader": false,
     ///                                            "id": "pot2",
     ///                                            "itemNameKey": [],
     ///                                            "itemDescriptionKey": [],
     ///                                            "hasAdditionalNote": false,
     ///                                            "additionalNoteKey": [],
     ///                                            "itemInsaneTitleKey": [],
     ///                                            "itemInsaneDescriptionKey": [],
     ///                                            "linkedDialogueNode": "",
     ///                                            "dialogueNodeSpecificDescription": [],
     ///                                            "itemType": "EQUIPMENT,ALL",
     ///                                            "itemSubtype": "POT,ALL",
     ///                                            "tooltipTextColor": {
     ///                                                "r": 0.4901961,
     ///                                                "g": 0.3843137,
     ///                                                "b": 0.2666667,
     ///                                                "a": 1.0
     ///                                            },
     ///                                            "tooltipNotesColor": {
     ///                                                "r": 1.0,
     ///                                                "g": 1.0,
     ///                                                "b": 1.0,
     ///                                                "a": 1.0
     ///                                            },
     ///                                            "itemTypeIcon": {
     ///                                                "$id": "32"
     ///                                            },
     ///                                            "harvestParticlePrefab": null,
     ///                                            "overrideHarvestParticleDepth": false,
     ///                                            "harvestParticleDepthOffset": -3.0,
     ///                                            "flattenParticleShape": false,
     ///                                            "availableInDemo": false,
     ///                                            "entitlementsRequired": [
     ///                                                "NONE"
     ///                                            ],
     ///                                            "$type": "DeployableItemData"
     ///                                        }
     ///                                    },
     ///                                    {
     ///                                        "itemData": {
     ///                                            "timeBetweenCatchRolls": 0.5,
     ///                                            "catchRate": 1.0,
     ///                                            "maxDurabilityDays": 5.0,
     ///                                            "gridConfig": {
     ///                                                "cellGroupConfigs": [],
     ///                                                "mainItemType": "GENERAL,ALL",
     ///                                                "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                                "mainItemData": null,
     ///                                                "itemsInThisBelongToPlayer": true,
     ///                                                "canAddItemsInQuestMode": false,
     ///                                                "hasUnderlay": false,
     ///                                                "columns": 4,
     ///                                                "rows": 4
     ///                                            },
     ///                                            "gridKey": "NONE",
     ///                                            "harvestableTypes": [],
     ///                                            "isAdvancedEquipment": false,
     ///                                            "aberrationBonus": 0.02,
     ///                                            "canBeSoldByPlayer": true,
     ///                                            "canBeSoldInBulkAction": true,
     ///                                            "value": 150.0,
     ///                                            "hasSellOverride": false,
     ///                                            "sellOverrideValue": 0.0,
     ///                                            "sprite": {
     ///
     ///                                            },
     ///                                            "platformSpecificSpriteOverrides": null,
     ///                                            "itemColor": {
     ///                                                "r": 0.1921569,
     ///                                                "g": 0.1921569,
     ///                                                "b": 0.1921569,
     ///                                                "a": 255.0
     ///                                            },
     ///                                            "hasSpecialDiscardAction": false,
     ///                                            "discardPromptOverride": "",
     ///                                            "canBeDiscardedByPlayer": true,
     ///                                            "showAlertOnDiscardHold": true,
     ///                                            "discardHoldTimeOverride": true,
     ///                                            "discardHoldTimeSec": 2.0,
     ///                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                            "damageMode": "DURABILITY",
     ///                                            "moveMode": "FREE",
     ///                                            "ignoreDamageWhenPlacing": true,
     ///                                            "isUnderlayItem": false,
     ///                                            "forbidStorageTray": false,
     ///                                            "dimensions": [
     ///                                                {
     ///
     ///                                                },
     ///                                                {
     ///
     ///                                                },
     ///                                                {
     ///
     ///                                                }
     ///                                            ],
     ///                                            "squishFactor": 0.0,
     ///                                            "itemOwnPrerequisites": [],
     ///                                            "researchPrerequisites": [],
     ///                                            "researchPointsRequired": 1,
     ///                                            "buyableWithoutResearch": false,
     ///                                            "researchIsForRecipe": false,
     ///                                            "useIntenseAberratedUIShader": false,
     ///                                            "id": "pot3",
     ///                                            "itemNameKey": [],
     ///                                            "itemDescriptionKey": [],
     ///                                            "hasAdditionalNote": false,
     ///                                            "additionalNoteKey": [],
     ///                                            "itemInsaneTitleKey": [],
     ///                                            "itemInsaneDescriptionKey": [],
     ///                                            "linkedDialogueNode": "",
     ///                                            "dialogueNodeSpecificDescription": [],
     ///                                            "itemType": "EQUIPMENT,ALL",
     ///                                            "itemSubtype": "POT,ALL",
     ///                                            "tooltipTextColor": {
     ///                                                "r": 0.4901961,
     ///                                                "g": 0.3843137,
     ///                                                "b": 0.2666667,
     ///                                                "a": 1.0
     ///                                            },
     ///                                            "tooltipNotesColor": {
     ///                                                "r": 1.0,
     ///                                                "g": 1.0,
     ///                                                "b": 1.0,
     ///                                                "a": 1.0
     ///                                            },
     ///                                            "itemTypeIcon": {
     ///                                                "$ref": "32"
     ///                                            },
     ///                                            "harvestParticlePrefab": null,
     ///                                            "overrideHarvestParticleDepth": false,
     ///                                            "harvestParticleDepthOffset": -3.0,
     ///                                            "flattenParticleShape": false,
     ///                                            "availableInDemo": false,
     ///                                            "entitlementsRequired": [
     ///                                                "NONE"
     ///                                            ],
     ///                                            "$type": "DeployableItemData",
     ///                                            "$id": "35"
     ///                                        }
     ///                                    }
     ///                                ],
     ///                                "researchPointsRequired": 2,
     ///                                "buyableWithoutResearch": false,
     ///                                "researchIsForRecipe": false,
     ///                                "useIntenseAberratedUIShader": false,
     ///                                "id": "pot5",
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
     ///                                    "$ref": "32"
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
     ///                                "timeBetweenCatchRolls": 0.4,
     ///                                "catchRate": 1.0,
     ///                                "maxDurabilityDays": 6.0,
     ///                                "gridConfig": {
     ///                                    "cellGroupConfigs": [],
     ///                                    "mainItemType": "GENERAL,ALL",
     ///                                    "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                    "mainItemData": null,
     ///                                    "itemsInThisBelongToPlayer": true,
     ///                                    "canAddItemsInQuestMode": false,
     ///                                    "hasUnderlay": false,
     ///                                    "columns": 5,
     ///                                    "rows": 5
     ///                                },
     ///                                "gridKey": "NONE",
     ///                                "harvestableTypes": [],
     ///                                "isAdvancedEquipment": false,
     ///                                "aberrationBonus": 0.04,
     ///                                "canBeSoldByPlayer": true,
     ///                                "canBeSoldInBulkAction": true,
     ///                                "value": 225.0,
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
     ///                                    },
     ///                                    {
     ///
     ///                                    }
     ///                                ],
     ///                                "squishFactor": 0.0,
     ///                                "itemOwnPrerequisites": [],
     ///                                "researchPrerequisites": [
     ///                                    {
     ///                                        "itemData": {
     ///                                            "$ref": "35"
     ///                                        }
     ///                                    },
     ///                                    {
     ///                                        "itemData": {
     ///                                            "timeBetweenCatchRolls": 0.5,
     ///                                            "catchRate": 1.0,
     ///                                            "maxDurabilityDays": 3.0,
     ///                                            "gridConfig": {
     ///                                                "cellGroupConfigs": [],
     ///                                                "mainItemType": "GENERAL,ALL",
     ///                                                "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                                "mainItemData": null,
     ///                                                "itemsInThisBelongToPlayer": true,
     ///                                                "canAddItemsInQuestMode": false,
     ///                                                "hasUnderlay": false,
     ///                                                "columns": 5,
     ///                                                "rows": 4
     ///                                            },
     ///                                            "gridKey": "NONE",
     ///                                            "harvestableTypes": [],
     ///                                            "isAdvancedEquipment": false,
     ///                                            "aberrationBonus": 0.02,
     ///                                            "canBeSoldByPlayer": true,
     ///                                            "canBeSoldInBulkAction": true,
     ///                                            "value": 150.0,
     ///                                            "hasSellOverride": false,
     ///                                            "sellOverrideValue": 0.0,
     ///                                            "sprite": {
     ///
     ///                                            },
     ///                                            "platformSpecificSpriteOverrides": null,
     ///                                            "itemColor": {
     ///                                                "r": 0.1921569,
     ///                                                "g": 0.1921569,
     ///                                                "b": 0.1921569,
     ///                                                "a": 255.0
     ///                                            },
     ///                                            "hasSpecialDiscardAction": false,
     ///                                            "discardPromptOverride": "",
     ///                                            "canBeDiscardedByPlayer": true,
     ///                                            "showAlertOnDiscardHold": true,
     ///                                            "discardHoldTimeOverride": true,
     ///                                            "discardHoldTimeSec": 2.0,
     ///                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                            "damageMode": "DURABILITY",
     ///                                            "moveMode": "FREE",
     ///                                            "ignoreDamageWhenPlacing": true,
     ///                                            "isUnderlayItem": false,
     ///                                            "forbidStorageTray": false,
     ///                                            "dimensions": [
     ///                                                {
     ///
     ///                                                },
     ///                                                {
     ///
     ///                                                },
     ///                                                {
     ///
     ///                                                }
     ///                                            ],
     ///                                            "squishFactor": 0.0,
     ///                                            "itemOwnPrerequisites": [],
     ///                                            "researchPrerequisites": [],
     ///                                            "researchPointsRequired": 1,
     ///                                            "buyableWithoutResearch": false,
     ///                                            "researchIsForRecipe": false,
     ///                                            "useIntenseAberratedUIShader": false,
     ///                                            "id": "pot4",
     ///                                            "itemNameKey": [],
     ///                                            "itemDescriptionKey": [],
     ///                                            "hasAdditionalNote": false,
     ///                                            "additionalNoteKey": [],
     ///                                            "itemInsaneTitleKey": [],
     ///                                            "itemInsaneDescriptionKey": [],
     ///                                            "linkedDialogueNode": "",
     ///                                            "dialogueNodeSpecificDescription": [],
     ///                                            "itemType": "EQUIPMENT,ALL",
     ///                                            "itemSubtype": "POT,ALL",
     ///                                            "tooltipTextColor": {
     ///                                                "r": 0.4901961,
     ///                                                "g": 0.3843137,
     ///                                                "b": 0.2666667,
     ///                                                "a": 1.0
     ///                                            },
     ///                                            "tooltipNotesColor": {
     ///                                                "r": 1.0,
     ///                                                "g": 1.0,
     ///                                                "b": 1.0,
     ///                                                "a": 1.0
     ///                                            },
     ///                                            "itemTypeIcon": {
     ///                                                "$ref": "32"
     ///                                            },
     ///                                            "harvestParticlePrefab": null,
     ///                                            "overrideHarvestParticleDepth": false,
     ///                                            "harvestParticleDepthOffset": -3.0,
     ///                                            "flattenParticleShape": false,
     ///                                            "availableInDemo": false,
     ///                                            "entitlementsRequired": [
     ///                                                "NONE"
     ///                                            ],
     ///                                            "$type": "DeployableItemData"
     ///                                        }
     ///                                    }
     ///                                ],
     ///                                "researchPointsRequired": 2,
     ///                                "buyableWithoutResearch": false,
     ///                                "researchIsForRecipe": false,
     ///                                "useIntenseAberratedUIShader": false,
     ///                                "id": "pot6",
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
     ///                                    "$ref": "32"
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
     ///                    "researchPointsRequired": 3,
     ///                    "buyableWithoutResearch": false,
     ///                    "researchIsForRecipe": false,
     ///                    "useIntenseAberratedUIShader": false,
     ///                    "id": "pot7",
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
     ///                        "$ref": "32"
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
     ///            ],
     ///            "$type": "ResearchCompleteCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = RESEARCH_POTSInstance.evaluationConditions;
}

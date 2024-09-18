namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class RESEARCH_ENGINES
{
    public static AchievementData RESEARCH_ENGINESInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "RESEARCH_ENGINES");
    public static DredgeAchievementId id = DredgeAchievementId.RESEARCH_ENGINES;
    public static string steamId = "";
    public static int playStationId = 26;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "items": [
     ///                {
     ///                    "speedBonus": 9.0,
     ///                    "canBeSoldByPlayer": true,
     ///                    "canBeSoldInBulkAction": false,
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
     ///                    "damageMode": "OPERATION",
     ///                    "moveMode": "INSTALL",
     ///                    "ignoreDamageWhenPlacing": true,
     ///                    "isUnderlayItem": false,
     ///                    "forbidStorageTray": false,
     ///                    "dimensions": [
     ///                        {
     ///
     ///                        }
     ///                    ],
     ///                    "squishFactor": 0.0,
     ///                    "itemOwnPrerequisites": [],
     ///                    "researchPrerequisites": [
     ///                        {
     ///                            "itemData": {
     ///                                "speedBonus": 15.0,
     ///                                "canBeSoldByPlayer": true,
     ///                                "canBeSoldInBulkAction": false,
     ///                                "value": 200.0,
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
     ///                                "damageMode": "OPERATION",
     ///                                "moveMode": "INSTALL",
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
     ///                                "id": "engine3",
     ///                                "itemNameKey": [],
     ///                                "itemDescriptionKey": [],
     ///                                "hasAdditionalNote": false,
     ///                                "additionalNoteKey": [],
     ///                                "itemInsaneTitleKey": [],
     ///                                "itemInsaneDescriptionKey": [],
     ///                                "linkedDialogueNode": "",
     ///                                "dialogueNodeSpecificDescription": [],
     ///                                "itemType": "EQUIPMENT,ALL",
     ///                                "itemSubtype": "ENGINE,ALL",
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
     ///                                    "$id": "20"
     ///                                },
     ///                                "harvestParticlePrefab": null,
     ///                                "overrideHarvestParticleDepth": false,
     ///                                "harvestParticleDepthOffset": -3.0,
     ///                                "flattenParticleShape": false,
     ///                                "availableInDemo": false,
     ///                                "entitlementsRequired": [
     ///                                    "NONE"
     ///                                ],
     ///                                "$type": "EngineItemData",
     ///                                "$id": "9"
     ///                            }
     ///                        }
     ///                    ],
     ///                    "researchPointsRequired": 5,
     ///                    "buyableWithoutResearch": false,
     ///                    "researchIsForRecipe": false,
     ///                    "useIntenseAberratedUIShader": false,
     ///                    "id": "engine6",
     ///                    "itemNameKey": [],
     ///                    "itemDescriptionKey": [],
     ///                    "hasAdditionalNote": false,
     ///                    "additionalNoteKey": [],
     ///                    "itemInsaneTitleKey": [],
     ///                    "itemInsaneDescriptionKey": [],
     ///                    "linkedDialogueNode": "",
     ///                    "dialogueNodeSpecificDescription": [],
     ///                    "itemType": "EQUIPMENT,ALL",
     ///                    "itemSubtype": "ENGINE,ALL",
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
     ///                        "$ref": "20"
     ///                    },
     ///                    "harvestParticlePrefab": null,
     ///                    "overrideHarvestParticleDepth": false,
     ///                    "harvestParticleDepthOffset": -3.0,
     ///                    "flattenParticleShape": false,
     ///                    "availableInDemo": false,
     ///                    "entitlementsRequired": [
     ///                        "NONE"
     ///                    ],
     ///                    "$type": "EngineItemData"
     ///                },
     ///                {
     ///                    "speedBonus": 64.0,
     ///                    "canBeSoldByPlayer": true,
     ///                    "canBeSoldInBulkAction": false,
     ///                    "value": 750.0,
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
     ///                    "damageMode": "OPERATION",
     ///                    "moveMode": "INSTALL",
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
     ///                                "speedBonus": 25.0,
     ///                                "canBeSoldByPlayer": true,
     ///                                "canBeSoldInBulkAction": false,
     ///                                "value": 300.0,
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
     ///                                "damageMode": "OPERATION",
     ///                                "moveMode": "INSTALL",
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
     ///                                "researchPrerequisites": [
     ///                                    {
     ///                                        "itemData": {
     ///                                            "$ref": "9"
     ///                                        }
     ///                                    }
     ///                                ],
     ///                                "researchPointsRequired": 2,
     ///                                "buyableWithoutResearch": false,
     ///                                "researchIsForRecipe": false,
     ///                                "useIntenseAberratedUIShader": false,
     ///                                "id": "engine4",
     ///                                "itemNameKey": [],
     ///                                "itemDescriptionKey": [],
     ///                                "hasAdditionalNote": false,
     ///                                "additionalNoteKey": [],
     ///                                "itemInsaneTitleKey": [],
     ///                                "itemInsaneDescriptionKey": [],
     ///                                "linkedDialogueNode": "",
     ///                                "dialogueNodeSpecificDescription": [],
     ///                                "itemType": "EQUIPMENT,ALL",
     ///                                "itemSubtype": "ENGINE,ALL",
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
     ///                                    "$ref": "20"
     ///                                },
     ///                                "harvestParticlePrefab": null,
     ///                                "overrideHarvestParticleDepth": false,
     ///                                "harvestParticleDepthOffset": -3.0,
     ///                                "flattenParticleShape": false,
     ///                                "availableInDemo": false,
     ///                                "entitlementsRequired": [
     ///                                    "NONE"
     ///                                ],
     ///                                "$type": "EngineItemData"
     ///                            }
     ///                        },
     ///                        {
     ///                            "itemData": {
     ///                                "speedBonus": 50.0,
     ///                                "canBeSoldByPlayer": true,
     ///                                "canBeSoldInBulkAction": false,
     ///                                "value": 500.0,
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
     ///                                "damageMode": "OPERATION",
     ///                                "moveMode": "INSTALL",
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
     ///                                            "speedBonus": 35.0,
     ///                                            "canBeSoldByPlayer": true,
     ///                                            "canBeSoldInBulkAction": false,
     ///                                            "value": 450.0,
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
     ///                                            "damageMode": "OPERATION",
     ///                                            "moveMode": "INSTALL",
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
     ///                                                },
     ///                                                {
     ///
     ///                                                }
     ///                                            ],
     ///                                            "squishFactor": 0.0,
     ///                                            "itemOwnPrerequisites": [],
     ///                                            "researchPrerequisites": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "9"
     ///                                                    }
     ///                                                }
     ///                                            ],
     ///                                            "researchPointsRequired": 3,
     ///                                            "buyableWithoutResearch": false,
     ///                                            "researchIsForRecipe": false,
     ///                                            "useIntenseAberratedUIShader": false,
     ///                                            "id": "engine5",
     ///                                            "itemNameKey": [],
     ///                                            "itemDescriptionKey": [],
     ///                                            "hasAdditionalNote": false,
     ///                                            "additionalNoteKey": [],
     ///                                            "itemInsaneTitleKey": [],
     ///                                            "itemInsaneDescriptionKey": [],
     ///                                            "linkedDialogueNode": "",
     ///                                            "dialogueNodeSpecificDescription": [],
     ///                                            "itemType": "EQUIPMENT,ALL",
     ///                                            "itemSubtype": "ENGINE,ALL",
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
     ///                                                "$ref": "20"
     ///                                            },
     ///                                            "harvestParticlePrefab": null,
     ///                                            "overrideHarvestParticleDepth": false,
     ///                                            "harvestParticleDepthOffset": -3.0,
     ///                                            "flattenParticleShape": false,
     ///                                            "availableInDemo": false,
     ///                                            "entitlementsRequired": [
     ///                                                "NONE"
     ///                                            ],
     ///                                            "$type": "EngineItemData"
     ///                                        }
     ///                                    }
     ///                                ],
     ///                                "researchPointsRequired": 4,
     ///                                "buyableWithoutResearch": false,
     ///                                "researchIsForRecipe": false,
     ///                                "useIntenseAberratedUIShader": false,
     ///                                "id": "engine7",
     ///                                "itemNameKey": [],
     ///                                "itemDescriptionKey": [],
     ///                                "hasAdditionalNote": false,
     ///                                "additionalNoteKey": [],
     ///                                "itemInsaneTitleKey": [],
     ///                                "itemInsaneDescriptionKey": [],
     ///                                "linkedDialogueNode": "",
     ///                                "dialogueNodeSpecificDescription": [],
     ///                                "itemType": "EQUIPMENT,ALL",
     ///                                "itemSubtype": "ENGINE,ALL",
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
     ///                                    "$ref": "20"
     ///                                },
     ///                                "harvestParticlePrefab": null,
     ///                                "overrideHarvestParticleDepth": false,
     ///                                "harvestParticleDepthOffset": -3.0,
     ///                                "flattenParticleShape": false,
     ///                                "availableInDemo": false,
     ///                                "entitlementsRequired": [
     ///                                    "NONE"
     ///                                ],
     ///                                "$type": "EngineItemData"
     ///                            }
     ///                        }
     ///                    ],
     ///                    "researchPointsRequired": 5,
     ///                    "buyableWithoutResearch": false,
     ///                    "researchIsForRecipe": false,
     ///                    "useIntenseAberratedUIShader": false,
     ///                    "id": "engine8",
     ///                    "itemNameKey": [],
     ///                    "itemDescriptionKey": [],
     ///                    "hasAdditionalNote": false,
     ///                    "additionalNoteKey": [],
     ///                    "itemInsaneTitleKey": [],
     ///                    "itemInsaneDescriptionKey": [],
     ///                    "linkedDialogueNode": "",
     ///                    "dialogueNodeSpecificDescription": [],
     ///                    "itemType": "EQUIPMENT,ALL",
     ///                    "itemSubtype": "ENGINE,ALL",
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
     ///                        "$ref": "20"
     ///                    },
     ///                    "harvestParticlePrefab": null,
     ///                    "overrideHarvestParticleDepth": false,
     ///                    "harvestParticleDepthOffset": -3.0,
     ///                    "flattenParticleShape": false,
     ///                    "availableInDemo": false,
     ///                    "entitlementsRequired": [
     ///                        "NONE"
     ///                    ],
     ///                    "$type": "EngineItemData"
     ///                }
     ///            ],
     ///            "$type": "ResearchCompleteCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = RESEARCH_ENGINESInstance.evaluationConditions;
}

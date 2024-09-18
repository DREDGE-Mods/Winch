namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class DLC2_FactoryReward
{
    public static QuestGridConfig DLC2_FactoryRewardInstance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "DLC2_FactoryReward");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.RISK_ITEM_LOSS;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = DLC2_FactoryRewardInstance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = DLC2_FactoryRewardInstance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = DLC2_FactoryRewardInstance.exitPromptOverride;
     ///<json>
     /// null
     /// </json>
    public static UnityEngine.Sprite backgroundImage = null;
    public static float gridHeightOverride = 0f;
    public static bool overrideGridCellColor = false;
    public static DredgeColorTypeEnum gridCellColor = DredgeColorTypeEnum.NEUTRAL;
    public static bool allowStorageAccess = true;
    public static bool isSaved = false;
    public static bool createItemsIfEmpty = true;
    public static GridKey gridKey = GridKey.NONE;
    public static bool allowManualExit = true;
    public static bool allowEquipmentInstallation = true;
    public static bool createWithDurabilityValue = false;
    public static float startingDurabilityProportion = 1f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [],
     ///    "mainItemType": "EQUIPMENT,ALL",
     ///    "mainItemSubtype": "FISH,ENGINE,ROD,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,NET,DREDGE,GADGET,ALL",
     ///    "mainItemData": {
     ///        "fishingSpeedModifier": 0.7,
     ///        "harvestableTypes": [
     ///            "COASTAL",
     ///            "SHALLOW"
     ///        ],
     ///        "isAdvancedEquipment": true,
     ///        "aberrationBonus": 0.0,
     ///        "canBeSoldByPlayer": true,
     ///        "canBeSoldInBulkAction": false,
     ///        "value": 400.0,
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
     ///        "damageMode": "OPERATION",
     ///        "moveMode": "INSTALL",
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
     ///            }
     ///        ],
     ///        "squishFactor": 0.1,
     ///        "itemOwnPrerequisites": [],
     ///        "researchPrerequisites": [],
     ///        "researchPointsRequired": 0,
     ///        "buyableWithoutResearch": false,
     ///        "researchIsForRecipe": false,
     ///        "useIntenseAberratedUIShader": false,
     ///        "id": "tir-rod2",
     ///        "itemNameKey": [],
     ///        "itemDescriptionKey": [],
     ///        "hasAdditionalNote": false,
     ///        "additionalNoteKey": [],
     ///        "itemInsaneTitleKey": [],
     ///        "itemInsaneDescriptionKey": [],
     ///        "linkedDialogueNode": "",
     ///        "dialogueNodeSpecificDescription": [],
     ///        "itemType": "EQUIPMENT,ALL",
     ///        "itemSubtype": "ROD,ALL",
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
     ///        "harvestParticlePrefab": null,
     ///        "overrideHarvestParticleDepth": false,
     ///        "harvestParticleDepthOffset": -3.0,
     ///        "flattenParticleShape": false,
     ///        "availableInDemo": false,
     ///        "entitlementsRequired": [
     ///            "NONE"
     ///        ],
     ///        "$type": "RodItemData"
     ///    },
     ///    "itemsInThisBelongToPlayer": false,
     ///    "canAddItemsInQuestMode": true,
     ///    "hasUnderlay": false,
     ///    "columns": 1,
     ///    "rows": 3,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = DLC2_FactoryRewardInstance.gridConfiguration;
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
     ///            "id": "tir-rod2"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = DLC2_FactoryRewardInstance.presetGrid;
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
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = DLC2_FactoryRewardInstance.completeConditions;
}

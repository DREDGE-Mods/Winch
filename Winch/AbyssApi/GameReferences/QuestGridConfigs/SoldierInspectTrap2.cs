namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class SoldierInspectTrap2
{
    public static QuestGridConfig SoldierInspectTrap2Instance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "SoldierInspectTrap2");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.REVISITABLE;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = SoldierInspectTrap2Instance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = SoldierInspectTrap2Instance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = SoldierInspectTrap2Instance.exitPromptOverride;
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
    public static GridKey gridKey = (GridKey)215;
    public static bool allowManualExit = true;
    public static bool allowEquipmentInstallation = false;
    public static bool createWithDurabilityValue = false;
    public static float startingDurabilityProportion = 1f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [],
     ///    "mainItemType": "GENERAL,ALL",
     ///    "mainItemSubtype": "",
     ///    "mainItemData": {
     ///        "canBeSoldByPlayer": false,
     ///        "canBeSoldInBulkAction": true,
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
     ///            "a": 255.0
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
     ///            },
     ///            {
     ///
     ///            },
     ///            {
     ///
     ///            }
     ///        ],
     ///        "squishFactor": 0.4,
     ///        "itemOwnPrerequisites": [],
     ///        "researchPrerequisites": [],
     ///        "researchPointsRequired": 0,
     ///        "buyableWithoutResearch": false,
     ///        "researchIsForRecipe": false,
     ///        "useIntenseAberratedUIShader": false,
     ///        "id": "quest-corpse",
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
     ///        "harvestParticlePrefab": null,
     ///        "overrideHarvestParticleDepth": false,
     ///        "harvestParticleDepthOffset": -3.0,
     ///        "flattenParticleShape": false,
     ///        "availableInDemo": true,
     ///        "entitlementsRequired": [
     ///            "NONE"
     ///        ],
     ///        "$type": "SpatialItemData"
     ///    },
     ///    "itemsInThisBelongToPlayer": false,
     ///    "canAddItemsInQuestMode": true,
     ///    "hasUnderlay": false,
     ///    "columns": 2,
     ///    "rows": 3,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = SoldierInspectTrap2Instance.gridConfiguration;
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
     ///            "id": "quest-corpse"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = SoldierInspectTrap2Instance.presetGrid;
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
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = SoldierInspectTrap2Instance.completeConditions;
}

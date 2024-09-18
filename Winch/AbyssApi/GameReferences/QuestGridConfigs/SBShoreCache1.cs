namespace Winch.AbyssApi.GameReferences.QuestGridConfigs;
public static class SBShoreCache1
{
    public static QuestGridConfig SBShoreCache1Instance = (QuestGridConfig)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestGridConfigs, x => x.name == "SBShoreCache1");
    public static QuestGridExitMode questGridExitMode = QuestGridExitMode.REVISITABLE;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleString = SBShoreCache1Instance.titleString;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString helpStringOverride = SBShoreCache1Instance.helpStringOverride;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString exitPromptOverride = SBShoreCache1Instance.exitPromptOverride;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.Sprite backgroundImage = SBShoreCache1Instance.backgroundImage;
    public static float gridHeightOverride = 0f;
    public static bool overrideGridCellColor = false;
    public static DredgeColorTypeEnum gridCellColor = DredgeColorTypeEnum.NEUTRAL;
    public static bool allowStorageAccess = false;
    public static bool isSaved = true;
    public static bool createItemsIfEmpty = true;
    public static GridKey gridKey = GridKey.SB_SHORE_CACHE_1;
    public static bool allowManualExit = true;
    public static bool allowEquipmentInstallation = true;
    public static bool createWithDurabilityValue = false;
    public static float startingDurabilityProportion = 1f;
     ///<json>
     /// {
     ///    "cellGroupConfigs": [],
     ///    "mainItemType": "GENERAL,ALL",
     ///    "mainItemSubtype": "FISH,ENGINE,ROD,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,NET,DREDGE,GADGET,ALL",
     ///    "mainItemData": null,
     ///    "itemsInThisBelongToPlayer": false,
     ///    "canAddItemsInQuestMode": false,
     ///    "hasUnderlay": false,
     ///    "columns": 3,
     ///    "rows": 3,
     ///    "$type": "GridConfiguration"
     ///}
     ///</json>
    public static GridConfiguration gridConfiguration = SBShoreCache1Instance.gridConfiguration;
     ///<json>
     /// {
     ///    "spatialUnderlayItems": [],
     ///    "spatialItems": [
     ///        {
     ///            "x": 1,
     ///            "y": 0,
     ///            "z": 0,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "quest-map-1"
     ///        },
     ///        {
     ///            "x": 0,
     ///            "y": 0,
     ///            "z": 0,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "cloth"
     ///        },
     ///        {
     ///            "x": 0,
     ///            "y": 2,
     ///            "z": 0,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "lumber"
     ///        },
     ///        {
     ///            "x": 1,
     ///            "y": 1,
     ///            "z": 0,
     ///            "durability": 0.0,
     ///            "seen": false,
     ///            "id": "earring-2"
     ///        }
     ///    ],
     ///    "$type": "SerializableGrid"
     ///}
     ///</json>
    public static SerializableGrid presetGrid = SBShoreCache1Instance.presetGrid;
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
    public static System.Collections.Generic.List<CompletedGridCondition> completeConditions = SBShoreCache1Instance.completeConditions;
}

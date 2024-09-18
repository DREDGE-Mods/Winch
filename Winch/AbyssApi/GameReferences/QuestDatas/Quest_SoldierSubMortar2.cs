namespace Winch.AbyssApi.GameReferences.QuestDatas;
public static class Quest_SoldierSubMortar2
{
    public static QuestData Quest_SoldierSubMortar2Instance = (QuestData)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestDatas, x => x.name == "Quest_SoldierSubMortar2");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleKey = Quest_SoldierSubMortar2Instance.titleKey;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString summaryKey = Quest_SoldierSubMortar2Instance.summaryKey;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString[]"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString[] resolutionKeys = Quest_SoldierSubMortar2Instance.resolutionKeys;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[MapMarkerData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<MapMarkerData> mapMarkersToRemoveOnCompletion = Quest_SoldierSubMortar2Instance.mapMarkersToRemoveOnCompletion;
    public static bool showUnseenIndicators = false;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "mapMarkersToAddOnStart": [
     ///                {
     ///                    "x": -314.5,
     ///                    "z": 513.3,
     ///                    "mapMarkerType": "MAIN",
     ///                    "$id": "3"
     ///                }
     ///            ],
     ///            "mapMarkersToDeleteOnCompletion": [
     ///                {
     ///                    "$ref": "3"
     ///                }
     ///            ],
     ///            "hiddenWhenActive": false,
     ///            "hiddenWhenComplete": true,
     ///            "shortActiveKey": [],
     ///            "longActiveKey": [],
     ///            "completedKey": [],
     ///            "hideIfThisStepIsComplete": null,
     ///            "showAtDock": false,
     ///            "stepDock": null,
     ///            "showAtSpeaker": false,
     ///            "stepSpeaker": null,
     ///            "yarnRootNode": "",
     ///            "showConditions": [],
     ///            "canBeFailed": false,
     ///            "failureEvents": [],
     ///            "allowAutomaticCompletion": true,
     ///            "conditionMode": "ALL",
     ///            "completeConditions": [
     ///                {
     ///                    "itemId": "quest-mortar-2",
     ///                    "silent": false,
     ///                    "$type": "ItemInventoryCondition"
     ///                }
     ///            ]
     ///        },
     ///        {
     ///            "mapMarkersToAddOnStart": [],
     ///            "mapMarkersToDeleteOnCompletion": [],
     ///            "hiddenWhenActive": false,
     ///            "hiddenWhenComplete": false,
     ///            "shortActiveKey": [],
     ///            "longActiveKey": [],
     ///            "completedKey": [],
     ///            "hideIfThisStepIsComplete": {
     ///                "mapMarkersToAddOnStart": [
     ///                    {
     ///                        "x": -529.1,
     ///                        "z": 557.8,
     ///                        "mapMarkerType": "MAIN"
     ///                    },
     ///                    {
     ///                        "$ref": "3"
     ///                    }
     ///                ],
     ///                "mapMarkersToDeleteOnCompletion": [],
     ///                "hiddenWhenActive": false,
     ///                "hiddenWhenComplete": false,
     ///                "shortActiveKey": [],
     ///                "longActiveKey": [],
     ///                "completedKey": [],
     ///                "hideIfThisStepIsComplete": null,
     ///                "showAtDock": false,
     ///                "stepDock": null,
     ///                "showAtSpeaker": false,
     ///                "stepSpeaker": null,
     ///                "yarnRootNode": "",
     ///                "showConditions": [],
     ///                "canBeFailed": false,
     ///                "failureEvents": [],
     ///                "allowAutomaticCompletion": false,
     ///                "conditionMode": "ALL",
     ///                "completeConditions": []
     ///            },
     ///            "showAtDock": false,
     ///            "stepDock": null,
     ///            "showAtSpeaker": false,
     ///            "stepSpeaker": null,
     ///            "yarnRootNode": "",
     ///            "showConditions": [],
     ///            "canBeFailed": false,
     ///            "failureEvents": [],
     ///            "allowAutomaticCompletion": false,
     ///            "conditionMode": "ALL",
     ///            "completeConditions": []
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[QuestStepData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestStepData> steps = Quest_SoldierSubMortar2Instance.steps;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[QuestData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestData> subquests = Quest_SoldierSubMortar2Instance.subquests;
     ///<json>
     /// null
     /// </json>
    public static QuestStepData onOfferedQuestStep = null;
    public static bool canBeOfferedAutomatically = false;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[QuestStepCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestStepCondition> offerConditions = Quest_SoldierSubMortar2Instance.offerConditions;
    public static string PS5Subtask = "";
}

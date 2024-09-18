namespace Winch.AbyssApi.GameReferences.QuestDatas;
public static class Quest_Soldier
{
    public static QuestData Quest_SoldierInstance = (QuestData)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestDatas, x => x.name == "Quest_Soldier");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleKey = Quest_SoldierInstance.titleKey;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString summaryKey = Quest_SoldierInstance.summaryKey;
     ///<json>
     /// {
     ///    "$content": [
     ///        []
     ///    ],
     ///    "$type": "UnityEngine.Localization.LocalizedString[]"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString[] resolutionKeys = Quest_SoldierInstance.resolutionKeys;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[MapMarkerData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<MapMarkerData> mapMarkersToRemoveOnCompletion = Quest_SoldierInstance.mapMarkersToRemoveOnCompletion;
    public static bool showUnseenIndicators = true;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "mapMarkersToAddOnStart": [
     ///                {
     ///                    "x": -529.1,
     ///                    "z": 557.8,
     ///                    "mapMarkerType": "MAIN"
     ///                },
     ///                {
     ///                    "x": -314.5,
     ///                    "z": 513.3,
     ///                    "mapMarkerType": "MAIN"
     ///                }
     ///            ],
     ///            "mapMarkersToDeleteOnCompletion": [],
     ///            "hiddenWhenActive": false,
     ///            "hiddenWhenComplete": false,
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
     ///            "allowAutomaticCompletion": false,
     ///            "conditionMode": "ALL",
     ///            "completeConditions": []
     ///        },
     ///        {
     ///            "mapMarkersToAddOnStart": [],
     ///            "mapMarkersToDeleteOnCompletion": [],
     ///            "hiddenWhenActive": false,
     ///            "hiddenWhenComplete": false,
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
     ///            "allowAutomaticCompletion": false,
     ///            "conditionMode": "ALL",
     ///            "completeConditions": []
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[QuestStepData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestStepData> steps = Quest_SoldierInstance.steps;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "titleKey": [],
     ///            "summaryKey": [],
     ///            "resolutionKeys": [],
     ///            "mapMarkersToRemoveOnCompletion": [],
     ///            "showUnseenIndicators": false,
     ///            "steps": [
     ///                {
     ///                    "mapMarkersToAddOnStart": [
     ///                        {
     ///                            "x": -529.1,
     ///                            "z": 557.8,
     ///                            "mapMarkerType": "MAIN",
     ///                            "$id": "8"
     ///                        }
     ///                    ],
     ///                    "mapMarkersToDeleteOnCompletion": [
     ///                        {
     ///                            "$ref": "8"
     ///                        }
     ///                    ],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": true,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": null,
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": true,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": [
     ///                        {
     ///                            "itemId": "quest-mortar-1",
     ///                            "silent": false,
     ///                            "$type": "ItemInventoryCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": false,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": {
     ///                        "mapMarkersToAddOnStart": [
     ///                            {
     ///                                "$ref": "8"
     ///                            },
     ///                            {
     ///                                "x": -314.5,
     ///                                "z": 513.3,
     ///                                "mapMarkerType": "MAIN",
     ///                                "$id": "25"
     ///                            }
     ///                        ],
     ///                        "mapMarkersToDeleteOnCompletion": [],
     ///                        "hiddenWhenActive": false,
     ///                        "hiddenWhenComplete": false,
     ///                        "shortActiveKey": [],
     ///                        "longActiveKey": [],
     ///                        "completedKey": [],
     ///                        "hideIfThisStepIsComplete": null,
     ///                        "showAtDock": false,
     ///                        "stepDock": null,
     ///                        "showAtSpeaker": false,
     ///                        "stepSpeaker": null,
     ///                        "yarnRootNode": "",
     ///                        "showConditions": [],
     ///                        "canBeFailed": false,
     ///                        "failureEvents": [],
     ///                        "allowAutomaticCompletion": false,
     ///                        "conditionMode": "ALL",
     ///                        "completeConditions": [],
     ///                        "$id": "23"
     ///                    },
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                }
     ///            ],
     ///            "subquests": [],
     ///            "onOfferedQuestStep": null,
     ///            "canBeOfferedAutomatically": false,
     ///            "offerConditions": [],
     ///            "PS5Subtask": ""
     ///        },
     ///        {
     ///            "titleKey": [],
     ///            "summaryKey": [],
     ///            "resolutionKeys": [],
     ///            "mapMarkersToRemoveOnCompletion": [],
     ///            "showUnseenIndicators": false,
     ///            "steps": [
     ///                {
     ///                    "mapMarkersToAddOnStart": [
     ///                        {
     ///                            "$ref": "25"
     ///                        }
     ///                    ],
     ///                    "mapMarkersToDeleteOnCompletion": [
     ///                        {
     ///                            "$ref": "25"
     ///                        }
     ///                    ],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": true,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": null,
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": true,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": [
     ///                        {
     ///                            "itemId": "quest-mortar-2",
     ///                            "silent": false,
     ///                            "$type": "ItemInventoryCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": false,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": {
     ///                        "$ref": "23"
     ///                    },
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                }
     ///            ],
     ///            "subquests": [],
     ///            "onOfferedQuestStep": null,
     ///            "canBeOfferedAutomatically": false,
     ///            "offerConditions": [],
     ///            "PS5Subtask": ""
     ///        },
     ///        {
     ///            "titleKey": [],
     ///            "summaryKey": [],
     ///            "resolutionKeys": [],
     ///            "mapMarkersToRemoveOnCompletion": [],
     ///            "showUnseenIndicators": false,
     ///            "steps": [
     ///                {
     ///                    "mapMarkersToAddOnStart": [
     ///                        {
     ///                            "x": -367.8,
     ///                            "z": 463.1,
     ///                            "mapMarkerType": "MAIN"
     ///                        }
     ///                    ],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": true,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": null,
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                },
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": true,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": null,
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                },
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": false,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": {
     ///                        "mapMarkersToAddOnStart": [],
     ///                        "mapMarkersToDeleteOnCompletion": [],
     ///                        "hiddenWhenActive": false,
     ///                        "hiddenWhenComplete": false,
     ///                        "shortActiveKey": [],
     ///                        "longActiveKey": [],
     ///                        "completedKey": [],
     ///                        "hideIfThisStepIsComplete": null,
     ///                        "showAtDock": false,
     ///                        "stepDock": null,
     ///                        "showAtSpeaker": false,
     ///                        "stepSpeaker": null,
     ///                        "yarnRootNode": "",
     ///                        "showConditions": [],
     ///                        "canBeFailed": false,
     ///                        "failureEvents": [],
     ///                        "allowAutomaticCompletion": false,
     ///                        "conditionMode": "ALL",
     ///                        "completeConditions": [],
     ///                        "$id": "94"
     ///                    },
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                }
     ///            ],
     ///            "subquests": [],
     ///            "onOfferedQuestStep": null,
     ///            "canBeOfferedAutomatically": false,
     ///            "offerConditions": [],
     ///            "PS5Subtask": ""
     ///        },
     ///        {
     ///            "titleKey": [],
     ///            "summaryKey": [],
     ///            "resolutionKeys": [],
     ///            "mapMarkersToRemoveOnCompletion": [],
     ///            "showUnseenIndicators": false,
     ///            "steps": [
     ///                {
     ///                    "mapMarkersToAddOnStart": [
     ///                        {
     ///                            "x": -507.0,
     ///                            "z": 436.0,
     ///                            "mapMarkerType": "MAIN"
     ///                        }
     ///                    ],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": true,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": null,
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                },
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": true,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": null,
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                },
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": false,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": {
     ///                        "$ref": "94"
     ///                    },
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                }
     ///            ],
     ///            "subquests": [],
     ///            "onOfferedQuestStep": null,
     ///            "canBeOfferedAutomatically": false,
     ///            "offerConditions": [],
     ///            "PS5Subtask": ""
     ///        },
     ///        {
     ///            "titleKey": [],
     ///            "summaryKey": [],
     ///            "resolutionKeys": [],
     ///            "mapMarkersToRemoveOnCompletion": [],
     ///            "showUnseenIndicators": false,
     ///            "steps": [
     ///                {
     ///                    "mapMarkersToAddOnStart": [
     ///                        {
     ///                            "x": -451.0,
     ///                            "z": 612.4,
     ///                            "mapMarkerType": "MAIN"
     ///                        }
     ///                    ],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": true,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": null,
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                },
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": true,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": null,
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                },
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": false,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": {
     ///                        "$ref": "94"
     ///                    },
     ///                    "showAtDock": false,
     ///                    "stepDock": null,
     ///                    "showAtSpeaker": false,
     ///                    "stepSpeaker": null,
     ///                    "yarnRootNode": "",
     ///                    "showConditions": [],
     ///                    "canBeFailed": false,
     ///                    "failureEvents": [],
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                }
     ///            ],
     ///            "subquests": [],
     ///            "onOfferedQuestStep": null,
     ///            "canBeOfferedAutomatically": false,
     ///            "offerConditions": [],
     ///            "PS5Subtask": ""
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[QuestData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestData> subquests = Quest_SoldierInstance.subquests;
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
    public static System.Collections.Generic.List<QuestStepCondition> offerConditions = Quest_SoldierInstance.offerConditions;
    public static string PS5Subtask = "";
}

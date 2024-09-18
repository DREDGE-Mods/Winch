namespace Winch.AbyssApi.GameReferences.QuestDatas;
public static class Quest_Relics
{
    public static QuestData Quest_RelicsInstance = (QuestData)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestDatas, x => x.name == "Quest_Relics");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleKey = Quest_RelicsInstance.titleKey;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString summaryKey = Quest_RelicsInstance.summaryKey;
     ///<json>
     /// {
     ///    "$content": [
     ///        []
     ///    ],
     ///    "$type": "UnityEngine.Localization.LocalizedString[]"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString[] resolutionKeys = Quest_RelicsInstance.resolutionKeys;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[MapMarkerData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<MapMarkerData> mapMarkersToRemoveOnCompletion = Quest_RelicsInstance.mapMarkersToRemoveOnCompletion;
    public static bool showUnseenIndicators = true;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "mapMarkersToAddOnStart": [],
     ///            "mapMarkersToDeleteOnCompletion": [],
     ///            "hiddenWhenActive": true,
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
     ///            "allowAutomaticCompletion": true,
     ///            "conditionMode": "ALL",
     ///            "completeConditions": [
     ///                {
     ///                    "quest": {
     ///                        "titleKey": [],
     ///                        "summaryKey": [],
     ///                        "resolutionKeys": [],
     ///                        "mapMarkersToRemoveOnCompletion": [],
     ///                        "showUnseenIndicators": false,
     ///                        "steps": [
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "x": -76.35,
     ///                                        "z": -52.7,
     ///                                        "mapMarkerType": "MAIN",
     ///                                        "$id": "19"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": true,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": null,
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": true,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": [
     ///                                    {
     ///                                        "itemId": "relic1",
     ///                                        "silent": false,
     ///                                        "$type": "ItemInventoryCondition"
     ///                                    }
     ///                                ]
     ///                            },
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "$ref": "19"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": false,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": {
     ///                                    "$ref": "1"
     ///                                },
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": false,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": []
     ///                            }
     ///                        ],
     ///                        "subquests": [],
     ///                        "onOfferedQuestStep": null,
     ///                        "canBeOfferedAutomatically": false,
     ///                        "offerConditions": [],
     ///                        "PS5Subtask": "Task_Chapter1"
     ///                    },
     ///                    "state": "COMPLETED",
     ///                    "silent": false,
     ///                    "$type": "OtherQuestCondition"
     ///                },
     ///                {
     ///                    "quest": {
     ///                        "titleKey": [],
     ///                        "summaryKey": [],
     ///                        "resolutionKeys": [],
     ///                        "mapMarkersToRemoveOnCompletion": [],
     ///                        "showUnseenIndicators": false,
     ///                        "steps": [
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "x": 411.05,
     ///                                        "z": -463.04,
     ///                                        "mapMarkerType": "MAIN",
     ///                                        "$id": "47"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": true,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": null,
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": true,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": [
     ///                                    {
     ///                                        "itemId": "relic2",
     ///                                        "silent": false,
     ///                                        "$type": "ItemInventoryCondition"
     ///                                    }
     ///                                ]
     ///                            },
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "$ref": "47"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": false,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": {
     ///                                    "$ref": "1"
     ///                                },
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": false,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": []
     ///                            }
     ///                        ],
     ///                        "subquests": [],
     ///                        "onOfferedQuestStep": null,
     ///                        "canBeOfferedAutomatically": false,
     ///                        "offerConditions": [],
     ///                        "PS5Subtask": "Task_Chapter2"
     ///                    },
     ///                    "state": "COMPLETED",
     ///                    "silent": false,
     ///                    "$type": "OtherQuestCondition"
     ///                },
     ///                {
     ///                    "quest": {
     ///                        "titleKey": [],
     ///                        "summaryKey": [],
     ///                        "resolutionKeys": [],
     ///                        "mapMarkersToRemoveOnCompletion": [],
     ///                        "showUnseenIndicators": false,
     ///                        "steps": [
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "x": -431.6,
     ///                                        "z": -456.7,
     ///                                        "mapMarkerType": "MAIN",
     ///                                        "$id": "75"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": true,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": null,
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": true,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": [
     ///                                    {
     ///                                        "itemId": "relic3",
     ///                                        "silent": false,
     ///                                        "$type": "ItemInventoryCondition"
     ///                                    }
     ///                                ]
     ///                            },
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "$ref": "75"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": false,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": {
     ///                                    "$ref": "1"
     ///                                },
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": false,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": []
     ///                            }
     ///                        ],
     ///                        "subquests": [],
     ///                        "onOfferedQuestStep": null,
     ///                        "canBeOfferedAutomatically": false,
     ///                        "offerConditions": [],
     ///                        "PS5Subtask": "Task_Chapter3"
     ///                    },
     ///                    "state": "COMPLETED",
     ///                    "silent": false,
     ///                    "$type": "OtherQuestCondition"
     ///                },
     ///                {
     ///                    "quest": {
     ///                        "titleKey": [],
     ///                        "summaryKey": [],
     ///                        "resolutionKeys": [],
     ///                        "mapMarkersToRemoveOnCompletion": [],
     ///                        "showUnseenIndicators": false,
     ///                        "steps": [
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "x": -464.24,
     ///                                        "z": 530.35,
     ///                                        "mapMarkerType": "MAIN",
     ///                                        "$id": "103"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": true,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": null,
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": true,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": [
     ///                                    {
     ///                                        "itemId": "relic4",
     ///                                        "silent": false,
     ///                                        "$type": "ItemInventoryCondition"
     ///                                    }
     ///                                ]
     ///                            },
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "$ref": "103"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": false,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": {
     ///                                    "$ref": "1"
     ///                                },
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": false,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": []
     ///                            }
     ///                        ],
     ///                        "subquests": [],
     ///                        "onOfferedQuestStep": null,
     ///                        "canBeOfferedAutomatically": false,
     ///                        "offerConditions": [],
     ///                        "PS5Subtask": "Task_Chapter4"
     ///                    },
     ///                    "state": "COMPLETED",
     ///                    "silent": false,
     ///                    "$type": "OtherQuestCondition"
     ///                },
     ///                {
     ///                    "quest": {
     ///                        "titleKey": [],
     ///                        "summaryKey": [],
     ///                        "resolutionKeys": [],
     ///                        "mapMarkersToRemoveOnCompletion": [],
     ///                        "showUnseenIndicators": false,
     ///                        "steps": [
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "x": 454.3544,
     ///                                        "z": 451.7758,
     ///                                        "mapMarkerType": "MAIN",
     ///                                        "$id": "131"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": true,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": null,
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": true,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": [
     ///                                    {
     ///                                        "itemId": "relic5",
     ///                                        "silent": false,
     ///                                        "$type": "ItemInventoryCondition"
     ///                                    }
     ///                                ]
     ///                            },
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "$ref": "131"
     ///                                    }
     ///                                ],
     ///                                "hiddenWhenActive": false,
     ///                                "hiddenWhenComplete": false,
     ///                                "shortActiveKey": [],
     ///                                "longActiveKey": [],
     ///                                "completedKey": [],
     ///                                "hideIfThisStepIsComplete": {
     ///                                    "$ref": "1"
     ///                                },
     ///                                "showAtDock": false,
     ///                                "stepDock": null,
     ///                                "showAtSpeaker": false,
     ///                                "stepSpeaker": null,
     ///                                "yarnRootNode": "",
     ///                                "showConditions": [],
     ///                                "canBeFailed": false,
     ///                                "failureEvents": [],
     ///                                "allowAutomaticCompletion": false,
     ///                                "conditionMode": "ALL",
     ///                                "completeConditions": []
     ///                            }
     ///                        ],
     ///                        "subquests": [],
     ///                        "onOfferedQuestStep": null,
     ///                        "canBeOfferedAutomatically": false,
     ///                        "offerConditions": [],
     ///                        "PS5Subtask": "Task_Chapter5"
     ///                    },
     ///                    "state": "COMPLETED",
     ///                    "silent": false,
     ///                    "$type": "OtherQuestCondition"
     ///                }
     ///            ],
     ///            "$id": "1"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[QuestStepData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestStepData> steps = Quest_RelicsInstance.steps;
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
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [
     ///                        {
     ///                            "x": -76.35,
     ///                            "z": -52.7,
     ///                            "mapMarkerType": "MAIN",
     ///                            "$id": "9"
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
     ///                            "itemId": "relic1",
     ///                            "silent": false,
     ///                            "$type": "ItemInventoryCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [
     ///                        {
     ///                            "$ref": "9"
     ///                        }
     ///                    ],
     ///                    "hiddenWhenActive": false,
     ///                    "hiddenWhenComplete": false,
     ///                    "shortActiveKey": [],
     ///                    "longActiveKey": [],
     ///                    "completedKey": [],
     ///                    "hideIfThisStepIsComplete": {
     ///                        "mapMarkersToAddOnStart": [],
     ///                        "mapMarkersToDeleteOnCompletion": [],
     ///                        "hiddenWhenActive": true,
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
     ///                        "allowAutomaticCompletion": true,
     ///                        "conditionMode": "ALL",
     ///                        "completeConditions": [
     ///                            {
     ///                                "quest": {
     ///                                    "$ref": "1"
     ///                                },
     ///                                "state": "COMPLETED",
     ///                                "silent": false,
     ///                                "$type": "OtherQuestCondition"
     ///                            },
     ///                            {
     ///                                "quest": {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": false,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "x": 411.05,
     ///                                                    "z": -463.04,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "42"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": true,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": false,
     ///                                            "stepDock": null,
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": null,
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": true,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": [
     ///                                                {
     ///                                                    "itemId": "relic2",
     ///                                                    "silent": false,
     ///                                                    "$type": "ItemInventoryCondition"
     ///                                                }
     ///                                            ]
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "$ref": "42"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": {
     ///                                                "$ref": "23"
     ///                                            },
     ///                                            "showAtDock": false,
     ///                                            "stepDock": null,
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": null,
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": "Task_Chapter2",
     ///                                    "$id": "34"
     ///                                },
     ///                                "state": "COMPLETED",
     ///                                "silent": false,
     ///                                "$type": "OtherQuestCondition"
     ///                            },
     ///                            {
     ///                                "quest": {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": false,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "x": -431.6,
     ///                                                    "z": -456.7,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "70"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": true,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": false,
     ///                                            "stepDock": null,
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": null,
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": true,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": [
     ///                                                {
     ///                                                    "itemId": "relic3",
     ///                                                    "silent": false,
     ///                                                    "$type": "ItemInventoryCondition"
     ///                                                }
     ///                                            ]
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "$ref": "70"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": {
     ///                                                "$ref": "23"
     ///                                            },
     ///                                            "showAtDock": false,
     ///                                            "stepDock": null,
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": null,
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": "Task_Chapter3",
     ///                                    "$id": "62"
     ///                                },
     ///                                "state": "COMPLETED",
     ///                                "silent": false,
     ///                                "$type": "OtherQuestCondition"
     ///                            },
     ///                            {
     ///                                "quest": {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": false,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "x": -464.24,
     ///                                                    "z": 530.35,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "98"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": true,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": false,
     ///                                            "stepDock": null,
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": null,
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": true,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": [
     ///                                                {
     ///                                                    "itemId": "relic4",
     ///                                                    "silent": false,
     ///                                                    "$type": "ItemInventoryCondition"
     ///                                                }
     ///                                            ]
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "$ref": "98"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": {
     ///                                                "$ref": "23"
     ///                                            },
     ///                                            "showAtDock": false,
     ///                                            "stepDock": null,
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": null,
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": "Task_Chapter4",
     ///                                    "$id": "90"
     ///                                },
     ///                                "state": "COMPLETED",
     ///                                "silent": false,
     ///                                "$type": "OtherQuestCondition"
     ///                            },
     ///                            {
     ///                                "quest": {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": false,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "x": 454.3544,
     ///                                                    "z": 451.7758,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "126"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": true,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": false,
     ///                                            "stepDock": null,
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": null,
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": true,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": [
     ///                                                {
     ///                                                    "itemId": "relic5",
     ///                                                    "silent": false,
     ///                                                    "$type": "ItemInventoryCondition"
     ///                                                }
     ///                                            ]
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "$ref": "126"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": {
     ///                                                "$ref": "23"
     ///                                            },
     ///                                            "showAtDock": false,
     ///                                            "stepDock": null,
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": null,
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": "Task_Chapter5",
     ///                                    "$id": "118"
     ///                                },
     ///                                "state": "COMPLETED",
     ///                                "silent": false,
     ///                                "$type": "OtherQuestCondition"
     ///                            }
     ///                        ],
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
     ///            "PS5Subtask": "Task_Chapter1",
     ///            "$id": "1"
     ///        },
     ///        {
     ///            "$ref": "34"
     ///        },
     ///        {
     ///            "$ref": "62"
     ///        },
     ///        {
     ///            "$ref": "90"
     ///        },
     ///        {
     ///            "$ref": "118"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[QuestData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestData> subquests = Quest_RelicsInstance.subquests;
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
    public static System.Collections.Generic.List<QuestStepCondition> offerConditions = Quest_RelicsInstance.offerConditions;
    public static string PS5Subtask = "";
}

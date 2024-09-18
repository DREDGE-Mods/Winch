namespace Winch.AbyssApi.GameReferences.QuestDatas;
public static class Quest_PackageDelivery
{
    public static QuestData Quest_PackageDeliveryInstance = (QuestData)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestDatas, x => x.name == "Quest_PackageDelivery");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleKey = Quest_PackageDeliveryInstance.titleKey;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString summaryKey = Quest_PackageDeliveryInstance.summaryKey;
     ///<json>
     /// {
     ///    "$content": [
     ///        [],
     ///        []
     ///    ],
     ///    "$type": "UnityEngine.Localization.LocalizedString[]"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString[] resolutionKeys = Quest_PackageDeliveryInstance.resolutionKeys;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "x": 140.94,
     ///            "z": 5.61,
     ///            "mapMarkerType": "MAIN"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[MapMarkerData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<MapMarkerData> mapMarkersToRemoveOnCompletion = Quest_PackageDeliveryInstance.mapMarkersToRemoveOnCompletion;
    public static bool showUnseenIndicators = true;
     ///<json>
     /// {
     ///    "$content": [
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
     ///            "stepDock": {
     ///                "dockNameKey": [],
     ///                "id": "dock.little-marrow",
     ///                "musicAssetReference": {
     ///                    "m_AssetGUID": "80a38289b264da34eb1ac69d3a81ff84",
     ///                    "m_SubObjectName": "",
     ///                    "m_SubObjectType": ""
     ///                },
     ///                "musicAssetOverrides": [],
     ///                "ambienceDayAssetReference": {
     ///                    "m_AssetGUID": "eef6364d0529e244a80887eb8f72bf79",
     ///                    "m_SubObjectName": "",
     ///                    "m_SubObjectType": ""
     ///                },
     ///                "ambienceNightAssetReference": {
     ///                    "m_AssetGUID": "01ad287ea4a0759448c774174a98fe2a",
     ///                    "m_SubObjectName": "",
     ///                    "m_SubObjectType": ""
     ///                },
     ///                "ambienceDayAssetOverrides": [],
     ///                "ambienceNightAssetOverrides": [],
     ///                "yarnRootNode": "LittleMarrow_Root",
     ///                "progressTitleLocalizationKey": "",
     ///                "progressValueLocalizationKey": "",
     ///                "dockProgressType": "NONE",
     ///                "speakers": [
     ///                    {
     ///                        "speakerNameKey": "character.dockworker.name",
     ///                        "speakerNameKeyOverrides": [],
     ///                        "yarnRootNode": "Dockworker_Root",
     ///                        "portraitPrefab": {
     ///
     ///                        },
     ///                        "portraitOverrideConditions": [
     ///                            {
     ///                                "portraitPrefab": {
     ///
     ///                                },
     ///                                "smallPortraitSprite": {
     ///
     ///                                },
     ///                                "useManualState": false,
     ///                                "stateName": "",
     ///                                "stateValue": 0,
     ///                                "nodesVisited": [
     ///                                    "Dockworker_CourierDelivery"
     ///                                ]
     ///                            }
     ///                        ],
     ///                        "smallPortraitSprite": {
     ///
     ///                        },
     ///                        "visitSFX": {
     ///                            "m_AssetGUID": "",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        "loopSFX": null,
     ///                        "isIndoors": false,
     ///                        "availableInDemo": true,
     ///                        "alwaysAvailable": false,
     ///                        "hideNameplate": false,
     ///                        "highlightConditions": [],
     ///                        "paralinguistics": {
     ///                            "CHUCKLE": [
     ///                                {
     ///                                    "m_AssetGUID": "6efab088f6391ee4d8b6c97c1b71e93b",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "GRUNT": [
     ///                                {
     ///                                    "m_AssetGUID": "71c3fe710e38c0c4ab47871bd0839f07",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "MM": [
     ///                                {
     ///                                    "m_AssetGUID": "a107f17729a580c43874bcab839be868",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "0bedec62bb65f5c4d8269faf65832991",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "86ceb3ae2b72d64499435c23bf1c22d4",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "SIGH": [
     ///                                {
     ///                                    "m_AssetGUID": "ace922ff616c17c4c9adcede120b09bc",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "5eb5f48f842362a42a2e025d96d4f2e1",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "b90159d1e894b3949acf46e5f387b7bf",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "GURGLE": [
     ///                                {
     ///                                    "m_AssetGUID": "cba33d70d96e9fa428cab7952c5fc7a0",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "387ef564933ce98488c198a8368effe7",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ]
     ///                        },
     ///                        "paralinguisticOverrideConditions": [],
     ///                        "$id": "16"
     ///                    },
     ///                    {
     ///                        "speakerNameKey": "character.grieving-father.name",
     ///                        "speakerNameKeyOverrides": [],
     ///                        "yarnRootNode": "GrievingFather_Root",
     ///                        "portraitPrefab": {
     ///
     ///                        },
     ///                        "portraitOverrideConditions": [],
     ///                        "smallPortraitSprite": {
     ///
     ///                        },
     ///                        "visitSFX": {
     ///                            "m_AssetGUID": "",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        "loopSFX": null,
     ///                        "isIndoors": false,
     ///                        "availableInDemo": true,
     ///                        "alwaysAvailable": false,
     ///                        "hideNameplate": false,
     ///                        "highlightConditions": [
     ///                            {
     ///                                "alwaysHighlight": false,
     ///                                "ifTheseStepsActive": [],
     ///                                "highlightIfNodesUnvisited": [
     ///                                    "GrievingFather_Shipwrecks"
     ///                                ],
     ///                                "andTheseNodesVisited": [],
     ///                                "andTheseStepsNotCompleted": [],
     ///                                "extraConditions": null
     ///                            }
     ///                        ],
     ///                        "paralinguistics": {
     ///                            "THANKFUL": [
     ///                                {
     ///                                    "m_AssetGUID": "df279379bca20a6429dc683e2d233258",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "MM": [
     ///                                {
     ///                                    "m_AssetGUID": "b5cee50c3b446ae4c886fbf6f81b4638",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "7d8aed18c2a8d1d42b4f97620d1ec893",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "SIGH": [
     ///                                {
     ///                                    "m_AssetGUID": "dc977d7b4631a8346bc86f80a744837e",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "47b5ccc59647ca24ba35aacb076a628d",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ]
     ///                        },
     ///                        "paralinguisticOverrideConditions": []
     ///                    }
     ///                ],
     ///                "hasCameraOverride": false,
     ///                "cameraOverrideX": 0.5,
     ///                "cameraOverrideY": 0.5
     ///            },
     ///            "showAtSpeaker": false,
     ///            "stepSpeaker": {
     ///                "$ref": "16"
     ///            },
     ///            "yarnRootNode": "PackageDelivery_1",
     ///            "showConditions": [
     ///                {
     ///                    "itemId": "quest-package",
     ///                    "silent": false,
     ///                    "$type": "ItemInventoryCondition"
     ///                }
     ///            ],
     ///            "canBeFailed": true,
     ///            "failureEvents": [
     ///                {
     ///                    "itemId": "quest-package",
     ///                    "resolutionIndex": 1,
     ///                    "$type": "DestroyItemEvent"
     ///                }
     ///            ],
     ///            "allowAutomaticCompletion": false,
     ///            "conditionMode": "ALL",
     ///            "completeConditions": []
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[QuestStepData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestStepData> steps = Quest_PackageDeliveryInstance.steps;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[QuestData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestData> subquests = Quest_PackageDeliveryInstance.subquests;
     ///<json>
     /// {
     ///    "mapMarkersToAddOnStart": [],
     ///    "mapMarkersToDeleteOnCompletion": [],
     ///    "hiddenWhenActive": true,
     ///    "hiddenWhenComplete": true,
     ///    "shortActiveKey": [],
     ///    "longActiveKey": [],
     ///    "completedKey": [],
     ///    "hideIfThisStepIsComplete": null,
     ///    "showAtDock": true,
     ///    "stepDock": {
     ///        "dockNameKey": [],
     ///        "id": "dock.greater-marrow",
     ///        "musicAssetReference": {
     ///            "m_AssetGUID": "545b15b34ec9bc546a5c8d124d49230c",
     ///            "m_SubObjectName": "",
     ///            "m_SubObjectType": ""
     ///        },
     ///        "musicAssetOverrides": [],
     ///        "ambienceDayAssetReference": {
     ///            "m_AssetGUID": "051e84abcd9100b4089ee849d43f2e5f",
     ///            "m_SubObjectName": "",
     ///            "m_SubObjectType": ""
     ///        },
     ///        "ambienceNightAssetReference": {
     ///            "m_AssetGUID": "035e5c286ea6136469780bee1eca250d",
     ///            "m_SubObjectName": "",
     ///            "m_SubObjectType": ""
     ///        },
     ///        "ambienceDayAssetOverrides": [],
     ///        "ambienceNightAssetOverrides": [],
     ///        "yarnRootNode": "GreaterMarrow_Root",
     ///        "progressTitleLocalizationKey": "gm-debt.label",
     ///        "progressValueLocalizationKey": "gm-debt.remaining",
     ///        "dockProgressType": "GM_REPAYMENTS",
     ///        "speakers": [
     ///            {
     ///                "speakerNameKey": "character.builder.name",
     ///                "speakerNameKeyOverrides": [],
     ///                "yarnRootNode": "Builder_Root",
     ///                "portraitPrefab": {
     ///
     ///                },
     ///                "portraitOverrideConditions": [],
     ///                "smallPortraitSprite": {
     ///
     ///                },
     ///                "visitSFX": {
     ///                    "m_AssetGUID": "",
     ///                    "m_SubObjectName": "",
     ///                    "m_SubObjectType": ""
     ///                },
     ///                "loopSFX": null,
     ///                "isIndoors": false,
     ///                "availableInDemo": true,
     ///                "alwaysAvailable": false,
     ///                "hideNameplate": false,
     ///                "highlightConditions": [],
     ///                "paralinguistics": {
     ///                    "AAH": [
     ///                        {
     ///                            "m_AssetGUID": "dd383509c16eac848823f832406afd07",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "8b576e7a58eaf8741814a30ebc5638e0",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "CHUCKLE": [
     ///                        {
     ///                            "m_AssetGUID": "a3b341c66c0444c42bf0f7473388ee5b",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "GRUNT": [
     ///                        {
     ///                            "m_AssetGUID": "a195e1cd21004434d94369d5368716c6",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "1c45287b4edca4447a94106978d32807",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "HMM": [
     ///                        {
     ///                            "m_AssetGUID": "166c639b77d1ebe4fbb28bb8b7dddf10",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "ef69ce306291a7b439c76ecf63a5e12c",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "SIGH": [
     ///                        {
     ///                            "m_AssetGUID": "c9fcda795bee2f34494d0dbe5300fe7e",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "91f144b8afd7b614cae66bffd6920c01",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "a79321828b7d74b4fa9a56f998075e47",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ]
     ///                },
     ///                "paralinguisticOverrideConditions": []
     ///            },
     ///            {
     ///                "speakerNameKey": "character.mayor.name",
     ///                "speakerNameKeyOverrides": [],
     ///                "yarnRootNode": "Mayor_Root",
     ///                "portraitPrefab": {
     ///
     ///                },
     ///                "portraitOverrideConditions": [],
     ///                "smallPortraitSprite": {
     ///
     ///                },
     ///                "visitSFX": {
     ///                    "m_AssetGUID": "426a185b105694b4882b4160aef8ece1",
     ///                    "m_SubObjectName": "",
     ///                    "m_SubObjectType": ""
     ///                },
     ///                "loopSFX": {
     ///
     ///                },
     ///                "isIndoors": true,
     ///                "availableInDemo": true,
     ///                "alwaysAvailable": false,
     ///                "hideNameplate": false,
     ///                "highlightConditions": [],
     ///                "paralinguistics": {
     ///                    "AAH": [
     ///                        {
     ///                            "m_AssetGUID": "089f81be0d5fa784d9b1c8583bc46bae",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "LISTLESS": [
     ///                        {
     ///                            "m_AssetGUID": "84b851b5018af43428d546cd1c18942f",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "66eed934c80ec5949ad0392c54854396",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "0ea670ae77cc1044485e643da59d9180",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "HMM": [
     ///                        {
     ///                            "m_AssetGUID": "d8a3eefca7552314d8d10a1e204d8443",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "19a13fb35694dee48bf2ec9c68a2bf87",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "SIGH": [
     ///                        {
     ///                            "m_AssetGUID": "05f382ea70da35f4da5483b65215ccbd",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "329a5ba3820e37c47b59c5088fc8efc9",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "ANNOYED": [
     ///                        {
     ///                            "m_AssetGUID": "11cfd4bb5332f47418da1e5ab24cdb33",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "93bf3c6cdc41ca246aecd377b055959f",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "CHUCKLE": [
     ///                        {
     ///                            "m_AssetGUID": "e23bc9ff3556d3f489ad9275e7177bdd",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "MM": [
     ///                        {
     ///                            "m_AssetGUID": "2a5570db2d67b1e42bd0a8711f0b1eb6",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "THANKFUL": [
     ///                        {
     ///                            "m_AssetGUID": "975a4c470a5756643961b52f2a6098d2",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ]
     ///                },
     ///                "paralinguisticOverrideConditions": [],
     ///                "$id": "39"
     ///            },
     ///            {
     ///                "speakerNameKey": "character.lighthouse-keeper.name",
     ///                "speakerNameKeyOverrides": [],
     ///                "yarnRootNode": "LighthouseKeeper_Root",
     ///                "portraitPrefab": {
     ///
     ///                },
     ///                "portraitOverrideConditions": [],
     ///                "smallPortraitSprite": {
     ///
     ///                },
     ///                "visitSFX": {
     ///                    "m_AssetGUID": "",
     ///                    "m_SubObjectName": "",
     ///                    "m_SubObjectType": ""
     ///                },
     ///                "loopSFX": {
     ///
     ///                },
     ///                "isIndoors": true,
     ///                "availableInDemo": true,
     ///                "alwaysAvailable": false,
     ///                "hideNameplate": false,
     ///                "highlightConditions": [
     ///                    {
     ///                        "alwaysHighlight": false,
     ///                        "ifTheseStepsActive": [],
     ///                        "highlightIfNodesUnvisited": [
     ///                            "LighthouseKeeper_Shipwrecks"
     ///                        ],
     ///                        "andTheseNodesVisited": [],
     ///                        "andTheseStepsNotCompleted": [
     ///                            {
     ///                                "mapMarkersToAddOnStart": [],
     ///                                "mapMarkersToDeleteOnCompletion": [
     ///                                    {
     ///                                        "x": -76.35,
     ///                                        "z": -52.7,
     ///                                        "mapMarkerType": "MAIN"
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
     ///                            }
     ///                        ],
     ///                        "extraConditions": null
     ///                    }
     ///                ],
     ///                "paralinguistics": {
     ///                    "AAH": [
     ///                        {
     ///                            "m_AssetGUID": "3ea22f4e9fecbec4da3cd17ab6ae5007",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "bc51ea0c141a1d84e803fcbb4c795742",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "e2bde7bd006250f41a6896c501c0560e",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "GRUNT": [
     ///                        {
     ///                            "m_AssetGUID": "40264be603a42a74b93b093d49501276",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "27ea6f278c91ed849bcfc2d5e2203b85",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "7f630249238d43a48bb68d7d4e992f7c",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "ba517ef434d53f2469bf80f07a5239a4",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "HMM": [
     ///                        {
     ///                            "m_AssetGUID": "1ab1727517560ee41b96938c2ca3667a",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "SIGH": [
     ///                        {
     ///                            "m_AssetGUID": "69b490a17c43a4d449763c86206527fd",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "4f41d0e5a7ca7e142aa05e3e60e86531",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "d77977dbccf9fa240867e69ccd3e9f96",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "081de1d5523fef944a10e8270291e0a2",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "DISGUSTED": [
     ///                        {
     ///                            "m_AssetGUID": "a53c809d70d6981449506b370b514dd5",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "e52f695ad5b098740a9f79cf9b05a231",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "a36fe4c8fad497145af8ab557daa4b2e",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "EXASPERATED": [
     ///                        {
     ///                            "m_AssetGUID": "c3d8f47f85ea7014db06c0df8c43818f",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "f23a6cfd6499e134796883e547627dbc",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "MM": [
     ///                        {
     ///                            "m_AssetGUID": "c3055620acc4b1149b2f6313eca8eea1",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "aa9ffeda9b7ed0840891705d88bae01a",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        {
     ///                            "m_AssetGUID": "a42dbfc309c77c342ae4837c5a13fde5",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ],
     ///                    "LISTLESS": [
     ///                        {
     ///                            "m_AssetGUID": "c054370cc676adc4ca89f9b59d1f0d7a",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        }
     ///                    ]
     ///                },
     ///                "paralinguisticOverrideConditions": []
     ///            }
     ///        ],
     ///        "hasCameraOverride": false,
     ///        "cameraOverrideX": 0.5,
     ///        "cameraOverrideY": 0.5
     ///    },
     ///    "showAtSpeaker": false,
     ///    "stepSpeaker": {
     ///        "$ref": "39"
     ///    },
     ///    "yarnRootNode": "PackageDelivery_Root",
     ///    "showConditions": [],
     ///    "canBeFailed": false,
     ///    "failureEvents": [],
     ///    "allowAutomaticCompletion": false,
     ///    "conditionMode": "ALL",
     ///    "completeConditions": [],
     ///    "$type": "QuestStepData"
     ///}
     ///</json>
    public static QuestStepData onOfferedQuestStep = Quest_PackageDeliveryInstance.onOfferedQuestStep;
    public static bool canBeOfferedAutomatically = true;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "day": 2,
     ///            "silent": false,
     ///            "$type": "DayCondition"
     ///        },
     ///        {
     ///            "quest": {
     ///                "titleKey": [],
     ///                "summaryKey": [],
     ///                "resolutionKeys": [
     ///                    []
     ///                ],
     ///                "mapMarkersToRemoveOnCompletion": [],
     ///                "showUnseenIndicators": true,
     ///                "steps": [
     ///                    {
     ///                        "mapMarkersToAddOnStart": [],
     ///                        "mapMarkersToDeleteOnCompletion": [],
     ///                        "hiddenWhenActive": false,
     ///                        "hiddenWhenComplete": false,
     ///                        "shortActiveKey": [],
     ///                        "longActiveKey": [],
     ///                        "completedKey": [],
     ///                        "hideIfThisStepIsComplete": null,
     ///                        "showAtDock": false,
     ///                        "stepDock": {
     ///                            "dockNameKey": [],
     ///                            "id": "dock.greater-marrow",
     ///                            "musicAssetReference": {
     ///                                "m_AssetGUID": "545b15b34ec9bc546a5c8d124d49230c",
     ///                                "m_SubObjectName": "",
     ///                                "m_SubObjectType": ""
     ///                            },
     ///                            "musicAssetOverrides": [],
     ///                            "ambienceDayAssetReference": {
     ///                                "m_AssetGUID": "051e84abcd9100b4089ee849d43f2e5f",
     ///                                "m_SubObjectName": "",
     ///                                "m_SubObjectType": ""
     ///                            },
     ///                            "ambienceNightAssetReference": {
     ///                                "m_AssetGUID": "035e5c286ea6136469780bee1eca250d",
     ///                                "m_SubObjectName": "",
     ///                                "m_SubObjectType": ""
     ///                            },
     ///                            "ambienceDayAssetOverrides": [],
     ///                            "ambienceNightAssetOverrides": [],
     ///                            "yarnRootNode": "GreaterMarrow_Root",
     ///                            "progressTitleLocalizationKey": "gm-debt.label",
     ///                            "progressValueLocalizationKey": "gm-debt.remaining",
     ///                            "dockProgressType": "GM_REPAYMENTS",
     ///                            "speakers": [
     ///                                {
     ///                                    "speakerNameKey": "character.builder.name",
     ///                                    "speakerNameKeyOverrides": [],
     ///                                    "yarnRootNode": "Builder_Root",
     ///                                    "portraitPrefab": {
     ///
     ///                                    },
     ///                                    "portraitOverrideConditions": [],
     ///                                    "smallPortraitSprite": {
     ///
     ///                                    },
     ///                                    "visitSFX": {
     ///                                        "m_AssetGUID": "",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    "loopSFX": null,
     ///                                    "isIndoors": false,
     ///                                    "availableInDemo": true,
     ///                                    "alwaysAvailable": false,
     ///                                    "hideNameplate": false,
     ///                                    "highlightConditions": [],
     ///                                    "paralinguistics": {
     ///                                        "AAH": [
     ///                                            {
     ///                                                "m_AssetGUID": "dd383509c16eac848823f832406afd07",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "8b576e7a58eaf8741814a30ebc5638e0",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "CHUCKLE": [
     ///                                            {
     ///                                                "m_AssetGUID": "a3b341c66c0444c42bf0f7473388ee5b",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "GRUNT": [
     ///                                            {
     ///                                                "m_AssetGUID": "a195e1cd21004434d94369d5368716c6",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "1c45287b4edca4447a94106978d32807",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "HMM": [
     ///                                            {
     ///                                                "m_AssetGUID": "166c639b77d1ebe4fbb28bb8b7dddf10",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "ef69ce306291a7b439c76ecf63a5e12c",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "SIGH": [
     ///                                            {
     ///                                                "m_AssetGUID": "c9fcda795bee2f34494d0dbe5300fe7e",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "91f144b8afd7b614cae66bffd6920c01",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "a79321828b7d74b4fa9a56f998075e47",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ]
     ///                                    },
     ///                                    "paralinguisticOverrideConditions": []
     ///                                },
     ///                                {
     ///                                    "speakerNameKey": "character.mayor.name",
     ///                                    "speakerNameKeyOverrides": [],
     ///                                    "yarnRootNode": "Mayor_Root",
     ///                                    "portraitPrefab": {
     ///
     ///                                    },
     ///                                    "portraitOverrideConditions": [],
     ///                                    "smallPortraitSprite": {
     ///
     ///                                    },
     ///                                    "visitSFX": {
     ///                                        "m_AssetGUID": "426a185b105694b4882b4160aef8ece1",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    "loopSFX": {
     ///
     ///                                    },
     ///                                    "isIndoors": true,
     ///                                    "availableInDemo": true,
     ///                                    "alwaysAvailable": false,
     ///                                    "hideNameplate": false,
     ///                                    "highlightConditions": [],
     ///                                    "paralinguistics": {
     ///                                        "AAH": [
     ///                                            {
     ///                                                "m_AssetGUID": "089f81be0d5fa784d9b1c8583bc46bae",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "LISTLESS": [
     ///                                            {
     ///                                                "m_AssetGUID": "84b851b5018af43428d546cd1c18942f",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "66eed934c80ec5949ad0392c54854396",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "0ea670ae77cc1044485e643da59d9180",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "HMM": [
     ///                                            {
     ///                                                "m_AssetGUID": "d8a3eefca7552314d8d10a1e204d8443",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "19a13fb35694dee48bf2ec9c68a2bf87",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "SIGH": [
     ///                                            {
     ///                                                "m_AssetGUID": "05f382ea70da35f4da5483b65215ccbd",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "329a5ba3820e37c47b59c5088fc8efc9",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "ANNOYED": [
     ///                                            {
     ///                                                "m_AssetGUID": "11cfd4bb5332f47418da1e5ab24cdb33",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "93bf3c6cdc41ca246aecd377b055959f",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "CHUCKLE": [
     ///                                            {
     ///                                                "m_AssetGUID": "e23bc9ff3556d3f489ad9275e7177bdd",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "MM": [
     ///                                            {
     ///                                                "m_AssetGUID": "2a5570db2d67b1e42bd0a8711f0b1eb6",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "THANKFUL": [
     ///                                            {
     ///                                                "m_AssetGUID": "975a4c470a5756643961b52f2a6098d2",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ]
     ///                                    },
     ///                                    "paralinguisticOverrideConditions": [],
     ///                                    "$id": "48"
     ///                                },
     ///                                {
     ///                                    "speakerNameKey": "character.lighthouse-keeper.name",
     ///                                    "speakerNameKeyOverrides": [],
     ///                                    "yarnRootNode": "LighthouseKeeper_Root",
     ///                                    "portraitPrefab": {
     ///
     ///                                    },
     ///                                    "portraitOverrideConditions": [],
     ///                                    "smallPortraitSprite": {
     ///
     ///                                    },
     ///                                    "visitSFX": {
     ///                                        "m_AssetGUID": "",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    "loopSFX": {
     ///
     ///                                    },
     ///                                    "isIndoors": true,
     ///                                    "availableInDemo": true,
     ///                                    "alwaysAvailable": false,
     ///                                    "hideNameplate": false,
     ///                                    "highlightConditions": [
     ///                                        {
     ///                                            "alwaysHighlight": false,
     ///                                            "ifTheseStepsActive": [],
     ///                                            "highlightIfNodesUnvisited": [
     ///                                                "LighthouseKeeper_Shipwrecks"
     ///                                            ],
     ///                                            "andTheseNodesVisited": [],
     ///                                            "andTheseStepsNotCompleted": [
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                        {
     ///                                                            "x": -76.35,
     ///                                                            "z": -52.7,
     ///                                                            "mapMarkerType": "MAIN"
     ///                                                        }
     ///                                                    ],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": true,
     ///                                                    "shortActiveKey": [],
     ///                                                    "longActiveKey": [],
     ///                                                    "completedKey": [],
     ///                                                    "hideIfThisStepIsComplete": null,
     ///                                                    "showAtDock": false,
     ///                                                    "stepDock": null,
     ///                                                    "showAtSpeaker": false,
     ///                                                    "stepSpeaker": null,
     ///                                                    "yarnRootNode": "",
     ///                                                    "showConditions": [],
     ///                                                    "canBeFailed": false,
     ///                                                    "failureEvents": [],
     ///                                                    "allowAutomaticCompletion": true,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": [
     ///                                                        {
     ///                                                            "itemId": "relic1",
     ///                                                            "silent": false,
     ///                                                            "$type": "ItemInventoryCondition"
     ///                                                        }
     ///                                                    ]
     ///                                                }
     ///                                            ],
     ///                                            "extraConditions": null
     ///                                        }
     ///                                    ],
     ///                                    "paralinguistics": {
     ///                                        "AAH": [
     ///                                            {
     ///                                                "m_AssetGUID": "3ea22f4e9fecbec4da3cd17ab6ae5007",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "bc51ea0c141a1d84e803fcbb4c795742",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "e2bde7bd006250f41a6896c501c0560e",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "GRUNT": [
     ///                                            {
     ///                                                "m_AssetGUID": "40264be603a42a74b93b093d49501276",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "27ea6f278c91ed849bcfc2d5e2203b85",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "7f630249238d43a48bb68d7d4e992f7c",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "ba517ef434d53f2469bf80f07a5239a4",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "HMM": [
     ///                                            {
     ///                                                "m_AssetGUID": "1ab1727517560ee41b96938c2ca3667a",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "SIGH": [
     ///                                            {
     ///                                                "m_AssetGUID": "69b490a17c43a4d449763c86206527fd",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "4f41d0e5a7ca7e142aa05e3e60e86531",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "d77977dbccf9fa240867e69ccd3e9f96",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "081de1d5523fef944a10e8270291e0a2",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "DISGUSTED": [
     ///                                            {
     ///                                                "m_AssetGUID": "a53c809d70d6981449506b370b514dd5",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "e52f695ad5b098740a9f79cf9b05a231",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "a36fe4c8fad497145af8ab557daa4b2e",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "EXASPERATED": [
     ///                                            {
     ///                                                "m_AssetGUID": "c3d8f47f85ea7014db06c0df8c43818f",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "f23a6cfd6499e134796883e547627dbc",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "MM": [
     ///                                            {
     ///                                                "m_AssetGUID": "c3055620acc4b1149b2f6313eca8eea1",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "aa9ffeda9b7ed0840891705d88bae01a",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            },
     ///                                            {
     ///                                                "m_AssetGUID": "a42dbfc309c77c342ae4837c5a13fde5",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ],
     ///                                        "LISTLESS": [
     ///                                            {
     ///                                                "m_AssetGUID": "c054370cc676adc4ca89f9b59d1f0d7a",
     ///                                                "m_SubObjectName": "",
     ///                                                "m_SubObjectType": ""
     ///                                            }
     ///                                        ]
     ///                                    },
     ///                                    "paralinguisticOverrideConditions": []
     ///                                }
     ///                            ],
     ///                            "hasCameraOverride": false,
     ///                            "cameraOverrideX": 0.5,
     ///                            "cameraOverrideY": 0.5,
     ///                            "$id": "15"
     ///                        },
     ///                        "showAtSpeaker": false,
     ///                        "stepSpeaker": {
     ///                            "$ref": "48"
     ///                        },
     ///                        "yarnRootNode": "",
     ///                        "showConditions": [],
     ///                        "canBeFailed": false,
     ///                        "failureEvents": [],
     ///                        "allowAutomaticCompletion": false,
     ///                        "conditionMode": "ALL",
     ///                        "completeConditions": []
     ///                    },
     ///                    {
     ///                        "mapMarkersToAddOnStart": [],
     ///                        "mapMarkersToDeleteOnCompletion": [],
     ///                        "hiddenWhenActive": false,
     ///                        "hiddenWhenComplete": false,
     ///                        "shortActiveKey": [],
     ///                        "longActiveKey": [],
     ///                        "completedKey": [],
     ///                        "hideIfThisStepIsComplete": null,
     ///                        "showAtDock": false,
     ///                        "stepDock": {
     ///                            "$ref": "15"
     ///                        },
     ///                        "showAtSpeaker": false,
     ///                        "stepSpeaker": {
     ///                            "$ref": "48"
     ///                        },
     ///                        "yarnRootNode": "",
     ///                        "showConditions": [],
     ///                        "canBeFailed": false,
     ///                        "failureEvents": [],
     ///                        "allowAutomaticCompletion": false,
     ///                        "conditionMode": "ALL",
     ///                        "completeConditions": []
     ///                    },
     ///                    {
     ///                        "mapMarkersToAddOnStart": [],
     ///                        "mapMarkersToDeleteOnCompletion": [],
     ///                        "hiddenWhenActive": false,
     ///                        "hiddenWhenComplete": false,
     ///                        "shortActiveKey": [],
     ///                        "longActiveKey": [],
     ///                        "completedKey": [],
     ///                        "hideIfThisStepIsComplete": null,
     ///                        "showAtDock": false,
     ///                        "stepDock": {
     ///                            "$ref": "15"
     ///                        },
     ///                        "showAtSpeaker": false,
     ///                        "stepSpeaker": {
     ///                            "$ref": "48"
     ///                        },
     ///                        "yarnRootNode": "",
     ///                        "showConditions": [],
     ///                        "canBeFailed": false,
     ///                        "failureEvents": [],
     ///                        "allowAutomaticCompletion": false,
     ///                        "conditionMode": "ALL",
     ///                        "completeConditions": []
     ///                    }
     ///                ],
     ///                "subquests": [],
     ///                "onOfferedQuestStep": null,
     ///                "canBeOfferedAutomatically": false,
     ///                "offerConditions": [],
     ///                "PS5Subtask": ""
     ///            },
     ///            "state": "COMPLETED",
     ///            "silent": false,
     ///            "$type": "OtherQuestCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[QuestStepCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestStepCondition> offerConditions = Quest_PackageDeliveryInstance.offerConditions;
    public static string PS5Subtask = "";
}

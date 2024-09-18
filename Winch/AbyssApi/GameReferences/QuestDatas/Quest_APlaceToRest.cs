namespace Winch.AbyssApi.GameReferences.QuestDatas;
public static class Quest_APlaceToRest
{
    public static QuestData Quest_APlaceToRestInstance = (QuestData)System.Linq.Enumerable.First(ScriptableObjectInstances.QuestDatas, x => x.name == "Quest_APlaceToRest");
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString titleKey = Quest_APlaceToRestInstance.titleKey;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "UnityEngine.Localization.LocalizedString"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString summaryKey = Quest_APlaceToRestInstance.summaryKey;
     ///<json>
     /// {
     ///    "$content": [
     ///        [],
     ///        []
     ///    ],
     ///    "$type": "UnityEngine.Localization.LocalizedString[]"
     ///}
     ///</json>
    public static UnityEngine.Localization.LocalizedString[] resolutionKeys = Quest_APlaceToRestInstance.resolutionKeys;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[MapMarkerData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<MapMarkerData> mapMarkersToRemoveOnCompletion = Quest_APlaceToRestInstance.mapMarkersToRemoveOnCompletion;
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
     ///            "showAtDock": true,
     ///            "stepDock": {
     ///                "dockNameKey": [],
     ///                "id": "dock.greater-marrow",
     ///                "musicAssetReference": {
     ///                    "m_AssetGUID": "545b15b34ec9bc546a5c8d124d49230c",
     ///                    "m_SubObjectName": "",
     ///                    "m_SubObjectType": ""
     ///                },
     ///                "musicAssetOverrides": [],
     ///                "ambienceDayAssetReference": {
     ///                    "m_AssetGUID": "051e84abcd9100b4089ee849d43f2e5f",
     ///                    "m_SubObjectName": "",
     ///                    "m_SubObjectType": ""
     ///                },
     ///                "ambienceNightAssetReference": {
     ///                    "m_AssetGUID": "035e5c286ea6136469780bee1eca250d",
     ///                    "m_SubObjectName": "",
     ///                    "m_SubObjectType": ""
     ///                },
     ///                "ambienceDayAssetOverrides": [],
     ///                "ambienceNightAssetOverrides": [],
     ///                "yarnRootNode": "GreaterMarrow_Root",
     ///                "progressTitleLocalizationKey": "gm-debt.label",
     ///                "progressValueLocalizationKey": "gm-debt.remaining",
     ///                "dockProgressType": "GM_REPAYMENTS",
     ///                "speakers": [
     ///                    {
     ///                        "speakerNameKey": "character.builder.name",
     ///                        "speakerNameKeyOverrides": [],
     ///                        "yarnRootNode": "Builder_Root",
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
     ///                        "highlightConditions": [],
     ///                        "paralinguistics": {
     ///                            "AAH": [
     ///                                {
     ///                                    "m_AssetGUID": "dd383509c16eac848823f832406afd07",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "8b576e7a58eaf8741814a30ebc5638e0",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "CHUCKLE": [
     ///                                {
     ///                                    "m_AssetGUID": "a3b341c66c0444c42bf0f7473388ee5b",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "GRUNT": [
     ///                                {
     ///                                    "m_AssetGUID": "a195e1cd21004434d94369d5368716c6",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "1c45287b4edca4447a94106978d32807",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "HMM": [
     ///                                {
     ///                                    "m_AssetGUID": "166c639b77d1ebe4fbb28bb8b7dddf10",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "ef69ce306291a7b439c76ecf63a5e12c",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "SIGH": [
     ///                                {
     ///                                    "m_AssetGUID": "c9fcda795bee2f34494d0dbe5300fe7e",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "91f144b8afd7b614cae66bffd6920c01",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "a79321828b7d74b4fa9a56f998075e47",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ]
     ///                        },
     ///                        "paralinguisticOverrideConditions": [],
     ///                        "$id": "25"
     ///                    },
     ///                    {
     ///                        "speakerNameKey": "character.mayor.name",
     ///                        "speakerNameKeyOverrides": [],
     ///                        "yarnRootNode": "Mayor_Root",
     ///                        "portraitPrefab": {
     ///
     ///                        },
     ///                        "portraitOverrideConditions": [],
     ///                        "smallPortraitSprite": {
     ///
     ///                        },
     ///                        "visitSFX": {
     ///                            "m_AssetGUID": "426a185b105694b4882b4160aef8ece1",
     ///                            "m_SubObjectName": "",
     ///                            "m_SubObjectType": ""
     ///                        },
     ///                        "loopSFX": {
     ///
     ///                        },
     ///                        "isIndoors": true,
     ///                        "availableInDemo": true,
     ///                        "alwaysAvailable": false,
     ///                        "hideNameplate": false,
     ///                        "highlightConditions": [],
     ///                        "paralinguistics": {
     ///                            "AAH": [
     ///                                {
     ///                                    "m_AssetGUID": "089f81be0d5fa784d9b1c8583bc46bae",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "LISTLESS": [
     ///                                {
     ///                                    "m_AssetGUID": "84b851b5018af43428d546cd1c18942f",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "66eed934c80ec5949ad0392c54854396",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "0ea670ae77cc1044485e643da59d9180",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "HMM": [
     ///                                {
     ///                                    "m_AssetGUID": "d8a3eefca7552314d8d10a1e204d8443",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "19a13fb35694dee48bf2ec9c68a2bf87",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "SIGH": [
     ///                                {
     ///                                    "m_AssetGUID": "05f382ea70da35f4da5483b65215ccbd",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "329a5ba3820e37c47b59c5088fc8efc9",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "ANNOYED": [
     ///                                {
     ///                                    "m_AssetGUID": "11cfd4bb5332f47418da1e5ab24cdb33",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "93bf3c6cdc41ca246aecd377b055959f",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "CHUCKLE": [
     ///                                {
     ///                                    "m_AssetGUID": "e23bc9ff3556d3f489ad9275e7177bdd",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "MM": [
     ///                                {
     ///                                    "m_AssetGUID": "2a5570db2d67b1e42bd0a8711f0b1eb6",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "THANKFUL": [
     ///                                {
     ///                                    "m_AssetGUID": "975a4c470a5756643961b52f2a6098d2",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ]
     ///                        },
     ///                        "paralinguisticOverrideConditions": []
     ///                    },
     ///                    {
     ///                        "speakerNameKey": "character.lighthouse-keeper.name",
     ///                        "speakerNameKeyOverrides": [],
     ///                        "yarnRootNode": "LighthouseKeeper_Root",
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
     ///                        "loopSFX": {
     ///
     ///                        },
     ///                        "isIndoors": true,
     ///                        "availableInDemo": true,
     ///                        "alwaysAvailable": false,
     ///                        "hideNameplate": false,
     ///                        "highlightConditions": [
     ///                            {
     ///                                "alwaysHighlight": false,
     ///                                "ifTheseStepsActive": [],
     ///                                "highlightIfNodesUnvisited": [
     ///                                    "LighthouseKeeper_Shipwrecks"
     ///                                ],
     ///                                "andTheseNodesVisited": [],
     ///                                "andTheseStepsNotCompleted": [
     ///                                    {
     ///                                        "mapMarkersToAddOnStart": [],
     ///                                        "mapMarkersToDeleteOnCompletion": [
     ///                                            {
     ///                                                "x": -76.35,
     ///                                                "z": -52.7,
     ///                                                "mapMarkerType": "MAIN"
     ///                                            }
     ///                                        ],
     ///                                        "hiddenWhenActive": false,
     ///                                        "hiddenWhenComplete": true,
     ///                                        "shortActiveKey": [],
     ///                                        "longActiveKey": [],
     ///                                        "completedKey": [],
     ///                                        "hideIfThisStepIsComplete": null,
     ///                                        "showAtDock": false,
     ///                                        "stepDock": null,
     ///                                        "showAtSpeaker": false,
     ///                                        "stepSpeaker": null,
     ///                                        "yarnRootNode": "",
     ///                                        "showConditions": [],
     ///                                        "canBeFailed": false,
     ///                                        "failureEvents": [],
     ///                                        "allowAutomaticCompletion": true,
     ///                                        "conditionMode": "ALL",
     ///                                        "completeConditions": [
     ///                                            {
     ///                                                "itemId": "relic1",
     ///                                                "silent": false,
     ///                                                "$type": "ItemInventoryCondition"
     ///                                            }
     ///                                        ]
     ///                                    }
     ///                                ],
     ///                                "extraConditions": null
     ///                            }
     ///                        ],
     ///                        "paralinguistics": {
     ///                            "AAH": [
     ///                                {
     ///                                    "m_AssetGUID": "3ea22f4e9fecbec4da3cd17ab6ae5007",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "bc51ea0c141a1d84e803fcbb4c795742",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "e2bde7bd006250f41a6896c501c0560e",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "GRUNT": [
     ///                                {
     ///                                    "m_AssetGUID": "40264be603a42a74b93b093d49501276",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "27ea6f278c91ed849bcfc2d5e2203b85",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "7f630249238d43a48bb68d7d4e992f7c",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "ba517ef434d53f2469bf80f07a5239a4",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "HMM": [
     ///                                {
     ///                                    "m_AssetGUID": "1ab1727517560ee41b96938c2ca3667a",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "SIGH": [
     ///                                {
     ///                                    "m_AssetGUID": "69b490a17c43a4d449763c86206527fd",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "4f41d0e5a7ca7e142aa05e3e60e86531",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "d77977dbccf9fa240867e69ccd3e9f96",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "081de1d5523fef944a10e8270291e0a2",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "DISGUSTED": [
     ///                                {
     ///                                    "m_AssetGUID": "a53c809d70d6981449506b370b514dd5",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "e52f695ad5b098740a9f79cf9b05a231",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "a36fe4c8fad497145af8ab557daa4b2e",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "EXASPERATED": [
     ///                                {
     ///                                    "m_AssetGUID": "c3d8f47f85ea7014db06c0df8c43818f",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "f23a6cfd6499e134796883e547627dbc",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "MM": [
     ///                                {
     ///                                    "m_AssetGUID": "c3055620acc4b1149b2f6313eca8eea1",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "aa9ffeda9b7ed0840891705d88bae01a",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                },
     ///                                {
     ///                                    "m_AssetGUID": "a42dbfc309c77c342ae4837c5a13fde5",
     ///                                    "m_SubObjectName": "",
     ///                                    "m_SubObjectType": ""
     ///                                }
     ///                            ],
     ///                            "LISTLESS": [
     ///                                {
     ///                                    "m_AssetGUID": "c054370cc676adc4ca89f9b59d1f0d7a",
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
     ///                "$ref": "25"
     ///            },
     ///            "yarnRootNode": "APlaceToRest_Return",
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
     ///            "canBeFailed": true,
     ///            "failureEvents": [
     ///                {
     ///                    "itemId": "quest-builder",
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
    public static System.Collections.Generic.List<QuestStepData> steps = Quest_APlaceToRestInstance.steps;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[QuestData, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<QuestData> subquests = Quest_APlaceToRestInstance.subquests;
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
     ///                "paralinguisticOverrideConditions": [],
     ///                "$id": "15"
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
     ///                "paralinguisticOverrideConditions": []
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
     ///        "$ref": "15"
     ///    },
     ///    "yarnRootNode": "APlaceToRest_Offer",
     ///    "showConditions": [],
     ///    "canBeFailed": false,
     ///    "failureEvents": [],
     ///    "allowAutomaticCompletion": false,
     ///    "conditionMode": "ALL",
     ///    "completeConditions": [],
     ///    "$type": "QuestStepData"
     ///}
     ///</json>
    public static QuestStepData onOfferedQuestStep = Quest_APlaceToRestInstance.onOfferedQuestStep;
    public static bool canBeOfferedAutomatically = true;
     ///<json>
     /// {
     ///    "$content": [
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
     ///                                    "paralinguisticOverrideConditions": []
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
     ///                            "cameraOverrideY": 0.5
     ///                        },
     ///                        "showAtSpeaker": false,
     ///                        "stepSpeaker": null,
     ///                        "yarnRootNode": "",
     ///                        "showConditions": [
     ///                            {
     ///                                "wantAberration": true,
     ///                                "silent": false,
     ///                                "$type": "AberrantItemInventoryCondition"
     ///                            }
     ///                        ],
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
     ///                            "dockNameKey": [],
     ///                            "id": "dock.outcast-isle",
     ///                            "musicAssetReference": {
     ///                                "m_AssetGUID": "7a961f399875688489479f74c490df31",
     ///                                "m_SubObjectName": "",
     ///                                "m_SubObjectType": ""
     ///                            },
     ///                            "musicAssetOverrides": [],
     ///                            "ambienceDayAssetReference": {
     ///                                "m_AssetGUID": "8f2262b4e25e7ad4d91dc832beb96f6b",
     ///                                "m_SubObjectName": "",
     ///                                "m_SubObjectType": ""
     ///                            },
     ///                            "ambienceNightAssetReference": {
     ///                                "m_AssetGUID": "50c2c977f0cdd2d4d882808242b0647c",
     ///                                "m_SubObjectName": "",
     ///                                "m_SubObjectType": ""
     ///                            },
     ///                            "ambienceDayAssetOverrides": [],
     ///                            "ambienceNightAssetOverrides": [],
     ///                            "yarnRootNode": "",
     ///                            "progressTitleLocalizationKey": "",
     ///                            "progressValueLocalizationKey": "",
     ///                            "dockProgressType": "NONE",
     ///                            "speakers": [],
     ///                            "hasCameraOverride": true,
     ///                            "cameraOverrideX": 0.5,
     ///                            "cameraOverrideY": 0.5,
     ///                            "$id": "142"
     ///                        },
     ///                        "showAtSpeaker": true,
     ///                        "stepSpeaker": {
     ///                            "speakerNameKey": "character.collector.name",
     ///                            "speakerNameKeyOverrides": [],
     ///                            "yarnRootNode": "Collector_Root",
     ///                            "portraitPrefab": {
     ///
     ///                            },
     ///                            "portraitOverrideConditions": [
     ///                                {
     ///                                    "portraitPrefab": {
     ///
     ///                                    },
     ///                                    "smallPortraitSprite": null,
     ///                                    "useManualState": false,
     ///                                    "stateName": "",
     ///                                    "stateValue": 0,
     ///                                    "nodesVisited": [
     ///                                        "Finale_BadRoot"
     ///                                    ]
     ///                                },
     ///                                {
     ///                                    "portraitPrefab": {
     ///
     ///                                    },
     ///                                    "smallPortraitSprite": null,
     ///                                    "useManualState": false,
     ///                                    "stateName": "",
     ///                                    "stateValue": 0,
     ///                                    "nodesVisited": [
     ///                                        "Collector_PickupAccept"
     ///                                    ]
     ///                                },
     ///                                {
     ///                                    "portraitPrefab": {
     ///
     ///                                    },
     ///                                    "smallPortraitSprite": null,
     ///                                    "useManualState": false,
     ///                                    "stateName": "",
     ///                                    "stateValue": 0,
     ///                                    "nodesVisited": [
     ///                                        "Collector_PostReveal"
     ///                                    ]
     ///                                },
     ///                                {
     ///                                    "portraitPrefab": {
     ///
     ///                                    },
     ///                                    "smallPortraitSprite": null,
     ///                                    "useManualState": false,
     ///                                    "stateName": "",
     ///                                    "stateValue": 0,
     ///                                    "nodesVisited": [
     ///                                        "Collector_Revealed"
     ///                                    ]
     ///                                }
     ///                            ],
     ///                            "smallPortraitSprite": null,
     ///                            "visitSFX": {
     ///                                "m_AssetGUID": "",
     ///                                "m_SubObjectName": "",
     ///                                "m_SubObjectType": ""
     ///                            },
     ///                            "loopSFX": null,
     ///                            "isIndoors": false,
     ///                            "availableInDemo": true,
     ///                            "alwaysAvailable": false,
     ///                            "hideNameplate": false,
     ///                            "highlightConditions": [],
     ///                            "paralinguistics": {
     ///                                "AAH": [
     ///                                    {
     ///                                        "m_AssetGUID": "1f9ba00a50e8e424eb20cce2a9d4a9af",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "2ce1aa98cbc7ad74db803f51ab303ece",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    }
     ///                                ],
     ///                                "ANNOYED": [
     ///                                    {
     ///                                        "m_AssetGUID": "fce20b595a067bf40a09542cf673f432",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    }
     ///                                ],
     ///                                "DISGUSTED": [
     ///                                    {
     ///                                        "m_AssetGUID": "ca3acd18a481e2041b3da32599b64af5",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    }
     ///                                ],
     ///                                "CHUCKLE": [
     ///                                    {
     ///                                        "m_AssetGUID": "c3b3e10ecc9325e42a22d4751b3c8e3d",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "2ccb2cebf2144a94888c4a609d215ff9",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "55200aaef6e37754b9d212dc6fc120b2",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    }
     ///                                ],
     ///                                "EXASPERATED": [
     ///                                    {
     ///                                        "m_AssetGUID": "c3d49a1182639e447aca6b95f6c16ac7",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "e6a93ac22b9c6954e8733ac29c79974b",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "ba9ae1baba1bb3c4da09566d14a3ff5a",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    }
     ///                                ],
     ///                                "GRUNT": [
     ///                                    {
     ///                                        "m_AssetGUID": "7d3c364eb47b05844827995ec69e27eb",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "007c19bf9e2e66945a29bfa848c99dbe",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    }
     ///                                ],
     ///                                "HMM": [
     ///                                    {
     ///                                        "m_AssetGUID": "be58804e09a93894890924b5040a9e3f",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "d4433e5a49c97114181b39c64808ea54",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "5697dbf2aa2fa3b40ade932be00264ab",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "36e833f36776fe947b11a1ee9378933d",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    }
     ///                                ],
     ///                                "IMPATIENT": [
     ///                                    {
     ///                                        "m_AssetGUID": "f89473fdbf0ed174d9321fd0976d0a6a",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "f1dac9d741cf1e64daa17cf4152db476",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "a8b07252016d0ab4fa183553a86057c8",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "2e9619114ba238645b4ae915188ae60f",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    }
     ///                                ],
     ///                                "SIGH": [
     ///                                    {
     ///                                        "m_AssetGUID": "b90a2776005bdc949b830cb44e1c8b1a",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    {
     ///                                        "m_AssetGUID": "7839f0a1ec95bb740b4804031f84938f",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    }
     ///                                ]
     ///                            },
     ///                            "paralinguisticOverrideConditions": [
     ///                                {
     ///                                    "config": {
     ///                                        "paralinguistics": {
     ///                                            "AAH": [
     ///                                                {
     ///                                                    "m_AssetGUID": "00f1ec6f05951124a8e2d80191bd9335",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "3dd665ceb038a584cb25df8dbe0d0385",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                }
     ///                                            ],
     ///                                            "ANNOYED": [
     ///                                                {
     ///                                                    "m_AssetGUID": "2688f4f309470de44ade3d2b3c2062eb",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                }
     ///                                            ],
     ///                                            "DISGUSTED": [
     ///                                                {
     ///                                                    "m_AssetGUID": "adeccd082d170eb47b4a0644a1b79914",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                }
     ///                                            ],
     ///                                            "CHUCKLE": [
     ///                                                {
     ///                                                    "m_AssetGUID": "7946f98f3d6018142a2b9c231c4d7035",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "a9844a35342b08541b19cb6792e3c6ab",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "07e15fe4af20c414181e27282082289e",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                }
     ///                                            ],
     ///                                            "EXASPERATED": [
     ///                                                {
     ///                                                    "m_AssetGUID": "34e75ee3bc5e0674baeae1ed86e5708b",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "054498a0672e4ea4e948d043080a9d59",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "58255c2e6f893184b82da9f547172eb8",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                }
     ///                                            ],
     ///                                            "GRUNT": [
     ///                                                {
     ///                                                    "m_AssetGUID": "2688f4f309470de44ade3d2b3c2062eb",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "4c4ded27a233fdf49964fe6f2e97af29",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                }
     ///                                            ],
     ///                                            "HMM": [
     ///                                                {
     ///                                                    "m_AssetGUID": "450634b1d1ed788439e832770e16f919",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "0a24147df8d49bd45a6fc9c9d5045ad7",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "a79f06cf1c674ad4592138bebb56c99d",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "a1c19f4a37ebd9043abe38b388094262",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                }
     ///                                            ],
     ///                                            "IMPATIENT": [
     ///                                                {
     ///                                                    "m_AssetGUID": "a36491d455eb6da4b99ec05a7aabcf49",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "cb4f65fffc6c1c14bb6071be3feaf960",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "b97864baf288df547af227ea78d0dfe5",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "f26911ef0536c864098f173e4fd2ef6c",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                }
     ///                                            ],
     ///                                            "SIGH": [
     ///                                                {
     ///                                                    "m_AssetGUID": "c7c67e23f7bc3bc4cb91280995e55316",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                {
     ///                                                    "m_AssetGUID": "bda96229ebf00b54695bb9faf204a09d",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                }
     ///                                            ]
     ///                                        }
     ///                                    },
     ///                                    "nodesVisited": [
     ///                                        "Collector_Revealed"
     ///                                    ]
     ///                                }
     ///                            ],
     ///                            "$id": "151"
     ///                        },
     ///                        "yarnRootNode": "Collector_StrangeFish_Meeting",
     ///                        "showConditions": [],
     ///                        "canBeFailed": false,
     ///                        "failureEvents": [],
     ///                        "allowAutomaticCompletion": false,
     ///                        "conditionMode": "ALL",
     ///                        "completeConditions": []
     ///                    },
     ///                    {
     ///                        "mapMarkersToAddOnStart": [],
     ///                        "mapMarkersToDeleteOnCompletion": [
     ///                            {
     ///                                "x": 89.5,
     ///                                "z": -123.5,
     ///                                "mapMarkerType": "MAIN"
     ///                            }
     ///                        ],
     ///                        "hiddenWhenActive": false,
     ///                        "hiddenWhenComplete": false,
     ///                        "shortActiveKey": [],
     ///                        "longActiveKey": [],
     ///                        "completedKey": [],
     ///                        "hideIfThisStepIsComplete": null,
     ///                        "showAtDock": false,
     ///                        "stepDock": {
     ///                            "$ref": "142"
     ///                        },
     ///                        "showAtSpeaker": true,
     ///                        "stepSpeaker": {
     ///                            "$ref": "151"
     ///                        },
     ///                        "yarnRootNode": "Collector_StrangeFish_Return_AfterDeclining",
     ///                        "showConditions": [],
     ///                        "canBeFailed": false,
     ///                        "failureEvents": [],
     ///                        "allowAutomaticCompletion": false,
     ///                        "conditionMode": "ALL",
     ///                        "completeConditions": []
     ///                    }
     ///                ],
     ///                "subquests": [],
     ///                "onOfferedQuestStep": {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": true,
     ///                    "hiddenWhenComplete": false,
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
     ///                            "wantAberration": true,
     ///                            "silent": false,
     ///                            "$type": "AberrantItemInventoryCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                "canBeOfferedAutomatically": true,
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
    public static System.Collections.Generic.List<QuestStepCondition> offerConditions = Quest_APlaceToRestInstance.offerConditions;
    public static string PS5Subtask = "";
}

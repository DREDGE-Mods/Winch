namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class ALL_ACHIEVEMENTS
{
    public static AchievementData ALL_ACHIEVEMENTSInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "ALL_ACHIEVEMENTS");
    public static DredgeAchievementId id = DredgeAchievementId.ALL_ACHIEVEMENTS;
    public static string steamId = "";
    public static int playStationId = 0;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "achievements": [
     ///                {
     ///                    "id": "ABILITY_ATROPHY",
     ///                    "steamId": "ABILITY_ATROPHY",
     ///                    "playStationId": 18,
     ///                    "xboxId": "18",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "ABILITY_BAIT",
     ///                    "steamId": "ABILITY_BAIT",
     ///                    "playStationId": 14,
     ///                    "xboxId": "14",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "ABILITY_BANISH",
     ///                    "steamId": "ABILITY_BANISH",
     ///                    "playStationId": 17,
     ///                    "xboxId": "17",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "key": "threats-banished",
     ///                            "target": 10,
     ///                            "evaluationMode": "GTE",
     ///                            "$type": "IntCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "ABILITY_FOGHORN",
     ///                    "steamId": "ABILITY_FOGHORN",
     ///                    "playStationId": 12,
     ///                    "xboxId": "12",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "ABILITY_HASTE",
     ///                    "steamId": "ABILITY_HASTE",
     ///                    "playStationId": 15,
     ///                    "xboxId": "15",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "ABILITY_MANIFEST",
     ///                    "steamId": "ABILITY_MANIFEST",
     ///                    "playStationId": 16,
     ///                    "xboxId": "16",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "ABILITY_SPYGLASS",
     ///                    "steamId": "ABILITY_SPYGLASS",
     ///                    "playStationId": 13,
     ///                    "xboxId": "13",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "keys": [
     ///                                "spied-coastal",
     ///                                "spied-shallow",
     ///                                "spied-oceanic",
     ///                                "spied-abyssal",
     ///                                "spied-hadal",
     ///                                "spied-mangrove",
     ///                                "spied-volcanic"
     ///                            ],
     ///                            "state": true,
     ///                            "$type": "BoolCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "CATCH_ALL_ABERRATIONS",
     ///                    "steamId": "CATCH_ALL_ABERRATIONS",
     ///                    "playStationId": 11,
     ///                    "xboxId": "11",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "CATCH_ALL_REGULAR_FISH",
     ///                    "steamId": "CATCH_ALL_REGULAR_FISH",
     ///                    "playStationId": 2,
     ///                    "xboxId": "2",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "CATCH_CRABS_POT_1",
     ///                    "steamId": "CATCH_CRABS_POT_1",
     ///                    "playStationId": 28,
     ///                    "xboxId": "28",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "key": "pot-crabs-caught",
     ///                            "target": 100,
     ///                            "evaluationMode": "GTE",
     ///                            "$type": "IntCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "CATCH_FISH_NET_1",
     ///                    "steamId": "CATCH_FISH_NET_1",
     ///                    "playStationId": 29,
     ///                    "xboxId": "29",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "key": "net-fish-caught",
     ///                            "target": 150,
     ///                            "evaluationMode": "GTE",
     ///                            "$type": "IntCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "CATCH_FISH_ROD_1",
     ///                    "steamId": "CATCH_FISH_ROD_1",
     ///                    "playStationId": 27,
     ///                    "xboxId": "27",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "key": "rod-fish-caught",
     ///                            "target": 250,
     ///                            "evaluationMode": "GTE",
     ///                            "$type": "IntCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "COMPLETE_ALL_SIDE_QUESTS",
     ///                    "steamId": "COMPLETE_ALL_SIDE_QUESTS",
     ///                    "playStationId": 19,
     ///                    "xboxId": "19",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "quests": [
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": true,
     ///                                            "stepDock": {
     ///                                                "dockNameKey": [],
     ///                                                "id": "dock.greater-marrow",
     ///                                                "musicAssetReference": {
     ///                                                    "m_AssetGUID": "545b15b34ec9bc546a5c8d124d49230c",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                "musicAssetOverrides": [],
     ///                                                "ambienceDayAssetReference": {
     ///                                                    "m_AssetGUID": "051e84abcd9100b4089ee849d43f2e5f",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                "ambienceNightAssetReference": {
     ///                                                    "m_AssetGUID": "035e5c286ea6136469780bee1eca250d",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                "ambienceDayAssetOverrides": [],
     ///                                                "ambienceNightAssetOverrides": [],
     ///                                                "yarnRootNode": "GreaterMarrow_Root",
     ///                                                "progressTitleLocalizationKey": "gm-debt.label",
     ///                                                "progressValueLocalizationKey": "gm-debt.remaining",
     ///                                                "dockProgressType": "GM_REPAYMENTS",
     ///                                                "speakers": [
     ///                                                    {
     ///                                                        "speakerNameKey": "character.builder.name",
     ///                                                        "speakerNameKeyOverrides": [],
     ///                                                        "yarnRootNode": "Builder_Root",
     ///                                                        "portraitPrefab": {
     ///
     ///                                                        },
     ///                                                        "portraitOverrideConditions": [],
     ///                                                        "smallPortraitSprite": {
     ///
     ///                                                        },
     ///                                                        "visitSFX": {
     ///                                                            "m_AssetGUID": "",
     ///                                                            "m_SubObjectName": "",
     ///                                                            "m_SubObjectType": ""
     ///                                                        },
     ///                                                        "loopSFX": null,
     ///                                                        "isIndoors": false,
     ///                                                        "availableInDemo": true,
     ///                                                        "alwaysAvailable": false,
     ///                                                        "hideNameplate": false,
     ///                                                        "highlightConditions": [],
     ///                                                        "paralinguistics": {
     ///                                                            "AAH": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "dd383509c16eac848823f832406afd07",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "8b576e7a58eaf8741814a30ebc5638e0",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "CHUCKLE": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "a3b341c66c0444c42bf0f7473388ee5b",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "GRUNT": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "a195e1cd21004434d94369d5368716c6",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "1c45287b4edca4447a94106978d32807",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "HMM": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "166c639b77d1ebe4fbb28bb8b7dddf10",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "ef69ce306291a7b439c76ecf63a5e12c",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "SIGH": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "c9fcda795bee2f34494d0dbe5300fe7e",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "91f144b8afd7b614cae66bffd6920c01",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "a79321828b7d74b4fa9a56f998075e47",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ]
     ///                                                        },
     ///                                                        "paralinguisticOverrideConditions": [],
     ///                                                        "$id": "68"
     ///                                                    },
     ///                                                    {
     ///                                                        "speakerNameKey": "character.mayor.name",
     ///                                                        "speakerNameKeyOverrides": [],
     ///                                                        "yarnRootNode": "Mayor_Root",
     ///                                                        "portraitPrefab": {
     ///
     ///                                                        },
     ///                                                        "portraitOverrideConditions": [],
     ///                                                        "smallPortraitSprite": {
     ///
     ///                                                        },
     ///                                                        "visitSFX": {
     ///                                                            "m_AssetGUID": "426a185b105694b4882b4160aef8ece1",
     ///                                                            "m_SubObjectName": "",
     ///                                                            "m_SubObjectType": ""
     ///                                                        },
     ///                                                        "loopSFX": {
     ///
     ///                                                        },
     ///                                                        "isIndoors": true,
     ///                                                        "availableInDemo": true,
     ///                                                        "alwaysAvailable": false,
     ///                                                        "hideNameplate": false,
     ///                                                        "highlightConditions": [],
     ///                                                        "paralinguistics": {
     ///                                                            "AAH": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "089f81be0d5fa784d9b1c8583bc46bae",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "LISTLESS": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "84b851b5018af43428d546cd1c18942f",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "66eed934c80ec5949ad0392c54854396",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "0ea670ae77cc1044485e643da59d9180",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "HMM": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "d8a3eefca7552314d8d10a1e204d8443",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "19a13fb35694dee48bf2ec9c68a2bf87",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "SIGH": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "05f382ea70da35f4da5483b65215ccbd",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "329a5ba3820e37c47b59c5088fc8efc9",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "ANNOYED": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "11cfd4bb5332f47418da1e5ab24cdb33",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "93bf3c6cdc41ca246aecd377b055959f",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "CHUCKLE": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "e23bc9ff3556d3f489ad9275e7177bdd",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "MM": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "2a5570db2d67b1e42bd0a8711f0b1eb6",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "THANKFUL": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "975a4c470a5756643961b52f2a6098d2",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ]
     ///                                                        },
     ///                                                        "paralinguisticOverrideConditions": [],
     ///                                                        "$id": "92"
     ///                                                    },
     ///                                                    {
     ///                                                        "speakerNameKey": "character.lighthouse-keeper.name",
     ///                                                        "speakerNameKeyOverrides": [],
     ///                                                        "yarnRootNode": "LighthouseKeeper_Root",
     ///                                                        "portraitPrefab": {
     ///
     ///                                                        },
     ///                                                        "portraitOverrideConditions": [],
     ///                                                        "smallPortraitSprite": {
     ///
     ///                                                        },
     ///                                                        "visitSFX": {
     ///                                                            "m_AssetGUID": "",
     ///                                                            "m_SubObjectName": "",
     ///                                                            "m_SubObjectType": ""
     ///                                                        },
     ///                                                        "loopSFX": {
     ///
     ///                                                        },
     ///                                                        "isIndoors": true,
     ///                                                        "availableInDemo": true,
     ///                                                        "alwaysAvailable": false,
     ///                                                        "hideNameplate": false,
     ///                                                        "highlightConditions": [
     ///                                                            {
     ///                                                                "alwaysHighlight": false,
     ///                                                                "ifTheseStepsActive": [],
     ///                                                                "highlightIfNodesUnvisited": [
     ///                                                                    "LighthouseKeeper_Shipwrecks"
     ///                                                                ],
     ///                                                                "andTheseNodesVisited": [],
     ///                                                                "andTheseStepsNotCompleted": [
     ///                                                                    {
     ///                                                                        "mapMarkersToAddOnStart": [],
     ///                                                                        "mapMarkersToDeleteOnCompletion": [
     ///                                                                            {
     ///                                                                                "x": -76.35,
     ///                                                                                "z": -52.7,
     ///                                                                                "mapMarkerType": "MAIN",
     ///                                                                                "$id": "138"
     ///                                                                            }
     ///                                                                        ],
     ///                                                                        "hiddenWhenActive": false,
     ///                                                                        "hiddenWhenComplete": true,
     ///                                                                        "shortActiveKey": [],
     ///                                                                        "longActiveKey": [],
     ///                                                                        "completedKey": [],
     ///                                                                        "hideIfThisStepIsComplete": null,
     ///                                                                        "showAtDock": false,
     ///                                                                        "stepDock": null,
     ///                                                                        "showAtSpeaker": false,
     ///                                                                        "stepSpeaker": null,
     ///                                                                        "yarnRootNode": "",
     ///                                                                        "showConditions": [],
     ///                                                                        "canBeFailed": false,
     ///                                                                        "failureEvents": [],
     ///                                                                        "allowAutomaticCompletion": true,
     ///                                                                        "conditionMode": "ALL",
     ///                                                                        "completeConditions": [
     ///                                                                            {
     ///                                                                                "itemId": "relic1",
     ///                                                                                "silent": false,
     ///                                                                                "$type": "ItemInventoryCondition"
     ///                                                                            }
     ///                                                                        ],
     ///                                                                        "$id": "135"
     ///                                                                    }
     ///                                                                ],
     ///                                                                "extraConditions": null
     ///                                                            }
     ///                                                        ],
     ///                                                        "paralinguistics": {
     ///                                                            "AAH": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "3ea22f4e9fecbec4da3cd17ab6ae5007",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "bc51ea0c141a1d84e803fcbb4c795742",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "e2bde7bd006250f41a6896c501c0560e",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "GRUNT": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "40264be603a42a74b93b093d49501276",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "27ea6f278c91ed849bcfc2d5e2203b85",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "7f630249238d43a48bb68d7d4e992f7c",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "ba517ef434d53f2469bf80f07a5239a4",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "HMM": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "1ab1727517560ee41b96938c2ca3667a",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "SIGH": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "69b490a17c43a4d449763c86206527fd",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "4f41d0e5a7ca7e142aa05e3e60e86531",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "d77977dbccf9fa240867e69ccd3e9f96",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "081de1d5523fef944a10e8270291e0a2",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "DISGUSTED": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "a53c809d70d6981449506b370b514dd5",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "e52f695ad5b098740a9f79cf9b05a231",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "a36fe4c8fad497145af8ab557daa4b2e",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "EXASPERATED": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "c3d8f47f85ea7014db06c0df8c43818f",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "f23a6cfd6499e134796883e547627dbc",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "MM": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "c3055620acc4b1149b2f6313eca8eea1",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "aa9ffeda9b7ed0840891705d88bae01a",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "a42dbfc309c77c342ae4837c5a13fde5",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "LISTLESS": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "c054370cc676adc4ca89f9b59d1f0d7a",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ]
     ///                                                        },
     ///                                                        "paralinguisticOverrideConditions": []
     ///                                                    }
     ///                                                ],
     ///                                                "hasCameraOverride": false,
     ///                                                "cameraOverrideX": 0.5,
     ///                                                "cameraOverrideY": 0.5,
     ///                                                "$id": "59"
     ///                                            },
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": {
     ///                                                "$ref": "68"
     ///                                            },
     ///                                            "yarnRootNode": "APlaceToRest_Return",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "canBeFailed": true,
     ///                                            "failureEvents": [
     ///                                                {
     ///                                                    "itemId": "quest-builder",
     ///                                                    "resolutionIndex": 1,
     ///                                                    "$type": "DestroyItemEvent"
     ///                                                }
     ///                                            ],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": {
     ///                                        "mapMarkersToAddOnStart": [],
     ///                                        "mapMarkersToDeleteOnCompletion": [],
     ///                                        "hiddenWhenActive": true,
     ///                                        "hiddenWhenComplete": true,
     ///                                        "shortActiveKey": [],
     ///                                        "longActiveKey": [],
     ///                                        "completedKey": [],
     ///                                        "hideIfThisStepIsComplete": null,
     ///                                        "showAtDock": true,
     ///                                        "stepDock": {
     ///                                            "$ref": "59"
     ///                                        },
     ///                                        "showAtSpeaker": false,
     ///                                        "stepSpeaker": {
     ///                                            "$ref": "68"
     ///                                        },
     ///                                        "yarnRootNode": "APlaceToRest_Offer",
     ///                                        "showConditions": [],
     ///                                        "canBeFailed": false,
     ///                                        "failureEvents": [],
     ///                                        "allowAutomaticCompletion": false,
     ///                                        "conditionMode": "ALL",
     ///                                        "completeConditions": []
     ///                                    },
     ///                                    "canBeOfferedAutomatically": true,
     ///                                    "offerConditions": [
     ///                                        {
     ///                                            "quest": {
     ///                                                "titleKey": [],
     ///                                                "summaryKey": [],
     ///                                                "resolutionKeys": [
     ///                                                    []
     ///                                                ],
     ///                                                "mapMarkersToRemoveOnCompletion": [],
     ///                                                "showUnseenIndicators": true,
     ///                                                "steps": [
     ///                                                    {
     ///                                                        "mapMarkersToAddOnStart": [],
     ///                                                        "mapMarkersToDeleteOnCompletion": [],
     ///                                                        "hiddenWhenActive": false,
     ///                                                        "hiddenWhenComplete": false,
     ///                                                        "shortActiveKey": [],
     ///                                                        "longActiveKey": [],
     ///                                                        "completedKey": [],
     ///                                                        "hideIfThisStepIsComplete": null,
     ///                                                        "showAtDock": false,
     ///                                                        "stepDock": {
     ///                                                            "$ref": "59"
     ///                                                        },
     ///                                                        "showAtSpeaker": false,
     ///                                                        "stepSpeaker": null,
     ///                                                        "yarnRootNode": "",
     ///                                                        "showConditions": [
     ///                                                            {
     ///                                                                "wantAberration": true,
     ///                                                                "silent": false,
     ///                                                                "$type": "AberrantItemInventoryCondition"
     ///                                                            }
     ///                                                        ],
     ///                                                        "canBeFailed": false,
     ///                                                        "failureEvents": [],
     ///                                                        "allowAutomaticCompletion": false,
     ///                                                        "conditionMode": "ALL",
     ///                                                        "completeConditions": []
     ///                                                    },
     ///                                                    {
     ///                                                        "mapMarkersToAddOnStart": [],
     ///                                                        "mapMarkersToDeleteOnCompletion": [],
     ///                                                        "hiddenWhenActive": false,
     ///                                                        "hiddenWhenComplete": false,
     ///                                                        "shortActiveKey": [],
     ///                                                        "longActiveKey": [],
     ///                                                        "completedKey": [],
     ///                                                        "hideIfThisStepIsComplete": null,
     ///                                                        "showAtDock": false,
     ///                                                        "stepDock": {
     ///                                                            "dockNameKey": [],
     ///                                                            "id": "dock.outcast-isle",
     ///                                                            "musicAssetReference": {
     ///                                                                "m_AssetGUID": "7a961f399875688489479f74c490df31",
     ///                                                                "m_SubObjectName": "",
     ///                                                                "m_SubObjectType": ""
     ///                                                            },
     ///                                                            "musicAssetOverrides": [],
     ///                                                            "ambienceDayAssetReference": {
     ///                                                                "m_AssetGUID": "8f2262b4e25e7ad4d91dc832beb96f6b",
     ///                                                                "m_SubObjectName": "",
     ///                                                                "m_SubObjectType": ""
     ///                                                            },
     ///                                                            "ambienceNightAssetReference": {
     ///                                                                "m_AssetGUID": "50c2c977f0cdd2d4d882808242b0647c",
     ///                                                                "m_SubObjectName": "",
     ///                                                                "m_SubObjectType": ""
     ///                                                            },
     ///                                                            "ambienceDayAssetOverrides": [],
     ///                                                            "ambienceNightAssetOverrides": [],
     ///                                                            "yarnRootNode": "",
     ///                                                            "progressTitleLocalizationKey": "",
     ///                                                            "progressValueLocalizationKey": "",
     ///                                                            "dockProgressType": "NONE",
     ///                                                            "speakers": [],
     ///                                                            "hasCameraOverride": true,
     ///                                                            "cameraOverrideX": 0.5,
     ///                                                            "cameraOverrideY": 0.5,
     ///                                                            "$id": "224"
     ///                                                        },
     ///                                                        "showAtSpeaker": true,
     ///                                                        "stepSpeaker": {
     ///                                                            "speakerNameKey": "character.collector.name",
     ///                                                            "speakerNameKeyOverrides": [],
     ///                                                            "yarnRootNode": "Collector_Root",
     ///                                                            "portraitPrefab": {
     ///
     ///                                                            },
     ///                                                            "portraitOverrideConditions": [
     ///                                                                {
     ///                                                                    "portraitPrefab": {
     ///
     ///                                                                    },
     ///                                                                    "smallPortraitSprite": null,
     ///                                                                    "useManualState": false,
     ///                                                                    "stateName": "",
     ///                                                                    "stateValue": 0,
     ///                                                                    "nodesVisited": [
     ///                                                                        "Finale_BadRoot"
     ///                                                                    ]
     ///                                                                },
     ///                                                                {
     ///                                                                    "portraitPrefab": {
     ///
     ///                                                                    },
     ///                                                                    "smallPortraitSprite": null,
     ///                                                                    "useManualState": false,
     ///                                                                    "stateName": "",
     ///                                                                    "stateValue": 0,
     ///                                                                    "nodesVisited": [
     ///                                                                        "Collector_PickupAccept"
     ///                                                                    ]
     ///                                                                },
     ///                                                                {
     ///                                                                    "portraitPrefab": {
     ///
     ///                                                                    },
     ///                                                                    "smallPortraitSprite": null,
     ///                                                                    "useManualState": false,
     ///                                                                    "stateName": "",
     ///                                                                    "stateValue": 0,
     ///                                                                    "nodesVisited": [
     ///                                                                        "Collector_PostReveal"
     ///                                                                    ]
     ///                                                                },
     ///                                                                {
     ///                                                                    "portraitPrefab": {
     ///
     ///                                                                    },
     ///                                                                    "smallPortraitSprite": null,
     ///                                                                    "useManualState": false,
     ///                                                                    "stateName": "",
     ///                                                                    "stateValue": 0,
     ///                                                                    "nodesVisited": [
     ///                                                                        "Collector_Revealed"
     ///                                                                    ]
     ///                                                                }
     ///                                                            ],
     ///                                                            "smallPortraitSprite": null,
     ///                                                            "visitSFX": {
     ///                                                                "m_AssetGUID": "",
     ///                                                                "m_SubObjectName": "",
     ///                                                                "m_SubObjectType": ""
     ///                                                            },
     ///                                                            "loopSFX": null,
     ///                                                            "isIndoors": false,
     ///                                                            "availableInDemo": true,
     ///                                                            "alwaysAvailable": false,
     ///                                                            "hideNameplate": false,
     ///                                                            "highlightConditions": [],
     ///                                                            "paralinguistics": {
     ///                                                                "AAH": [
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "1f9ba00a50e8e424eb20cce2a9d4a9af",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "2ce1aa98cbc7ad74db803f51ab303ece",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    }
     ///                                                                ],
     ///                                                                "ANNOYED": [
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "fce20b595a067bf40a09542cf673f432",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    }
     ///                                                                ],
     ///                                                                "DISGUSTED": [
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "ca3acd18a481e2041b3da32599b64af5",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    }
     ///                                                                ],
     ///                                                                "CHUCKLE": [
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "c3b3e10ecc9325e42a22d4751b3c8e3d",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "2ccb2cebf2144a94888c4a609d215ff9",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "55200aaef6e37754b9d212dc6fc120b2",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    }
     ///                                                                ],
     ///                                                                "EXASPERATED": [
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "c3d49a1182639e447aca6b95f6c16ac7",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "e6a93ac22b9c6954e8733ac29c79974b",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "ba9ae1baba1bb3c4da09566d14a3ff5a",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    }
     ///                                                                ],
     ///                                                                "GRUNT": [
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "7d3c364eb47b05844827995ec69e27eb",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "007c19bf9e2e66945a29bfa848c99dbe",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    }
     ///                                                                ],
     ///                                                                "HMM": [
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "be58804e09a93894890924b5040a9e3f",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "d4433e5a49c97114181b39c64808ea54",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "5697dbf2aa2fa3b40ade932be00264ab",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "36e833f36776fe947b11a1ee9378933d",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    }
     ///                                                                ],
     ///                                                                "IMPATIENT": [
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "f89473fdbf0ed174d9321fd0976d0a6a",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "f1dac9d741cf1e64daa17cf4152db476",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "a8b07252016d0ab4fa183553a86057c8",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "2e9619114ba238645b4ae915188ae60f",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    }
     ///                                                                ],
     ///                                                                "SIGH": [
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "b90a2776005bdc949b830cb44e1c8b1a",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    },
     ///                                                                    {
     ///                                                                        "m_AssetGUID": "7839f0a1ec95bb740b4804031f84938f",
     ///                                                                        "m_SubObjectName": "",
     ///                                                                        "m_SubObjectType": ""
     ///                                                                    }
     ///                                                                ]
     ///                                                            },
     ///                                                            "paralinguisticOverrideConditions": [
     ///                                                                {
     ///                                                                    "config": {
     ///                                                                        "paralinguistics": {
     ///                                                                            "AAH": [
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "00f1ec6f05951124a8e2d80191bd9335",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "3dd665ceb038a584cb25df8dbe0d0385",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                }
     ///                                                                            ],
     ///                                                                            "ANNOYED": [
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "2688f4f309470de44ade3d2b3c2062eb",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                }
     ///                                                                            ],
     ///                                                                            "DISGUSTED": [
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "adeccd082d170eb47b4a0644a1b79914",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                }
     ///                                                                            ],
     ///                                                                            "CHUCKLE": [
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "7946f98f3d6018142a2b9c231c4d7035",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "a9844a35342b08541b19cb6792e3c6ab",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "07e15fe4af20c414181e27282082289e",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                }
     ///                                                                            ],
     ///                                                                            "EXASPERATED": [
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "34e75ee3bc5e0674baeae1ed86e5708b",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "054498a0672e4ea4e948d043080a9d59",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "58255c2e6f893184b82da9f547172eb8",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                }
     ///                                                                            ],
     ///                                                                            "GRUNT": [
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "2688f4f309470de44ade3d2b3c2062eb",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "4c4ded27a233fdf49964fe6f2e97af29",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                }
     ///                                                                            ],
     ///                                                                            "HMM": [
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "450634b1d1ed788439e832770e16f919",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "0a24147df8d49bd45a6fc9c9d5045ad7",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "a79f06cf1c674ad4592138bebb56c99d",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "a1c19f4a37ebd9043abe38b388094262",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                }
     ///                                                                            ],
     ///                                                                            "IMPATIENT": [
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "a36491d455eb6da4b99ec05a7aabcf49",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "cb4f65fffc6c1c14bb6071be3feaf960",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "b97864baf288df547af227ea78d0dfe5",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "f26911ef0536c864098f173e4fd2ef6c",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                }
     ///                                                                            ],
     ///                                                                            "SIGH": [
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "c7c67e23f7bc3bc4cb91280995e55316",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                },
     ///                                                                                {
     ///                                                                                    "m_AssetGUID": "bda96229ebf00b54695bb9faf204a09d",
     ///                                                                                    "m_SubObjectName": "",
     ///                                                                                    "m_SubObjectType": ""
     ///                                                                                }
     ///                                                                            ]
     ///                                                                        }
     ///                                                                    },
     ///                                                                    "nodesVisited": [
     ///                                                                        "Collector_Revealed"
     ///                                                                    ]
     ///                                                                }
     ///                                                            ],
     ///                                                            "$id": "233"
     ///                                                        },
     ///                                                        "yarnRootNode": "Collector_StrangeFish_Meeting",
     ///                                                        "showConditions": [],
     ///                                                        "canBeFailed": false,
     ///                                                        "failureEvents": [],
     ///                                                        "allowAutomaticCompletion": false,
     ///                                                        "conditionMode": "ALL",
     ///                                                        "completeConditions": []
     ///                                                    },
     ///                                                    {
     ///                                                        "mapMarkersToAddOnStart": [],
     ///                                                        "mapMarkersToDeleteOnCompletion": [
     ///                                                            {
     ///                                                                "x": 89.5,
     ///                                                                "z": -123.5,
     ///                                                                "mapMarkerType": "MAIN"
     ///                                                            }
     ///                                                        ],
     ///                                                        "hiddenWhenActive": false,
     ///                                                        "hiddenWhenComplete": false,
     ///                                                        "shortActiveKey": [],
     ///                                                        "longActiveKey": [],
     ///                                                        "completedKey": [],
     ///                                                        "hideIfThisStepIsComplete": null,
     ///                                                        "showAtDock": false,
     ///                                                        "stepDock": {
     ///                                                            "$ref": "224"
     ///                                                        },
     ///                                                        "showAtSpeaker": true,
     ///                                                        "stepSpeaker": {
     ///                                                            "$ref": "233"
     ///                                                        },
     ///                                                        "yarnRootNode": "Collector_StrangeFish_Return_AfterDeclining",
     ///                                                        "showConditions": [],
     ///                                                        "canBeFailed": false,
     ///                                                        "failureEvents": [],
     ///                                                        "allowAutomaticCompletion": false,
     ///                                                        "conditionMode": "ALL",
     ///                                                        "completeConditions": []
     ///                                                    }
     ///                                                ],
     ///                                                "subquests": [],
     ///                                                "onOfferedQuestStep": {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": true,
     ///                                                    "hiddenWhenComplete": false,
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
     ///                                                            "wantAberration": true,
     ///                                                            "silent": false,
     ///                                                            "$type": "AberrantItemInventoryCondition"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "canBeOfferedAutomatically": true,
     ///                                                "offerConditions": [],
     ///                                                "PS5Subtask": "",
     ///                                                "$id": "202"
     ///                                            },
     ///                                            "state": "COMPLETED",
     ///                                            "silent": false,
     ///                                            "$type": "OtherQuestCondition"
     ///                                        }
     ///                                    ],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "canBeFailed": true,
     ///                                            "failureEvents": [
     ///                                                {
     ///                                                    "itemId": "quest-castaway",
     ///                                                    "resolutionIndex": 2,
     ///                                                    "$type": "DestroyItemEvent"
     ///                                                }
     ///                                            ],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": [],
     ///                                            "$id": "391"
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": {
     ///                                        "$ref": "391"
     ///                                    },
     ///                                    "canBeOfferedAutomatically": true,
     ///                                    "offerConditions": [
     ///                                        {
     ///                                            "day": 1,
     ///                                            "silent": false,
     ///                                            "$type": "DayCondition"
     ///                                        }
     ///                                    ],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": true,
     ///                                            "stepDock": null,
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": null,
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": true,
     ///                                            "failureEvents": [
     ///                                                {
     ///                                                    "itemId": "quest-package-2",
     ///                                                    "resolutionIndex": 1,
     ///                                                    "$type": "DestroyItemEvent"
     ///                                                }
     ///                                            ],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "canBeFailed": true,
     ///                                            "failureEvents": [
     ///                                                {
     ///                                                    "itemId": "quest-dog",
     ///                                                    "resolutionIndex": 2,
     ///                                                    "$type": "DestroyItemEvent"
     ///                                                }
     ///                                            ],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [
     ///                                                {
     ///                                                    "x": 638.84,
     ///                                                    "z": 450.99,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "513"
     ///                                                },
     ///                                                {
     ///                                                    "x": 641.22,
     ///                                                    "z": 564.73,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "514"
     ///                                                },
     ///                                                {
     ///                                                    "x": 537.68,
     ///                                                    "z": 615.13,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "515"
     ///                                                }
     ///                                            ],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "$ref": "513"
     ///                                                },
     ///                                                {
     ///                                                    "$ref": "514"
     ///                                                },
     ///                                                {
     ///                                                    "$ref": "515"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [
     ///                                                {
     ///                                                    "x": 174.15,
     ///                                                    "z": -24.2,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "544"
     ///                                                }
     ///                                            ],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "$ref": "544"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                                    "itemId": "quest-belt-buckle",
     ///                                                    "silent": false,
     ///                                                    "$type": "ItemSeenCondition"
     ///                                                }
     ///                                            ]
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": false,
     ///                                            "stepDock": {
     ///                                                "dockNameKey": [],
     ///                                                "id": "dock.little-marrow",
     ///                                                "musicAssetReference": {
     ///                                                    "m_AssetGUID": "80a38289b264da34eb1ac69d3a81ff84",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                "musicAssetOverrides": [],
     ///                                                "ambienceDayAssetReference": {
     ///                                                    "m_AssetGUID": "eef6364d0529e244a80887eb8f72bf79",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                "ambienceNightAssetReference": {
     ///                                                    "m_AssetGUID": "01ad287ea4a0759448c774174a98fe2a",
     ///                                                    "m_SubObjectName": "",
     ///                                                    "m_SubObjectType": ""
     ///                                                },
     ///                                                "ambienceDayAssetOverrides": [],
     ///                                                "ambienceNightAssetOverrides": [],
     ///                                                "yarnRootNode": "LittleMarrow_Root",
     ///                                                "progressTitleLocalizationKey": "",
     ///                                                "progressValueLocalizationKey": "",
     ///                                                "dockProgressType": "NONE",
     ///                                                "speakers": [
     ///                                                    {
     ///                                                        "speakerNameKey": "character.dockworker.name",
     ///                                                        "speakerNameKeyOverrides": [],
     ///                                                        "yarnRootNode": "Dockworker_Root",
     ///                                                        "portraitPrefab": {
     ///
     ///                                                        },
     ///                                                        "portraitOverrideConditions": [
     ///                                                            {
     ///                                                                "portraitPrefab": {
     ///
     ///                                                                },
     ///                                                                "smallPortraitSprite": {
     ///
     ///                                                                },
     ///                                                                "useManualState": false,
     ///                                                                "stateName": "",
     ///                                                                "stateValue": 0,
     ///                                                                "nodesVisited": [
     ///                                                                    "Dockworker_CourierDelivery"
     ///                                                                ]
     ///                                                            }
     ///                                                        ],
     ///                                                        "smallPortraitSprite": {
     ///
     ///                                                        },
     ///                                                        "visitSFX": {
     ///                                                            "m_AssetGUID": "",
     ///                                                            "m_SubObjectName": "",
     ///                                                            "m_SubObjectType": ""
     ///                                                        },
     ///                                                        "loopSFX": null,
     ///                                                        "isIndoors": false,
     ///                                                        "availableInDemo": true,
     ///                                                        "alwaysAvailable": false,
     ///                                                        "hideNameplate": false,
     ///                                                        "highlightConditions": [],
     ///                                                        "paralinguistics": {
     ///                                                            "CHUCKLE": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "6efab088f6391ee4d8b6c97c1b71e93b",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "GRUNT": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "71c3fe710e38c0c4ab47871bd0839f07",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "MM": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "a107f17729a580c43874bcab839be868",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "0bedec62bb65f5c4d8269faf65832991",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "86ceb3ae2b72d64499435c23bf1c22d4",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "SIGH": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "ace922ff616c17c4c9adcede120b09bc",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "5eb5f48f842362a42a2e025d96d4f2e1",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "b90159d1e894b3949acf46e5f387b7bf",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "GURGLE": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "cba33d70d96e9fa428cab7952c5fc7a0",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "387ef564933ce98488c198a8368effe7",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ]
     ///                                                        },
     ///                                                        "paralinguisticOverrideConditions": [],
     ///                                                        "$id": "568"
     ///                                                    },
     ///                                                    {
     ///                                                        "speakerNameKey": "character.grieving-father.name",
     ///                                                        "speakerNameKeyOverrides": [],
     ///                                                        "yarnRootNode": "GrievingFather_Root",
     ///                                                        "portraitPrefab": {
     ///
     ///                                                        },
     ///                                                        "portraitOverrideConditions": [],
     ///                                                        "smallPortraitSprite": {
     ///
     ///                                                        },
     ///                                                        "visitSFX": {
     ///                                                            "m_AssetGUID": "",
     ///                                                            "m_SubObjectName": "",
     ///                                                            "m_SubObjectType": ""
     ///                                                        },
     ///                                                        "loopSFX": null,
     ///                                                        "isIndoors": false,
     ///                                                        "availableInDemo": true,
     ///                                                        "alwaysAvailable": false,
     ///                                                        "hideNameplate": false,
     ///                                                        "highlightConditions": [
     ///                                                            {
     ///                                                                "alwaysHighlight": false,
     ///                                                                "ifTheseStepsActive": [],
     ///                                                                "highlightIfNodesUnvisited": [
     ///                                                                    "GrievingFather_Shipwrecks"
     ///                                                                ],
     ///                                                                "andTheseNodesVisited": [],
     ///                                                                "andTheseStepsNotCompleted": [],
     ///                                                                "extraConditions": null
     ///                                                            }
     ///                                                        ],
     ///                                                        "paralinguistics": {
     ///                                                            "THANKFUL": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "df279379bca20a6429dc683e2d233258",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "MM": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "b5cee50c3b446ae4c886fbf6f81b4638",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "7d8aed18c2a8d1d42b4f97620d1ec893",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ],
     ///                                                            "SIGH": [
     ///                                                                {
     ///                                                                    "m_AssetGUID": "dc977d7b4631a8346bc86f80a744837e",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                },
     ///                                                                {
     ///                                                                    "m_AssetGUID": "47b5ccc59647ca24ba35aacb076a628d",
     ///                                                                    "m_SubObjectName": "",
     ///                                                                    "m_SubObjectType": ""
     ///                                                                }
     ///                                                            ]
     ///                                                        },
     ///                                                        "paralinguisticOverrideConditions": [],
     ///                                                        "$id": "595"
     ///                                                    }
     ///                                                ],
     ///                                                "hasCameraOverride": false,
     ///                                                "cameraOverrideX": 0.5,
     ///                                                "cameraOverrideY": 0.5,
     ///                                                "$id": "559"
     ///                                            },
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": {
     ///                                                "$ref": "595"
     ///                                            },
     ///                                            "yarnRootNode": "GrievingFather_Evaluate",
     ///                                            "showConditions": [
     ///                                                {
     ///                                                    "itemId": "quest-belt-buckle",
     ///                                                    "silent": false,
     ///                                                    "$type": "ItemInventoryCondition"
     ///                                                }
     ///                                            ],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [
     ///                                                {
     ///                                                    "itemId": "quest-belt-buckle",
     ///                                                    "resolutionIndex": 1,
     ///                                                    "$type": "SoldItemEvent"
     ///                                                },
     ///                                                {
     ///                                                    "itemId": "quest-belt-buckle",
     ///                                                    "resolutionIndex": 2,
     ///                                                    "$type": "DestroyItemEvent"
     ///                                                }
     ///                                            ],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [
     ///                                        {
     ///                                            "quest": {
     ///                                                "$ref": "202"
     ///                                            },
     ///                                            "state": "COMPLETED",
     ///                                            "silent": false,
     ///                                            "$type": "OtherQuestCondition"
     ///                                        }
     ///                                    ],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [
     ///                                                {
     ///                                                    "x": 539.7,
     ///                                                    "z": -482.7,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "634"
     ///                                                }
     ///                                            ],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "$ref": "634"
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
     ///                                                    "itemId": "quest-crest",
     ///                                                    "silent": false,
     ///                                                    "$type": "ItemInventoryCondition"
     ///                                                }
     ///                                            ]
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "canBeFailed": true,
     ///                                            "failureEvents": [
     ///                                                {
     ///                                                    "itemId": "quest-hermit",
     ///                                                    "resolutionIndex": 1,
     ///                                                    "$type": "DestroyItemEvent"
     ///                                                }
     ///                                            ],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": false,
     ///                                            "stepDock": {
     ///                                                "$ref": "59"
     ///                                            },
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": {
     ///                                                "$ref": "92"
     ///                                            },
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": false,
     ///                                            "stepDock": {
     ///                                                "$ref": "59"
     ///                                            },
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": {
     ///                                                "$ref": "92"
     ///                                            },
     ///                                            "yarnRootNode": "",
     ///                                            "showConditions": [],
     ///                                            "canBeFailed": false,
     ///                                            "failureEvents": [],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": false,
     ///                                            "stepDock": {
     ///                                                "$ref": "59"
     ///                                            },
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": {
     ///                                                "$ref": "92"
     ///                                            },
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
     ///                                    "PS5Subtask": "",
     ///                                    "$id": "844"
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        [],
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [
     ///                                        {
     ///                                            "x": 140.94,
     ///                                            "z": 5.61,
     ///                                            "mapMarkerType": "MAIN"
     ///                                        }
     ///                                    ],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": null,
     ///                                            "showAtDock": false,
     ///                                            "stepDock": {
     ///                                                "$ref": "559"
     ///                                            },
     ///                                            "showAtSpeaker": false,
     ///                                            "stepSpeaker": {
     ///                                                "$ref": "568"
     ///                                            },
     ///                                            "yarnRootNode": "PackageDelivery_1",
     ///                                            "showConditions": [
     ///                                                {
     ///                                                    "itemId": "quest-package",
     ///                                                    "silent": false,
     ///                                                    "$type": "ItemInventoryCondition"
     ///                                                }
     ///                                            ],
     ///                                            "canBeFailed": true,
     ///                                            "failureEvents": [
     ///                                                {
     ///                                                    "itemId": "quest-package",
     ///                                                    "resolutionIndex": 1,
     ///                                                    "$type": "DestroyItemEvent"
     ///                                                }
     ///                                            ],
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": {
     ///                                        "mapMarkersToAddOnStart": [],
     ///                                        "mapMarkersToDeleteOnCompletion": [],
     ///                                        "hiddenWhenActive": true,
     ///                                        "hiddenWhenComplete": true,
     ///                                        "shortActiveKey": [],
     ///                                        "longActiveKey": [],
     ///                                        "completedKey": [],
     ///                                        "hideIfThisStepIsComplete": null,
     ///                                        "showAtDock": true,
     ///                                        "stepDock": {
     ///                                            "$ref": "59"
     ///                                        },
     ///                                        "showAtSpeaker": false,
     ///                                        "stepSpeaker": {
     ///                                            "$ref": "92"
     ///                                        },
     ///                                        "yarnRootNode": "PackageDelivery_Root",
     ///                                        "showConditions": [],
     ///                                        "canBeFailed": false,
     ///                                        "failureEvents": [],
     ///                                        "allowAutomaticCompletion": false,
     ///                                        "conditionMode": "ALL",
     ///                                        "completeConditions": []
     ///                                    },
     ///                                    "canBeOfferedAutomatically": true,
     ///                                    "offerConditions": [
     ///                                        {
     ///                                            "day": 2,
     ///                                            "silent": false,
     ///                                            "$type": "DayCondition"
     ///                                        },
     ///                                        {
     ///                                            "quest": {
     ///                                                "$ref": "844"
     ///                                            },
     ///                                            "state": "COMPLETED",
     ///                                            "silent": false,
     ///                                            "$type": "OtherQuestCondition"
     ///                                        }
     ///                                    ],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": true,
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
     ///                                                    "quest": {
     ///                                                        "titleKey": [],
     ///                                                        "summaryKey": [],
     ///                                                        "resolutionKeys": [
     ///                                                            []
     ///                                                        ],
     ///                                                        "mapMarkersToRemoveOnCompletion": [],
     ///                                                        "showUnseenIndicators": false,
     ///                                                        "steps": [
     ///                                                            {
     ///                                                                "mapMarkersToAddOnStart": [],
     ///                                                                "mapMarkersToDeleteOnCompletion": [],
     ///                                                                "hiddenWhenActive": false,
     ///                                                                "hiddenWhenComplete": true,
     ///                                                                "shortActiveKey": [],
     ///                                                                "longActiveKey": [],
     ///                                                                "completedKey": [],
     ///                                                                "hideIfThisStepIsComplete": null,
     ///                                                                "showAtDock": false,
     ///                                                                "stepDock": null,
     ///                                                                "showAtSpeaker": false,
     ///                                                                "stepSpeaker": null,
     ///                                                                "yarnRootNode": "",
     ///                                                                "showConditions": [],
     ///                                                                "canBeFailed": false,
     ///                                                                "failureEvents": [],
     ///                                                                "allowAutomaticCompletion": true,
     ///                                                                "conditionMode": "ALL",
     ///                                                                "completeConditions": [
     ///                                                                    {
     ///                                                                        "itemId": "oarfish",
     ///                                                                        "silent": false,
     ///                                                                        "$type": "ItemSeenCondition"
     ///                                                                    }
     ///                                                                ]
     ///                                                            },
     ///                                                            {
     ///                                                                "mapMarkersToAddOnStart": [],
     ///                                                                "mapMarkersToDeleteOnCompletion": [],
     ///                                                                "hiddenWhenActive": false,
     ///                                                                "hiddenWhenComplete": false,
     ///                                                                "shortActiveKey": [],
     ///                                                                "longActiveKey": [],
     ///                                                                "completedKey": [],
     ///                                                                "hideIfThisStepIsComplete": null,
     ///                                                                "showAtDock": false,
     ///                                                                "stepDock": null,
     ///                                                                "showAtSpeaker": false,
     ///                                                                "stepSpeaker": null,
     ///                                                                "yarnRootNode": "",
     ///                                                                "showConditions": [],
     ///                                                                "canBeFailed": false,
     ///                                                                "failureEvents": [],
     ///                                                                "allowAutomaticCompletion": false,
     ///                                                                "conditionMode": "ALL",
     ///                                                                "completeConditions": []
     ///                                                            }
     ///                                                        ],
     ///                                                        "subquests": [],
     ///                                                        "onOfferedQuestStep": null,
     ///                                                        "canBeOfferedAutomatically": false,
     ///                                                        "offerConditions": [],
     ///                                                        "PS5Subtask": "",
     ///                                                        "$id": "927"
     ///                                                    },
     ///                                                    "state": "COMPLETED",
     ///                                                    "silent": false,
     ///                                                    "$type": "OtherQuestCondition"
     ///                                                },
     ///                                                {
     ///                                                    "quest": {
     ///                                                        "titleKey": [],
     ///                                                        "summaryKey": [],
     ///                                                        "resolutionKeys": [
     ///                                                            []
     ///                                                        ],
     ///                                                        "mapMarkersToRemoveOnCompletion": [],
     ///                                                        "showUnseenIndicators": false,
     ///                                                        "steps": [
     ///                                                            {
     ///                                                                "mapMarkersToAddOnStart": [],
     ///                                                                "mapMarkersToDeleteOnCompletion": [],
     ///                                                                "hiddenWhenActive": false,
     ///                                                                "hiddenWhenComplete": true,
     ///                                                                "shortActiveKey": [],
     ///                                                                "longActiveKey": [],
     ///                                                                "completedKey": [],
     ///                                                                "hideIfThisStepIsComplete": null,
     ///                                                                "showAtDock": false,
     ///                                                                "stepDock": null,
     ///                                                                "showAtSpeaker": false,
     ///                                                                "stepSpeaker": null,
     ///                                                                "yarnRootNode": "",
     ///                                                                "showConditions": [],
     ///                                                                "canBeFailed": false,
     ///                                                                "failureEvents": [],
     ///                                                                "allowAutomaticCompletion": true,
     ///                                                                "conditionMode": "ALL",
     ///                                                                "completeConditions": [
     ///                                                                    {
     ///                                                                        "itemId": "gulper-eel",
     ///                                                                        "silent": false,
     ///                                                                        "$type": "ItemSeenCondition"
     ///                                                                    }
     ///                                                                ]
     ///                                                            },
     ///                                                            {
     ///                                                                "mapMarkersToAddOnStart": [],
     ///                                                                "mapMarkersToDeleteOnCompletion": [],
     ///                                                                "hiddenWhenActive": false,
     ///                                                                "hiddenWhenComplete": false,
     ///                                                                "shortActiveKey": [],
     ///                                                                "longActiveKey": [],
     ///                                                                "completedKey": [],
     ///                                                                "hideIfThisStepIsComplete": null,
     ///                                                                "showAtDock": false,
     ///                                                                "stepDock": null,
     ///                                                                "showAtSpeaker": false,
     ///                                                                "stepSpeaker": null,
     ///                                                                "yarnRootNode": "",
     ///                                                                "showConditions": [],
     ///                                                                "canBeFailed": false,
     ///                                                                "failureEvents": [],
     ///                                                                "allowAutomaticCompletion": false,
     ///                                                                "conditionMode": "ALL",
     ///                                                                "completeConditions": []
     ///                                                            }
     ///                                                        ],
     ///                                                        "subquests": [],
     ///                                                        "onOfferedQuestStep": null,
     ///                                                        "canBeOfferedAutomatically": false,
     ///                                                        "offerConditions": [],
     ///                                                        "PS5Subtask": "",
     ///                                                        "$id": "955"
     ///                                                    },
     ///                                                    "state": "COMPLETED",
     ///                                                    "silent": false,
     ///                                                    "$type": "OtherQuestCondition"
     ///                                                },
     ///                                                {
     ///                                                    "quest": {
     ///                                                        "titleKey": [],
     ///                                                        "summaryKey": [],
     ///                                                        "resolutionKeys": [
     ///                                                            []
     ///                                                        ],
     ///                                                        "mapMarkersToRemoveOnCompletion": [],
     ///                                                        "showUnseenIndicators": false,
     ///                                                        "steps": [
     ///                                                            {
     ///                                                                "mapMarkersToAddOnStart": [],
     ///                                                                "mapMarkersToDeleteOnCompletion": [],
     ///                                                                "hiddenWhenActive": false,
     ///                                                                "hiddenWhenComplete": true,
     ///                                                                "shortActiveKey": [],
     ///                                                                "longActiveKey": [],
     ///                                                                "completedKey": [],
     ///                                                                "hideIfThisStepIsComplete": null,
     ///                                                                "showAtDock": false,
     ///                                                                "stepDock": null,
     ///                                                                "showAtSpeaker": false,
     ///                                                                "stepSpeaker": null,
     ///                                                                "yarnRootNode": "",
     ///                                                                "showConditions": [],
     ///                                                                "canBeFailed": false,
     ///                                                                "failureEvents": [],
     ///                                                                "allowAutomaticCompletion": true,
     ///                                                                "conditionMode": "ALL",
     ///                                                                "completeConditions": [
     ///                                                                    {
     ///                                                                        "itemId": "goliath-tigerfish",
     ///                                                                        "silent": false,
     ///                                                                        "$type": "ItemSeenCondition"
     ///                                                                    }
     ///                                                                ]
     ///                                                            },
     ///                                                            {
     ///                                                                "mapMarkersToAddOnStart": [],
     ///                                                                "mapMarkersToDeleteOnCompletion": [],
     ///                                                                "hiddenWhenActive": false,
     ///                                                                "hiddenWhenComplete": false,
     ///                                                                "shortActiveKey": [],
     ///                                                                "longActiveKey": [],
     ///                                                                "completedKey": [],
     ///                                                                "hideIfThisStepIsComplete": null,
     ///                                                                "showAtDock": false,
     ///                                                                "stepDock": null,
     ///                                                                "showAtSpeaker": false,
     ///                                                                "stepSpeaker": null,
     ///                                                                "yarnRootNode": "",
     ///                                                                "showConditions": [],
     ///                                                                "canBeFailed": false,
     ///                                                                "failureEvents": [],
     ///                                                                "allowAutomaticCompletion": false,
     ///                                                                "conditionMode": "ALL",
     ///                                                                "completeConditions": []
     ///                                                            }
     ///                                                        ],
     ///                                                        "subquests": [],
     ///                                                        "onOfferedQuestStep": null,
     ///                                                        "canBeOfferedAutomatically": false,
     ///                                                        "offerConditions": [],
     ///                                                        "PS5Subtask": "",
     ///                                                        "$id": "983"
     ///                                                    },
     ///                                                    "state": "COMPLETED",
     ///                                                    "silent": false,
     ///                                                    "$type": "OtherQuestCondition"
     ///                                                },
     ///                                                {
     ///                                                    "quest": {
     ///                                                        "titleKey": [],
     ///                                                        "summaryKey": [],
     ///                                                        "resolutionKeys": [
     ///                                                            []
     ///                                                        ],
     ///                                                        "mapMarkersToRemoveOnCompletion": [],
     ///                                                        "showUnseenIndicators": false,
     ///                                                        "steps": [
     ///                                                            {
     ///                                                                "mapMarkersToAddOnStart": [],
     ///                                                                "mapMarkersToDeleteOnCompletion": [],
     ///                                                                "hiddenWhenActive": false,
     ///                                                                "hiddenWhenComplete": true,
     ///                                                                "shortActiveKey": [],
     ///                                                                "longActiveKey": [],
     ///                                                                "completedKey": [],
     ///                                                                "hideIfThisStepIsComplete": null,
     ///                                                                "showAtDock": false,
     ///                                                                "stepDock": null,
     ///                                                                "showAtSpeaker": false,
     ///                                                                "stepSpeaker": null,
     ///                                                                "yarnRootNode": "",
     ///                                                                "showConditions": [],
     ///                                                                "canBeFailed": false,
     ///                                                                "failureEvents": [],
     ///                                                                "allowAutomaticCompletion": true,
     ///                                                                "conditionMode": "ALL",
     ///                                                                "completeConditions": [
     ///                                                                    {
     ///                                                                        "itemId": "coelacanth",
     ///                                                                        "silent": false,
     ///                                                                        "$type": "ItemSeenCondition"
     ///                                                                    }
     ///                                                                ]
     ///                                                            },
     ///                                                            {
     ///                                                                "mapMarkersToAddOnStart": [],
     ///                                                                "mapMarkersToDeleteOnCompletion": [],
     ///                                                                "hiddenWhenActive": false,
     ///                                                                "hiddenWhenComplete": false,
     ///                                                                "shortActiveKey": [],
     ///                                                                "longActiveKey": [],
     ///                                                                "completedKey": [],
     ///                                                                "hideIfThisStepIsComplete": null,
     ///                                                                "showAtDock": false,
     ///                                                                "stepDock": null,
     ///                                                                "showAtSpeaker": false,
     ///                                                                "stepSpeaker": null,
     ///                                                                "yarnRootNode": "",
     ///                                                                "showConditions": [],
     ///                                                                "canBeFailed": false,
     ///                                                                "failureEvents": [],
     ///                                                                "allowAutomaticCompletion": false,
     ///                                                                "conditionMode": "ALL",
     ///                                                                "completeConditions": []
     ///                                                            }
     ///                                                        ],
     ///                                                        "subquests": [],
     ///                                                        "onOfferedQuestStep": null,
     ///                                                        "canBeOfferedAutomatically": false,
     ///                                                        "offerConditions": [],
     ///                                                        "PS5Subtask": "",
     ///                                                        "$id": "1011"
     ///                                                    },
     ///                                                    "state": "COMPLETED",
     ///                                                    "silent": false,
     ///                                                    "$type": "OtherQuestCondition"
     ///                                                }
     ///                                            ]
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [
     ///                                        {
     ///                                            "$ref": "927"
     ///                                        },
     ///                                        {
     ///                                            "$ref": "955"
     ///                                        },
     ///                                        {
     ///                                            "$ref": "983"
     ///                                        },
     ///                                        {
     ///                                            "$ref": "1011"
     ///                                        }
     ///                                    ],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [
     ///                                        {
     ///                                            "titleKey": [],
     ///                                            "summaryKey": [],
     ///                                            "resolutionKeys": [],
     ///                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                            "showUnseenIndicators": false,
     ///                                            "steps": [
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": false,
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                }
     ///                                            ],
     ///                                            "subquests": [],
     ///                                            "onOfferedQuestStep": null,
     ///                                            "canBeOfferedAutomatically": false,
     ///                                            "offerConditions": [],
     ///                                            "PS5Subtask": ""
     ///                                        },
     ///                                        {
     ///                                            "titleKey": [],
     ///                                            "summaryKey": [],
     ///                                            "resolutionKeys": [],
     ///                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                            "showUnseenIndicators": false,
     ///                                            "steps": [
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": false,
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": false,
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                }
     ///                                            ],
     ///                                            "subquests": [],
     ///                                            "onOfferedQuestStep": null,
     ///                                            "canBeOfferedAutomatically": false,
     ///                                            "offerConditions": [],
     ///                                            "PS5Subtask": ""
     ///                                        },
     ///                                        {
     ///                                            "titleKey": [],
     ///                                            "summaryKey": [],
     ///                                            "resolutionKeys": [],
     ///                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                            "showUnseenIndicators": false,
     ///                                            "steps": [
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": false,
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                }
     ///                                            ],
     ///                                            "subquests": [],
     ///                                            "onOfferedQuestStep": null,
     ///                                            "canBeOfferedAutomatically": false,
     ///                                            "offerConditions": [],
     ///                                            "PS5Subtask": ""
     ///                                        }
     ///                                    ],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [
     ///                                                {
     ///                                                    "x": -529.1,
     ///                                                    "z": 557.8,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "1140"
     ///                                                },
     ///                                                {
     ///                                                    "x": -314.5,
     ///                                                    "z": 513.3,
     ///                                                    "mapMarkerType": "MAIN",
     ///                                                    "$id": "1141"
     ///                                                }
     ///                                            ],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": [],
     ///                                            "$id": "1138"
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": [],
     ///                                            "$id": "1149"
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [
     ///                                        {
     ///                                            "titleKey": [],
     ///                                            "summaryKey": [],
     ///                                            "resolutionKeys": [],
     ///                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                            "showUnseenIndicators": false,
     ///                                            "steps": [
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [
     ///                                                        {
     ///                                                            "$ref": "1140"
     ///                                                        }
     ///                                                    ],
     ///                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                        {
     ///                                                            "$ref": "1140"
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
     ///                                                            "itemId": "quest-mortar-1",
     ///                                                            "silent": false,
     ///                                                            "$type": "ItemInventoryCondition"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": false,
     ///                                                    "shortActiveKey": [],
     ///                                                    "longActiveKey": [],
     ///                                                    "completedKey": [],
     ///                                                    "hideIfThisStepIsComplete": {
     ///                                                        "$ref": "1138"
     ///                                                    },
     ///                                                    "showAtDock": false,
     ///                                                    "stepDock": null,
     ///                                                    "showAtSpeaker": false,
     ///                                                    "stepSpeaker": null,
     ///                                                    "yarnRootNode": "",
     ///                                                    "showConditions": [],
     ///                                                    "canBeFailed": false,
     ///                                                    "failureEvents": [],
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                }
     ///                                            ],
     ///                                            "subquests": [],
     ///                                            "onOfferedQuestStep": null,
     ///                                            "canBeOfferedAutomatically": false,
     ///                                            "offerConditions": [],
     ///                                            "PS5Subtask": ""
     ///                                        },
     ///                                        {
     ///                                            "titleKey": [],
     ///                                            "summaryKey": [],
     ///                                            "resolutionKeys": [],
     ///                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                            "showUnseenIndicators": false,
     ///                                            "steps": [
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [
     ///                                                        {
     ///                                                            "$ref": "1141"
     ///                                                        }
     ///                                                    ],
     ///                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                        {
     ///                                                            "$ref": "1141"
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
     ///                                                            "itemId": "quest-mortar-2",
     ///                                                            "silent": false,
     ///                                                            "$type": "ItemInventoryCondition"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": false,
     ///                                                    "shortActiveKey": [],
     ///                                                    "longActiveKey": [],
     ///                                                    "completedKey": [],
     ///                                                    "hideIfThisStepIsComplete": {
     ///                                                        "$ref": "1138"
     ///                                                    },
     ///                                                    "showAtDock": false,
     ///                                                    "stepDock": null,
     ///                                                    "showAtSpeaker": false,
     ///                                                    "stepSpeaker": null,
     ///                                                    "yarnRootNode": "",
     ///                                                    "showConditions": [],
     ///                                                    "canBeFailed": false,
     ///                                                    "failureEvents": [],
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                }
     ///                                            ],
     ///                                            "subquests": [],
     ///                                            "onOfferedQuestStep": null,
     ///                                            "canBeOfferedAutomatically": false,
     ///                                            "offerConditions": [],
     ///                                            "PS5Subtask": ""
     ///                                        },
     ///                                        {
     ///                                            "titleKey": [],
     ///                                            "summaryKey": [],
     ///                                            "resolutionKeys": [],
     ///                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                            "showUnseenIndicators": false,
     ///                                            "steps": [
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [
     ///                                                        {
     ///                                                            "x": -367.8,
     ///                                                            "z": 463.1,
     ///                                                            "mapMarkerType": "MAIN"
     ///                                                        }
     ///                                                    ],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": false,
     ///                                                    "shortActiveKey": [],
     ///                                                    "longActiveKey": [],
     ///                                                    "completedKey": [],
     ///                                                    "hideIfThisStepIsComplete": {
     ///                                                        "$ref": "1149"
     ///                                                    },
     ///                                                    "showAtDock": false,
     ///                                                    "stepDock": null,
     ///                                                    "showAtSpeaker": false,
     ///                                                    "stepSpeaker": null,
     ///                                                    "yarnRootNode": "",
     ///                                                    "showConditions": [],
     ///                                                    "canBeFailed": false,
     ///                                                    "failureEvents": [],
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                }
     ///                                            ],
     ///                                            "subquests": [],
     ///                                            "onOfferedQuestStep": null,
     ///                                            "canBeOfferedAutomatically": false,
     ///                                            "offerConditions": [],
     ///                                            "PS5Subtask": ""
     ///                                        },
     ///                                        {
     ///                                            "titleKey": [],
     ///                                            "summaryKey": [],
     ///                                            "resolutionKeys": [],
     ///                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                            "showUnseenIndicators": false,
     ///                                            "steps": [
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [
     ///                                                        {
     ///                                                            "x": -507.0,
     ///                                                            "z": 436.0,
     ///                                                            "mapMarkerType": "MAIN"
     ///                                                        }
     ///                                                    ],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": false,
     ///                                                    "shortActiveKey": [],
     ///                                                    "longActiveKey": [],
     ///                                                    "completedKey": [],
     ///                                                    "hideIfThisStepIsComplete": {
     ///                                                        "$ref": "1149"
     ///                                                    },
     ///                                                    "showAtDock": false,
     ///                                                    "stepDock": null,
     ///                                                    "showAtSpeaker": false,
     ///                                                    "stepSpeaker": null,
     ///                                                    "yarnRootNode": "",
     ///                                                    "showConditions": [],
     ///                                                    "canBeFailed": false,
     ///                                                    "failureEvents": [],
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                }
     ///                                            ],
     ///                                            "subquests": [],
     ///                                            "onOfferedQuestStep": null,
     ///                                            "canBeOfferedAutomatically": false,
     ///                                            "offerConditions": [],
     ///                                            "PS5Subtask": ""
     ///                                        },
     ///                                        {
     ///                                            "titleKey": [],
     ///                                            "summaryKey": [],
     ///                                            "resolutionKeys": [],
     ///                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                            "showUnseenIndicators": false,
     ///                                            "steps": [
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [
     ///                                                        {
     ///                                                            "x": -451.0,
     ///                                                            "z": 612.4,
     ///                                                            "mapMarkerType": "MAIN"
     ///                                                        }
     ///                                                    ],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
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
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                },
     ///                                                {
     ///                                                    "mapMarkersToAddOnStart": [],
     ///                                                    "mapMarkersToDeleteOnCompletion": [],
     ///                                                    "hiddenWhenActive": false,
     ///                                                    "hiddenWhenComplete": false,
     ///                                                    "shortActiveKey": [],
     ///                                                    "longActiveKey": [],
     ///                                                    "completedKey": [],
     ///                                                    "hideIfThisStepIsComplete": {
     ///                                                        "$ref": "1149"
     ///                                                    },
     ///                                                    "showAtDock": false,
     ///                                                    "stepDock": null,
     ///                                                    "showAtSpeaker": false,
     ///                                                    "stepSpeaker": null,
     ///                                                    "yarnRootNode": "",
     ///                                                    "showConditions": [],
     ///                                                    "canBeFailed": false,
     ///                                                    "failureEvents": [],
     ///                                                    "allowAutomaticCompletion": false,
     ///                                                    "conditionMode": "ALL",
     ///                                                    "completeConditions": []
     ///                                                }
     ///                                            ],
     ///                                            "subquests": [],
     ///                                            "onOfferedQuestStep": null,
     ///                                            "canBeOfferedAutomatically": false,
     ///                                            "offerConditions": [],
     ///                                            "PS5Subtask": ""
     ///                                        }
     ///                                    ],
     ///                                    "onOfferedQuestStep": null,
     ///                                    "canBeOfferedAutomatically": false,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                },
     ///                                {
     ///                                    "$ref": "202"
     ///                                },
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [
     ///                                        []
     ///                                    ],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": true,
     ///                                    "steps": [
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ALL",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ANY",
     ///                                            "completeConditions": []
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
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
     ///                                            "allowAutomaticCompletion": false,
     ///                                            "conditionMode": "ANY",
     ///                                            "completeConditions": []
     ///                                        }
     ///                                    ],
     ///                                    "subquests": [],
     ///                                    "onOfferedQuestStep": {
     ///                                        "mapMarkersToAddOnStart": [],
     ///                                        "mapMarkersToDeleteOnCompletion": [],
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
     ///                                        "conditionMode": "ANY",
     ///                                        "completeConditions": [
     ///                                            {
     ///                                                "itemId": "quest-tablet-1",
     ///                                                "silent": false,
     ///                                                "$type": "ItemInventoryCondition"
     ///                                            },
     ///                                            {
     ///                                                "itemId": "quest-tablet-2",
     ///                                                "silent": false,
     ///                                                "$type": "ItemInventoryCondition"
     ///                                            },
     ///                                            {
     ///                                                "itemId": "quest-tablet-3",
     ///                                                "silent": false,
     ///                                                "$type": "ItemInventoryCondition"
     ///                                            }
     ///                                        ]
     ///                                    },
     ///                                    "canBeOfferedAutomatically": true,
     ///                                    "offerConditions": [],
     ///                                    "PS5Subtask": ""
     ///                                }
     ///                            ],
     ///                            "$type": "QuestCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "COMPLETE_CHAPTER_1",
     ///                    "steamId": "COMPLETE_CHAPTER_1",
     ///                    "playStationId": 3,
     ///                    "xboxId": "3",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "quests": [
     ///                                {
     ///                                    "titleKey": [],
     ///                                    "summaryKey": [],
     ///                                    "resolutionKeys": [],
     ///                                    "mapMarkersToRemoveOnCompletion": [],
     ///                                    "showUnseenIndicators": false,
     ///                                    "steps": [
     ///                                        {
     ///                                            "$ref": "135"
     ///                                        },
     ///                                        {
     ///                                            "mapMarkersToAddOnStart": [],
     ///                                            "mapMarkersToDeleteOnCompletion": [
     ///                                                {
     ///                                                    "$ref": "138"
     ///                                                }
     ///                                            ],
     ///                                            "hiddenWhenActive": false,
     ///                                            "hiddenWhenComplete": false,
     ///                                            "shortActiveKey": [],
     ///                                            "longActiveKey": [],
     ///                                            "completedKey": [],
     ///                                            "hideIfThisStepIsComplete": {
     ///                                                "mapMarkersToAddOnStart": [],
     ///                                                "mapMarkersToDeleteOnCompletion": [],
     ///                                                "hiddenWhenActive": true,
     ///                                                "hiddenWhenComplete": false,
     ///                                                "shortActiveKey": [],
     ///                                                "longActiveKey": [],
     ///                                                "completedKey": [],
     ///                                                "hideIfThisStepIsComplete": null,
     ///                                                "showAtDock": false,
     ///                                                "stepDock": null,
     ///                                                "showAtSpeaker": false,
     ///                                                "stepSpeaker": null,
     ///                                                "yarnRootNode": "",
     ///                                                "showConditions": [],
     ///                                                "canBeFailed": false,
     ///                                                "failureEvents": [],
     ///                                                "allowAutomaticCompletion": true,
     ///                                                "conditionMode": "ALL",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "quest": {
     ///                                                            "$ref": "1368"
     ///                                                        },
     ///                                                        "state": "COMPLETED",
     ///                                                        "silent": false,
     ///                                                        "$type": "OtherQuestCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "quest": {
     ///                                                            "titleKey": [],
     ///                                                            "summaryKey": [],
     ///                                                            "resolutionKeys": [],
     ///                                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                                            "showUnseenIndicators": false,
     ///                                                            "steps": [
     ///                                                                {
     ///                                                                    "mapMarkersToAddOnStart": [],
     ///                                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                                        {
     ///                                                                            "x": 411.05,
     ///                                                                            "z": -463.04,
     ///                                                                            "mapMarkerType": "MAIN",
     ///                                                                            "$id": "1398"
     ///                                                                        }
     ///                                                                    ],
     ///                                                                    "hiddenWhenActive": false,
     ///                                                                    "hiddenWhenComplete": true,
     ///                                                                    "shortActiveKey": [],
     ///                                                                    "longActiveKey": [],
     ///                                                                    "completedKey": [],
     ///                                                                    "hideIfThisStepIsComplete": null,
     ///                                                                    "showAtDock": false,
     ///                                                                    "stepDock": null,
     ///                                                                    "showAtSpeaker": false,
     ///                                                                    "stepSpeaker": null,
     ///                                                                    "yarnRootNode": "",
     ///                                                                    "showConditions": [],
     ///                                                                    "canBeFailed": false,
     ///                                                                    "failureEvents": [],
     ///                                                                    "allowAutomaticCompletion": true,
     ///                                                                    "conditionMode": "ALL",
     ///                                                                    "completeConditions": [
     ///                                                                        {
     ///                                                                            "itemId": "relic2",
     ///                                                                            "silent": false,
     ///                                                                            "$type": "ItemInventoryCondition"
     ///                                                                        }
     ///                                                                    ]
     ///                                                                },
     ///                                                                {
     ///                                                                    "mapMarkersToAddOnStart": [],
     ///                                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                                        {
     ///                                                                            "$ref": "1398"
     ///                                                                        }
     ///                                                                    ],
     ///                                                                    "hiddenWhenActive": false,
     ///                                                                    "hiddenWhenComplete": false,
     ///                                                                    "shortActiveKey": [],
     ///                                                                    "longActiveKey": [],
     ///                                                                    "completedKey": [],
     ///                                                                    "hideIfThisStepIsComplete": {
     ///                                                                        "$ref": "1379"
     ///                                                                    },
     ///                                                                    "showAtDock": false,
     ///                                                                    "stepDock": null,
     ///                                                                    "showAtSpeaker": false,
     ///                                                                    "stepSpeaker": null,
     ///                                                                    "yarnRootNode": "",
     ///                                                                    "showConditions": [],
     ///                                                                    "canBeFailed": false,
     ///                                                                    "failureEvents": [],
     ///                                                                    "allowAutomaticCompletion": false,
     ///                                                                    "conditionMode": "ALL",
     ///                                                                    "completeConditions": []
     ///                                                                }
     ///                                                            ],
     ///                                                            "subquests": [],
     ///                                                            "onOfferedQuestStep": null,
     ///                                                            "canBeOfferedAutomatically": false,
     ///                                                            "offerConditions": [],
     ///                                                            "PS5Subtask": "Task_Chapter2",
     ///                                                            "$id": "1390"
     ///                                                        },
     ///                                                        "state": "COMPLETED",
     ///                                                        "silent": false,
     ///                                                        "$type": "OtherQuestCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "quest": {
     ///                                                            "titleKey": [],
     ///                                                            "summaryKey": [],
     ///                                                            "resolutionKeys": [],
     ///                                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                                            "showUnseenIndicators": false,
     ///                                                            "steps": [
     ///                                                                {
     ///                                                                    "mapMarkersToAddOnStart": [],
     ///                                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                                        {
     ///                                                                            "x": -431.6,
     ///                                                                            "z": -456.7,
     ///                                                                            "mapMarkerType": "MAIN",
     ///                                                                            "$id": "1426"
     ///                                                                        }
     ///                                                                    ],
     ///                                                                    "hiddenWhenActive": false,
     ///                                                                    "hiddenWhenComplete": true,
     ///                                                                    "shortActiveKey": [],
     ///                                                                    "longActiveKey": [],
     ///                                                                    "completedKey": [],
     ///                                                                    "hideIfThisStepIsComplete": null,
     ///                                                                    "showAtDock": false,
     ///                                                                    "stepDock": null,
     ///                                                                    "showAtSpeaker": false,
     ///                                                                    "stepSpeaker": null,
     ///                                                                    "yarnRootNode": "",
     ///                                                                    "showConditions": [],
     ///                                                                    "canBeFailed": false,
     ///                                                                    "failureEvents": [],
     ///                                                                    "allowAutomaticCompletion": true,
     ///                                                                    "conditionMode": "ALL",
     ///                                                                    "completeConditions": [
     ///                                                                        {
     ///                                                                            "itemId": "relic3",
     ///                                                                            "silent": false,
     ///                                                                            "$type": "ItemInventoryCondition"
     ///                                                                        }
     ///                                                                    ]
     ///                                                                },
     ///                                                                {
     ///                                                                    "mapMarkersToAddOnStart": [],
     ///                                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                                        {
     ///                                                                            "$ref": "1426"
     ///                                                                        }
     ///                                                                    ],
     ///                                                                    "hiddenWhenActive": false,
     ///                                                                    "hiddenWhenComplete": false,
     ///                                                                    "shortActiveKey": [],
     ///                                                                    "longActiveKey": [],
     ///                                                                    "completedKey": [],
     ///                                                                    "hideIfThisStepIsComplete": {
     ///                                                                        "$ref": "1379"
     ///                                                                    },
     ///                                                                    "showAtDock": false,
     ///                                                                    "stepDock": null,
     ///                                                                    "showAtSpeaker": false,
     ///                                                                    "stepSpeaker": null,
     ///                                                                    "yarnRootNode": "",
     ///                                                                    "showConditions": [],
     ///                                                                    "canBeFailed": false,
     ///                                                                    "failureEvents": [],
     ///                                                                    "allowAutomaticCompletion": false,
     ///                                                                    "conditionMode": "ALL",
     ///                                                                    "completeConditions": []
     ///                                                                }
     ///                                                            ],
     ///                                                            "subquests": [],
     ///                                                            "onOfferedQuestStep": null,
     ///                                                            "canBeOfferedAutomatically": false,
     ///                                                            "offerConditions": [],
     ///                                                            "PS5Subtask": "Task_Chapter3",
     ///                                                            "$id": "1418"
     ///                                                        },
     ///                                                        "state": "COMPLETED",
     ///                                                        "silent": false,
     ///                                                        "$type": "OtherQuestCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "quest": {
     ///                                                            "titleKey": [],
     ///                                                            "summaryKey": [],
     ///                                                            "resolutionKeys": [],
     ///                                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                                            "showUnseenIndicators": false,
     ///                                                            "steps": [
     ///                                                                {
     ///                                                                    "mapMarkersToAddOnStart": [],
     ///                                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                                        {
     ///                                                                            "x": -464.24,
     ///                                                                            "z": 530.35,
     ///                                                                            "mapMarkerType": "MAIN",
     ///                                                                            "$id": "1454"
     ///                                                                        }
     ///                                                                    ],
     ///                                                                    "hiddenWhenActive": false,
     ///                                                                    "hiddenWhenComplete": true,
     ///                                                                    "shortActiveKey": [],
     ///                                                                    "longActiveKey": [],
     ///                                                                    "completedKey": [],
     ///                                                                    "hideIfThisStepIsComplete": null,
     ///                                                                    "showAtDock": false,
     ///                                                                    "stepDock": null,
     ///                                                                    "showAtSpeaker": false,
     ///                                                                    "stepSpeaker": null,
     ///                                                                    "yarnRootNode": "",
     ///                                                                    "showConditions": [],
     ///                                                                    "canBeFailed": false,
     ///                                                                    "failureEvents": [],
     ///                                                                    "allowAutomaticCompletion": true,
     ///                                                                    "conditionMode": "ALL",
     ///                                                                    "completeConditions": [
     ///                                                                        {
     ///                                                                            "itemId": "relic4",
     ///                                                                            "silent": false,
     ///                                                                            "$type": "ItemInventoryCondition"
     ///                                                                        }
     ///                                                                    ]
     ///                                                                },
     ///                                                                {
     ///                                                                    "mapMarkersToAddOnStart": [],
     ///                                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                                        {
     ///                                                                            "$ref": "1454"
     ///                                                                        }
     ///                                                                    ],
     ///                                                                    "hiddenWhenActive": false,
     ///                                                                    "hiddenWhenComplete": false,
     ///                                                                    "shortActiveKey": [],
     ///                                                                    "longActiveKey": [],
     ///                                                                    "completedKey": [],
     ///                                                                    "hideIfThisStepIsComplete": {
     ///                                                                        "$ref": "1379"
     ///                                                                    },
     ///                                                                    "showAtDock": false,
     ///                                                                    "stepDock": null,
     ///                                                                    "showAtSpeaker": false,
     ///                                                                    "stepSpeaker": null,
     ///                                                                    "yarnRootNode": "",
     ///                                                                    "showConditions": [],
     ///                                                                    "canBeFailed": false,
     ///                                                                    "failureEvents": [],
     ///                                                                    "allowAutomaticCompletion": false,
     ///                                                                    "conditionMode": "ALL",
     ///                                                                    "completeConditions": []
     ///                                                                }
     ///                                                            ],
     ///                                                            "subquests": [],
     ///                                                            "onOfferedQuestStep": null,
     ///                                                            "canBeOfferedAutomatically": false,
     ///                                                            "offerConditions": [],
     ///                                                            "PS5Subtask": "Task_Chapter4",
     ///                                                            "$id": "1446"
     ///                                                        },
     ///                                                        "state": "COMPLETED",
     ///                                                        "silent": false,
     ///                                                        "$type": "OtherQuestCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "quest": {
     ///                                                            "titleKey": [],
     ///                                                            "summaryKey": [],
     ///                                                            "resolutionKeys": [],
     ///                                                            "mapMarkersToRemoveOnCompletion": [],
     ///                                                            "showUnseenIndicators": false,
     ///                                                            "steps": [
     ///                                                                {
     ///                                                                    "mapMarkersToAddOnStart": [],
     ///                                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                                        {
     ///                                                                            "x": 454.3544,
     ///                                                                            "z": 451.7758,
     ///                                                                            "mapMarkerType": "MAIN",
     ///                                                                            "$id": "1482"
     ///                                                                        }
     ///                                                                    ],
     ///                                                                    "hiddenWhenActive": false,
     ///                                                                    "hiddenWhenComplete": true,
     ///                                                                    "shortActiveKey": [],
     ///                                                                    "longActiveKey": [],
     ///                                                                    "completedKey": [],
     ///                                                                    "hideIfThisStepIsComplete": null,
     ///                                                                    "showAtDock": false,
     ///                                                                    "stepDock": null,
     ///                                                                    "showAtSpeaker": false,
     ///                                                                    "stepSpeaker": null,
     ///                                                                    "yarnRootNode": "",
     ///                                                                    "showConditions": [],
     ///                                                                    "canBeFailed": false,
     ///                                                                    "failureEvents": [],
     ///                                                                    "allowAutomaticCompletion": true,
     ///                                                                    "conditionMode": "ALL",
     ///                                                                    "completeConditions": [
     ///                                                                        {
     ///                                                                            "itemId": "relic5",
     ///                                                                            "silent": false,
     ///                                                                            "$type": "ItemInventoryCondition"
     ///                                                                        }
     ///                                                                    ]
     ///                                                                },
     ///                                                                {
     ///                                                                    "mapMarkersToAddOnStart": [],
     ///                                                                    "mapMarkersToDeleteOnCompletion": [
     ///                                                                        {
     ///                                                                            "$ref": "1482"
     ///                                                                        }
     ///                                                                    ],
     ///                                                                    "hiddenWhenActive": false,
     ///                                                                    "hiddenWhenComplete": false,
     ///                                                                    "shortActiveKey": [],
     ///                                                                    "longActiveKey": [],
     ///                                                                    "completedKey": [],
     ///                                                                    "hideIfThisStepIsComplete": {
     ///                                                                        "$ref": "1379"
     ///                                                                    },
     ///                                                                    "showAtDock": false,
     ///                                                                    "stepDock": null,
     ///                                                                    "showAtSpeaker": false,
     ///                                                                    "stepSpeaker": null,
     ///                                                                    "yarnRootNode": "",
     ///                                                                    "showConditions": [],
     ///                                                                    "canBeFailed": false,
     ///                                                                    "failureEvents": [],
     ///                                                                    "allowAutomaticCompletion": false,
     ///                                                                    "conditionMode": "ALL",
     ///                                                                    "completeConditions": []
     ///                                                                }
     ///                                                            ],
     ///                                                            "subquests": [],
     ///                                                            "onOfferedQuestStep": null,
     ///                                                            "canBeOfferedAutomatically": false,
     ///                                                            "offerConditions": [],
     ///                                                            "PS5Subtask": "Task_Chapter5",
     ///                                                            "$id": "1474"
     ///                                                        },
     ///                                                        "state": "COMPLETED",
     ///                                                        "silent": false,
     ///                                                        "$type": "OtherQuestCondition"
     ///                                                    }
     ///                                                ],
     ///                                                "$id": "1379"
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
     ///                                    "PS5Subtask": "Task_Chapter1",
     ///                                    "$id": "1368"
     ///                                }
     ///                            ],
     ///                            "$type": "QuestCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "COMPLETE_CHAPTER_2",
     ///                    "steamId": "COMPLETE_CHAPTER_2",
     ///                    "playStationId": 4,
     ///                    "xboxId": "4",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "quests": [
     ///                                {
     ///                                    "$ref": "1390"
     ///                                }
     ///                            ],
     ///                            "$type": "QuestCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "COMPLETE_CHAPTER_3",
     ///                    "steamId": "COMPLETE_CHAPTER_3",
     ///                    "playStationId": 5,
     ///                    "xboxId": "5",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "quests": [
     ///                                {
     ///                                    "$ref": "1418"
     ///                                }
     ///                            ],
     ///                            "$type": "QuestCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "COMPLETE_CHAPTER_4",
     ///                    "steamId": "COMPLETE_CHAPTER_4",
     ///                    "playStationId": 6,
     ///                    "xboxId": "6",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "quests": [
     ///                                {
     ///                                    "$ref": "1446"
     ///                                }
     ///                            ],
     ///                            "$type": "QuestCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "COMPLETE_CHAPTER_5",
     ///                    "steamId": "COMPLETE_CHAPTER_5",
     ///                    "playStationId": 7,
     ///                    "xboxId": "7",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "quests": [
     ///                                {
     ///                                    "$ref": "1474"
     ///                                }
     ///                            ],
     ///                            "$type": "QuestCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "DEPLETE_FISH_SPOTS",
     ///                    "steamId": "DEPLETE_FISH_SPOTS",
     ///                    "playStationId": 32,
     ///                    "xboxId": "32",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "key": "fish-depleted-count",
     ///                            "target": 25,
     ///                            "evaluationMode": "GTE",
     ///                            "$type": "IntCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "DISCARD_FISH",
     ///                    "steamId": "DISCARD_FISH",
     ///                    "playStationId": 39,
     ///                    "xboxId": "39",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "key": "fish-discard-count",
     ///                            "target": 25,
     ///                            "evaluationMode": "GTE",
     ///                            "$type": "IntCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "DISCOVER_ALL_DOCKS",
     ///                    "steamId": "DISCOVER_ALL_DOCKS",
     ///                    "playStationId": 20,
     ///                    "xboxId": "20",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "keys": [
     ///                                "has-visited-dock-dock.greater-marrow",
     ///                                "has-visited-dock-dock.little-marrow",
     ///                                "has-visited-dock-dock.gale-cliffs",
     ///                                "has-visited-dock-dock.ingfell",
     ///                                "has-visited-dock-dock.old-fort",
     ///                                "has-visited-dock-dock.old-mayor-ds",
     ///                                "has-visited-dock-dock.old-mayor-gc",
     ///                                "has-visited-dock-dock.old-mayor-sb",
     ///                                "has-visited-dock-dock.old-mayor-ts",
     ///                                "has-visited-dock-dock.outcast-isle",
     ///                                "has-visited-dock-dock.pontoon-ds",
     ///                                "has-visited-dock-dock.pontoon-gc",
     ///                                "has-visited-dock-dock.pontoon-sb",
     ///                                "has-visited-dock-dock.pontoon-ts",
     ///                                "has-visited-dock-dock.research-pontoon",
     ///                                "has-visited-dock-dock.soldier-camp",
     ///                                "has-visited-dock-dock.steel-point",
     ///                                "has-visited-dock-dock.ds-temple",
     ///                                "has-visited-dock-dock.ancient-ruins"
     ///                            ],
     ///                            "state": true,
     ///                            "$type": "BoolCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "ENDING",
     ///                    "steamId": "ENDING",
     ///                    "playStationId": 8,
     ///                    "xboxId": "8",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "ENDING_ALT",
     ///                    "steamId": "ENDING_ALT",
     ///                    "playStationId": 9,
     ///                    "xboxId": "9",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "FULL_CARGO",
     ///                    "steamId": "FULL_CARGO",
     ///                    "playStationId": 10,
     ///                    "xboxId": "10",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "FULL_EQUIPMENT",
     ///                    "steamId": "FULL_EQUIPMENT",
     ///                    "playStationId": 22,
     ///                    "xboxId": "22",
     ///                    "evaluationConditions": []
     ///                },
     ///                {
     ///                    "id": "HULL_2",
     ///                    "steamId": "HULL_2",
     ///                    "playStationId": 36,
     ///                    "xboxId": "36",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "upgrades": [
     ///                                {
     ///                                    "hullGridConfiguration": {
     ///                                        "cellGroupConfigs": [
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,ENGINE,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "",
     ///                                                "itemSubtype": "",
     ///                                                "isHidden": true,
     ///                                                "damageImmune": true
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,NET,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "DREDGE,ALL",
     ///                                                "isHidden": true,
     ///                                                "damageImmune": true
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            }
     ///                                        ],
     ///                                        "mainItemType": "GENERAL,ALL",
     ///                                        "mainItemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                        "mainItemData": null,
     ///                                        "itemsInThisBelongToPlayer": true,
     ///                                        "canAddItemsInQuestMode": false,
     ///                                        "hasUnderlay": true,
     ///                                        "columns": 7,
     ///                                        "rows": 10
     ///                                    },
     ///                                    "engineAudioClip": {
     ///                                        "m_AssetGUID": "99d55ad587e04e84eadf4becbae5a2a7",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    "newCellCount": 5,
     ///                                    "hullSprite": {
     ///
     ///                                    },
     ///                                    "id": "tier-2-hull",
     ///                                    "tier": 2,
     ///                                    "sprite": {
     ///                                        "$id": "1555"
     ///                                    },
     ///                                    "gridConfig": {
     ///                                        "questGridExitMode": "REVISITABLE",
     ///                                        "titleString": [],
     ///                                        "helpStringOverride": [],
     ///                                        "exitPromptOverride": [],
     ///                                        "backgroundImage": null,
     ///                                        "gridHeightOverride": 0.0,
     ///                                        "overrideGridCellColor": false,
     ///                                        "gridCellColor": "NEUTRAL",
     ///                                        "allowStorageAccess": true,
     ///                                        "isSaved": true,
     ///                                        "createItemsIfEmpty": false,
     ///                                        "gridKey": "UPGRADE_T2_HULL",
     ///                                        "allowManualExit": true,
     ///                                        "allowEquipmentInstallation": false,
     ///                                        "createWithDurabilityValue": false,
     ///                                        "startingDurabilityProportion": 1.0,
     ///                                        "gridConfiguration": {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "",
     ///                                                    "itemSubtype": "",
     ///                                                    "isHidden": true,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "mainItemType": "GENERAL,ALL",
     ///                                            "mainItemSubtype": "MATERIAL,ALL",
     ///                                            "mainItemData": null,
     ///                                            "itemsInThisBelongToPlayer": true,
     ///                                            "canAddItemsInQuestMode": true,
     ///                                            "hasUnderlay": false,
     ///                                            "columns": 5,
     ///                                            "rows": 6
     ///                                        },
     ///                                        "presetGrid": {
     ///                                            "spatialUnderlayItems": [],
     ///                                            "spatialItems": [
     ///                                                {
     ///                                                    "x": 0,
     ///                                                    "y": 0,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 0,
     ///                                                    "y": 3,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 4,
     ///                                                    "y": 0,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 4,
     ///                                                    "y": 3,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 1,
     ///                                                    "y": 0,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "scrap"
     ///                                                },
     ///                                                {
     ///                                                    "x": 1,
     ///                                                    "y": 2,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "scrap"
     ///                                                },
     ///                                                {
     ///                                                    "x": 3,
     ///                                                    "y": 0,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 3,
     ///                                                    "y": 2,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 3,
     ///                                                    "y": 4,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 2,
     ///                                                    "y": 5,
     ///                                                    "z": 180,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "metal"
     ///                                                }
     ///                                            ]
     ///                                        },
     ///                                        "presetGridMode": "SILHOUETTE",
     ///                                        "completeConditions": [
     ///                                            {
     ///                                                "item": {
     ///                                                    "harvestMinigameType": "DREDGE_RADIAL",
     ///                                                    "perSpotMin": 2,
     ///                                                    "perSpotMax": 4,
     ///                                                    "harvestItemWeight": 250.0,
     ///                                                    "regenHarvestSpotOnDestroy": false,
     ///                                                    "harvestPOICategory": "MATERIAL",
     ///                                                    "harvestableType": "DREDGE",
     ///                                                    "requiresAdvancedEquipment": false,
     ///                                                    "harvestDifficulty": "EASY",
     ///                                                    "canBeReplacedWithResearchItem": true,
     ///                                                    "canBeCaughtByRod": false,
     ///                                                    "canBeCaughtByPot": true,
     ///                                                    "canBeCaughtByNet": true,
     ///                                                    "affectedByFishingSustain": true,
     ///                                                    "hasMinDepth": false,
     ///                                                    "minDepth": "VERY_SHALLOW",
     ///                                                    "hasMaxDepth": false,
     ///                                                    "maxDepth": "VERY_SHALLOW",
     ///                                                    "zonesFoundIn": "",
     ///                                                    "canBeSoldByPlayer": true,
     ///                                                    "canBeSoldInBulkAction": false,
     ///                                                    "value": 10.0,
     ///                                                    "hasSellOverride": false,
     ///                                                    "sellOverrideValue": 0.0,
     ///                                                    "sprite": {
     ///
     ///                                                    },
     ///                                                    "platformSpecificSpriteOverrides": null,
     ///                                                    "itemColor": {
     ///                                                        "r": 0.227451,
     ///                                                        "g": 0.1568628,
     ///                                                        "b": 0.1254902,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "hasSpecialDiscardAction": false,
     ///                                                    "discardPromptOverride": "",
     ///                                                    "canBeDiscardedByPlayer": true,
     ///                                                    "showAlertOnDiscardHold": false,
     ///                                                    "discardHoldTimeOverride": false,
     ///                                                    "discardHoldTimeSec": 0.0,
     ///                                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                                    "damageMode": "DESTROY",
     ///                                                    "moveMode": "FREE",
     ///                                                    "ignoreDamageWhenPlacing": false,
     ///                                                    "isUnderlayItem": false,
     ///                                                    "forbidStorageTray": false,
     ///                                                    "dimensions": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "squishFactor": 0.0,
     ///                                                    "itemOwnPrerequisites": [],
     ///                                                    "researchPrerequisites": [],
     ///                                                    "researchPointsRequired": 0,
     ///                                                    "buyableWithoutResearch": false,
     ///                                                    "researchIsForRecipe": false,
     ///                                                    "useIntenseAberratedUIShader": false,
     ///                                                    "id": "lumber",
     ///                                                    "itemNameKey": [],
     ///                                                    "itemDescriptionKey": [],
     ///                                                    "hasAdditionalNote": false,
     ///                                                    "additionalNoteKey": [],
     ///                                                    "itemInsaneTitleKey": [],
     ///                                                    "itemInsaneDescriptionKey": [],
     ///                                                    "linkedDialogueNode": "",
     ///                                                    "dialogueNodeSpecificDescription": [],
     ///                                                    "itemType": "GENERAL,ALL",
     ///                                                    "itemSubtype": "MATERIAL,ALL",
     ///                                                    "tooltipTextColor": {
     ///                                                        "r": 0.4901961,
     ///                                                        "g": 0.3843137,
     ///                                                        "b": 0.2666667,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "tooltipNotesColor": {
     ///                                                        "r": 1.0,
     ///                                                        "g": 1.0,
     ///                                                        "b": 1.0,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "itemTypeIcon": {
     ///
     ///                                                    },
     ///                                                    "harvestParticlePrefab": {
     ///
     ///                                                    },
     ///                                                    "overrideHarvestParticleDepth": false,
     ///                                                    "harvestParticleDepthOffset": -3.0,
     ///                                                    "flattenParticleShape": false,
     ///                                                    "availableInDemo": true,
     ///                                                    "entitlementsRequired": [
     ///                                                        "NONE"
     ///                                                    ],
     ///                                                    "$type": "HarvestableItemData",
     ///                                                    "$id": "1578"
     ///                                                },
     ///                                                "count": 4,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            },
     ///                                            {
     ///                                                "item": {
     ///                                                    "harvestMinigameType": "DREDGE_RADIAL",
     ///                                                    "perSpotMin": 2,
     ///                                                    "perSpotMax": 4,
     ///                                                    "harvestItemWeight": 250.0,
     ///                                                    "regenHarvestSpotOnDestroy": false,
     ///                                                    "harvestPOICategory": "MATERIAL",
     ///                                                    "harvestableType": "DREDGE",
     ///                                                    "requiresAdvancedEquipment": false,
     ///                                                    "harvestDifficulty": "EASY",
     ///                                                    "canBeReplacedWithResearchItem": true,
     ///                                                    "canBeCaughtByRod": false,
     ///                                                    "canBeCaughtByPot": true,
     ///                                                    "canBeCaughtByNet": true,
     ///                                                    "affectedByFishingSustain": true,
     ///                                                    "hasMinDepth": false,
     ///                                                    "minDepth": "VERY_SHALLOW",
     ///                                                    "hasMaxDepth": false,
     ///                                                    "maxDepth": "VERY_SHALLOW",
     ///                                                    "zonesFoundIn": "",
     ///                                                    "canBeSoldByPlayer": true,
     ///                                                    "canBeSoldInBulkAction": false,
     ///                                                    "value": 15.0,
     ///                                                    "hasSellOverride": false,
     ///                                                    "sellOverrideValue": 0.0,
     ///                                                    "sprite": {
     ///
     ///                                                    },
     ///                                                    "platformSpecificSpriteOverrides": null,
     ///                                                    "itemColor": {
     ///                                                        "r": 0.227451,
     ///                                                        "g": 0.1568628,
     ///                                                        "b": 0.1254902,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "hasSpecialDiscardAction": false,
     ///                                                    "discardPromptOverride": "",
     ///                                                    "canBeDiscardedByPlayer": true,
     ///                                                    "showAlertOnDiscardHold": false,
     ///                                                    "discardHoldTimeOverride": false,
     ///                                                    "discardHoldTimeSec": 0.0,
     ///                                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                                    "damageMode": "DESTROY",
     ///                                                    "moveMode": "FREE",
     ///                                                    "ignoreDamageWhenPlacing": false,
     ///                                                    "isUnderlayItem": false,
     ///                                                    "forbidStorageTray": false,
     ///                                                    "dimensions": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "squishFactor": 0.0,
     ///                                                    "itemOwnPrerequisites": [],
     ///                                                    "researchPrerequisites": [],
     ///                                                    "researchPointsRequired": 0,
     ///                                                    "buyableWithoutResearch": false,
     ///                                                    "researchIsForRecipe": false,
     ///                                                    "useIntenseAberratedUIShader": false,
     ///                                                    "id": "scrap",
     ///                                                    "itemNameKey": [],
     ///                                                    "itemDescriptionKey": [],
     ///                                                    "hasAdditionalNote": false,
     ///                                                    "additionalNoteKey": [],
     ///                                                    "itemInsaneTitleKey": [],
     ///                                                    "itemInsaneDescriptionKey": [],
     ///                                                    "linkedDialogueNode": "",
     ///                                                    "dialogueNodeSpecificDescription": [],
     ///                                                    "itemType": "GENERAL,ALL",
     ///                                                    "itemSubtype": "MATERIAL,ALL",
     ///                                                    "tooltipTextColor": {
     ///                                                        "r": 0.4901961,
     ///                                                        "g": 0.3843137,
     ///                                                        "b": 0.2666667,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "tooltipNotesColor": {
     ///                                                        "r": 1.0,
     ///                                                        "g": 1.0,
     ///                                                        "b": 1.0,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "itemTypeIcon": {
     ///
     ///                                                    },
     ///                                                    "harvestParticlePrefab": {
     ///
     ///                                                    },
     ///                                                    "overrideHarvestParticleDepth": false,
     ///                                                    "harvestParticleDepthOffset": -3.0,
     ///                                                    "flattenParticleShape": false,
     ///                                                    "availableInDemo": true,
     ///                                                    "entitlementsRequired": [
     ///                                                        "NONE"
     ///                                                    ],
     ///                                                    "$type": "HarvestableItemData",
     ///                                                    "$id": "1593"
     ///                                                },
     ///                                                "count": 2,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            },
     ///                                            {
     ///                                                "item": {
     ///                                                    "harvestMinigameType": "DREDGE_RADIAL",
     ///                                                    "perSpotMin": 2,
     ///                                                    "perSpotMax": 3,
     ///                                                    "harvestItemWeight": 150.0,
     ///                                                    "regenHarvestSpotOnDestroy": false,
     ///                                                    "harvestPOICategory": "MATERIAL",
     ///                                                    "harvestableType": "DREDGE",
     ///                                                    "requiresAdvancedEquipment": false,
     ///                                                    "harvestDifficulty": "MEDIUM",
     ///                                                    "canBeReplacedWithResearchItem": true,
     ///                                                    "canBeCaughtByRod": false,
     ///                                                    "canBeCaughtByPot": true,
     ///                                                    "canBeCaughtByNet": true,
     ///                                                    "affectedByFishingSustain": true,
     ///                                                    "hasMinDepth": false,
     ///                                                    "minDepth": "VERY_SHALLOW",
     ///                                                    "hasMaxDepth": false,
     ///                                                    "maxDepth": "VERY_SHALLOW",
     ///                                                    "zonesFoundIn": "",
     ///                                                    "canBeSoldByPlayer": true,
     ///                                                    "canBeSoldInBulkAction": false,
     ///                                                    "value": 20.0,
     ///                                                    "hasSellOverride": false,
     ///                                                    "sellOverrideValue": 0.0,
     ///                                                    "sprite": {
     ///
     ///                                                    },
     ///                                                    "platformSpecificSpriteOverrides": null,
     ///                                                    "itemColor": {
     ///                                                        "r": 0.227451,
     ///                                                        "g": 0.1568628,
     ///                                                        "b": 0.1254902,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "hasSpecialDiscardAction": false,
     ///                                                    "discardPromptOverride": "",
     ///                                                    "canBeDiscardedByPlayer": true,
     ///                                                    "showAlertOnDiscardHold": false,
     ///                                                    "discardHoldTimeOverride": false,
     ///                                                    "discardHoldTimeSec": 0.0,
     ///                                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                                    "damageMode": "DESTROY",
     ///                                                    "moveMode": "FREE",
     ///                                                    "ignoreDamageWhenPlacing": false,
     ///                                                    "isUnderlayItem": false,
     ///                                                    "forbidStorageTray": false,
     ///                                                    "dimensions": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "squishFactor": 0.0,
     ///                                                    "itemOwnPrerequisites": [],
     ///                                                    "researchPrerequisites": [],
     ///                                                    "researchPointsRequired": 0,
     ///                                                    "buyableWithoutResearch": false,
     ///                                                    "researchIsForRecipe": false,
     ///                                                    "useIntenseAberratedUIShader": false,
     ///                                                    "id": "cloth",
     ///                                                    "itemNameKey": [],
     ///                                                    "itemDescriptionKey": [],
     ///                                                    "hasAdditionalNote": false,
     ///                                                    "additionalNoteKey": [],
     ///                                                    "itemInsaneTitleKey": [],
     ///                                                    "itemInsaneDescriptionKey": [],
     ///                                                    "linkedDialogueNode": "",
     ///                                                    "dialogueNodeSpecificDescription": [],
     ///                                                    "itemType": "GENERAL,ALL",
     ///                                                    "itemSubtype": "MATERIAL,ALL",
     ///                                                    "tooltipTextColor": {
     ///                                                        "r": 0.4901961,
     ///                                                        "g": 0.3843137,
     ///                                                        "b": 0.2666667,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "tooltipNotesColor": {
     ///                                                        "r": 1.0,
     ///                                                        "g": 1.0,
     ///                                                        "b": 1.0,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "itemTypeIcon": {
     ///
     ///                                                    },
     ///                                                    "harvestParticlePrefab": {
     ///
     ///                                                    },
     ///                                                    "overrideHarvestParticleDepth": false,
     ///                                                    "harvestParticleDepthOffset": -3.0,
     ///                                                    "flattenParticleShape": false,
     ///                                                    "availableInDemo": true,
     ///                                                    "entitlementsRequired": [
     ///                                                        "NONE"
     ///                                                    ],
     ///                                                    "$type": "HarvestableItemData",
     ///                                                    "$id": "1608"
     ///                                                },
     ///                                                "count": 3,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            },
     ///                                            {
     ///                                                "item": {
     ///                                                    "harvestMinigameType": "DREDGE_RADIAL",
     ///                                                    "perSpotMin": 1,
     ///                                                    "perSpotMax": 1,
     ///                                                    "harvestItemWeight": 10.0,
     ///                                                    "regenHarvestSpotOnDestroy": false,
     ///                                                    "harvestPOICategory": "MATERIAL",
     ///                                                    "harvestableType": "DREDGE",
     ///                                                    "requiresAdvancedEquipment": false,
     ///                                                    "harvestDifficulty": "VERY_HARD",
     ///                                                    "canBeReplacedWithResearchItem": false,
     ///                                                    "canBeCaughtByRod": false,
     ///                                                    "canBeCaughtByPot": true,
     ///                                                    "canBeCaughtByNet": true,
     ///                                                    "affectedByFishingSustain": true,
     ///                                                    "hasMinDepth": false,
     ///                                                    "minDepth": "VERY_SHALLOW",
     ///                                                    "hasMaxDepth": false,
     ///                                                    "maxDepth": "VERY_SHALLOW",
     ///                                                    "zonesFoundIn": "",
     ///                                                    "canBeSoldByPlayer": true,
     ///                                                    "canBeSoldInBulkAction": false,
     ///                                                    "value": 500.0,
     ///                                                    "hasSellOverride": true,
     ///                                                    "sellOverrideValue": 200.0,
     ///                                                    "sprite": {
     ///
     ///                                                    },
     ///                                                    "platformSpecificSpriteOverrides": null,
     ///                                                    "itemColor": {
     ///                                                        "r": 0.227451,
     ///                                                        "g": 0.1568628,
     ///                                                        "b": 0.1254902,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "hasSpecialDiscardAction": false,
     ///                                                    "discardPromptOverride": "",
     ///                                                    "canBeDiscardedByPlayer": true,
     ///                                                    "showAlertOnDiscardHold": false,
     ///                                                    "discardHoldTimeOverride": false,
     ///                                                    "discardHoldTimeSec": 0.0,
     ///                                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                                    "damageMode": "DESTROY",
     ///                                                    "moveMode": "FREE",
     ///                                                    "ignoreDamageWhenPlacing": false,
     ///                                                    "isUnderlayItem": false,
     ///                                                    "forbidStorageTray": false,
     ///                                                    "dimensions": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "squishFactor": 0.0,
     ///                                                    "itemOwnPrerequisites": [],
     ///                                                    "researchPrerequisites": [],
     ///                                                    "researchPointsRequired": 0,
     ///                                                    "buyableWithoutResearch": false,
     ///                                                    "researchIsForRecipe": false,
     ///                                                    "useIntenseAberratedUIShader": false,
     ///                                                    "id": "metal",
     ///                                                    "itemNameKey": [],
     ///                                                    "itemDescriptionKey": [],
     ///                                                    "hasAdditionalNote": false,
     ///                                                    "additionalNoteKey": [],
     ///                                                    "itemInsaneTitleKey": [],
     ///                                                    "itemInsaneDescriptionKey": [],
     ///                                                    "linkedDialogueNode": "",
     ///                                                    "dialogueNodeSpecificDescription": [],
     ///                                                    "itemType": "GENERAL,ALL",
     ///                                                    "itemSubtype": "MATERIAL,ALL",
     ///                                                    "tooltipTextColor": {
     ///                                                        "r": 0.4901961,
     ///                                                        "g": 0.3843137,
     ///                                                        "b": 0.2666667,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "tooltipNotesColor": {
     ///                                                        "r": 1.0,
     ///                                                        "g": 1.0,
     ///                                                        "b": 1.0,
     ///                                                        "a": 1.0
     ///                                                    },
     ///                                                    "itemTypeIcon": {
     ///
     ///                                                    },
     ///                                                    "harvestParticlePrefab": {
     ///
     ///                                                    },
     ///                                                    "overrideHarvestParticleDepth": false,
     ///                                                    "harvestParticleDepthOffset": -3.0,
     ///                                                    "flattenParticleShape": false,
     ///                                                    "availableInDemo": true,
     ///                                                    "entitlementsRequired": [
     ///                                                        "NONE"
     ///                                                    ],
     ///                                                    "$type": "HarvestableItemData",
     ///                                                    "$id": "1623"
     ///                                                },
     ///                                                "count": 1,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            }
     ///                                        ]
     ///                                    },
     ///                                    "titleKey": [],
     ///                                    "descriptionKey": [],
     ///                                    "monetaryCost": 500.0,
     ///                                    "availableInDemo": false,
     ///                                    "upgradeCost": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1578"
     ///                                            },
     ///                                            "num": 4
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1593"
     ///                                            },
     ///                                            "num": 2
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1608"
     ///                                            },
     ///                                            "num": 3
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1623"
     ///                                            },
     ///                                            "num": 1
     ///                                        }
     ///                                    ],
     ///                                    "itemCost": [],
     ///                                    "prerequisiteUpgrades": [
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,ENGINE,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-1-engines-1",
     ///                                            "tier": 1,
     ///                                            "sprite": {
     ///                                                "$id": "1649"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T1_ENGINES_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 3,
     ///                                                    "rows": 4
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 2,
     ///                                                            "y": 1,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 1,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 100.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 1
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        },
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,NET,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-1-net-1",
     ///                                            "tier": 1,
     ///                                            "sprite": {
     ///                                                "$id": "1676"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T1_NET_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 3,
     ///                                                    "rows": 3
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 1,
     ///                                                            "z": 90,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 1,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1608"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 125.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 1
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1608"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        },
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-1-lights-1",
     ///                                            "tier": 1,
     ///                                            "sprite": {
     ///                                                "$id": "1703"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T1_LIGHTS_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 3,
     ///                                                    "rows": 4
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 0,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 3,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 1,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 1,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 50.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 1
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        },
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-1-fishing-1",
     ///                                            "tier": 1,
     ///                                            "sprite": {
     ///                                                "$id": "1730"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T1_FISHING_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 3,
     ///                                                    "rows": 4
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 3,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 2,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 1,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1608"
     ///                                                        },
     ///                                                        "count": 1,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 95.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 1
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1608"
     ///                                                    },
     ///                                                    "num": 1
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        }
     ///                                    ],
     ///                                    "$type": "HullUpgradeData",
     ///                                    "$id": "1544"
     ///                                }
     ///                            ],
     ///                            "$type": "UpgradeOwnedCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "HULL_3",
     ///                    "steamId": "HULL_3",
     ///                    "playStationId": 37,
     ///                    "xboxId": "37",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "upgrades": [
     ///                                {
     ///                                    "hullGridConfiguration": {
     ///                                        "cellGroupConfigs": [
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,ENGINE,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "",
     ///                                                "itemSubtype": "",
     ///                                                "isHidden": true,
     ///                                                "damageImmune": true
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,NET,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "DREDGE,ALL",
     ///                                                "isHidden": true,
     ///                                                "damageImmune": true
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            }
     ///                                        ],
     ///                                        "mainItemType": "GENERAL,ALL",
     ///                                        "mainItemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                        "mainItemData": null,
     ///                                        "itemsInThisBelongToPlayer": true,
     ///                                        "canAddItemsInQuestMode": false,
     ///                                        "hasUnderlay": true,
     ///                                        "columns": 8,
     ///                                        "rows": 11
     ///                                    },
     ///                                    "engineAudioClip": {
     ///                                        "m_AssetGUID": "30f49651a808ab344992537363ef983a",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    "newCellCount": 9,
     ///                                    "hullSprite": {
     ///
     ///                                    },
     ///                                    "id": "tier-3-hull",
     ///                                    "tier": 3,
     ///                                    "sprite": {
     ///                                        "$ref": "1555"
     ///                                    },
     ///                                    "gridConfig": {
     ///                                        "questGridExitMode": "REVISITABLE",
     ///                                        "titleString": [],
     ///                                        "helpStringOverride": [],
     ///                                        "exitPromptOverride": [],
     ///                                        "backgroundImage": null,
     ///                                        "gridHeightOverride": 0.0,
     ///                                        "overrideGridCellColor": false,
     ///                                        "gridCellColor": "NEUTRAL",
     ///                                        "allowStorageAccess": true,
     ///                                        "isSaved": true,
     ///                                        "createItemsIfEmpty": false,
     ///                                        "gridKey": "UPGRADE_T3_HULL",
     ///                                        "allowManualExit": true,
     ///                                        "allowEquipmentInstallation": false,
     ///                                        "createWithDurabilityValue": false,
     ///                                        "startingDurabilityProportion": 1.0,
     ///                                        "gridConfiguration": {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "",
     ///                                                    "itemSubtype": "",
     ///                                                    "isHidden": true,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "mainItemType": "GENERAL,ALL",
     ///                                            "mainItemSubtype": "MATERIAL,ALL",
     ///                                            "mainItemData": null,
     ///                                            "itemsInThisBelongToPlayer": true,
     ///                                            "canAddItemsInQuestMode": true,
     ///                                            "hasUnderlay": false,
     ///                                            "columns": 6,
     ///                                            "rows": 6
     ///                                        },
     ///                                        "presetGrid": {
     ///                                            "spatialUnderlayItems": [],
     ///                                            "spatialItems": [
     ///                                                {
     ///                                                    "x": 1,
     ///                                                    "y": 0,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 1,
     ///                                                    "y": 3,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 4,
     ///                                                    "y": 0,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 4,
     ///                                                    "y": 3,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 2,
     ///                                                    "y": 1,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "scrap"
     ///                                                },
     ///                                                {
     ///                                                    "x": 0,
     ///                                                    "y": 2,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 5,
     ///                                                    "y": 2,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 2,
     ///                                                    "y": 0,
     ///                                                    "z": 90,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 3,
     ///                                                    "y": 4,
     ///                                                    "z": 180,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "metal"
     ///                                                },
     ///                                                {
     ///                                                    "x": 2,
     ///                                                    "y": 4,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "metal"
     ///                                                }
     ///                                            ]
     ///                                        },
     ///                                        "presetGridMode": "SILHOUETTE",
     ///                                        "completeConditions": [
     ///                                            {
     ///                                                "item": {
     ///                                                    "$ref": "1578"
     ///                                                },
     ///                                                "count": 4,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            },
     ///                                            {
     ///                                                "item": {
     ///                                                    "$ref": "1593"
     ///                                                },
     ///                                                "count": 1,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            },
     ///                                            {
     ///                                                "item": {
     ///                                                    "$ref": "1608"
     ///                                                },
     ///                                                "count": 3,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            },
     ///                                            {
     ///                                                "item": {
     ///                                                    "$ref": "1623"
     ///                                                },
     ///                                                "count": 2,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            }
     ///                                        ]
     ///                                    },
     ///                                    "titleKey": [],
     ///                                    "descriptionKey": [],
     ///                                    "monetaryCost": 800.0,
     ///                                    "availableInDemo": false,
     ///                                    "upgradeCost": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1578"
     ///                                            },
     ///                                            "num": 4
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1593"
     ///                                            },
     ///                                            "num": 1
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1608"
     ///                                            },
     ///                                            "num": 3
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1623"
     ///                                            },
     ///                                            "num": 2
     ///                                        }
     ///                                    ],
     ///                                    "itemCost": [],
     ///                                    "prerequisiteUpgrades": [
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,ENGINE,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-2-engines-1",
     ///                                            "tier": 2,
     ///                                            "sprite": {
     ///                                                "$ref": "1649"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T2_ENGINES_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 4,
     ///                                                    "rows": 4
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 1,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 3,
     ///                                                            "y": 1,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 75.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [
     ///                                                {
     ///                                                    "$ref": "1544"
     ///                                                }
     ///                                            ],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        },
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-2-fishing-1",
     ///                                            "tier": 2,
     ///                                            "sprite": {
     ///                                                "$ref": "1730"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T2_FISHING_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 4,
     ///                                                    "rows": 4
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 1,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 3,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 3,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 1,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1608"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 100.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 1
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1608"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [
     ///                                                {
     ///                                                    "$ref": "1544"
     ///                                                }
     ///                                            ],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        },
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,ALL",
     ///                                                    "itemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-2-storage-1",
     ///                                            "tier": 2,
     ///                                            "sprite": {
     ///                                                "$id": "1866"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T2_STORAGE_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 4,
     ///                                                    "rows": 5
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 1,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 3,
     ///                                                            "y": 1,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 4,
     ///                                                            "z": 90,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1608"
     ///                                                        },
     ///                                                        "count": 1,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 300.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1608"
     ///                                                    },
     ///                                                    "num": 1
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [
     ///                                                {
     ///                                                    "$ref": "1544"
     ///                                                }
     ///                                            ],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        }
     ///                                    ],
     ///                                    "$type": "HullUpgradeData",
     ///                                    "$id": "1761"
     ///                                }
     ///                            ],
     ///                            "$type": "UpgradeOwnedCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "HULL_4",
     ///                    "steamId": "HULL_4",
     ///                    "playStationId": 38,
     ///                    "xboxId": "38",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "upgrades": [
     ///                                {
     ///                                    "hullGridConfiguration": {
     ///                                        "cellGroupConfigs": [
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,ENGINE,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "",
     ///                                                "itemSubtype": "",
     ///                                                "isHidden": true,
     ///                                                "damageImmune": true
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,NET,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "DREDGE,ALL",
     ///                                                "isHidden": true,
     ///                                                "damageImmune": true
     ///                                            },
     ///                                            {
     ///                                                "cells": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                "itemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,GADGET,ALL",
     ///                                                "isHidden": false,
     ///                                                "damageImmune": false
     ///                                            }
     ///                                        ],
     ///                                        "mainItemType": "GENERAL,ALL",
     ///                                        "mainItemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                        "mainItemData": null,
     ///                                        "itemsInThisBelongToPlayer": true,
     ///                                        "canAddItemsInQuestMode": false,
     ///                                        "hasUnderlay": true,
     ///                                        "columns": 9,
     ///                                        "rows": 12
     ///                                    },
     ///                                    "engineAudioClip": {
     ///                                        "m_AssetGUID": "e553f68d84642c648818c0dfcdb889f8",
     ///                                        "m_SubObjectName": "",
     ///                                        "m_SubObjectType": ""
     ///                                    },
     ///                                    "newCellCount": 15,
     ///                                    "hullSprite": {
     ///
     ///                                    },
     ///                                    "id": "tier-4-hull",
     ///                                    "tier": 4,
     ///                                    "sprite": {
     ///                                        "$ref": "1555"
     ///                                    },
     ///                                    "gridConfig": {
     ///                                        "questGridExitMode": "REVISITABLE",
     ///                                        "titleString": [],
     ///                                        "helpStringOverride": [],
     ///                                        "exitPromptOverride": [],
     ///                                        "backgroundImage": null,
     ///                                        "gridHeightOverride": 0.0,
     ///                                        "overrideGridCellColor": false,
     ///                                        "gridCellColor": "NEUTRAL",
     ///                                        "allowStorageAccess": true,
     ///                                        "isSaved": true,
     ///                                        "createItemsIfEmpty": false,
     ///                                        "gridKey": "UPGRADE_T4_HULL",
     ///                                        "allowManualExit": true,
     ///                                        "allowEquipmentInstallation": false,
     ///                                        "createWithDurabilityValue": false,
     ///                                        "startingDurabilityProportion": 1.0,
     ///                                        "gridConfiguration": {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "",
     ///                                                    "itemSubtype": "",
     ///                                                    "isHidden": true,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "mainItemType": "GENERAL,ALL",
     ///                                            "mainItemSubtype": "MATERIAL,ALL",
     ///                                            "mainItemData": null,
     ///                                            "itemsInThisBelongToPlayer": true,
     ///                                            "canAddItemsInQuestMode": true,
     ///                                            "hasUnderlay": false,
     ///                                            "columns": 7,
     ///                                            "rows": 6
     ///                                        },
     ///                                        "presetGrid": {
     ///                                            "spatialUnderlayItems": [],
     ///                                            "spatialItems": [
     ///                                                {
     ///                                                    "x": 0,
     ///                                                    "y": 0,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 0,
     ///                                                    "y": 3,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 6,
     ///                                                    "y": 0,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 6,
     ///                                                    "y": 3,
     ///                                                    "z": 270,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "lumber"
     ///                                                },
     ///                                                {
     ///                                                    "x": 2,
     ///                                                    "y": 0,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "scrap"
     ///                                                },
     ///                                                {
     ///                                                    "x": 2,
     ///                                                    "y": 2,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "scrap"
     ///                                                },
     ///                                                {
     ///                                                    "x": 4,
     ///                                                    "y": 0,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "scrap"
     ///                                                },
     ///                                                {
     ///                                                    "x": 1,
     ///                                                    "y": 0,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 1,
     ///                                                    "y": 2,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 4,
     ///                                                    "y": 2,
     ///                                                    "z": 90,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 4,
     ///                                                    "y": 3,
     ///                                                    "z": 90,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "cloth"
     ///                                                },
     ///                                                {
     ///                                                    "x": 2,
     ///                                                    "y": 5,
     ///                                                    "z": 180,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "metal"
     ///                                                },
     ///                                                {
     ///                                                    "x": 2,
     ///                                                    "y": 4,
     ///                                                    "z": 0,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "metal"
     ///                                                },
     ///                                                {
     ///                                                    "x": 5,
     ///                                                    "y": 5,
     ///                                                    "z": 180,
     ///                                                    "durability": 0.0,
     ///                                                    "seen": false,
     ///                                                    "id": "metal"
     ///                                                }
     ///                                            ]
     ///                                        },
     ///                                        "presetGridMode": "SILHOUETTE",
     ///                                        "completeConditions": [
     ///                                            {
     ///                                                "item": {
     ///                                                    "$ref": "1578"
     ///                                                },
     ///                                                "count": 4,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            },
     ///                                            {
     ///                                                "item": {
     ///                                                    "$ref": "1593"
     ///                                                },
     ///                                                "count": 3,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            },
     ///                                            {
     ///                                                "item": {
     ///                                                    "$ref": "1608"
     ///                                                },
     ///                                                "count": 4,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            },
     ///                                            {
     ///                                                "item": {
     ///                                                    "$ref": "1623"
     ///                                                },
     ///                                                "count": 3,
     ///                                                "allowLinkedAberrations": false,
     ///                                                "$type": "ItemCountCondition"
     ///                                            }
     ///                                        ]
     ///                                    },
     ///                                    "titleKey": [],
     ///                                    "descriptionKey": [],
     ///                                    "monetaryCost": 1500.0,
     ///                                    "availableInDemo": false,
     ///                                    "upgradeCost": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1578"
     ///                                            },
     ///                                            "num": 4
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1593"
     ///                                            },
     ///                                            "num": 3
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1608"
     ///                                            },
     ///                                            "num": 4
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "1623"
     ///                                            },
     ///                                            "num": 3
     ///                                        }
     ///                                    ],
     ///                                    "itemCost": [],
     ///                                    "prerequisiteUpgrades": [
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,NET,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-3-net-1",
     ///                                            "tier": 3,
     ///                                            "sprite": {
     ///                                                "$ref": "1676"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T3_NET_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 3,
     ///                                                    "rows": 4
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 0,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 3,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 1,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 2,
     ///                                                            "y": 1,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1608"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 200.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1608"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [
     ///                                                {
     ///                                                    "$ref": "1761"
     ///                                                }
     ///                                            ],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        },
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,ENGINE,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-3-engines-1",
     ///                                            "tier": 3,
     ///                                            "sprite": {
     ///                                                "$ref": "1649"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T3_ENGINES_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 4,
     ///                                                    "rows": 5
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 2,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 3,
     ///                                                            "y": 2,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 2,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 3,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 80.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 3
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [
     ///                                                {
     ///                                                    "$ref": "1761"
     ///                                                }
     ///                                            ],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        },
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,LIGHT,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-3-lights-1",
     ///                                            "tier": 3,
     ///                                            "sprite": {
     ///                                                "$ref": "1703"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T3_LIGHTS_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 4,
     ///                                                    "rows": 5
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 2,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 4,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 75.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [
     ///                                                {
     ///                                                    "$ref": "1761"
     ///                                                }
     ///                                            ],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        },
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,ALL",
     ///                                                    "itemSubtype": "FISH,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-3-storage-1",
     ///                                            "tier": 3,
     ///                                            "sprite": {
     ///                                                "$ref": "1866"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T3_STORAGE_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 6,
     ///                                                    "rows": 5
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 1,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 5,
     ///                                                            "y": 1,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 4,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 3,
     ///                                                            "y": 4,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 3,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 3,
     ///                                                            "y": 2,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 0,
     ///                                                            "z": 90,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 1,
     ///                                                            "z": 90,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 4,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 3,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1608"
     ///                                                        },
     ///                                                        "count": 2,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 300.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 4
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 3
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1608"
     ///                                                    },
     ///                                                    "num": 2
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [
     ///                                                {
     ///                                                    "$ref": "1761"
     ///                                                }
     ///                                            ],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        },
     ///                                        {
     ///                                            "cellGroupConfigs": [
     ///                                                {
     ///                                                    "cells": [
     ///                                                        {
     ///
     ///                                                        },
     ///                                                        {
     ///
     ///                                                        }
     ///                                                    ],
     ///                                                    "itemType": "GENERAL,EQUIPMENT,ALL",
     ///                                                    "itemSubtype": "FISH,ROD,GENERAL,RELIC,TRINKET,MATERIAL,POT,GADGET,ALL",
     ///                                                    "isHidden": false,
     ///                                                    "damageImmune": false
     ///                                                }
     ///                                            ],
     ///                                            "id": "tier-3-fishing-1",
     ///                                            "tier": 3,
     ///                                            "sprite": {
     ///                                                "$ref": "1730"
     ///                                            },
     ///                                            "gridConfig": {
     ///                                                "questGridExitMode": "REVISITABLE",
     ///                                                "titleString": [],
     ///                                                "helpStringOverride": [],
     ///                                                "exitPromptOverride": [],
     ///                                                "backgroundImage": null,
     ///                                                "gridHeightOverride": 0.0,
     ///                                                "overrideGridCellColor": false,
     ///                                                "gridCellColor": "NEUTRAL",
     ///                                                "allowStorageAccess": true,
     ///                                                "isSaved": true,
     ///                                                "createItemsIfEmpty": false,
     ///                                                "gridKey": "UPGRADE_T3_FISHING_1",
     ///                                                "allowManualExit": true,
     ///                                                "allowEquipmentInstallation": false,
     ///                                                "createWithDurabilityValue": false,
     ///                                                "startingDurabilityProportion": 1.0,
     ///                                                "gridConfiguration": {
     ///                                                    "cellGroupConfigs": [
     ///                                                        {
     ///                                                            "cells": [
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "itemType": "",
     ///                                                            "itemSubtype": "",
     ///                                                            "isHidden": true,
     ///                                                            "damageImmune": false
     ///                                                        }
     ///                                                    ],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "MATERIAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": true,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 4,
     ///                                                    "rows": 4
     ///                                                },
     ///                                                "presetGrid": {
     ///                                                    "spatialUnderlayItems": [],
     ///                                                    "spatialItems": [
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 0,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 3,
     ///                                                            "y": 1,
     ///                                                            "z": 270,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 0,
     ///                                                            "y": 3,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "lumber"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 0,
     ///                                                            "z": 0,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "scrap"
     ///                                                        },
     ///                                                        {
     ///                                                            "x": 1,
     ///                                                            "y": 2,
     ///                                                            "z": 90,
     ///                                                            "durability": 0.0,
     ///                                                            "seen": false,
     ///                                                            "id": "cloth"
     ///                                                        }
     ///                                                    ]
     ///                                                },
     ///                                                "presetGridMode": "SILHOUETTE",
     ///                                                "completeConditions": [
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1578"
     ///                                                        },
     ///                                                        "count": 3,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1593"
     ///                                                        },
     ///                                                        "count": 1,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    },
     ///                                                    {
     ///                                                        "item": {
     ///                                                            "$ref": "1608"
     ///                                                        },
     ///                                                        "count": 1,
     ///                                                        "allowLinkedAberrations": false,
     ///                                                        "$type": "ItemCountCondition"
     ///                                                    }
     ///                                                ]
     ///                                            },
     ///                                            "titleKey": [],
     ///                                            "descriptionKey": [],
     ///                                            "monetaryCost": 120.0,
     ///                                            "availableInDemo": false,
     ///                                            "upgradeCost": [
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1578"
     ///                                                    },
     ///                                                    "num": 3
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1593"
     ///                                                    },
     ///                                                    "num": 1
     ///                                                },
     ///                                                {
     ///                                                    "itemData": {
     ///                                                        "$ref": "1608"
     ///                                                    },
     ///                                                    "num": 1
     ///                                                }
     ///                                            ],
     ///                                            "itemCost": [],
     ///                                            "prerequisiteUpgrades": [
     ///                                                {
     ///                                                    "$ref": "1761"
     ///                                                }
     ///                                            ],
     ///                                            "$type": "SlotUpgradeData"
     ///                                        }
     ///                                    ],
     ///                                    "$type": "HullUpgradeData"
     ///                                }
     ///                            ],
     ///                            "$type": "UpgradeOwnedCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "INTRODUCTIONS",
     ///                    "steamId": "INTRODUCTIONS",
     ///                    "playStationId": 1,
     ///                    "xboxId": "1",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "quests": [
     ///                                {
     ///                                    "$ref": "844"
     ///                                }
     ///                            ],
     ///                            "$type": "QuestCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "RESEARCH_ENGINES",
     ///                    "steamId": "RESEARCH_ENGINES",
     ///                    "playStationId": 26,
     ///                    "xboxId": "26",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "items": [
     ///                                {
     ///                                    "speedBonus": 9.0,
     ///                                    "canBeSoldByPlayer": true,
     ///                                    "canBeSoldInBulkAction": false,
     ///                                    "value": 300.0,
     ///                                    "hasSellOverride": false,
     ///                                    "sellOverrideValue": 0.0,
     ///                                    "sprite": {
     ///
     ///                                    },
     ///                                    "platformSpecificSpriteOverrides": null,
     ///                                    "itemColor": {
     ///                                        "r": 0.1921569,
     ///                                        "g": 0.1921569,
     ///                                        "b": 0.1921569,
     ///                                        "a": 255.0
     ///                                    },
     ///                                    "hasSpecialDiscardAction": false,
     ///                                    "discardPromptOverride": "",
     ///                                    "canBeDiscardedByPlayer": true,
     ///                                    "showAlertOnDiscardHold": true,
     ///                                    "discardHoldTimeOverride": true,
     ///                                    "discardHoldTimeSec": 2.0,
     ///                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                    "damageMode": "OPERATION",
     ///                                    "moveMode": "INSTALL",
     ///                                    "ignoreDamageWhenPlacing": true,
     ///                                    "isUnderlayItem": false,
     ///                                    "forbidStorageTray": false,
     ///                                    "dimensions": [
     ///                                        {
     ///
     ///                                        }
     ///                                    ],
     ///                                    "squishFactor": 0.0,
     ///                                    "itemOwnPrerequisites": [],
     ///                                    "researchPrerequisites": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "speedBonus": 15.0,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": false,
     ///                                                "value": 200.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "OPERATION",
     ///                                                "moveMode": "INSTALL",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.0,
     ///                                                "itemOwnPrerequisites": [],
     ///                                                "researchPrerequisites": [],
     ///                                                "researchPointsRequired": 1,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "engine3",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "ENGINE,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$id": "2118"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "EngineItemData",
     ///                                                "$id": "2107"
     ///                                            }
     ///                                        }
     ///                                    ],
     ///                                    "researchPointsRequired": 5,
     ///                                    "buyableWithoutResearch": false,
     ///                                    "researchIsForRecipe": false,
     ///                                    "useIntenseAberratedUIShader": false,
     ///                                    "id": "engine6",
     ///                                    "itemNameKey": [],
     ///                                    "itemDescriptionKey": [],
     ///                                    "hasAdditionalNote": false,
     ///                                    "additionalNoteKey": [],
     ///                                    "itemInsaneTitleKey": [],
     ///                                    "itemInsaneDescriptionKey": [],
     ///                                    "linkedDialogueNode": "",
     ///                                    "dialogueNodeSpecificDescription": [],
     ///                                    "itemType": "EQUIPMENT,ALL",
     ///                                    "itemSubtype": "ENGINE,ALL",
     ///                                    "tooltipTextColor": {
     ///                                        "r": 0.4901961,
     ///                                        "g": 0.3843137,
     ///                                        "b": 0.2666667,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "tooltipNotesColor": {
     ///                                        "r": 1.0,
     ///                                        "g": 1.0,
     ///                                        "b": 1.0,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "itemTypeIcon": {
     ///                                        "$ref": "2118"
     ///                                    },
     ///                                    "harvestParticlePrefab": null,
     ///                                    "overrideHarvestParticleDepth": false,
     ///                                    "harvestParticleDepthOffset": -3.0,
     ///                                    "flattenParticleShape": false,
     ///                                    "availableInDemo": false,
     ///                                    "entitlementsRequired": [
     ///                                        "NONE"
     ///                                    ],
     ///                                    "$type": "EngineItemData"
     ///                                },
     ///                                {
     ///                                    "speedBonus": 64.0,
     ///                                    "canBeSoldByPlayer": true,
     ///                                    "canBeSoldInBulkAction": false,
     ///                                    "value": 750.0,
     ///                                    "hasSellOverride": false,
     ///                                    "sellOverrideValue": 0.0,
     ///                                    "sprite": {
     ///
     ///                                    },
     ///                                    "platformSpecificSpriteOverrides": null,
     ///                                    "itemColor": {
     ///                                        "r": 0.1921569,
     ///                                        "g": 0.1921569,
     ///                                        "b": 0.1921569,
     ///                                        "a": 255.0
     ///                                    },
     ///                                    "hasSpecialDiscardAction": false,
     ///                                    "discardPromptOverride": "",
     ///                                    "canBeDiscardedByPlayer": true,
     ///                                    "showAlertOnDiscardHold": true,
     ///                                    "discardHoldTimeOverride": true,
     ///                                    "discardHoldTimeSec": 2.0,
     ///                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                    "damageMode": "OPERATION",
     ///                                    "moveMode": "INSTALL",
     ///                                    "ignoreDamageWhenPlacing": true,
     ///                                    "isUnderlayItem": false,
     ///                                    "forbidStorageTray": false,
     ///                                    "dimensions": [
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        }
     ///                                    ],
     ///                                    "squishFactor": 0.0,
     ///                                    "itemOwnPrerequisites": [],
     ///                                    "researchPrerequisites": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "speedBonus": 25.0,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": false,
     ///                                                "value": 300.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "OPERATION",
     ///                                                "moveMode": "INSTALL",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.0,
     ///                                                "itemOwnPrerequisites": [],
     ///                                                "researchPrerequisites": [
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "$ref": "2107"
     ///                                                        }
     ///                                                    }
     ///                                                ],
     ///                                                "researchPointsRequired": 2,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "engine4",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "ENGINE,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$ref": "2118"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "EngineItemData"
     ///                                            }
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "speedBonus": 50.0,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": false,
     ///                                                "value": 500.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "OPERATION",
     ///                                                "moveMode": "INSTALL",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.0,
     ///                                                "itemOwnPrerequisites": [],
     ///                                                "researchPrerequisites": [
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "speedBonus": 35.0,
     ///                                                            "canBeSoldByPlayer": true,
     ///                                                            "canBeSoldInBulkAction": false,
     ///                                                            "value": 450.0,
     ///                                                            "hasSellOverride": false,
     ///                                                            "sellOverrideValue": 0.0,
     ///                                                            "sprite": {
     ///
     ///                                                            },
     ///                                                            "platformSpecificSpriteOverrides": null,
     ///                                                            "itemColor": {
     ///                                                                "r": 0.1921569,
     ///                                                                "g": 0.1921569,
     ///                                                                "b": 0.1921569,
     ///                                                                "a": 255.0
     ///                                                            },
     ///                                                            "hasSpecialDiscardAction": false,
     ///                                                            "discardPromptOverride": "",
     ///                                                            "canBeDiscardedByPlayer": true,
     ///                                                            "showAlertOnDiscardHold": true,
     ///                                                            "discardHoldTimeOverride": true,
     ///                                                            "discardHoldTimeSec": 2.0,
     ///                                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                                            "damageMode": "OPERATION",
     ///                                                            "moveMode": "INSTALL",
     ///                                                            "ignoreDamageWhenPlacing": true,
     ///                                                            "isUnderlayItem": false,
     ///                                                            "forbidStorageTray": false,
     ///                                                            "dimensions": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "squishFactor": 0.0,
     ///                                                            "itemOwnPrerequisites": [],
     ///                                                            "researchPrerequisites": [
     ///                                                                {
     ///                                                                    "itemData": {
     ///                                                                        "$ref": "2107"
     ///                                                                    }
     ///                                                                }
     ///                                                            ],
     ///                                                            "researchPointsRequired": 3,
     ///                                                            "buyableWithoutResearch": false,
     ///                                                            "researchIsForRecipe": false,
     ///                                                            "useIntenseAberratedUIShader": false,
     ///                                                            "id": "engine5",
     ///                                                            "itemNameKey": [],
     ///                                                            "itemDescriptionKey": [],
     ///                                                            "hasAdditionalNote": false,
     ///                                                            "additionalNoteKey": [],
     ///                                                            "itemInsaneTitleKey": [],
     ///                                                            "itemInsaneDescriptionKey": [],
     ///                                                            "linkedDialogueNode": "",
     ///                                                            "dialogueNodeSpecificDescription": [],
     ///                                                            "itemType": "EQUIPMENT,ALL",
     ///                                                            "itemSubtype": "ENGINE,ALL",
     ///                                                            "tooltipTextColor": {
     ///                                                                "r": 0.4901961,
     ///                                                                "g": 0.3843137,
     ///                                                                "b": 0.2666667,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "tooltipNotesColor": {
     ///                                                                "r": 1.0,
     ///                                                                "g": 1.0,
     ///                                                                "b": 1.0,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "itemTypeIcon": {
     ///                                                                "$ref": "2118"
     ///                                                            },
     ///                                                            "harvestParticlePrefab": null,
     ///                                                            "overrideHarvestParticleDepth": false,
     ///                                                            "harvestParticleDepthOffset": -3.0,
     ///                                                            "flattenParticleShape": false,
     ///                                                            "availableInDemo": false,
     ///                                                            "entitlementsRequired": [
     ///                                                                "NONE"
     ///                                                            ],
     ///                                                            "$type": "EngineItemData"
     ///                                                        }
     ///                                                    }
     ///                                                ],
     ///                                                "researchPointsRequired": 4,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "engine7",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "ENGINE,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$ref": "2118"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "EngineItemData"
     ///                                            }
     ///                                        }
     ///                                    ],
     ///                                    "researchPointsRequired": 5,
     ///                                    "buyableWithoutResearch": false,
     ///                                    "researchIsForRecipe": false,
     ///                                    "useIntenseAberratedUIShader": false,
     ///                                    "id": "engine8",
     ///                                    "itemNameKey": [],
     ///                                    "itemDescriptionKey": [],
     ///                                    "hasAdditionalNote": false,
     ///                                    "additionalNoteKey": [],
     ///                                    "itemInsaneTitleKey": [],
     ///                                    "itemInsaneDescriptionKey": [],
     ///                                    "linkedDialogueNode": "",
     ///                                    "dialogueNodeSpecificDescription": [],
     ///                                    "itemType": "EQUIPMENT,ALL",
     ///                                    "itemSubtype": "ENGINE,ALL",
     ///                                    "tooltipTextColor": {
     ///                                        "r": 0.4901961,
     ///                                        "g": 0.3843137,
     ///                                        "b": 0.2666667,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "tooltipNotesColor": {
     ///                                        "r": 1.0,
     ///                                        "g": 1.0,
     ///                                        "b": 1.0,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "itemTypeIcon": {
     ///                                        "$ref": "2118"
     ///                                    },
     ///                                    "harvestParticlePrefab": null,
     ///                                    "overrideHarvestParticleDepth": false,
     ///                                    "harvestParticleDepthOffset": -3.0,
     ///                                    "flattenParticleShape": false,
     ///                                    "availableInDemo": false,
     ///                                    "entitlementsRequired": [
     ///                                        "NONE"
     ///                                    ],
     ///                                    "$type": "EngineItemData"
     ///                                }
     ///                            ],
     ///                            "$type": "ResearchCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "RESEARCH_NETS",
     ///                    "steamId": "RESEARCH_NETS",
     ///                    "playStationId": 24,
     ///                    "xboxId": "24",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "items": [
     ///                                {
     ///                                    "timeBetweenCatchRolls": 0.083,
     ///                                    "catchRate": 1.0,
     ///                                    "maxDurabilityDays": 2.0,
     ///                                    "gridConfig": {
     ///                                        "cellGroupConfigs": [],
     ///                                        "mainItemType": "GENERAL,ALL",
     ///                                        "mainItemSubtype": "FISH,ALL",
     ///                                        "mainItemData": null,
     ///                                        "itemsInThisBelongToPlayer": true,
     ///                                        "canAddItemsInQuestMode": false,
     ///                                        "hasUnderlay": false,
     ///                                        "columns": 6,
     ///                                        "rows": 6
     ///                                    },
     ///                                    "gridKey": "TRAWL_NET",
     ///                                    "harvestableTypes": [
     ///                                        "MANGROVE",
     ///                                        "SHALLOW"
     ///                                    ],
     ///                                    "isAdvancedEquipment": false,
     ///                                    "aberrationBonus": 0.0,
     ///                                    "canBeSoldByPlayer": true,
     ///                                    "canBeSoldInBulkAction": true,
     ///                                    "value": 350.0,
     ///                                    "hasSellOverride": false,
     ///                                    "sellOverrideValue": 0.0,
     ///                                    "sprite": {
     ///
     ///                                    },
     ///                                    "platformSpecificSpriteOverrides": null,
     ///                                    "itemColor": {
     ///                                        "r": 0.1921569,
     ///                                        "g": 0.1921569,
     ///                                        "b": 0.1921569,
     ///                                        "a": 255.0
     ///                                    },
     ///                                    "hasSpecialDiscardAction": false,
     ///                                    "discardPromptOverride": "",
     ///                                    "canBeDiscardedByPlayer": true,
     ///                                    "showAlertOnDiscardHold": true,
     ///                                    "discardHoldTimeOverride": true,
     ///                                    "discardHoldTimeSec": 2.0,
     ///                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                    "damageMode": "DURABILITY",
     ///                                    "moveMode": "INSTALL",
     ///                                    "ignoreDamageWhenPlacing": true,
     ///                                    "isUnderlayItem": false,
     ///                                    "forbidStorageTray": false,
     ///                                    "dimensions": [
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        }
     ///                                    ],
     ///                                    "squishFactor": 0.0,
     ///                                    "itemOwnPrerequisites": [],
     ///                                    "researchPrerequisites": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "timeBetweenCatchRolls": 0.1,
     ///                                                "catchRate": 1.0,
     ///                                                "maxDurabilityDays": 2.0,
     ///                                                "gridConfig": {
     ///                                                    "cellGroupConfigs": [],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "FISH,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": false,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 5,
     ///                                                    "rows": 6
     ///                                                },
     ///                                                "gridKey": "TRAWL_NET",
     ///                                                "harvestableTypes": [
     ///                                                    "COASTAL"
     ///                                                ],
     ///                                                "isAdvancedEquipment": false,
     ///                                                "aberrationBonus": 0.0,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": true,
     ///                                                "value": 300.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "DURABILITY",
     ///                                                "moveMode": "INSTALL",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.0,
     ///                                                "itemOwnPrerequisites": [],
     ///                                                "researchPrerequisites": [],
     ///                                                "researchPointsRequired": 1,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "net2",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "NET,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$id": "2205"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "DeployableItemData",
     ///                                                "$id": "2192"
     ///                                            }
     ///                                        }
     ///                                    ],
     ///                                    "researchPointsRequired": 2,
     ///                                    "buyableWithoutResearch": false,
     ///                                    "researchIsForRecipe": false,
     ///                                    "useIntenseAberratedUIShader": false,
     ///                                    "id": "net3",
     ///                                    "itemNameKey": [],
     ///                                    "itemDescriptionKey": [],
     ///                                    "hasAdditionalNote": false,
     ///                                    "additionalNoteKey": [],
     ///                                    "itemInsaneTitleKey": [],
     ///                                    "itemInsaneDescriptionKey": [],
     ///                                    "linkedDialogueNode": "",
     ///                                    "dialogueNodeSpecificDescription": [],
     ///                                    "itemType": "EQUIPMENT,ALL",
     ///                                    "itemSubtype": "NET,ALL",
     ///                                    "tooltipTextColor": {
     ///                                        "r": 0.4901961,
     ///                                        "g": 0.3843137,
     ///                                        "b": 0.2666667,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "tooltipNotesColor": {
     ///                                        "r": 1.0,
     ///                                        "g": 1.0,
     ///                                        "b": 1.0,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "itemTypeIcon": {
     ///                                        "$ref": "2205"
     ///                                    },
     ///                                    "harvestParticlePrefab": null,
     ///                                    "overrideHarvestParticleDepth": false,
     ///                                    "harvestParticleDepthOffset": -3.0,
     ///                                    "flattenParticleShape": false,
     ///                                    "availableInDemo": false,
     ///                                    "entitlementsRequired": [
     ///                                        "NONE"
     ///                                    ],
     ///                                    "$type": "DeployableItemData"
     ///                                },
     ///                                {
     ///                                    "timeBetweenCatchRolls": 0.083,
     ///                                    "catchRate": 1.0,
     ///                                    "maxDurabilityDays": 2.0,
     ///                                    "gridConfig": {
     ///                                        "cellGroupConfigs": [],
     ///                                        "mainItemType": "GENERAL,ALL",
     ///                                        "mainItemSubtype": "FISH,ALL",
     ///                                        "mainItemData": null,
     ///                                        "itemsInThisBelongToPlayer": true,
     ///                                        "canAddItemsInQuestMode": false,
     ///                                        "hasUnderlay": false,
     ///                                        "columns": 6,
     ///                                        "rows": 6
     ///                                    },
     ///                                    "gridKey": "TRAWL_NET",
     ///                                    "harvestableTypes": [
     ///                                        "VOLCANIC",
     ///                                        "COASTAL"
     ///                                    ],
     ///                                    "isAdvancedEquipment": false,
     ///                                    "aberrationBonus": 0.0,
     ///                                    "canBeSoldByPlayer": true,
     ///                                    "canBeSoldInBulkAction": true,
     ///                                    "value": 350.0,
     ///                                    "hasSellOverride": false,
     ///                                    "sellOverrideValue": 0.0,
     ///                                    "sprite": {
     ///
     ///                                    },
     ///                                    "platformSpecificSpriteOverrides": null,
     ///                                    "itemColor": {
     ///                                        "r": 0.1921569,
     ///                                        "g": 0.1921569,
     ///                                        "b": 0.1921569,
     ///                                        "a": 255.0
     ///                                    },
     ///                                    "hasSpecialDiscardAction": false,
     ///                                    "discardPromptOverride": "",
     ///                                    "canBeDiscardedByPlayer": true,
     ///                                    "showAlertOnDiscardHold": true,
     ///                                    "discardHoldTimeOverride": true,
     ///                                    "discardHoldTimeSec": 2.0,
     ///                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                    "damageMode": "DURABILITY",
     ///                                    "moveMode": "INSTALL",
     ///                                    "ignoreDamageWhenPlacing": true,
     ///                                    "isUnderlayItem": false,
     ///                                    "forbidStorageTray": false,
     ///                                    "dimensions": [
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        }
     ///                                    ],
     ///                                    "squishFactor": 0.0,
     ///                                    "itemOwnPrerequisites": [],
     ///                                    "researchPrerequisites": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "$ref": "2192"
     ///                                            }
     ///                                        }
     ///                                    ],
     ///                                    "researchPointsRequired": 2,
     ///                                    "buyableWithoutResearch": false,
     ///                                    "researchIsForRecipe": false,
     ///                                    "useIntenseAberratedUIShader": false,
     ///                                    "id": "net4",
     ///                                    "itemNameKey": [],
     ///                                    "itemDescriptionKey": [],
     ///                                    "hasAdditionalNote": false,
     ///                                    "additionalNoteKey": [],
     ///                                    "itemInsaneTitleKey": [],
     ///                                    "itemInsaneDescriptionKey": [],
     ///                                    "linkedDialogueNode": "",
     ///                                    "dialogueNodeSpecificDescription": [],
     ///                                    "itemType": "EQUIPMENT,ALL",
     ///                                    "itemSubtype": "NET,ALL",
     ///                                    "tooltipTextColor": {
     ///                                        "r": 0.4901961,
     ///                                        "g": 0.3843137,
     ///                                        "b": 0.2666667,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "tooltipNotesColor": {
     ///                                        "r": 1.0,
     ///                                        "g": 1.0,
     ///                                        "b": 1.0,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "itemTypeIcon": {
     ///                                        "$ref": "2205"
     ///                                    },
     ///                                    "harvestParticlePrefab": null,
     ///                                    "overrideHarvestParticleDepth": false,
     ///                                    "harvestParticleDepthOffset": -3.0,
     ///                                    "flattenParticleShape": false,
     ///                                    "availableInDemo": false,
     ///                                    "entitlementsRequired": [
     ///                                        "NONE"
     ///                                    ],
     ///                                    "$type": "DeployableItemData"
     ///                                },
     ///                                {
     ///                                    "timeBetweenCatchRolls": 0.0555,
     ///                                    "catchRate": 1.0,
     ///                                    "maxDurabilityDays": 3.0,
     ///                                    "gridConfig": {
     ///                                        "cellGroupConfigs": [],
     ///                                        "mainItemType": "GENERAL,ALL",
     ///                                        "mainItemSubtype": "FISH,ALL",
     ///                                        "mainItemData": null,
     ///                                        "itemsInThisBelongToPlayer": true,
     ///                                        "canAddItemsInQuestMode": false,
     ///                                        "hasUnderlay": false,
     ///                                        "columns": 9,
     ///                                        "rows": 10
     ///                                    },
     ///                                    "gridKey": "TRAWL_NET",
     ///                                    "harvestableTypes": [
     ///                                        "COASTAL",
     ///                                        "OCEANIC"
     ///                                    ],
     ///                                    "isAdvancedEquipment": false,
     ///                                    "aberrationBonus": 0.0,
     ///                                    "canBeSoldByPlayer": true,
     ///                                    "canBeSoldInBulkAction": true,
     ///                                    "value": 800.0,
     ///                                    "hasSellOverride": false,
     ///                                    "sellOverrideValue": 0.0,
     ///                                    "sprite": {
     ///
     ///                                    },
     ///                                    "platformSpecificSpriteOverrides": null,
     ///                                    "itemColor": {
     ///                                        "r": 0.1921569,
     ///                                        "g": 0.1921569,
     ///                                        "b": 0.1921569,
     ///                                        "a": 255.0
     ///                                    },
     ///                                    "hasSpecialDiscardAction": false,
     ///                                    "discardPromptOverride": "",
     ///                                    "canBeDiscardedByPlayer": true,
     ///                                    "showAlertOnDiscardHold": true,
     ///                                    "discardHoldTimeOverride": true,
     ///                                    "discardHoldTimeSec": 2.0,
     ///                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                    "damageMode": "DURABILITY",
     ///                                    "moveMode": "INSTALL",
     ///                                    "ignoreDamageWhenPlacing": true,
     ///                                    "isUnderlayItem": false,
     ///                                    "forbidStorageTray": false,
     ///                                    "dimensions": [
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        }
     ///                                    ],
     ///                                    "squishFactor": 0.0,
     ///                                    "itemOwnPrerequisites": [],
     ///                                    "researchPrerequisites": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "timeBetweenCatchRolls": 0.083,
     ///                                                "catchRate": 1.0,
     ///                                                "maxDurabilityDays": 3.0,
     ///                                                "gridConfig": {
     ///                                                    "cellGroupConfigs": [],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "FISH,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": false,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 8,
     ///                                                    "rows": 8
     ///                                                },
     ///                                                "gridKey": "TRAWL_NET",
     ///                                                "harvestableTypes": [
     ///                                                    "COASTAL",
     ///                                                    "SHALLOW"
     ///                                                ],
     ///                                                "isAdvancedEquipment": false,
     ///                                                "aberrationBonus": 0.0,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": true,
     ///                                                "value": 400.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "DURABILITY",
     ///                                                "moveMode": "INSTALL",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.0,
     ///                                                "itemOwnPrerequisites": [],
     ///                                                "researchPrerequisites": [
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "$ref": "2192"
     ///                                                        }
     ///                                                    }
     ///                                                ],
     ///                                                "researchPointsRequired": 3,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "net5",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "NET,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$ref": "2205"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "DeployableItemData"
     ///                                            }
     ///                                        }
     ///                                    ],
     ///                                    "researchPointsRequired": 4,
     ///                                    "buyableWithoutResearch": false,
     ///                                    "researchIsForRecipe": false,
     ///                                    "useIntenseAberratedUIShader": false,
     ///                                    "id": "net6",
     ///                                    "itemNameKey": [],
     ///                                    "itemDescriptionKey": [],
     ///                                    "hasAdditionalNote": false,
     ///                                    "additionalNoteKey": [],
     ///                                    "itemInsaneTitleKey": [],
     ///                                    "itemInsaneDescriptionKey": [],
     ///                                    "linkedDialogueNode": "",
     ///                                    "dialogueNodeSpecificDescription": [],
     ///                                    "itemType": "EQUIPMENT,ALL",
     ///                                    "itemSubtype": "NET,ALL",
     ///                                    "tooltipTextColor": {
     ///                                        "r": 0.4901961,
     ///                                        "g": 0.3843137,
     ///                                        "b": 0.2666667,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "tooltipNotesColor": {
     ///                                        "r": 1.0,
     ///                                        "g": 1.0,
     ///                                        "b": 1.0,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "itemTypeIcon": {
     ///                                        "$ref": "2205"
     ///                                    },
     ///                                    "harvestParticlePrefab": null,
     ///                                    "overrideHarvestParticleDepth": false,
     ///                                    "harvestParticleDepthOffset": -3.0,
     ///                                    "flattenParticleShape": false,
     ///                                    "availableInDemo": false,
     ///                                    "entitlementsRequired": [
     ///                                        "NONE"
     ///                                    ],
     ///                                    "$type": "DeployableItemData"
     ///                                }
     ///                            ],
     ///                            "$type": "ResearchCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "RESEARCH_POTS",
     ///                    "steamId": "RESEARCH_POTS",
     ///                    "playStationId": 25,
     ///                    "xboxId": "25",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "items": [
     ///                                {
     ///                                    "timeBetweenCatchRolls": 0.33,
     ///                                    "catchRate": 1.0,
     ///                                    "maxDurabilityDays": 8.0,
     ///                                    "gridConfig": {
     ///                                        "cellGroupConfigs": [],
     ///                                        "mainItemType": "GENERAL,ALL",
     ///                                        "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                        "mainItemData": null,
     ///                                        "itemsInThisBelongToPlayer": true,
     ///                                        "canAddItemsInQuestMode": false,
     ///                                        "hasUnderlay": false,
     ///                                        "columns": 6,
     ///                                        "rows": 5
     ///                                    },
     ///                                    "gridKey": "NONE",
     ///                                    "harvestableTypes": [],
     ///                                    "isAdvancedEquipment": false,
     ///                                    "aberrationBonus": 0.08,
     ///                                    "canBeSoldByPlayer": true,
     ///                                    "canBeSoldInBulkAction": true,
     ///                                    "value": 300.0,
     ///                                    "hasSellOverride": false,
     ///                                    "sellOverrideValue": 0.0,
     ///                                    "sprite": {
     ///
     ///                                    },
     ///                                    "platformSpecificSpriteOverrides": null,
     ///                                    "itemColor": {
     ///                                        "r": 0.1921569,
     ///                                        "g": 0.1921569,
     ///                                        "b": 0.1921569,
     ///                                        "a": 255.0
     ///                                    },
     ///                                    "hasSpecialDiscardAction": false,
     ///                                    "discardPromptOverride": "",
     ///                                    "canBeDiscardedByPlayer": true,
     ///                                    "showAlertOnDiscardHold": true,
     ///                                    "discardHoldTimeOverride": true,
     ///                                    "discardHoldTimeSec": 2.0,
     ///                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                    "damageMode": "DURABILITY",
     ///                                    "moveMode": "FREE",
     ///                                    "ignoreDamageWhenPlacing": true,
     ///                                    "isUnderlayItem": false,
     ///                                    "forbidStorageTray": false,
     ///                                    "dimensions": [
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        }
     ///                                    ],
     ///                                    "squishFactor": 0.0,
     ///                                    "itemOwnPrerequisites": [],
     ///                                    "researchPrerequisites": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "timeBetweenCatchRolls": 0.33,
     ///                                                "catchRate": 1.0,
     ///                                                "maxDurabilityDays": 6.0,
     ///                                                "gridConfig": {
     ///                                                    "cellGroupConfigs": [],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": false,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 5,
     ///                                                    "rows": 4
     ///                                                },
     ///                                                "gridKey": "NONE",
     ///                                                "harvestableTypes": [],
     ///                                                "isAdvancedEquipment": false,
     ///                                                "aberrationBonus": 0.04,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": true,
     ///                                                "value": 225.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "DURABILITY",
     ///                                                "moveMode": "FREE",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.0,
     ///                                                "itemOwnPrerequisites": [],
     ///                                                "researchPrerequisites": [
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "timeBetweenCatchRolls": 0.35,
     ///                                                            "catchRate": 1.0,
     ///                                                            "maxDurabilityDays": 3.0,
     ///                                                            "gridConfig": {
     ///                                                                "cellGroupConfigs": [],
     ///                                                                "mainItemType": "GENERAL,ALL",
     ///                                                                "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                                                "mainItemData": null,
     ///                                                                "itemsInThisBelongToPlayer": true,
     ///                                                                "canAddItemsInQuestMode": false,
     ///                                                                "hasUnderlay": false,
     ///                                                                "columns": 4,
     ///                                                                "rows": 4
     ///                                                            },
     ///                                                            "gridKey": "NONE",
     ///                                                            "harvestableTypes": [],
     ///                                                            "isAdvancedEquipment": false,
     ///                                                            "aberrationBonus": 0.02,
     ///                                                            "canBeSoldByPlayer": true,
     ///                                                            "canBeSoldInBulkAction": true,
     ///                                                            "value": 150.0,
     ///                                                            "hasSellOverride": false,
     ///                                                            "sellOverrideValue": 0.0,
     ///                                                            "sprite": {
     ///
     ///                                                            },
     ///                                                            "platformSpecificSpriteOverrides": null,
     ///                                                            "itemColor": {
     ///                                                                "r": 0.1921569,
     ///                                                                "g": 0.1921569,
     ///                                                                "b": 0.1921569,
     ///                                                                "a": 255.0
     ///                                                            },
     ///                                                            "hasSpecialDiscardAction": false,
     ///                                                            "discardPromptOverride": "",
     ///                                                            "canBeDiscardedByPlayer": true,
     ///                                                            "showAlertOnDiscardHold": true,
     ///                                                            "discardHoldTimeOverride": true,
     ///                                                            "discardHoldTimeSec": 2.0,
     ///                                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                                            "damageMode": "DURABILITY",
     ///                                                            "moveMode": "FREE",
     ///                                                            "ignoreDamageWhenPlacing": true,
     ///                                                            "isUnderlayItem": false,
     ///                                                            "forbidStorageTray": false,
     ///                                                            "dimensions": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "squishFactor": 0.0,
     ///                                                            "itemOwnPrerequisites": [],
     ///                                                            "researchPrerequisites": [],
     ///                                                            "researchPointsRequired": 1,
     ///                                                            "buyableWithoutResearch": false,
     ///                                                            "researchIsForRecipe": false,
     ///                                                            "useIntenseAberratedUIShader": false,
     ///                                                            "id": "pot2",
     ///                                                            "itemNameKey": [],
     ///                                                            "itemDescriptionKey": [],
     ///                                                            "hasAdditionalNote": false,
     ///                                                            "additionalNoteKey": [],
     ///                                                            "itemInsaneTitleKey": [],
     ///                                                            "itemInsaneDescriptionKey": [],
     ///                                                            "linkedDialogueNode": "",
     ///                                                            "dialogueNodeSpecificDescription": [],
     ///                                                            "itemType": "EQUIPMENT,ALL",
     ///                                                            "itemSubtype": "POT,ALL",
     ///                                                            "tooltipTextColor": {
     ///                                                                "r": 0.4901961,
     ///                                                                "g": 0.3843137,
     ///                                                                "b": 0.2666667,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "tooltipNotesColor": {
     ///                                                                "r": 1.0,
     ///                                                                "g": 1.0,
     ///                                                                "b": 1.0,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "itemTypeIcon": {
     ///                                                                "$id": "2292"
     ///                                                            },
     ///                                                            "harvestParticlePrefab": null,
     ///                                                            "overrideHarvestParticleDepth": false,
     ///                                                            "harvestParticleDepthOffset": -3.0,
     ///                                                            "flattenParticleShape": false,
     ///                                                            "availableInDemo": false,
     ///                                                            "entitlementsRequired": [
     ///                                                                "NONE"
     ///                                                            ],
     ///                                                            "$type": "DeployableItemData"
     ///                                                        }
     ///                                                    },
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "timeBetweenCatchRolls": 0.5,
     ///                                                            "catchRate": 1.0,
     ///                                                            "maxDurabilityDays": 5.0,
     ///                                                            "gridConfig": {
     ///                                                                "cellGroupConfigs": [],
     ///                                                                "mainItemType": "GENERAL,ALL",
     ///                                                                "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                                                "mainItemData": null,
     ///                                                                "itemsInThisBelongToPlayer": true,
     ///                                                                "canAddItemsInQuestMode": false,
     ///                                                                "hasUnderlay": false,
     ///                                                                "columns": 4,
     ///                                                                "rows": 4
     ///                                                            },
     ///                                                            "gridKey": "NONE",
     ///                                                            "harvestableTypes": [],
     ///                                                            "isAdvancedEquipment": false,
     ///                                                            "aberrationBonus": 0.02,
     ///                                                            "canBeSoldByPlayer": true,
     ///                                                            "canBeSoldInBulkAction": true,
     ///                                                            "value": 150.0,
     ///                                                            "hasSellOverride": false,
     ///                                                            "sellOverrideValue": 0.0,
     ///                                                            "sprite": {
     ///
     ///                                                            },
     ///                                                            "platformSpecificSpriteOverrides": null,
     ///                                                            "itemColor": {
     ///                                                                "r": 0.1921569,
     ///                                                                "g": 0.1921569,
     ///                                                                "b": 0.1921569,
     ///                                                                "a": 255.0
     ///                                                            },
     ///                                                            "hasSpecialDiscardAction": false,
     ///                                                            "discardPromptOverride": "",
     ///                                                            "canBeDiscardedByPlayer": true,
     ///                                                            "showAlertOnDiscardHold": true,
     ///                                                            "discardHoldTimeOverride": true,
     ///                                                            "discardHoldTimeSec": 2.0,
     ///                                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                                            "damageMode": "DURABILITY",
     ///                                                            "moveMode": "FREE",
     ///                                                            "ignoreDamageWhenPlacing": true,
     ///                                                            "isUnderlayItem": false,
     ///                                                            "forbidStorageTray": false,
     ///                                                            "dimensions": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "squishFactor": 0.0,
     ///                                                            "itemOwnPrerequisites": [],
     ///                                                            "researchPrerequisites": [],
     ///                                                            "researchPointsRequired": 1,
     ///                                                            "buyableWithoutResearch": false,
     ///                                                            "researchIsForRecipe": false,
     ///                                                            "useIntenseAberratedUIShader": false,
     ///                                                            "id": "pot3",
     ///                                                            "itemNameKey": [],
     ///                                                            "itemDescriptionKey": [],
     ///                                                            "hasAdditionalNote": false,
     ///                                                            "additionalNoteKey": [],
     ///                                                            "itemInsaneTitleKey": [],
     ///                                                            "itemInsaneDescriptionKey": [],
     ///                                                            "linkedDialogueNode": "",
     ///                                                            "dialogueNodeSpecificDescription": [],
     ///                                                            "itemType": "EQUIPMENT,ALL",
     ///                                                            "itemSubtype": "POT,ALL",
     ///                                                            "tooltipTextColor": {
     ///                                                                "r": 0.4901961,
     ///                                                                "g": 0.3843137,
     ///                                                                "b": 0.2666667,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "tooltipNotesColor": {
     ///                                                                "r": 1.0,
     ///                                                                "g": 1.0,
     ///                                                                "b": 1.0,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "itemTypeIcon": {
     ///                                                                "$ref": "2292"
     ///                                                            },
     ///                                                            "harvestParticlePrefab": null,
     ///                                                            "overrideHarvestParticleDepth": false,
     ///                                                            "harvestParticleDepthOffset": -3.0,
     ///                                                            "flattenParticleShape": false,
     ///                                                            "availableInDemo": false,
     ///                                                            "entitlementsRequired": [
     ///                                                                "NONE"
     ///                                                            ],
     ///                                                            "$type": "DeployableItemData",
     ///                                                            "$id": "2295"
     ///                                                        }
     ///                                                    }
     ///                                                ],
     ///                                                "researchPointsRequired": 2,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "pot5",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "POT,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$ref": "2292"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "DeployableItemData"
     ///                                            }
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "timeBetweenCatchRolls": 0.4,
     ///                                                "catchRate": 1.0,
     ///                                                "maxDurabilityDays": 6.0,
     ///                                                "gridConfig": {
     ///                                                    "cellGroupConfigs": [],
     ///                                                    "mainItemType": "GENERAL,ALL",
     ///                                                    "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                                    "mainItemData": null,
     ///                                                    "itemsInThisBelongToPlayer": true,
     ///                                                    "canAddItemsInQuestMode": false,
     ///                                                    "hasUnderlay": false,
     ///                                                    "columns": 5,
     ///                                                    "rows": 5
     ///                                                },
     ///                                                "gridKey": "NONE",
     ///                                                "harvestableTypes": [],
     ///                                                "isAdvancedEquipment": false,
     ///                                                "aberrationBonus": 0.04,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": true,
     ///                                                "value": 225.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "DURABILITY",
     ///                                                "moveMode": "FREE",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.0,
     ///                                                "itemOwnPrerequisites": [],
     ///                                                "researchPrerequisites": [
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "$ref": "2295"
     ///                                                        }
     ///                                                    },
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "timeBetweenCatchRolls": 0.5,
     ///                                                            "catchRate": 1.0,
     ///                                                            "maxDurabilityDays": 3.0,
     ///                                                            "gridConfig": {
     ///                                                                "cellGroupConfigs": [],
     ///                                                                "mainItemType": "GENERAL,ALL",
     ///                                                                "mainItemSubtype": "FISH,GENERAL,ALL",
     ///                                                                "mainItemData": null,
     ///                                                                "itemsInThisBelongToPlayer": true,
     ///                                                                "canAddItemsInQuestMode": false,
     ///                                                                "hasUnderlay": false,
     ///                                                                "columns": 5,
     ///                                                                "rows": 4
     ///                                                            },
     ///                                                            "gridKey": "NONE",
     ///                                                            "harvestableTypes": [],
     ///                                                            "isAdvancedEquipment": false,
     ///                                                            "aberrationBonus": 0.02,
     ///                                                            "canBeSoldByPlayer": true,
     ///                                                            "canBeSoldInBulkAction": true,
     ///                                                            "value": 150.0,
     ///                                                            "hasSellOverride": false,
     ///                                                            "sellOverrideValue": 0.0,
     ///                                                            "sprite": {
     ///
     ///                                                            },
     ///                                                            "platformSpecificSpriteOverrides": null,
     ///                                                            "itemColor": {
     ///                                                                "r": 0.1921569,
     ///                                                                "g": 0.1921569,
     ///                                                                "b": 0.1921569,
     ///                                                                "a": 255.0
     ///                                                            },
     ///                                                            "hasSpecialDiscardAction": false,
     ///                                                            "discardPromptOverride": "",
     ///                                                            "canBeDiscardedByPlayer": true,
     ///                                                            "showAlertOnDiscardHold": true,
     ///                                                            "discardHoldTimeOverride": true,
     ///                                                            "discardHoldTimeSec": 2.0,
     ///                                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                                            "damageMode": "DURABILITY",
     ///                                                            "moveMode": "FREE",
     ///                                                            "ignoreDamageWhenPlacing": true,
     ///                                                            "isUnderlayItem": false,
     ///                                                            "forbidStorageTray": false,
     ///                                                            "dimensions": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "squishFactor": 0.0,
     ///                                                            "itemOwnPrerequisites": [],
     ///                                                            "researchPrerequisites": [],
     ///                                                            "researchPointsRequired": 1,
     ///                                                            "buyableWithoutResearch": false,
     ///                                                            "researchIsForRecipe": false,
     ///                                                            "useIntenseAberratedUIShader": false,
     ///                                                            "id": "pot4",
     ///                                                            "itemNameKey": [],
     ///                                                            "itemDescriptionKey": [],
     ///                                                            "hasAdditionalNote": false,
     ///                                                            "additionalNoteKey": [],
     ///                                                            "itemInsaneTitleKey": [],
     ///                                                            "itemInsaneDescriptionKey": [],
     ///                                                            "linkedDialogueNode": "",
     ///                                                            "dialogueNodeSpecificDescription": [],
     ///                                                            "itemType": "EQUIPMENT,ALL",
     ///                                                            "itemSubtype": "POT,ALL",
     ///                                                            "tooltipTextColor": {
     ///                                                                "r": 0.4901961,
     ///                                                                "g": 0.3843137,
     ///                                                                "b": 0.2666667,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "tooltipNotesColor": {
     ///                                                                "r": 1.0,
     ///                                                                "g": 1.0,
     ///                                                                "b": 1.0,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "itemTypeIcon": {
     ///                                                                "$ref": "2292"
     ///                                                            },
     ///                                                            "harvestParticlePrefab": null,
     ///                                                            "overrideHarvestParticleDepth": false,
     ///                                                            "harvestParticleDepthOffset": -3.0,
     ///                                                            "flattenParticleShape": false,
     ///                                                            "availableInDemo": false,
     ///                                                            "entitlementsRequired": [
     ///                                                                "NONE"
     ///                                                            ],
     ///                                                            "$type": "DeployableItemData"
     ///                                                        }
     ///                                                    }
     ///                                                ],
     ///                                                "researchPointsRequired": 2,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "pot6",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "POT,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$ref": "2292"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "DeployableItemData"
     ///                                            }
     ///                                        }
     ///                                    ],
     ///                                    "researchPointsRequired": 3,
     ///                                    "buyableWithoutResearch": false,
     ///                                    "researchIsForRecipe": false,
     ///                                    "useIntenseAberratedUIShader": false,
     ///                                    "id": "pot7",
     ///                                    "itemNameKey": [],
     ///                                    "itemDescriptionKey": [],
     ///                                    "hasAdditionalNote": false,
     ///                                    "additionalNoteKey": [],
     ///                                    "itemInsaneTitleKey": [],
     ///                                    "itemInsaneDescriptionKey": [],
     ///                                    "linkedDialogueNode": "",
     ///                                    "dialogueNodeSpecificDescription": [],
     ///                                    "itemType": "EQUIPMENT,ALL",
     ///                                    "itemSubtype": "POT,ALL",
     ///                                    "tooltipTextColor": {
     ///                                        "r": 0.4901961,
     ///                                        "g": 0.3843137,
     ///                                        "b": 0.2666667,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "tooltipNotesColor": {
     ///                                        "r": 1.0,
     ///                                        "g": 1.0,
     ///                                        "b": 1.0,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "itemTypeIcon": {
     ///                                        "$ref": "2292"
     ///                                    },
     ///                                    "harvestParticlePrefab": null,
     ///                                    "overrideHarvestParticleDepth": false,
     ///                                    "harvestParticleDepthOffset": -3.0,
     ///                                    "flattenParticleShape": false,
     ///                                    "availableInDemo": false,
     ///                                    "entitlementsRequired": [
     ///                                        "NONE"
     ///                                    ],
     ///                                    "$type": "DeployableItemData"
     ///                                }
     ///                            ],
     ///                            "$type": "ResearchCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "RESEARCH_RODS",
     ///                    "steamId": "RESEARCH_RODS",
     ///                    "playStationId": 23,
     ///                    "xboxId": "23",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "items": [
     ///                                {
     ///                                    "fishingSpeedModifier": 0.75,
     ///                                    "harvestableTypes": [
     ///                                        "ABYSSAL",
     ///                                        "HADAL",
     ///                                        "OCEANIC"
     ///                                    ],
     ///                                    "isAdvancedEquipment": false,
     ///                                    "aberrationBonus": 0.0,
     ///                                    "canBeSoldByPlayer": true,
     ///                                    "canBeSoldInBulkAction": false,
     ///                                    "value": 750.0,
     ///                                    "hasSellOverride": false,
     ///                                    "sellOverrideValue": 0.0,
     ///                                    "sprite": {
     ///
     ///                                    },
     ///                                    "platformSpecificSpriteOverrides": null,
     ///                                    "itemColor": {
     ///                                        "r": 0.1921569,
     ///                                        "g": 0.1921569,
     ///                                        "b": 0.1921569,
     ///                                        "a": 255.0
     ///                                    },
     ///                                    "hasSpecialDiscardAction": false,
     ///                                    "discardPromptOverride": "",
     ///                                    "canBeDiscardedByPlayer": true,
     ///                                    "showAlertOnDiscardHold": true,
     ///                                    "discardHoldTimeOverride": true,
     ///                                    "discardHoldTimeSec": 2.0,
     ///                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                    "damageMode": "OPERATION",
     ///                                    "moveMode": "INSTALL",
     ///                                    "ignoreDamageWhenPlacing": true,
     ///                                    "isUnderlayItem": false,
     ///                                    "forbidStorageTray": false,
     ///                                    "dimensions": [
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        }
     ///                                    ],
     ///                                    "squishFactor": 0.1,
     ///                                    "itemOwnPrerequisites": [],
     ///                                    "researchPrerequisites": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "fishingSpeedModifier": 0.35,
     ///                                                "harvestableTypes": [
     ///                                                    "ABYSSAL",
     ///                                                    "HADAL"
     ///                                                ],
     ///                                                "isAdvancedEquipment": false,
     ///                                                "aberrationBonus": 0.0,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": false,
     ///                                                "value": 450.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "OPERATION",
     ///                                                "moveMode": "INSTALL",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.1,
     ///                                                "itemOwnPrerequisites": [
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "fishingSpeedModifier": 0.1,
     ///                                                            "harvestableTypes": [
     ///                                                                "ABYSSAL"
     ///                                                            ],
     ///                                                            "isAdvancedEquipment": false,
     ///                                                            "aberrationBonus": 0.0,
     ///                                                            "canBeSoldByPlayer": false,
     ///                                                            "canBeSoldInBulkAction": true,
     ///                                                            "value": 0.0,
     ///                                                            "hasSellOverride": false,
     ///                                                            "sellOverrideValue": 0.0,
     ///                                                            "sprite": {
     ///
     ///                                                            },
     ///                                                            "platformSpecificSpriteOverrides": null,
     ///                                                            "itemColor": {
     ///                                                                "r": 0.1921569,
     ///                                                                "g": 0.1921569,
     ///                                                                "b": 0.1921569,
     ///                                                                "a": 255.0
     ///                                                            },
     ///                                                            "hasSpecialDiscardAction": false,
     ///                                                            "discardPromptOverride": "",
     ///                                                            "canBeDiscardedByPlayer": true,
     ///                                                            "showAlertOnDiscardHold": true,
     ///                                                            "discardHoldTimeOverride": true,
     ///                                                            "discardHoldTimeSec": 2.0,
     ///                                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                                            "damageMode": "OPERATION",
     ///                                                            "moveMode": "INSTALL",
     ///                                                            "ignoreDamageWhenPlacing": true,
     ///                                                            "isUnderlayItem": false,
     ///                                                            "forbidStorageTray": false,
     ///                                                            "dimensions": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "squishFactor": 0.1,
     ///                                                            "itemOwnPrerequisites": [],
     ///                                                            "researchPrerequisites": [],
     ///                                                            "researchPointsRequired": 0,
     ///                                                            "buyableWithoutResearch": false,
     ///                                                            "researchIsForRecipe": false,
     ///                                                            "useIntenseAberratedUIShader": false,
     ///                                                            "id": "rod5",
     ///                                                            "itemNameKey": [],
     ///                                                            "itemDescriptionKey": [],
     ///                                                            "hasAdditionalNote": false,
     ///                                                            "additionalNoteKey": [],
     ///                                                            "itemInsaneTitleKey": [],
     ///                                                            "itemInsaneDescriptionKey": [],
     ///                                                            "linkedDialogueNode": "",
     ///                                                            "dialogueNodeSpecificDescription": [],
     ///                                                            "itemType": "EQUIPMENT,ALL",
     ///                                                            "itemSubtype": "ROD,ALL",
     ///                                                            "tooltipTextColor": {
     ///                                                                "r": 0.4901961,
     ///                                                                "g": 0.3843137,
     ///                                                                "b": 0.2666667,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "tooltipNotesColor": {
     ///                                                                "r": 1.0,
     ///                                                                "g": 1.0,
     ///                                                                "b": 1.0,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "itemTypeIcon": {
     ///                                                                "$id": "2380"
     ///                                                            },
     ///                                                            "harvestParticlePrefab": null,
     ///                                                            "overrideHarvestParticleDepth": false,
     ///                                                            "harvestParticleDepthOffset": -3.0,
     ///                                                            "flattenParticleShape": false,
     ///                                                            "availableInDemo": false,
     ///                                                            "entitlementsRequired": [
     ///                                                                "NONE"
     ///                                                            ],
     ///                                                            "$type": "RodItemData"
     ///                                                        }
     ///                                                    }
     ///                                                ],
     ///                                                "researchPrerequisites": [],
     ///                                                "researchPointsRequired": 1,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "rod6",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "ROD,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$ref": "2380"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "RodItemData"
     ///                                            }
     ///                                        }
     ///                                    ],
     ///                                    "researchPointsRequired": 3,
     ///                                    "buyableWithoutResearch": false,
     ///                                    "researchIsForRecipe": false,
     ///                                    "useIntenseAberratedUIShader": false,
     ///                                    "id": "rod11",
     ///                                    "itemNameKey": [],
     ///                                    "itemDescriptionKey": [],
     ///                                    "hasAdditionalNote": false,
     ///                                    "additionalNoteKey": [],
     ///                                    "itemInsaneTitleKey": [],
     ///                                    "itemInsaneDescriptionKey": [],
     ///                                    "linkedDialogueNode": "",
     ///                                    "dialogueNodeSpecificDescription": [],
     ///                                    "itemType": "EQUIPMENT,ALL",
     ///                                    "itemSubtype": "ROD,ALL",
     ///                                    "tooltipTextColor": {
     ///                                        "r": 0.4901961,
     ///                                        "g": 0.3843137,
     ///                                        "b": 0.2666667,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "tooltipNotesColor": {
     ///                                        "r": 1.0,
     ///                                        "g": 1.0,
     ///                                        "b": 1.0,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "itemTypeIcon": {
     ///                                        "$ref": "2380"
     ///                                    },
     ///                                    "harvestParticlePrefab": null,
     ///                                    "overrideHarvestParticleDepth": false,
     ///                                    "harvestParticleDepthOffset": -3.0,
     ///                                    "flattenParticleShape": false,
     ///                                    "availableInDemo": false,
     ///                                    "entitlementsRequired": [
     ///                                        "NONE"
     ///                                    ],
     ///                                    "$type": "RodItemData"
     ///                                },
     ///                                {
     ///                                    "fishingSpeedModifier": 1.2,
     ///                                    "harvestableTypes": [
     ///                                        "COASTAL",
     ///                                        "SHALLOW",
     ///                                        "OCEANIC"
     ///                                    ],
     ///                                    "isAdvancedEquipment": false,
     ///                                    "aberrationBonus": 0.0,
     ///                                    "canBeSoldByPlayer": true,
     ///                                    "canBeSoldInBulkAction": false,
     ///                                    "value": 800.0,
     ///                                    "hasSellOverride": false,
     ///                                    "sellOverrideValue": 0.0,
     ///                                    "sprite": {
     ///
     ///                                    },
     ///                                    "platformSpecificSpriteOverrides": null,
     ///                                    "itemColor": {
     ///                                        "r": 0.1921569,
     ///                                        "g": 0.1921569,
     ///                                        "b": 0.1921569,
     ///                                        "a": 255.0
     ///                                    },
     ///                                    "hasSpecialDiscardAction": false,
     ///                                    "discardPromptOverride": "",
     ///                                    "canBeDiscardedByPlayer": true,
     ///                                    "showAlertOnDiscardHold": true,
     ///                                    "discardHoldTimeOverride": true,
     ///                                    "discardHoldTimeSec": 2.0,
     ///                                    "canBeDiscardedDuringQuestPickup": true,
     ///                                    "damageMode": "OPERATION",
     ///                                    "moveMode": "INSTALL",
     ///                                    "ignoreDamageWhenPlacing": true,
     ///                                    "isUnderlayItem": false,
     ///                                    "forbidStorageTray": false,
     ///                                    "dimensions": [
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        },
     ///                                        {
     ///
     ///                                        }
     ///                                    ],
     ///                                    "squishFactor": 0.1,
     ///                                    "itemOwnPrerequisites": [],
     ///                                    "researchPrerequisites": [
     ///                                        {
     ///                                            "itemData": {
     ///                                                "fishingSpeedModifier": 0.5,
     ///                                                "harvestableTypes": [
     ///                                                    "OCEANIC"
     ///                                                ],
     ///                                                "isAdvancedEquipment": false,
     ///                                                "aberrationBonus": 0.0,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": false,
     ///                                                "value": 410.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "OPERATION",
     ///                                                "moveMode": "INSTALL",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.0,
     ///                                                "itemOwnPrerequisites": [],
     ///                                                "researchPrerequisites": [],
     ///                                                "researchPointsRequired": 1,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "rod3",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "ROD,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$ref": "2380"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "RodItemData"
     ///                                            }
     ///                                        },
     ///                                        {
     ///                                            "itemData": {
     ///                                                "fishingSpeedModifier": 0.75,
     ///                                                "harvestableTypes": [
     ///                                                    "COASTAL",
     ///                                                    "SHALLOW",
     ///                                                    "MANGROVE",
     ///                                                    "VOLCANIC"
     ///                                                ],
     ///                                                "isAdvancedEquipment": false,
     ///                                                "aberrationBonus": 0.0,
     ///                                                "canBeSoldByPlayer": true,
     ///                                                "canBeSoldInBulkAction": false,
     ///                                                "value": 600.0,
     ///                                                "hasSellOverride": false,
     ///                                                "sellOverrideValue": 0.0,
     ///                                                "sprite": {
     ///
     ///                                                },
     ///                                                "platformSpecificSpriteOverrides": null,
     ///                                                "itemColor": {
     ///                                                    "r": 0.1921569,
     ///                                                    "g": 0.1921569,
     ///                                                    "b": 0.1921569,
     ///                                                    "a": 255.0
     ///                                                },
     ///                                                "hasSpecialDiscardAction": false,
     ///                                                "discardPromptOverride": "",
     ///                                                "canBeDiscardedByPlayer": true,
     ///                                                "showAlertOnDiscardHold": true,
     ///                                                "discardHoldTimeOverride": true,
     ///                                                "discardHoldTimeSec": 2.0,
     ///                                                "canBeDiscardedDuringQuestPickup": true,
     ///                                                "damageMode": "OPERATION",
     ///                                                "moveMode": "INSTALL",
     ///                                                "ignoreDamageWhenPlacing": true,
     ///                                                "isUnderlayItem": false,
     ///                                                "forbidStorageTray": false,
     ///                                                "dimensions": [
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    },
     ///                                                    {
     ///
     ///                                                    }
     ///                                                ],
     ///                                                "squishFactor": 0.1,
     ///                                                "itemOwnPrerequisites": [],
     ///                                                "researchPrerequisites": [
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "fishingSpeedModifier": 0.5,
     ///                                                            "harvestableTypes": [
     ///                                                                "VOLCANIC",
     ///                                                                "SHALLOW"
     ///                                                            ],
     ///                                                            "isAdvancedEquipment": false,
     ///                                                            "aberrationBonus": 0.0,
     ///                                                            "canBeSoldByPlayer": true,
     ///                                                            "canBeSoldInBulkAction": false,
     ///                                                            "value": 330.0,
     ///                                                            "hasSellOverride": false,
     ///                                                            "sellOverrideValue": 0.0,
     ///                                                            "sprite": {
     ///
     ///                                                            },
     ///                                                            "platformSpecificSpriteOverrides": null,
     ///                                                            "itemColor": {
     ///                                                                "r": 0.1921569,
     ///                                                                "g": 0.1921569,
     ///                                                                "b": 0.1921569,
     ///                                                                "a": 255.0
     ///                                                            },
     ///                                                            "hasSpecialDiscardAction": false,
     ///                                                            "discardPromptOverride": "",
     ///                                                            "canBeDiscardedByPlayer": true,
     ///                                                            "showAlertOnDiscardHold": true,
     ///                                                            "discardHoldTimeOverride": true,
     ///                                                            "discardHoldTimeSec": 2.0,
     ///                                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                                            "damageMode": "OPERATION",
     ///                                                            "moveMode": "INSTALL",
     ///                                                            "ignoreDamageWhenPlacing": true,
     ///                                                            "isUnderlayItem": false,
     ///                                                            "forbidStorageTray": false,
     ///                                                            "dimensions": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "squishFactor": 0.1,
     ///                                                            "itemOwnPrerequisites": [],
     ///                                                            "researchPrerequisites": [
     ///                                                                {
     ///                                                                    "itemData": {
     ///                                                                        "fishingSpeedModifier": 0.45,
     ///                                                                        "harvestableTypes": [
     ///                                                                            "COASTAL",
     ///                                                                            "SHALLOW"
     ///                                                                        ],
     ///                                                                        "isAdvancedEquipment": false,
     ///                                                                        "aberrationBonus": 0.0,
     ///                                                                        "canBeSoldByPlayer": true,
     ///                                                                        "canBeSoldInBulkAction": false,
     ///                                                                        "value": 460.0,
     ///                                                                        "hasSellOverride": false,
     ///                                                                        "sellOverrideValue": 0.0,
     ///                                                                        "sprite": {
     ///
     ///                                                                        },
     ///                                                                        "platformSpecificSpriteOverrides": null,
     ///                                                                        "itemColor": {
     ///                                                                            "r": 0.1921569,
     ///                                                                            "g": 0.1921569,
     ///                                                                            "b": 0.1921569,
     ///                                                                            "a": 255.0
     ///                                                                        },
     ///                                                                        "hasSpecialDiscardAction": false,
     ///                                                                        "discardPromptOverride": "",
     ///                                                                        "canBeDiscardedByPlayer": true,
     ///                                                                        "showAlertOnDiscardHold": true,
     ///                                                                        "discardHoldTimeOverride": true,
     ///                                                                        "discardHoldTimeSec": 2.0,
     ///                                                                        "canBeDiscardedDuringQuestPickup": true,
     ///                                                                        "damageMode": "OPERATION",
     ///                                                                        "moveMode": "INSTALL",
     ///                                                                        "ignoreDamageWhenPlacing": true,
     ///                                                                        "isUnderlayItem": false,
     ///                                                                        "forbidStorageTray": false,
     ///                                                                        "dimensions": [
     ///                                                                            {
     ///
     ///                                                                            },
     ///                                                                            {
     ///
     ///                                                                            },
     ///                                                                            {
     ///
     ///                                                                            }
     ///                                                                        ],
     ///                                                                        "squishFactor": 0.1,
     ///                                                                        "itemOwnPrerequisites": [],
     ///                                                                        "researchPrerequisites": [],
     ///                                                                        "researchPointsRequired": 2,
     ///                                                                        "buyableWithoutResearch": false,
     ///                                                                        "researchIsForRecipe": false,
     ///                                                                        "useIntenseAberratedUIShader": false,
     ///                                                                        "id": "rod4",
     ///                                                                        "itemNameKey": [],
     ///                                                                        "itemDescriptionKey": [],
     ///                                                                        "hasAdditionalNote": false,
     ///                                                                        "additionalNoteKey": [],
     ///                                                                        "itemInsaneTitleKey": [],
     ///                                                                        "itemInsaneDescriptionKey": [],
     ///                                                                        "linkedDialogueNode": "",
     ///                                                                        "dialogueNodeSpecificDescription": [],
     ///                                                                        "itemType": "EQUIPMENT,ALL",
     ///                                                                        "itemSubtype": "ROD,ALL",
     ///                                                                        "tooltipTextColor": {
     ///                                                                            "r": 0.4901961,
     ///                                                                            "g": 0.3843137,
     ///                                                                            "b": 0.2666667,
     ///                                                                            "a": 1.0
     ///                                                                        },
     ///                                                                        "tooltipNotesColor": {
     ///                                                                            "r": 1.0,
     ///                                                                            "g": 1.0,
     ///                                                                            "b": 1.0,
     ///                                                                            "a": 1.0
     ///                                                                        },
     ///                                                                        "itemTypeIcon": {
     ///                                                                            "$ref": "2380"
     ///                                                                        },
     ///                                                                        "harvestParticlePrefab": null,
     ///                                                                        "overrideHarvestParticleDepth": false,
     ///                                                                        "harvestParticleDepthOffset": -3.0,
     ///                                                                        "flattenParticleShape": false,
     ///                                                                        "availableInDemo": false,
     ///                                                                        "entitlementsRequired": [
     ///                                                                            "NONE"
     ///                                                                        ],
     ///                                                                        "$type": "RodItemData",
     ///                                                                        "$id": "2428"
     ///                                                                    }
     ///                                                                }
     ///                                                            ],
     ///                                                            "researchPointsRequired": 2,
     ///                                                            "buyableWithoutResearch": false,
     ///                                                            "researchIsForRecipe": false,
     ///                                                            "useIntenseAberratedUIShader": false,
     ///                                                            "id": "rod12",
     ///                                                            "itemNameKey": [],
     ///                                                            "itemDescriptionKey": [],
     ///                                                            "hasAdditionalNote": false,
     ///                                                            "additionalNoteKey": [],
     ///                                                            "itemInsaneTitleKey": [],
     ///                                                            "itemInsaneDescriptionKey": [],
     ///                                                            "linkedDialogueNode": "",
     ///                                                            "dialogueNodeSpecificDescription": [],
     ///                                                            "itemType": "EQUIPMENT,ALL",
     ///                                                            "itemSubtype": "ROD,ALL",
     ///                                                            "tooltipTextColor": {
     ///                                                                "r": 0.4901961,
     ///                                                                "g": 0.3843137,
     ///                                                                "b": 0.2666667,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "tooltipNotesColor": {
     ///                                                                "r": 1.0,
     ///                                                                "g": 1.0,
     ///                                                                "b": 1.0,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "itemTypeIcon": {
     ///                                                                "$ref": "2380"
     ///                                                            },
     ///                                                            "harvestParticlePrefab": null,
     ///                                                            "overrideHarvestParticleDepth": false,
     ///                                                            "harvestParticleDepthOffset": -3.0,
     ///                                                            "flattenParticleShape": false,
     ///                                                            "availableInDemo": false,
     ///                                                            "entitlementsRequired": [
     ///                                                                "NONE"
     ///                                                            ],
     ///                                                            "$type": "RodItemData"
     ///                                                        }
     ///                                                    },
     ///                                                    {
     ///                                                        "itemData": {
     ///                                                            "fishingSpeedModifier": 0.5,
     ///                                                            "harvestableTypes": [
     ///                                                                "MANGROVE",
     ///                                                                "COASTAL"
     ///                                                            ],
     ///                                                            "isAdvancedEquipment": false,
     ///                                                            "aberrationBonus": 0.0,
     ///                                                            "canBeSoldByPlayer": true,
     ///                                                            "canBeSoldInBulkAction": false,
     ///                                                            "value": 350.0,
     ///                                                            "hasSellOverride": false,
     ///                                                            "sellOverrideValue": 0.0,
     ///                                                            "sprite": {
     ///
     ///                                                            },
     ///                                                            "platformSpecificSpriteOverrides": null,
     ///                                                            "itemColor": {
     ///                                                                "r": 0.1921569,
     ///                                                                "g": 0.1921569,
     ///                                                                "b": 0.1921569,
     ///                                                                "a": 255.0
     ///                                                            },
     ///                                                            "hasSpecialDiscardAction": false,
     ///                                                            "discardPromptOverride": "",
     ///                                                            "canBeDiscardedByPlayer": true,
     ///                                                            "showAlertOnDiscardHold": true,
     ///                                                            "discardHoldTimeOverride": true,
     ///                                                            "discardHoldTimeSec": 2.0,
     ///                                                            "canBeDiscardedDuringQuestPickup": true,
     ///                                                            "damageMode": "OPERATION",
     ///                                                            "moveMode": "INSTALL",
     ///                                                            "ignoreDamageWhenPlacing": true,
     ///                                                            "isUnderlayItem": false,
     ///                                                            "forbidStorageTray": false,
     ///                                                            "dimensions": [
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                },
     ///                                                                {
     ///
     ///                                                                }
     ///                                                            ],
     ///                                                            "squishFactor": 0.1,
     ///                                                            "itemOwnPrerequisites": [],
     ///                                                            "researchPrerequisites": [
     ///                                                                {
     ///                                                                    "itemData": {
     ///                                                                        "$ref": "2428"
     ///                                                                    }
     ///                                                                }
     ///                                                            ],
     ///                                                            "researchPointsRequired": 2,
     ///                                                            "buyableWithoutResearch": false,
     ///                                                            "researchIsForRecipe": false,
     ///                                                            "useIntenseAberratedUIShader": false,
     ///                                                            "id": "rod13",
     ///                                                            "itemNameKey": [],
     ///                                                            "itemDescriptionKey": [],
     ///                                                            "hasAdditionalNote": false,
     ///                                                            "additionalNoteKey": [],
     ///                                                            "itemInsaneTitleKey": [],
     ///                                                            "itemInsaneDescriptionKey": [],
     ///                                                            "linkedDialogueNode": "",
     ///                                                            "dialogueNodeSpecificDescription": [],
     ///                                                            "itemType": "EQUIPMENT,ALL",
     ///                                                            "itemSubtype": "ROD,ALL",
     ///                                                            "tooltipTextColor": {
     ///                                                                "r": 0.4901961,
     ///                                                                "g": 0.3843137,
     ///                                                                "b": 0.2666667,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "tooltipNotesColor": {
     ///                                                                "r": 1.0,
     ///                                                                "g": 1.0,
     ///                                                                "b": 1.0,
     ///                                                                "a": 1.0
     ///                                                            },
     ///                                                            "itemTypeIcon": {
     ///                                                                "$ref": "2380"
     ///                                                            },
     ///                                                            "harvestParticlePrefab": null,
     ///                                                            "overrideHarvestParticleDepth": false,
     ///                                                            "harvestParticleDepthOffset": -3.0,
     ///                                                            "flattenParticleShape": false,
     ///                                                            "availableInDemo": false,
     ///                                                            "entitlementsRequired": [
     ///                                                                "NONE"
     ///                                                            ],
     ///                                                            "$type": "RodItemData"
     ///                                                        }
     ///                                                    }
     ///                                                ],
     ///                                                "researchPointsRequired": 4,
     ///                                                "buyableWithoutResearch": false,
     ///                                                "researchIsForRecipe": false,
     ///                                                "useIntenseAberratedUIShader": false,
     ///                                                "id": "rod14",
     ///                                                "itemNameKey": [],
     ///                                                "itemDescriptionKey": [],
     ///                                                "hasAdditionalNote": false,
     ///                                                "additionalNoteKey": [],
     ///                                                "itemInsaneTitleKey": [],
     ///                                                "itemInsaneDescriptionKey": [],
     ///                                                "linkedDialogueNode": "",
     ///                                                "dialogueNodeSpecificDescription": [],
     ///                                                "itemType": "EQUIPMENT,ALL",
     ///                                                "itemSubtype": "ROD,ALL",
     ///                                                "tooltipTextColor": {
     ///                                                    "r": 0.4901961,
     ///                                                    "g": 0.3843137,
     ///                                                    "b": 0.2666667,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "tooltipNotesColor": {
     ///                                                    "r": 1.0,
     ///                                                    "g": 1.0,
     ///                                                    "b": 1.0,
     ///                                                    "a": 1.0
     ///                                                },
     ///                                                "itemTypeIcon": {
     ///                                                    "$ref": "2380"
     ///                                                },
     ///                                                "harvestParticlePrefab": null,
     ///                                                "overrideHarvestParticleDepth": false,
     ///                                                "harvestParticleDepthOffset": -3.0,
     ///                                                "flattenParticleShape": false,
     ///                                                "availableInDemo": false,
     ///                                                "entitlementsRequired": [
     ///                                                    "NONE"
     ///                                                ],
     ///                                                "$type": "RodItemData"
     ///                                            }
     ///                                        }
     ///                                    ],
     ///                                    "researchPointsRequired": 5,
     ///                                    "buyableWithoutResearch": false,
     ///                                    "researchIsForRecipe": false,
     ///                                    "useIntenseAberratedUIShader": false,
     ///                                    "id": "rod15",
     ///                                    "itemNameKey": [],
     ///                                    "itemDescriptionKey": [],
     ///                                    "hasAdditionalNote": false,
     ///                                    "additionalNoteKey": [],
     ///                                    "itemInsaneTitleKey": [],
     ///                                    "itemInsaneDescriptionKey": [],
     ///                                    "linkedDialogueNode": "",
     ///                                    "dialogueNodeSpecificDescription": [],
     ///                                    "itemType": "EQUIPMENT,ALL",
     ///                                    "itemSubtype": "ROD,ALL",
     ///                                    "tooltipTextColor": {
     ///                                        "r": 0.4901961,
     ///                                        "g": 0.3843137,
     ///                                        "b": 0.2666667,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "tooltipNotesColor": {
     ///                                        "r": 1.0,
     ///                                        "g": 1.0,
     ///                                        "b": 1.0,
     ///                                        "a": 1.0
     ///                                    },
     ///                                    "itemTypeIcon": {
     ///                                        "$ref": "2380"
     ///                                    },
     ///                                    "harvestParticlePrefab": null,
     ///                                    "overrideHarvestParticleDepth": false,
     ///                                    "harvestParticleDepthOffset": -3.0,
     ///                                    "flattenParticleShape": false,
     ///                                    "availableInDemo": false,
     ///                                    "entitlementsRequired": [
     ///                                        "NONE"
     ///                                    ],
     ///                                    "$type": "RodItemData"
     ///                                }
     ///                            ],
     ///                            "$type": "ResearchCompleteCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "SELL_FISH_VALUE_1",
     ///                    "steamId": "SELL_FISH_VALUE_1",
     ///                    "playStationId": 30,
     ///                    "xboxId": "30",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "key": "fish-sale-total",
     ///                            "target": 2500.0,
     ///                            "evaluationMode": "GTE",
     ///                            "$type": "DecimalCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "SELL_TRINKETS_VALUE_1",
     ///                    "steamId": "SELL_TRINKETS_VALUE_1",
     ///                    "playStationId": 31,
     ///                    "xboxId": "31",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "key": "trinket-sale-total",
     ///                            "target": 1500.0,
     ///                            "evaluationMode": "GTE",
     ///                            "$type": "DecimalCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "SOLVE_ALL_SHRINES",
     ///                    "steamId": "SOLVE_ALL_SHRINES",
     ///                    "playStationId": 21,
     ///                    "xboxId": "21",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "nodeNames": [
     ///                                "CodShrine_Complete",
     ///                                "SharkShrine_Complete",
     ///                                "AberrationShrine_Complete",
     ///                                "CrabShrine_Complete"
     ///                            ],
     ///                            "$type": "NodeVisitedCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "STAT_ENGINE_SPEED",
     ///                    "steamId": "STAT_ENGINE_SPEED",
     ///                    "playStationId": 34,
     ///                    "xboxId": "34",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "target": 75.0,
     ///                            "$type": "EngineSpeedCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "STAT_FISHING_SPEED",
     ///                    "steamId": "STAT_FISHING_SPEED",
     ///                    "playStationId": 33,
     ///                    "xboxId": "33",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "target": 2.0,
     ///                            "$type": "FishingSpeedCondition"
     ///                        }
     ///                    ]
     ///                },
     ///                {
     ///                    "id": "STAT_LIGHT_STRENGTH",
     ///                    "steamId": "STAT_LIGHT_STRENGTH",
     ///                    "playStationId": 35,
     ///                    "xboxId": "35",
     ///                    "evaluationConditions": [
     ///                        {
     ///                            "target": 3000.0,
     ///                            "$type": "LightStrengthCondition"
     ///                        }
     ///                    ]
     ///                }
     ///            ],
     ///            "$type": "AchievementEarnedCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = ALL_ACHIEVEMENTSInstance.evaluationConditions;
}

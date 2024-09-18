namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class DLC_4_3
{
    public static AchievementData DLC_4_3Instance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "DLC_4_3");
    public static DredgeAchievementId id = DredgeAchievementId.DLC_4_3;
    public static string steamId = "";
    public static int playStationId = 0;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "questSteps": [
     ///                {
     ///                    "mapMarkersToAddOnStart": [],
     ///                    "mapMarkersToDeleteOnCompletion": [],
     ///                    "hiddenWhenActive": false,
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
     ///                    "allowAutomaticCompletion": false,
     ///                    "conditionMode": "ALL",
     ///                    "completeConditions": []
     ///                }
     ///            ],
     ///            "$type": "QuestStepCompleteCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = DLC_4_3Instance.evaluationConditions;
}

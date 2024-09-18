namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class DLC_4_7
{
    public static AchievementData DLC_4_7Instance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "DLC_4_7");
    public static DredgeAchievementId id = DredgeAchievementId.DLC_4_7;
    public static string steamId = "";
    public static int playStationId = 0;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "key": "canisters-caught",
     ///            "target": 10,
     ///            "evaluationMode": "GTE",
     ///            "$type": "IntCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = DLC_4_7Instance.evaluationConditions;
}

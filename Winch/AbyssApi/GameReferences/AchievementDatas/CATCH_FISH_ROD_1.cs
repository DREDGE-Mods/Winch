namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class CATCH_FISH_ROD_1
{
    public static AchievementData CATCH_FISH_ROD_1Instance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "CATCH_FISH_ROD_1");
    public static DredgeAchievementId id = DredgeAchievementId.CATCH_FISH_ROD_1;
    public static string steamId = "";
    public static int playStationId = 27;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "key": "rod-fish-caught",
     ///            "target": 250,
     ///            "evaluationMode": "GTE",
     ///            "$type": "IntCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = CATCH_FISH_ROD_1Instance.evaluationConditions;
}

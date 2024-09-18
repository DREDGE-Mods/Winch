namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class DEPLETE_FISH_SPOTS
{
    public static AchievementData DEPLETE_FISH_SPOTSInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "DEPLETE_FISH_SPOTS");
    public static DredgeAchievementId id = DredgeAchievementId.DEPLETE_FISH_SPOTS;
    public static string steamId = "";
    public static int playStationId = 32;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "key": "fish-depleted-count",
     ///            "target": 25,
     ///            "evaluationMode": "GTE",
     ///            "$type": "IntCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = DEPLETE_FISH_SPOTSInstance.evaluationConditions;
}

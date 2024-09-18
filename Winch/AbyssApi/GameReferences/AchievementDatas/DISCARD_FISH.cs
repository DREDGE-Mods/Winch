namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class DISCARD_FISH
{
    public static AchievementData DISCARD_FISHInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "DISCARD_FISH");
    public static DredgeAchievementId id = DredgeAchievementId.DISCARD_FISH;
    public static string steamId = "";
    public static int playStationId = 39;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "key": "fish-discard-count",
     ///            "target": 25,
     ///            "evaluationMode": "GTE",
     ///            "$type": "IntCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = DISCARD_FISHInstance.evaluationConditions;
}

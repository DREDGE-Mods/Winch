namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class CATCH_ALL_REGULAR_FISH
{
    public static AchievementData CATCH_ALL_REGULAR_FISHInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "CATCH_ALL_REGULAR_FISH");
    public static DredgeAchievementId id = DredgeAchievementId.CATCH_ALL_REGULAR_FISH;
    public static string steamId = "";
    public static int playStationId = 2;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = CATCH_ALL_REGULAR_FISHInstance.evaluationConditions;
}

namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class ENDING_ALT
{
    public static AchievementData ENDING_ALTInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "ENDING_ALT");
    public static DredgeAchievementId id = DredgeAchievementId.ENDING_ALT;
    public static string steamId = "";
    public static int playStationId = 9;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = ENDING_ALTInstance.evaluationConditions;
}

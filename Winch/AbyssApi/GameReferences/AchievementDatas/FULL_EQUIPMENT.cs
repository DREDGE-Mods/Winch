namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class FULL_EQUIPMENT
{
    public static AchievementData FULL_EQUIPMENTInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "FULL_EQUIPMENT");
    public static DredgeAchievementId id = DredgeAchievementId.FULL_EQUIPMENT;
    public static string steamId = "";
    public static int playStationId = 22;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = FULL_EQUIPMENTInstance.evaluationConditions;
}

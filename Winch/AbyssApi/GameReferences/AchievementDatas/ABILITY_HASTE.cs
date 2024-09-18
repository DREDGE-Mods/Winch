namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class ABILITY_HASTE
{
    public static AchievementData ABILITY_HASTEInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "ABILITY_HASTE");
    public static DredgeAchievementId id = DredgeAchievementId.ABILITY_HASTE;
    public static string steamId = "";
    public static int playStationId = 15;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = ABILITY_HASTEInstance.evaluationConditions;
}

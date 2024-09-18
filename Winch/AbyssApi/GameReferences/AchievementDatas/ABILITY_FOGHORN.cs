namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class ABILITY_FOGHORN
{
    public static AchievementData ABILITY_FOGHORNInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "ABILITY_FOGHORN");
    public static DredgeAchievementId id = DredgeAchievementId.ABILITY_FOGHORN;
    public static string steamId = "";
    public static int playStationId = 12;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = ABILITY_FOGHORNInstance.evaluationConditions;
}

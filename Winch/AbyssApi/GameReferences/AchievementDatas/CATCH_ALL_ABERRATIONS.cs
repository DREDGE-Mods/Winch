namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class CATCH_ALL_ABERRATIONS
{
    public static AchievementData CATCH_ALL_ABERRATIONSInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "CATCH_ALL_ABERRATIONS");
    public static DredgeAchievementId id = DredgeAchievementId.CATCH_ALL_ABERRATIONS;
    public static string steamId = "";
    public static int playStationId = 11;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = CATCH_ALL_ABERRATIONSInstance.evaluationConditions;
}

namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class FULL_CARGO
{
    public static AchievementData FULL_CARGOInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "FULL_CARGO");
    public static DredgeAchievementId id = DredgeAchievementId.FULL_CARGO;
    public static string steamId = "";
    public static int playStationId = 10;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = FULL_CARGOInstance.evaluationConditions;
}

namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class DLC_4_9
{
    public static AchievementData DLC_4_9Instance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "DLC_4_9");
    public static DredgeAchievementId id = DredgeAchievementId.DLC_4_9;
    public static string steamId = "";
    public static int playStationId = 0;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = DLC_4_9Instance.evaluationConditions;
}

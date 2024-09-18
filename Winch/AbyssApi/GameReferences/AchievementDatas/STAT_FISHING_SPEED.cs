namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class STAT_FISHING_SPEED
{
    public static AchievementData STAT_FISHING_SPEEDInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "STAT_FISHING_SPEED");
    public static DredgeAchievementId id = DredgeAchievementId.STAT_FISHING_SPEED;
    public static string steamId = "";
    public static int playStationId = 33;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "target": 2.0,
     ///            "$type": "FishingSpeedCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = STAT_FISHING_SPEEDInstance.evaluationConditions;
}

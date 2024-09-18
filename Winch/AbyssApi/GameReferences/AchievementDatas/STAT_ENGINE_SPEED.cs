namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class STAT_ENGINE_SPEED
{
    public static AchievementData STAT_ENGINE_SPEEDInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "STAT_ENGINE_SPEED");
    public static DredgeAchievementId id = DredgeAchievementId.STAT_ENGINE_SPEED;
    public static string steamId = "";
    public static int playStationId = 34;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "target": 75.0,
     ///            "$type": "EngineSpeedCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = STAT_ENGINE_SPEEDInstance.evaluationConditions;
}

namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class STAT_LIGHT_STRENGTH
{
    public static AchievementData STAT_LIGHT_STRENGTHInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "STAT_LIGHT_STRENGTH");
    public static DredgeAchievementId id = DredgeAchievementId.STAT_LIGHT_STRENGTH;
    public static string steamId = "";
    public static int playStationId = 35;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "target": 3000.0,
     ///            "$type": "LightStrengthCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = STAT_LIGHT_STRENGTHInstance.evaluationConditions;
}

namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class ABILITY_BANISH
{
    public static AchievementData ABILITY_BANISHInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "ABILITY_BANISH");
    public static DredgeAchievementId id = DredgeAchievementId.ABILITY_BANISH;
    public static string steamId = "";
    public static int playStationId = 17;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "key": "threats-banished",
     ///            "target": 10,
     ///            "evaluationMode": "GTE",
     ///            "$type": "IntCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = ABILITY_BANISHInstance.evaluationConditions;
}

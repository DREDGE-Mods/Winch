namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class SELL_FISH_VALUE_1
{
    public static AchievementData SELL_FISH_VALUE_1Instance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "SELL_FISH_VALUE_1");
    public static DredgeAchievementId id = DredgeAchievementId.SELL_FISH_VALUE_1;
    public static string steamId = "";
    public static int playStationId = 30;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "key": "fish-sale-total",
     ///            "target": 2500.0,
     ///            "evaluationMode": "GTE",
     ///            "$type": "DecimalCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = SELL_FISH_VALUE_1Instance.evaluationConditions;
}

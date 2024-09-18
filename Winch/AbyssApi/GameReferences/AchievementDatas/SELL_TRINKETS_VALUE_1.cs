namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class SELL_TRINKETS_VALUE_1
{
    public static AchievementData SELL_TRINKETS_VALUE_1Instance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "SELL_TRINKETS_VALUE_1");
    public static DredgeAchievementId id = DredgeAchievementId.SELL_TRINKETS_VALUE_1;
    public static string steamId = "";
    public static int playStationId = 31;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "key": "trinket-sale-total",
     ///            "target": 1500.0,
     ///            "evaluationMode": "GTE",
     ///            "$type": "DecimalCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = SELL_TRINKETS_VALUE_1Instance.evaluationConditions;
}

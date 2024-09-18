namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class SOLVE_ALL_SHRINES
{
    public static AchievementData SOLVE_ALL_SHRINESInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "SOLVE_ALL_SHRINES");
    public static DredgeAchievementId id = DredgeAchievementId.SOLVE_ALL_SHRINES;
    public static string steamId = "";
    public static int playStationId = 21;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "nodeNames": [
     ///                "CodShrine_Complete",
     ///                "SharkShrine_Complete",
     ///                "AberrationShrine_Complete",
     ///                "CrabShrine_Complete"
     ///            ],
     ///            "$type": "NodeVisitedCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = SOLVE_ALL_SHRINESInstance.evaluationConditions;
}

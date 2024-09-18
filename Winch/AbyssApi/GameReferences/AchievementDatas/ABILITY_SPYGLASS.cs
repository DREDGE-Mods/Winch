namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class ABILITY_SPYGLASS
{
    public static AchievementData ABILITY_SPYGLASSInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "ABILITY_SPYGLASS");
    public static DredgeAchievementId id = DredgeAchievementId.ABILITY_SPYGLASS;
    public static string steamId = "";
    public static int playStationId = 13;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "keys": [
     ///                "spied-coastal",
     ///                "spied-shallow",
     ///                "spied-oceanic",
     ///                "spied-abyssal",
     ///                "spied-hadal",
     ///                "spied-mangrove",
     ///                "spied-volcanic"
     ///            ],
     ///            "state": true,
     ///            "$type": "BoolCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = ABILITY_SPYGLASSInstance.evaluationConditions;
}

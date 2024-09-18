namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class DISCOVER_ALL_DOCKS
{
    public static AchievementData DISCOVER_ALL_DOCKSInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "DISCOVER_ALL_DOCKS");
    public static DredgeAchievementId id = DredgeAchievementId.DISCOVER_ALL_DOCKS;
    public static string steamId = "";
    public static int playStationId = 20;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "keys": [
     ///                "has-visited-dock-dock.greater-marrow",
     ///                "has-visited-dock-dock.little-marrow",
     ///                "has-visited-dock-dock.gale-cliffs",
     ///                "has-visited-dock-dock.ingfell",
     ///                "has-visited-dock-dock.old-fort",
     ///                "has-visited-dock-dock.old-mayor-ds",
     ///                "has-visited-dock-dock.old-mayor-gc",
     ///                "has-visited-dock-dock.old-mayor-sb",
     ///                "has-visited-dock-dock.old-mayor-ts",
     ///                "has-visited-dock-dock.outcast-isle",
     ///                "has-visited-dock-dock.pontoon-ds",
     ///                "has-visited-dock-dock.pontoon-gc",
     ///                "has-visited-dock-dock.pontoon-sb",
     ///                "has-visited-dock-dock.pontoon-ts",
     ///                "has-visited-dock-dock.research-pontoon",
     ///                "has-visited-dock-dock.soldier-camp",
     ///                "has-visited-dock-dock.steel-point",
     ///                "has-visited-dock-dock.ds-temple",
     ///                "has-visited-dock-dock.ancient-ruins"
     ///            ],
     ///            "state": true,
     ///            "$type": "BoolCondition"
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = DISCOVER_ALL_DOCKSInstance.evaluationConditions;
}

namespace Winch.AbyssApi.GameReferences.AchievementDatas;
public static class ABILITY_MANIFEST
{
    public static AchievementData ABILITY_MANIFESTInstance = (AchievementData)System.Linq.Enumerable.First(ScriptableObjectInstances.AchievementDatas, x => x.name == "ABILITY_MANIFEST");
    public static DredgeAchievementId id = DredgeAchievementId.ABILITY_MANIFEST;
    public static string steamId = "";
    public static int playStationId = 16;
    public static string xboxId = "";
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[AchievementCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<AchievementCondition> evaluationConditions = ABILITY_MANIFESTInstance.evaluationConditions;
}

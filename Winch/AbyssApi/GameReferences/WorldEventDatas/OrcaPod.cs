namespace Winch.AbyssApi.GameReferences.WorldEventDatas;
public static class OrcaPod
{
    public static WorldEventData OrcaPodInstance = (WorldEventData)System.Linq.Enumerable.First(ScriptableObjectInstances.WorldEventDatas, x => x.name == "OrcaPod");
    public static WorldEventType eventType = WorldEventType.SPAWN_PREFAB;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.GameObject prefab = OrcaPodInstance.prefab;
    public static bool dispelByBanish = false;
    public static bool dispelByFoghorn = false;
    public static float foghornDispelTime = 0f;
    public static float foghornDispelCount = 0f;
    public static int minWorldPhase = 0;
    public static float minSanity = 0.75f;
    public static float maxSanity = 1f;
     ///<json>
     /// {
     ///    "NORMAL": 10.0,
     ///    "PASSIVE": 10.0,
     ///    "NIGHTMARE": 10.0,
     ///    "$type": "System.Collections.Generic.Dictionary`2[[GameMode, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"
     ///}
     ///</json>
    public static System.Collections.Generic.Dictionary<GameMode,float> repeatDelay = OrcaPodInstance.repeatDelay;
    public static float weight = 10f;
    public static float spawnStartTime = 0.25f;
    public static float spawnEndTime = 0.75f;
    public static bool hasDuration = false;
    public static float durationSec = 0f;
    public static bool hasMinDepth = true;
    public static float minDepth = 0.1f;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "x": -15.0,
     ///            "y": 0.0,
     ///            "z": 25.0
     ///        },
     ///        {
     ///            "x": -15.0,
     ///            "y": 0.0,
     ///            "z": 125.0
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[UnityEngine.Vector3, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<UnityEngine.Vector3> depthTestPath = OrcaPodInstance.depthTestPath;
    public static bool isPath = true;
    public static float depthPathNumChecks = 10f;
    public static UnityEngine.Vector3 playerSpawnOffset = new UnityEngine.Vector3(-15f, 0f, 25f);
    public static UnityEngine.Vector3 zoneTestOffset = new UnityEngine.Vector3(0f, 0f, 0f);
    public static bool doSafeZoneHitCheck = true;
    public static UnityEngine.Vector3 safeZoneHitCheckOffset = new UnityEngine.Vector3(-15f, 0f, 25f);
    public static ZoneEnum forbiddenZones = ZoneEnum.NONE | ZoneEnum.STELLAR_BASIN | ZoneEnum.PALE_REACH;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[InventoryCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<InventoryCondition> itemInventoryConditions = OrcaPodInstance.itemInventoryConditions;
    public static bool forbidOoze = true;
    public static bool allowInPassiveMode = true;
}

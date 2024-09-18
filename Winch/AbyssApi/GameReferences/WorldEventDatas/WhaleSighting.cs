namespace Winch.AbyssApi.GameReferences.WorldEventDatas;
public static class WhaleSighting
{
    public static WorldEventData WhaleSightingInstance = (WorldEventData)System.Linq.Enumerable.First(ScriptableObjectInstances.WorldEventDatas, x => x.name == "WhaleSighting");
    public static WorldEventType eventType = WorldEventType.SPAWN_PREFAB;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.GameObject prefab = WhaleSightingInstance.prefab;
    public static bool dispelByBanish = false;
    public static bool dispelByFoghorn = false;
    public static float foghornDispelTime = 0f;
    public static float foghornDispelCount = 0f;
    public static int minWorldPhase = 0;
    public static float minSanity = 0.75f;
    public static float maxSanity = 1f;
     ///<json>
     /// {
     ///    "NORMAL": 14.0,
     ///    "PASSIVE": 14.0,
     ///    "NIGHTMARE": 14.0,
     ///    "$type": "System.Collections.Generic.Dictionary`2[[GameMode, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"
     ///}
     ///</json>
    public static System.Collections.Generic.Dictionary<GameMode,float> repeatDelay = WhaleSightingInstance.repeatDelay;
    public static float weight = 100f;
    public static float spawnStartTime = 0.35f;
    public static float spawnEndTime = 0.7f;
    public static bool hasDuration = false;
    public static float durationSec = 0f;
    public static bool hasMinDepth = true;
    public static float minDepth = 0.35f;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "x": 0.0,
     ///            "y": 0.0,
     ///            "z": 85.0
     ///        },
     ///        {
     ///            "x": -40.0,
     ///            "y": 0.0,
     ///            "z": 50.0
     ///        },
     ///        {
     ///            "x": -65.0,
     ///            "y": 0.0,
     ///            "z": 10.0
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[UnityEngine.Vector3, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<UnityEngine.Vector3> depthTestPath = WhaleSightingInstance.depthTestPath;
    public static bool isPath = false;
    public static float depthPathNumChecks = 5f;
    public static UnityEngine.Vector3 playerSpawnOffset = new UnityEngine.Vector3(5f, -22f, 85f);
    public static UnityEngine.Vector3 zoneTestOffset = new UnityEngine.Vector3(5f, 0f, 85f);
    public static bool doSafeZoneHitCheck = true;
    public static UnityEngine.Vector3 safeZoneHitCheckOffset = new UnityEngine.Vector3(5f, 0f, 85f);
    public static ZoneEnum forbiddenZones = ZoneEnum.NONE | ZoneEnum.GALE_CLIFFS | ZoneEnum.STELLAR_BASIN | ZoneEnum.PALE_REACH;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[InventoryCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<InventoryCondition> itemInventoryConditions = WhaleSightingInstance.itemInventoryConditions;
    public static bool forbidOoze = true;
    public static bool allowInPassiveMode = true;
}

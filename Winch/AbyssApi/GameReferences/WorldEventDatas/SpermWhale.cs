namespace Winch.AbyssApi.GameReferences.WorldEventDatas;
public static class SpermWhale
{
    public static WorldEventData SpermWhaleInstance = (WorldEventData)System.Linq.Enumerable.First(ScriptableObjectInstances.WorldEventDatas, x => x.name == "SpermWhale");
    public static WorldEventType eventType = WorldEventType.SPAWN_PREFAB;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.GameObject prefab = SpermWhaleInstance.prefab;
    public static bool dispelByBanish = false;
    public static bool dispelByFoghorn = false;
    public static float foghornDispelTime = 0f;
    public static float foghornDispelCount = 0f;
    public static int minWorldPhase = 2;
    public static float minSanity = 0f;
    public static float maxSanity = 0.75f;
     ///<json>
     /// {
     ///    "NORMAL": 14.0,
     ///    "PASSIVE": 14.0,
     ///    "NIGHTMARE": 14.0,
     ///    "$type": "System.Collections.Generic.Dictionary`2[[GameMode, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"
     ///}
     ///</json>
    public static System.Collections.Generic.Dictionary<GameMode,float> repeatDelay = SpermWhaleInstance.repeatDelay;
    public static float weight = 200f;
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
     ///            "x": 10.0,
     ///            "y": 0.0,
     ///            "z": 100.0
     ///        },
     ///        {
     ///            "x": 0.0,
     ///            "y": 0.0,
     ///            "z": 115.0
     ///        },
     ///        {
     ///            "x": 0.0,
     ///            "y": 0.0,
     ///            "z": 110.0
     ///        },
     ///        {
     ///            "x": 0.0,
     ///            "y": 0.0,
     ///            "z": 120.0
     ///        },
     ///        {
     ///            "x": 5.0,
     ///            "y": 0.0,
     ///            "z": 115.0
     ///        },
     ///        {
     ///            "x": -5.0,
     ///            "y": 0.0,
     ///            "z": 115.0
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[UnityEngine.Vector3, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<UnityEngine.Vector3> depthTestPath = SpermWhaleInstance.depthTestPath;
    public static bool isPath = false;
    public static float depthPathNumChecks = 5f;
    public static UnityEngine.Vector3 playerSpawnOffset = new UnityEngine.Vector3(0f, 0f, 115f);
    public static UnityEngine.Vector3 zoneTestOffset = new UnityEngine.Vector3(0f, 0f, 115f);
    public static bool doSafeZoneHitCheck = true;
    public static UnityEngine.Vector3 safeZoneHitCheckOffset = new UnityEngine.Vector3(0f, 0f, 115f);
    public static ZoneEnum forbiddenZones = ZoneEnum.NONE | ZoneEnum.STELLAR_BASIN;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[InventoryCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<InventoryCondition> itemInventoryConditions = SpermWhaleInstance.itemInventoryConditions;
    public static bool forbidOoze = true;
    public static bool allowInPassiveMode = true;
}

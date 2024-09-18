namespace Winch.AbyssApi.GameReferences.WorldEventDatas;
public static class LeviathanCircle
{
    public static WorldEventData LeviathanCircleInstance = (WorldEventData)System.Linq.Enumerable.First(ScriptableObjectInstances.WorldEventDatas, x => x.name == "LeviathanCircle");
    public static WorldEventType eventType = WorldEventType.SPAWN_PREFAB;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.GameObject prefab = LeviathanCircleInstance.prefab;
    public static bool dispelByBanish = false;
    public static bool dispelByFoghorn = false;
    public static float foghornDispelTime = 0f;
    public static float foghornDispelCount = 0f;
    public static int minWorldPhase = 2;
    public static float minSanity = 0f;
    public static float maxSanity = 0.5f;
     ///<json>
     /// {
     ///    "NORMAL": 10.0,
     ///    "PASSIVE": 10.0,
     ///    "NIGHTMARE": 3.0,
     ///    "$type": "System.Collections.Generic.Dictionary`2[[GameMode, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"
     ///}
     ///</json>
    public static System.Collections.Generic.Dictionary<GameMode,float> repeatDelay = LeviathanCircleInstance.repeatDelay;
    public static float weight = 10f;
    public static float spawnStartTime = 0f;
    public static float spawnEndTime = 1f;
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
     ///            "z": 50.0
     ///        },
     ///        {
     ///            "x": -25.0,
     ///            "y": 0.0,
     ///            "z": 75.0
     ///        },
     ///        {
     ///            "x": -25.0,
     ///            "y": 0.0,
     ///            "z": 25.0
     ///        },
     ///        {
     ///            "x": 25.0,
     ///            "y": 0.0,
     ///            "z": 75.0
     ///        },
     ///        {
     ///            "x": 25.0,
     ///            "y": 0.0,
     ///            "z": 35.0
     ///        },
     ///        {
     ///            "x": -85.0,
     ///            "y": 0.0,
     ///            "z": 135.0
     ///        },
     ///        {
     ///            "x": -85.0,
     ///            "y": 0.0,
     ///            "z": -35.0
     ///        },
     ///        {
     ///            "x": 85.0,
     ///            "y": 0.0,
     ///            "z": 135.0
     ///        },
     ///        {
     ///            "x": 85.0,
     ///            "y": 0.0,
     ///            "z": -35.0
     ///        },
     ///        {
     ///            "x": 0.0,
     ///            "y": 0.0,
     ///            "z": -35.0
     ///        },
     ///        {
     ///            "x": 0.0,
     ///            "y": 0.0,
     ///            "z": 135.0
     ///        },
     ///        {
     ///            "x": -85.0,
     ///            "y": 0.0,
     ///            "z": 50.0
     ///        },
     ///        {
     ///            "x": 85.0,
     ///            "y": 0.0,
     ///            "z": 50.0
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[UnityEngine.Vector3, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<UnityEngine.Vector3> depthTestPath = LeviathanCircleInstance.depthTestPath;
    public static bool isPath = false;
    public static float depthPathNumChecks = 1f;
    public static UnityEngine.Vector3 playerSpawnOffset = new UnityEngine.Vector3(0f, 0f, 50f);
    public static UnityEngine.Vector3 zoneTestOffset = new UnityEngine.Vector3(0f, 0f, 0f);
    public static bool doSafeZoneHitCheck = true;
    public static UnityEngine.Vector3 safeZoneHitCheckOffset = new UnityEngine.Vector3(0f, 0f, 50f);
    public static ZoneEnum forbiddenZones = ZoneEnum.NONE | ZoneEnum.PALE_REACH;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[InventoryCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<InventoryCondition> itemInventoryConditions = LeviathanCircleInstance.itemInventoryConditions;
    public static bool forbidOoze = true;
    public static bool allowInPassiveMode = false;
}

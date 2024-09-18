namespace Winch.AbyssApi.GameReferences.WorldEventDatas;
public static class PhantomShark
{
    public static WorldEventData PhantomSharkInstance = (WorldEventData)System.Linq.Enumerable.First(ScriptableObjectInstances.WorldEventDatas, x => x.name == "PhantomShark");
    public static WorldEventType eventType = WorldEventType.SPAWN_PREFAB;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.GameObject prefab = PhantomSharkInstance.prefab;
    public static bool dispelByBanish = true;
    public static bool dispelByFoghorn = false;
    public static float foghornDispelTime = 0f;
    public static float foghornDispelCount = 0f;
    public static int minWorldPhase = 2;
    public static float minSanity = 0f;
    public static float maxSanity = 0.25f;
     ///<json>
     /// {
     ///    "NORMAL": 3.0,
     ///    "PASSIVE": 3.0,
     ///    "NIGHTMARE": 0.25,
     ///    "$type": "System.Collections.Generic.Dictionary`2[[GameMode, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"
     ///}
     ///</json>
    public static System.Collections.Generic.Dictionary<GameMode,float> repeatDelay = PhantomSharkInstance.repeatDelay;
    public static float weight = 5f;
    public static float spawnStartTime = 0f;
    public static float spawnEndTime = 1f;
    public static bool hasDuration = false;
    public static float durationSec = 0f;
    public static bool hasMinDepth = true;
    public static float minDepth = 0.02f;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "x": -25.0,
     ///            "y": 0.0,
     ///            "z": 80.0
     ///        },
     ///        {
     ///            "x": -10.0,
     ///            "y": 0.0,
     ///            "z": 75.0
     ///        },
     ///        {
     ///            "x": -5.0,
     ///            "y": 0.0,
     ///            "z": 60.0
     ///        },
     ///        {
     ///            "x": 0.0,
     ///            "y": 0.0,
     ///            "z": 0.0
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[UnityEngine.Vector3, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<UnityEngine.Vector3> depthTestPath = PhantomSharkInstance.depthTestPath;
    public static bool isPath = true;
    public static float depthPathNumChecks = 10f;
    public static UnityEngine.Vector3 playerSpawnOffset = new UnityEngine.Vector3(-25f, 0f, 80f);
    public static UnityEngine.Vector3 zoneTestOffset = new UnityEngine.Vector3(-25f, 0f, 80f);
    public static bool doSafeZoneHitCheck = true;
    public static UnityEngine.Vector3 safeZoneHitCheckOffset = new UnityEngine.Vector3(-25f, 0f, 80f);
    public static ZoneEnum forbiddenZones = ZoneEnum.NONE | ZoneEnum.DEVILS_SPINE;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[InventoryCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<InventoryCondition> itemInventoryConditions = PhantomSharkInstance.itemInventoryConditions;
    public static bool forbidOoze = true;
    public static bool allowInPassiveMode = false;
}

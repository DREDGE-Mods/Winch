namespace Winch.AbyssApi.GameReferences.WorldEventDatas;
public static class Waterspout_Corrupt
{
    public static WorldEventData Waterspout_CorruptInstance = (WorldEventData)System.Linq.Enumerable.First(ScriptableObjectInstances.WorldEventDatas, x => x.name == "Waterspout_Corrupt");
    public static WorldEventType eventType = WorldEventType.SPAWN_PREFAB;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.GameObject prefab = Waterspout_CorruptInstance.prefab;
    public static bool dispelByBanish = true;
    public static bool dispelByFoghorn = false;
    public static float foghornDispelTime = 0f;
    public static float foghornDispelCount = 0f;
    public static int minWorldPhase = 2;
    public static float minSanity = 0f;
    public static float maxSanity = 0.5f;
     ///<json>
     /// {
     ///    "NORMAL": 5.0,
     ///    "PASSIVE": 5.0,
     ///    "NIGHTMARE": 1.0,
     ///    "$type": "System.Collections.Generic.Dictionary`2[[GameMode, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"
     ///}
     ///</json>
    public static System.Collections.Generic.Dictionary<GameMode,float> repeatDelay = Waterspout_CorruptInstance.repeatDelay;
    public static float weight = 7f;
    public static float spawnStartTime = 0f;
    public static float spawnEndTime = 1f;
    public static bool hasDuration = true;
    public static float durationSec = 40f;
    public static bool hasMinDepth = true;
    public static float minDepth = 0.01f;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "x": -5.0,
     ///            "y": 0.0,
     ///            "z": 40.0
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[UnityEngine.Vector3, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<UnityEngine.Vector3> depthTestPath = Waterspout_CorruptInstance.depthTestPath;
    public static bool isPath = false;
    public static float depthPathNumChecks = 1f;
    public static UnityEngine.Vector3 playerSpawnOffset = new UnityEngine.Vector3(-5f, 0f, 40f);
    public static UnityEngine.Vector3 zoneTestOffset = new UnityEngine.Vector3(-5f, 0f, 40f);
    public static bool doSafeZoneHitCheck = true;
    public static UnityEngine.Vector3 safeZoneHitCheckOffset = new UnityEngine.Vector3(-5f, 0f, 40f);
    public static ZoneEnum forbiddenZones = ZoneEnum.NONE | ZoneEnum.GALE_CLIFFS | ZoneEnum.TWISTED_STRAND;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[InventoryCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<InventoryCondition> itemInventoryConditions = Waterspout_CorruptInstance.itemInventoryConditions;
    public static bool forbidOoze = false;
    public static bool allowInPassiveMode = false;
}

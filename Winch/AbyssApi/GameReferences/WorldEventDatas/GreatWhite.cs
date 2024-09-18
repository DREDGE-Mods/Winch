namespace Winch.AbyssApi.GameReferences.WorldEventDatas;
public static class GreatWhite
{
    public static WorldEventData GreatWhiteInstance = (WorldEventData)System.Linq.Enumerable.First(ScriptableObjectInstances.WorldEventDatas, x => x.name == "GreatWhite");
    public static WorldEventType eventType = WorldEventType.SPAWN_PREFAB;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.GameObject prefab = GreatWhiteInstance.prefab;
    public static bool dispelByBanish = false;
    public static bool dispelByFoghorn = false;
    public static float foghornDispelTime = 0f;
    public static float foghornDispelCount = 0f;
    public static int minWorldPhase = 1;
    public static float minSanity = 0.25f;
    public static float maxSanity = 0.75f;
     ///<json>
     /// {
     ///    "NORMAL": 7.0,
     ///    "PASSIVE": 7.0,
     ///    "NIGHTMARE": 7.0,
     ///    "$type": "System.Collections.Generic.Dictionary`2[[GameMode, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"
     ///}
     ///</json>
    public static System.Collections.Generic.Dictionary<GameMode,float> repeatDelay = GreatWhiteInstance.repeatDelay;
    public static float weight = 30f;
    public static float spawnStartTime = 0.25f;
    public static float spawnEndTime = 0.75f;
    public static bool hasDuration = false;
    public static float durationSec = 0f;
    public static bool hasMinDepth = true;
    public static float minDepth = 0.15f;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "x": 25.0,
     ///            "y": 0.0,
     ///            "z": 100.0
     ///        },
     ///        {
     ///            "x": -25.0,
     ///            "y": 0.0,
     ///            "z": 100.0
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
    public static System.Collections.Generic.List<UnityEngine.Vector3> depthTestPath = GreatWhiteInstance.depthTestPath;
    public static bool isPath = true;
    public static float depthPathNumChecks = 10f;
    public static UnityEngine.Vector3 playerSpawnOffset = new UnityEngine.Vector3(25f, 0f, 100f);
    public static UnityEngine.Vector3 zoneTestOffset = new UnityEngine.Vector3(25f, 0f, 100f);
    public static bool doSafeZoneHitCheck = true;
    public static UnityEngine.Vector3 safeZoneHitCheckOffset = new UnityEngine.Vector3(25f, 0f, 100f);
    public static ZoneEnum forbiddenZones = ZoneEnum.NONE | ZoneEnum.THE_MARROWS | ZoneEnum.GALE_CLIFFS | ZoneEnum.STELLAR_BASIN | ZoneEnum.TWISTED_STRAND | ZoneEnum.DEVILS_SPINE | ZoneEnum.PALE_REACH;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[InventoryCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<InventoryCondition> itemInventoryConditions = GreatWhiteInstance.itemInventoryConditions;
    public static bool forbidOoze = true;
    public static bool allowInPassiveMode = true;
}

namespace Winch.AbyssApi.GameReferences.WorldEventDatas;
public static class Waterspout
{
    public static WorldEventData WaterspoutInstance = (WorldEventData)System.Linq.Enumerable.First(ScriptableObjectInstances.WorldEventDatas, x => x.name == "Waterspout");
    public static WorldEventType eventType = WorldEventType.SPAWN_PREFAB;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.GameObject prefab = WaterspoutInstance.prefab;
    public static bool dispelByBanish = false;
    public static bool dispelByFoghorn = false;
    public static float foghornDispelTime = 0f;
    public static float foghornDispelCount = 0f;
    public static int minWorldPhase = 0;
    public static float minSanity = 0.25f;
    public static float maxSanity = 0.75f;
     ///<json>
     /// {
     ///    "NORMAL": 3.0,
     ///    "PASSIVE": 3.0,
     ///    "NIGHTMARE": 3.0,
     ///    "$type": "System.Collections.Generic.Dictionary`2[[GameMode, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"
     ///}
     ///</json>
    public static System.Collections.Generic.Dictionary<GameMode,float> repeatDelay = WaterspoutInstance.repeatDelay;
    public static float weight = 5f;
    public static float spawnStartTime = 0f;
    public static float spawnEndTime = 1f;
    public static bool hasDuration = true;
    public static float durationSec = 25f;
    public static bool hasMinDepth = true;
    public static float minDepth = 0.01f;
     ///<json>
     /// {
     ///    "$content": [
     ///        {
     ///            "x": 70.0,
     ///            "y": 0.0,
     ///            "z": 50.0
     ///        }
     ///    ],
     ///    "$type": "System.Collections.Generic.List`1[[UnityEngine.Vector3, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<UnityEngine.Vector3> depthTestPath = WaterspoutInstance.depthTestPath;
    public static bool isPath = false;
    public static float depthPathNumChecks = 1f;
    public static UnityEngine.Vector3 playerSpawnOffset = new UnityEngine.Vector3(70f, 0f, 50f);
    public static UnityEngine.Vector3 zoneTestOffset = new UnityEngine.Vector3(70f, 0f, 50f);
    public static bool doSafeZoneHitCheck = true;
    public static UnityEngine.Vector3 safeZoneHitCheckOffset = new UnityEngine.Vector3(70f, 0f, 50f);
    public static ZoneEnum forbiddenZones = ZoneEnum.NONE | ZoneEnum.GALE_CLIFFS | ZoneEnum.TWISTED_STRAND;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[InventoryCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<InventoryCondition> itemInventoryConditions = WaterspoutInstance.itemInventoryConditions;
    public static bool forbidOoze = false;
    public static bool allowInPassiveMode = true;
}

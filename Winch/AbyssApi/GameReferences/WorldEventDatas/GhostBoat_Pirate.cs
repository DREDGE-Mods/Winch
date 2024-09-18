namespace Winch.AbyssApi.GameReferences.WorldEventDatas;
public static class GhostBoat_Pirate
{
    public static WorldEventData GhostBoat_PirateInstance = (WorldEventData)System.Linq.Enumerable.First(ScriptableObjectInstances.WorldEventDatas, x => x.name == "GhostBoat_Pirate");
    public static WorldEventType eventType = WorldEventType.SPAWN_PREFAB;
     ///<json>
     /// Serialization does not support this type.
     /// </json>
    public static UnityEngine.GameObject prefab = GhostBoat_PirateInstance.prefab;
    public static bool dispelByBanish = false;
    public static bool dispelByFoghorn = false;
    public static float foghornDispelTime = 0f;
    public static float foghornDispelCount = 0f;
    public static int minWorldPhase = 3;
    public static float minSanity = 0.25f;
    public static float maxSanity = 0.75f;
     ///<json>
     /// {
     ///    "NORMAL": 5.0,
     ///    "PASSIVE": 5.0,
     ///    "NIGHTMARE": 5.0,
     ///    "$type": "System.Collections.Generic.Dictionary`2[[GameMode, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"
     ///}
     ///</json>
    public static System.Collections.Generic.Dictionary<GameMode,float> repeatDelay = GhostBoat_PirateInstance.repeatDelay;
    public static float weight = 2f;
    public static float spawnStartTime = 0.85f;
    public static float spawnEndTime = 0.15f;
    public static bool hasDuration = true;
    public static float durationSec = 30f;
    public static bool hasMinDepth = false;
    public static float minDepth = 0f;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[UnityEngine.Vector3, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<UnityEngine.Vector3> depthTestPath = GhostBoat_PirateInstance.depthTestPath;
    public static bool isPath = false;
    public static float depthPathNumChecks = 5f;
    public static UnityEngine.Vector3 playerSpawnOffset = new UnityEngine.Vector3(-100f, 0f, 50f);
    public static UnityEngine.Vector3 zoneTestOffset = new UnityEngine.Vector3(-100f, 0f, 50f);
    public static bool doSafeZoneHitCheck = true;
    public static UnityEngine.Vector3 safeZoneHitCheckOffset = new UnityEngine.Vector3(-100f, 0f, 50f);
    public static ZoneEnum forbiddenZones = ZoneEnum.NONE | ZoneEnum.GALE_CLIFFS | ZoneEnum.TWISTED_STRAND;
     ///<json>
     /// {
     ///    "$content": [],
     ///    "$type": "System.Collections.Generic.List`1[[InventoryCondition, DREDGE_Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]"
     ///}
     ///</json>
    public static System.Collections.Generic.List<InventoryCondition> itemInventoryConditions = GhostBoat_PirateInstance.itemInventoryConditions;
    public static bool forbidOoze = false;
    public static bool allowInPassiveMode = true;
}

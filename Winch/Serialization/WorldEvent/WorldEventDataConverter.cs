using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Util;

namespace Winch.Serialization.WorldEvent;

public class WorldEventDataConverter : DredgeTypeConverter<ModdedWorldEvent>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(null, null) },
        { "eventType", new(WorldEventType.NONE, o=> DredgeTypeHelpers.GetEnumValue<WorldEventType>(o) )},
        { "allowInPassiveMode", new(false, o=> bool.Parse(o.ToString())) },
        { "dispelByBanish", new(true, o=> bool.Parse(o.ToString())) },
        { "dispelByFoghorn", new(false, o=> bool.Parse(o.ToString())) },
        { "foghornDispelTime", new(0f, o => float.Parse(o.ToString())) },
        { "foghornDispelCount", new(3f, o => float.Parse(o.ToString())) },
        { "minWorldPhase", new(0, o => int.Parse(o.ToString())) },
        { "minSanity", new(0f, o => Mathf.Clamp01(float.Parse(o.ToString()))) },
        { "maxSanity", new(1f, o => Mathf.Clamp01(float.Parse(o.ToString()))) },
        { "weight", new(0f, o => float.Parse(o.ToString())) },
        { "repeatDelay", new(new Dictionary<GameMode, float>(), o => DredgeTypeHelpers.ParseDictionary<GameMode, float>(o, k => DredgeTypeHelpers.GetEnumValue<GameMode>(k), v => float.Parse(v.ToString()))) },
        { "spawnStartTime", new(0f, o => Mathf.Clamp01(float.Parse(o.ToString()))) },
        { "spawnEndTime", new(1f, o => Mathf.Clamp01(float.Parse(o.ToString()))) },
        { "hasDuration", new(false, o=> bool.Parse(o.ToString())) },
        { "durationSec", new(0f, o => float.Parse(o.ToString())) },
        { "hasMinDepth", new(false, o=> bool.Parse(o.ToString())) },
        { "minDepth", new(0f, o => float.Parse(o.ToString())) },
        { "depthTestPath", new(new List<Vector3>(){ Vector3.zero }, o=> DredgeTypeHelpers.ParseVector3Array((JArray)o)) },
        { "isPath", new(false, o=> bool.Parse(o.ToString())) },
        { "depthPathNumChecks", new(5f, o => float.Parse(o.ToString())) },
        { "playerSpawnOffset", new(Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "zoneTestOffset", new(Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "doSafeZoneHitCheck", new(true, o=> bool.Parse(o.ToString())) },
        { "safeZoneHitCheckOffset", new(Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "itemInventoryConditions", new(new List<InventoryCondition>(), o=> DredgeTypeHelpers.ParseInventoryConditions((JArray)o)) },
        { "forbiddenZones", new(ZoneEnum.NONE, o => DredgeTypeHelpers.ParseFlagsEnum<ZoneEnum>(o)) },
    };

    public WorldEventDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
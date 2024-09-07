using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using Winch.Data.POI.Dock;
using static Winch.Data.POI.Dock.CustomDockPOI;

namespace Winch.Serialization.POI.Dock;

public class CustomDockPOIConverter : CustomPOIConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "rotation", new( Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "dockData", new(string.Empty, null) },
        { "prefab", new(DockPrefab.GENERIC, o=>DredgeTypeHelpers.GetEnumValue<DockPrefab>(o) ) },
        { "poiOffset", new( null, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "collider", new( null, o=> DredgeTypeHelpers.ParseDockCollider(o.ToJToken())) },
        { "vCam", new( null, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "lookAtTarget", new( null, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "boatActions", new( null, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "storage", new( null, o=> DredgeTypeHelpers.ParsePrebuiltStorageDestination(o.ToJToken())) },
        { "dockSlots", new(null, o=>DredgeTypeHelpers.ParseDockSlots((JArray)o) ) },
        { "sanityModifier", new( new DockSanityModifier(), o=> DredgeTypeHelpers.ParseDockSanityModifier(o.ToJToken())) },
        { "safeZone", new( new DockSafeZone(), o=> DredgeTypeHelpers.ParseDockSafeZone(o.ToJToken())) },
    };

    private readonly Dictionary<string, string> _reroutes = new()
    {
        { "dockData", "id" }
    };

    public CustomDockPOIConverter()
    {
        AddDefinitions(_definitions);
        AddReroutes(_reroutes);
    }
}

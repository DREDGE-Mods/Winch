using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using Winch.Data.POI.Dock;
using Winch.Data.POI.Dock.Destinations;

namespace Winch.Serialization.POI.Dock;

public class CustomDockPOIConverter : CustomPOIConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "rotation", new( Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "dockData", new(string.Empty, null) },
        { "prefab", new(DockPrefab.GENERIC, o=>DredgeTypeHelpers.GetEnumValue<DockPrefab>(o) ) },
        { "poiOffset", new( null, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "collider", new( null, o=> DredgeTypeHelpers.ParseDockCollider(o)) },
        { "vCam", new( null, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "lookAtTarget", new( null, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "boatActions", new( null, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "characters", new( new List<CustomCharacterDestination>() , o=> DredgeTypeHelpers.ParseCharacterDestinations((JArray)o)) },
        { "markets", new( new List<CustomMarketDestination>() , o=> DredgeTypeHelpers.ParseMarketDestinations((JArray)o)) },
        { "shipyards", new( new List<CustomShipyardDestination>() , o=> DredgeTypeHelpers.ParseShipyardDestinations((JArray)o)) },
        { "upgraders", new( new List<CustomUpgradeDestination>() , o=> DredgeTypeHelpers.ParseUpgradeDestinations((JArray)o)) },
        { "constructables", new( new List<CustomConstructableDestination>() , o=> DredgeTypeHelpers.ParseConstructableDestinations((JArray)o)) },
        { "storage", new( null, o=> DredgeTypeHelpers.ParsePrebuiltStorageDestination(o)) },
        { "dockSlots", new(null, o=>DredgeTypeHelpers.ParseDockSlots((JArray)o) ) },
        { "sanityModifier", new( new DockSanityModifier(), o=> DredgeTypeHelpers.ParseDockSanityModifier(o)) },
        { "safeZone", new( new DockSafeZone(), o=> DredgeTypeHelpers.ParseDockSafeZone(o)) },
        { "speakerVCams", new( new Dictionary<string, SpeakerVCam>(), o=> DredgeTypeHelpers.GetSpeakerVCamsFromJsonObject(o)) },
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

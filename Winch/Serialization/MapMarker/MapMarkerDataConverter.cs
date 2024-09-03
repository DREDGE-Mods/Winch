using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winch.Util;

namespace Winch.Serialization.MapMarker;

public class MapMarkerDataConverter : DredgeTypeConverter<MapMarkerData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "x", new(0f, o => float.Parse(o.ToString())) },
        { "z", new(0f, o => float.Parse(o.ToString())) },
        { "mapMarkerType", new(MapMarkerType.SIDE, o=> DredgeTypeHelpers.GetEnumValue<MapMarkerType>(o) )},
    };

    public MapMarkerDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

using System.Collections.Generic;
using UnityEngine;
using Winch.Data.Boat;

namespace Winch.Serialization.Boat;

public class BoatPaintDataConverter : DredgeTypeConverter<BoatPaintData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) },
        { "color", new(Color.white, o => DredgeTypeHelpers.GetColorFromJsonObject(o)) },
        { "localizedNameKey", new(null, null) },
        { "questGridConfig", new(null, null) }
    };

    private readonly Dictionary<string, string> _reroutes = new()
    {
        { "localizedNameKey", "id" }, { "questGridConfig", "id" }
    };

    public BoatPaintDataConverter()
    {
        AddDefinitions(_definitions);
        AddReroutes(_reroutes);
    }
}
using System.Collections.Generic;
using Winch.Data.Boat;
using Winch.Util;

namespace Winch.Serialization.Boat;

public class BoatFlagDataConverter : DredgeTypeConverter<BoatFlagData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) },
        { "flagItem", new(string.Empty, null) },
        { "flagTexture", new(TextureUtil.GetTexture("FlagMaterialTemplate"), o=>TextureUtil.GetTexture(o.ToString())) },
        { "localizedNameKey", new(null, null) }
    };

    private readonly Dictionary<string, string> _reroutes = new()
    {
        { "localizedNameKey", "id" }
    };

    public BoatFlagDataConverter()
    {
        AddDefinitions(_definitions);
        AddReroutes(_reroutes);
    }
}
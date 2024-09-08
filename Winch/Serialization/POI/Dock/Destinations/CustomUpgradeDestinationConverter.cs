using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Winch.Util;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomUpgradeDestinationConverter : CustomBaseDestinationConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "visitSFX", new(new AssetReference("7994ba0180486f742a531316472175ee"), null) },
        { "icon", new(TextureUtil.GetSprite("GeneralEquipmentIcon"), null) },
    };

    public CustomUpgradeDestinationConverter()
    {
        AddDefinitions(_definitions);
    }
}

using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Winch.Util;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomShipyardDestinationConverter : CustomMarketDestinationConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "visitSFX", new(new AssetReference("7994ba0180486f742a531316472175ee"), null) },
        { "icon", new(TextureUtil.GetSprite("WheelIcon"), null) },
        { "itemTypesBought", new(ItemType.GENERAL | ItemType.EQUIPMENT, null) },
        { "itemSubtypesBought", new(ItemSubtype.ENGINE | ItemSubtype.ROD | ItemSubtype.GENERAL | ItemSubtype.MATERIAL | ItemSubtype.LIGHT | ItemSubtype.NET, null) },
        { "bulkItemTypesBought", new(ItemType.NONE, null) },
        { "bulkItemSubtypesBought", new(ItemSubtype.NONE, null) },
        { "specificItemsBought", new(new List<string>(), null) },
        { "sellValueModifier", new( 0.5f, null) },
        { "allowSellIfGridFull", new( false, null) },
        { "allowStorageAccess", new( true, null) },
        { "allowRepairs", new( true, null) },
        { "allowBulkSell", new( false, null) },
        { "bulkSellPromptString", new(string.Empty, null) },
        { "bulkSellNotificationString", new(string.Empty, null) },
    };

    public CustomShipyardDestinationConverter()
    {
        AddDefinitions(_definitions);
    }
}

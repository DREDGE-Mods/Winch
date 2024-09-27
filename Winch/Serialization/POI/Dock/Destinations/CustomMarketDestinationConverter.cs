using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomMarketDestinationConverter : CustomBaseDestinationConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "icon", new(TextureUtil.GetSprite("FishIcon"), null) },
        { "playerInventoryTabIndexesToShow", new(new List<int> { 0,1,3 }, null) },
        { "itemTypesBought", new(ItemType.GENERAL | ItemType.EQUIPMENT, o => DredgeTypeHelpers.ParseFlagsEnum<ItemType>(o)) },
        { "itemSubtypesBought", new(ItemSubtype.FISH | ItemSubtype.POT, o => DredgeTypeHelpers.ParseFlagsEnum<ItemSubtype>(o)) },
        { "bulkItemTypesBought", new(ItemType.GENERAL, o => DredgeTypeHelpers.ParseFlagsEnum<ItemType>(o)) },
        { "bulkItemSubtypesBought", new(ItemSubtype.FISH, o => DredgeTypeHelpers.ParseFlagsEnum<ItemSubtype>(o)) },
        { "specificItemsBought", new(new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "sellValueModifier", new( 0.5f, o=> float.Parse(o.ToString())) },
        { "allowSellIfGridFull", new( true, o=> bool.Parse(o.ToString())) },
        { "allowStorageAccess", new( true, o=> bool.Parse(o.ToString())) },
        { "allowRepairs", new( false, o=> bool.Parse(o.ToString())) },
        { "allowBulkSell", new( true, o=> bool.Parse(o.ToString())) },
        { "bulkSellPromptString", new("prompt.sell-all-fish", null) },
        { "bulkSellNotificationString", new("notification.sell-fish-bulk", null) },
        { "marketTabs", new(new List<MarketTabConfig>(), o => DredgeTypeHelpers.ParseMarketTabConfigList((JArray)o)) },
    };

    public CustomMarketDestinationConverter()
    {
        AddDefinitions(_definitions);
    }
}

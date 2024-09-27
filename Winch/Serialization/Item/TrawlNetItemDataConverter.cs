using System.Collections.Generic;
using Winch.Util;
using static ActiveAbilityInfoPanel;
using static TrawlNetAbility;

namespace Winch.Serialization.Item;

public class TrawlNetItemDataConverter : DeployableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("TrawlIcon"), null) },
        { "itemSubtype", new(ItemSubtype.NET, null) },
        { "gridKey", new( GridKey.TRAWL_NET, null ) },
        { "moveMode", new(MoveMode.INSTALL, null) },
        { "abilityMode", new(AbilityMode.TRAWL, o => DredgeTypeHelpers.GetEnumValue<AbilityMode>(o)) },
        { "trawlMode", new(TrawlMode.TRAWL, o => DredgeTypeHelpers.GetEnumValue<TrawlMode>(o)) },
        { "netType", new(NetType.REGULAR, o => DredgeTypeHelpers.GetEnumValue<NetType>(o)) },
        { "qualityIcon", new(null, o => TextureUtil.GetSprite(o.ToString())) },
        { "counterIcon", new(null, o => TextureUtil.GetSprite(o.ToString())) },
    };

    public TrawlNetItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
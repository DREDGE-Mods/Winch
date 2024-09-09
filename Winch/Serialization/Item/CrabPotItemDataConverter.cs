using System.Collections.Generic;
using Winch.Data.Item;
using Winch.Util;
using static ActiveAbilityInfoPanel;

namespace Winch.Serialization.Item;

public class CrabPotItemDataConverter : DeployableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("CrabPotIcon"), null) },
        { "itemSubtype", new(ItemSubtype.POT, null) },
        { "harvestableTypes", new(new HarvestableType[1]{HarvestableType.CRAB}, null) },
        { "abilityMode", new(AbilityMode.POT, o => DredgeTypeHelpers.GetEnumValue<AbilityMode>(o)) },
        { "potType", new(PotType.CRAB, o => DredgeTypeHelpers.GetEnumValue<PotType>(o)) },
        { "qualityIcon", new(null, o => TextureUtil.GetSprite(o.ToString())) },
    };

    public CrabPotItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
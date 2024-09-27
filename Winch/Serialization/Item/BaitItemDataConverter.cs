using System.Collections.Generic;
using UnityEngine;
using Winch.Data.Item;
using Winch.Util;
using static ActiveAbilityInfoPanel;

namespace Winch.Serialization.Item;

public class BaitItemDataConverter : SpatialItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "damageMode", new(DamageMode.DESTROY, null) },
        { "value", new(50m, null) },
        { "hasSellOverride", new(true, null) },
        { "sellOverrideValue", new(10m, null) },
        { "itemColor", new(new Color(0.2275f, 0.1569f, 0.1255f, 1f), null) }, // default game uses
        { "itemTypeIcon", new(TextureUtil.GetSprite("BaitIcon"), null) },
        { "abilityMode", new(AbilityMode.BAIT, o => DredgeTypeHelpers.GetEnumValue<AbilityMode>(o)) },
        { "baitType", new(BaitType.FISH, o => DredgeTypeHelpers.GetEnumValue<BaitType>(o)) },
        { "qualityIcon", new(null, o => TextureUtil.GetSprite(o.ToString())) },
    };

    public BaitItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Upgrade;

public class HullUpgradeDataConverter : UpgradeDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "hullGridConfiguration", new( string.Empty, null) },
        { "engineAudioClip", new(AddressablesUtil.EmptyAssetReference, o=>DredgeTypeHelpers.ParseAudioReference(o.ToString())) },
        { "newCellCount", new(0, o=>int.Parse(o.ToString())) },
        { "hullSprite", new(TextureUtil.GetSprite("EmptyIcon"), o => TextureUtil.GetSprite(o.ToString())) },
    };

    public HullUpgradeDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

using System.Collections.Generic;
using UnityEngine.Localization;
using Winch.Util;

namespace Winch.Serialization.Upgrade;

public class UpgradeDataConverter : DredgeTypeConverter<UpgradeData>
{
    internal static readonly string TableDefinition = LanguageManager.STRING_TABLE;

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new( string.Empty, null) },
        { "tier", new(0, o=>int.Parse(o.ToString())) },
        { "sprite", new(TextureUtil.GetSprite("EmptyIcon"), o => TextureUtil.GetSprite(o.ToString())) },
        { "gridConfig", new( string.Empty, null) },
        { "titleKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "descriptionKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "monetaryCost", new(0m, o=>decimal.Parse(o.ToString())) },
        { "availableInDemo", new(false, o=>bool.Parse(o.ToString())) },
    };

    public UpgradeDataConverter()
    {
        AddDefinitions(_definitions);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(TableDefinition, value);
}

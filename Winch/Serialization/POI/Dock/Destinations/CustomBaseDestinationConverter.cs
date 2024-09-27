using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Data.POI.Dock.Destinations;
using Winch.Util;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomBaseDestinationConverter : DredgeTypeConverter<CustomBaseDestination>
{
    internal static readonly string TableDefinition = LanguageManager.STRING_TABLE;

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new( string.Empty, null) },
        { "titleKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "position", new(Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "vCam", new(Vector3.one, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "lookAtTarget", new(Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "alwaysShow", new( true, o=> bool.Parse(o.ToString())) },
        { "speakerData", new( string.Empty, null) },
        { "speakerRootNodeOverride", new( string.Empty, null) },
        { "visitSFX", new(AddressablesUtil.EmptyAssetReference, o=>DredgeTypeHelpers.ParseAudioReference(o.ToString())) },
        { "loopSFX", new(string.Empty, null) },
        { "isIndoors", new( false, o=> bool.Parse(o.ToString())) },
        { "icon", new(null, o => TextureUtil.GetSprite(o.ToString())) },
        { "playerInventoryTabIndexesToShow", new(new List<int>(), o => DredgeTypeHelpers.ParseIntList((JArray)o)) },
        { "highlightConditions", new(new List<HighlightCondition>(), o=>DredgeTypeHelpers.ParseHighlightConditions((JArray)o)) },
        { "useFixedScreenPosition", new( false, o=> bool.Parse(o.ToString())) },
        { "pointTo", new( Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "screenPosition", new(Vector2.zero, o=> DredgeTypeHelpers.ParseVector2(o)) },
        { "selectOnLeft", new(new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "selectOnRight", new(new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "selectOnUp", new(new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "selectOnDown", new(new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
    };

    public CustomBaseDestinationConverter()
    {
        AddDefinitions(_definitions);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(TableDefinition, value);
}

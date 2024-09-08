using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using Winch.Data.POI.Dock.Destinations;
using Winch.Util;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomBaseDestinationConverter : DredgeTypeConverter<CustomBaseDestination>
{
    internal const string DestinationTableDefinition = "Strings";

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new( string.Empty, null) },
        { "titleKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "position", new( new Vector3(-1.825f, 3, 0.125f), o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "vCam", new( new Vector3(10, 2, 6.675f), o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "lookAtTarget", new(new Vector3(-0.7f, -2f, -0.25f), o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "alwaysShow", new( true, o=> bool.Parse(o.ToString())) },
        { "speakerData", new( string.Empty, null) },
        { "speakerRootNodeOverride", new( string.Empty, null) },
        { "visitSFX", new(new AssetReference(), o=>DredgeTypeHelpers.ParseAudioReference(o.ToString())) },
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

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(DestinationTableDefinition, value);
}

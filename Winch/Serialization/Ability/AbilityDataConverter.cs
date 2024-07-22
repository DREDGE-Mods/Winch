using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Core;
using Winch.Data.Abilities;
using Winch.Serialization.Item;
using Winch.Util;

namespace Winch.Serialization.Ability;

public class AbilityDataConverter : DredgeTypeConverter<ModdedAbilityData>
{
    internal const string TableDefinition = "Strings";

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(null, null) },
        { "autoUnlock", new(true, o=> bool.Parse(o.ToString())) },
        { "nameKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "descriptionKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "shortDescriptionKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "icon", new(TextureUtil.GetSprite("EmptyIcon"), o => TextureUtil.GetSprite(o.ToString())) },
        { "allowDamagedItems", new(false, o=> bool.Parse(o.ToString())) },
        { "allowExhaustedItems", new(false, o=> bool.Parse(o.ToString())) },
        { "allowExitAction", new(false, o=> bool.Parse(o.ToString())) },
        { "canFailCast", new(false, o=> bool.Parse(o.ToString())) },
        { "castTime", new(0f, o => float.Parse(o.ToString())) },
        { "cooldown", new(0f, o => float.Parse(o.ToString())) },
        { "deactivateOnInputLayerChanged", new(false, o=> bool.Parse(o.ToString())) },
        { "duration", new(0f, o => float.Parse(o.ToString())) },
        { "exitActionLayer", new(ActionLayer.NONE, o=> DredgeTypeHelpers.GetEnumValue<ActionLayer>(o) )},
        { "isContinuous", new(false, o=> bool.Parse(o.ToString())) },
        { "linkedItems", new( new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "linkedItemSubtype", new(ItemSubtype.NONE, o=> DredgeTypeHelpers.GetEnumValue<ItemSubtype>(o) )},
        { "persistAbilityToggle", new(false, o=> bool.Parse(o.ToString())) },
        { "requiresAbilityFocus", new(false, o=> bool.Parse(o.ToString())) },
        { "sfxRepeatThreshold", new(0f, o => float.Parse(o.ToString())) },
        { "showsCounter", new(false, o=> bool.Parse(o.ToString())) }
    };

    public AbilityDataConverter()
    {
        AddDefinitions(_definitions);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(TableDefinition, value);
}
using System.Collections.Generic;
using UnityEngine.Localization;
using Winch.Data.POI.Dock.Destinations;
using Winch.Util;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomBaseDestinationTierConverter : DredgeTypeConverter<CustomBaseDestinationTier>
{
    internal static readonly string TableDefinition = LanguageManager.STRING_TABLE;

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "type", new(DestinationTierType.Base, o=>DredgeTypeHelpers.GetEnumValue<DestinationTierType>(o)) },
        { "tierId", new(BuildingTierId.NONE, o=>DredgeTypeHelpers.GetEnumValue<BuildingTierId>(o)) },
        { "tierNameKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "recipeToCreateThis", new( string.Empty, null) },
        { "descriptionDialogueNodeName", new( string.Empty, null) },
        { "postConstructionDialogueNodeName", new( string.Empty, null) },
        { "viewAfterConstruction", new(ConstructableDestinationUI.ConstructionViewState.NONE, o=>DredgeTypeHelpers.GetEnumValue<ConstructableDestinationUI.ConstructionViewState>(o)) },
    };

    public CustomBaseDestinationTierConverter()
    {
        AddDefinitions(_definitions);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(TableDefinition, value);
}

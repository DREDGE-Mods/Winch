using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Winch.Data.ConstructableBuilding;

namespace Winch.Serialization.ConstructableBuilding;

public class ConstructableBuildingDependencyDataConverter : DredgeTypeConverter<DeferredConstructableBuildingDependencyData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) },
        { "tierId", new(BuildingTierId.NONE, o=>DredgeTypeHelpers.GetEnumValue<BuildingTierId>(o)) },
        { "dependentTierIds", new(new List<BuildingTierId>(), o=>DredgeTypeHelpers.GetEnumValues<BuildingTierId>(o)) },
        { "dependentTirWorldPhase", new(0, o => int.Parse(o.ToString())) },
        { "dependentQuestSteps", new(new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "immediate", new(true, o => bool.Parse(o.ToString())) },
    };

    public ConstructableBuildingDependencyDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

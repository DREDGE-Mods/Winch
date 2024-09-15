using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Winch.Data.POI.Dock.Destinations;
using Winch.Util;

namespace Winch.Serialization.POI.Dock.Destinations;
internal class CustomConstructableDestinationDataConverter : DredgeTypeConverter<CustomConstructableDestinationData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "tiers", new(new List<CustomBaseDestinationTier>(), o=>DredgeTypeHelpers.ParseDestinationTiers((JArray)o)) },
        { "productQuestGrid", new(string.Empty, null) },
        { "itemProductPickupReminderDialogueNodeName", new(string.Empty, null) }
    };

    public CustomConstructableDestinationDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Winch.Serialization.Vibration;

public class VibrationDataConverter : DredgeTypeConverter<VibrationData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "vibrationParamsList", new(new List<VibrationParams>(), o=>DredgeTypeHelpers.ParseVibrationParamsList((JArray)o)) }
    };

    public VibrationDataConverter()
    {
        AddDefinitions(_definitions);
    }
}

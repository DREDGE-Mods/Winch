using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winch.Util;

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

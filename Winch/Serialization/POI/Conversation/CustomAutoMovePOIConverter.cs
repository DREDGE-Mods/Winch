using System.Collections.Generic;
using UnityEngine;

namespace Winch.Serialization.POI.Conversation;

public class CustomAutoMovePOIConverter : CustomConversationPOIConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "autoMovePosition", new(Vector3.zero, o=>DredgeTypeHelpers.ParseVector3(o)) },
        { "includeRotation", new(false, o=> bool.Parse(o.ToString())) },
        { "autoMoveRotation", new(Vector3.zero, o=>DredgeTypeHelpers.ParseVector3(o)) },
        { "unlockPlayerMovementAfterConversationCompleted", new(true, o=> bool.Parse(o.ToString())) },
    };
    
    public CustomAutoMovePOIConverter()
    {
        AddDefinitions(_definitions);
    }
}

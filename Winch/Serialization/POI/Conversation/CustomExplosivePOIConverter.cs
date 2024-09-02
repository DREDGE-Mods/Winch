using System.Collections.Generic;

namespace Winch.Serialization.POI.Conversation;

// ReSharper disable HeapView.BoxingAllocation

public class CustomExplosivePOIConverter : CustomConversationPOIConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "conversationNodeName", new("Explosives_Root", null) },
        { "isOneTimeOnly", new(false, null) },
        { "explodeVibration", new(string.Empty, null) },
    };
    
    public CustomExplosivePOIConverter()
    {
        AddDefinitions(_definitions);
    }
}

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Winch.Serialization.POI.Conversation;

public class CustomConversationPOIConverter : CustomPOIConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "conversationNodeName", new( string.Empty, null) },
        { "enabledByOtherNodeVisit", new( false, o=>bool.Parse(o.ToString())) },
        { "enableNodeNames", new( new List<string>(), o=>DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "isOneTimeOnly", new( true, o=>bool.Parse(o.ToString())) },
        { "otherNodeNames", new( new List<string>(), o=>DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "releaseCameraOnComplete", new( true, o=>bool.Parse(o.ToString())) },
        { "shouldDisableOnOtherNodeVisit", new( false, o=>bool.Parse(o.ToString())) },
        { "vCam", new( Vector3.one, o=>DredgeTypeHelpers.ParseVector3(o)) },
    };
    
    public CustomConversationPOIConverter()
    {
        AddDefinitions(_definitions);
    }
}

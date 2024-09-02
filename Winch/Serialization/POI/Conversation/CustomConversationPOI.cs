using Cinemachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Winch.Serialization.POI.Conversation;

public class CustomConversationPOI : CustomPOI
{
    [SerializeField]
    public bool isOneTimeOnly = true;

    [SerializeField]
    public bool releaseCameraOnComplete = true;

    [SerializeField]
    public string conversationNodeName = string.Empty;

    [SerializeField]
    public bool enabledByOtherNodeVisit;

    [SerializeField]
    public List<string> enableNodeNames = new List<string>();

    [SerializeField]
    public bool shouldDisableOnOtherNodeVisit;

    [SerializeField]
    public List<string> otherNodeNames = new List<string>();

    [SerializeField]
    public Vector3 vCam;
}

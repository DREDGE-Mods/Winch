﻿using System.Collections.Generic;
using UnityEngine;

namespace Winch.Data.POI.Conversation;

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

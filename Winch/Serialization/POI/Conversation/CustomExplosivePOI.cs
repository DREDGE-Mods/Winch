using Cinemachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Winch.Serialization.POI.Conversation;

public class CustomExplosivePOI : CustomConversationPOI
{
    [SerializeField]
    public string explodeVibration;
}

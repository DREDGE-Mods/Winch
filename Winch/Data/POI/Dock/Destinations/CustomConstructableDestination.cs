using System;
using UnityEngine;

namespace Winch.Data.POI.Dock.Destinations;

[Serializable]
public class CustomConstructableDestination : CustomBaseDestination
{
    [SerializeField]
    public string useThisDestinationInsteadIfConstructed = null;

    [SerializeField]
    public CustomConstructableDestinationData constructableDestinationData;
}

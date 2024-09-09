using System;
using UnityEngine;

namespace Winch.Data.POI.Dock.Destinations;

[Serializable]
public class CustomConstructableDestination : CustomBaseDestination
{
    [SerializeField]
#pragma warning disable CS8625
    public string useThisDestinationInsteadIfConstructed = null;
#pragma warning restore CS8625

    [SerializeField]
#pragma warning disable CS8618
    public ConstructableDestinationData constructableDestinationData;
#pragma warning restore CS8618
}

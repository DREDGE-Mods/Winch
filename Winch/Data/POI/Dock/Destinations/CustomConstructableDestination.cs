using UnityEngine;

namespace Winch.Data.POI.Dock.Destinations;

public class CustomConstructableDestination : CustomBaseDestination
{
    [SerializeField]
    public string useThisDestinationInsteadIfConstructed = null;

    [SerializeField]
    public ConstructableDestinationData constructableDestinationData;
}

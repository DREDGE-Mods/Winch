using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Winch.Serialization.POI.Dock;

// TODO: actually implement this
public class CustomDockPOI : CustomPOI
{
    [SerializeField]
    public List<Vector3> dockSlots = new List<Vector3>();
}

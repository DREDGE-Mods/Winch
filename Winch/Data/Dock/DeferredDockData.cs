using System.Collections.Generic;
using UnityEngine;

namespace Winch.Data.Dock;

public class DeferredDockData : DockData
{
    [SerializeField]
    public new List<string> speakers = new List<string>();
}

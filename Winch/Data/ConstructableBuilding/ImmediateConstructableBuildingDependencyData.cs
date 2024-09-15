using System;
using System.Collections.Generic;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.ConstructableBuilding;

[Serializable]
public class ImmediateConstructableBuildingDependencyData : ConstructableBuildingDependencyData
{
    [SerializeField]
    public bool immediate = true;
}

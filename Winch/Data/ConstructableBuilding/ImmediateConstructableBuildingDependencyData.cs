using System;
using UnityEngine;

namespace Winch.Data.ConstructableBuilding;

[Serializable]
public class ImmediateConstructableBuildingDependencyData : ConstructableBuildingDependencyData
{
    [SerializeField]
    public bool immediate = true;
}

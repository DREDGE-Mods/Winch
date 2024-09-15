using System;
using System.Collections.Generic;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.ConstructableBuilding;

[Serializable]
public class DeferredConstructableBuildingDependencyData : ImmediateConstructableBuildingDependencyData
{
    [SerializeField]
    public string id = string.Empty;

    [SerializeField]
    public new List<string> dependentQuestSteps = new List<string>();

    public void Populate()
    {
        base.dependentQuestSteps = QuestUtil.TryGetQuestSteps(dependentQuestSteps);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.Quest;

public class DeferredQuestData : QuestData
{
    [SerializeField]
    public string id = string.Empty;

    [SerializeField]
    public new List<string> mapMarkersToRemoveOnCompletion = new List<string>();

    [SerializeField]
    public new List<string> steps = new List<string>();

    [SerializeField]
    public new List<string> subquests = new List<string>();

    [SerializeField]
    public new string onOfferedQuestStep = string.Empty;

    internal void Populate()
    {
        base.mapMarkersToRemoveOnCompletion = MapMarkerUtil.TryGetMapMarkers(mapMarkersToRemoveOnCompletion);
        base.steps = QuestUtil.TryGetQuestSteps(steps);
        base.subquests = QuestUtil.TryGetQuests(subquests);
        base.onOfferedQuestStep = QuestUtil.GetQuestStepData(onOfferedQuestStep);
    }
}

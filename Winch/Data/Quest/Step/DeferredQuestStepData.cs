using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.Quest.Step;

public class DeferredQuestStepData : QuestStepData
{
    [SerializeField]
    public string id = string.Empty;

    [SerializeField]
    public new List<string> mapMarkersToAddOnStart = new List<string>();

    [SerializeField]
    public new List<string> mapMarkersToDeleteOnCompletion = new List<string>();

    [SerializeField]
    public new string hideIfThisStepIsComplete = string.Empty;

    [SerializeField]
    public new string stepDock = string.Empty;

    [SerializeField]
    public new string stepSpeaker = string.Empty;

    internal void Populate()
    {
        base.mapMarkersToAddOnStart = MapMarkerUtil.TryGetMapMarkers(mapMarkersToAddOnStart);
        base.mapMarkersToDeleteOnCompletion = MapMarkerUtil.TryGetMapMarkers(mapMarkersToDeleteOnCompletion);
        base.hideIfThisStepIsComplete = QuestUtil.GetQuestStepData(hideIfThisStepIsComplete);
        base.stepDock = DockUtil.GetDockData(stepDock);
        base.stepSpeaker = CharacterUtil.GetSpeakerData(stepSpeaker);
    }
}

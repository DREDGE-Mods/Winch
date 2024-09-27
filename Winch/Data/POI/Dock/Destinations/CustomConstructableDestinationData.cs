using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.POI.Dock.Destinations;

[Serializable]
public class CustomConstructableDestinationData
{
    [SerializeField]
    public List<CustomBaseDestinationTier> tiers = new List<CustomBaseDestinationTier>();

    [SerializeField]
    public string productQuestGrid = string.Empty;

    [SerializeField]
    public string itemProductPickupReminderDialogueNodeName = string.Empty;

    public QuestGridConfig ProductQuestGrid => QuestUtil.GetQuestGridConfig(productQuestGrid);

    public List<BaseDestinationTier> Tiers => tiers.Select(tier => tier.ToVanilla()).ToList();
}
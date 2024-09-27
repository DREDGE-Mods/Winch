using UnityEngine;
using Winch.Util;

namespace Winch.Data.Item.Prerequisites;

internal class ModdedResearchedItemResearchablePrerequisite : ResearchedItemResearchablePrerequisite
{
    [SerializeField]
    public string itemId = string.Empty;

    public override bool IsPrerequisiteMet()
    {
        if (!string.IsNullOrWhiteSpace(itemId) && ItemUtil.SpatialItemDataDict.TryGetValue(itemId, out itemData))
        {
            return base.IsPrerequisiteMet();
        }
        return false;
    }
}

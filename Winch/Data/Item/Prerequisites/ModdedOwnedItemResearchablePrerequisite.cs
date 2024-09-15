using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.Item.Prerequisites;

internal class ModdedOwnedItemResearchablePrerequisite : OwnedItemResearchablePrerequisite
{
    [SerializeField]
    public string itemId = string.Empty;

    public override bool IsPrerequisiteMet()
    {
        if (!string.IsNullOrWhiteSpace(itemId) && ItemUtil.AllItemDataDict.TryGetValue(itemId, out itemData))
        {
            return base.IsPrerequisiteMet();
        }
        return false;
    }
}
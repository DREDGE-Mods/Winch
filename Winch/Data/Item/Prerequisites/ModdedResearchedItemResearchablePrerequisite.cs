using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winch.Util;

namespace Winch.Data.Item.Prerequisites
{
    internal class ModdedResearchedItemResearchablePrerequisite : ResearchedItemResearchablePrerequisite
    {
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
}

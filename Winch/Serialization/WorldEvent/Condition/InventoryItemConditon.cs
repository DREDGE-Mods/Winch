using System.Collections.Generic;
using System.Linq;
using Winch.Util;

namespace Winch.Serialization.WorldEvent.Condition
{
    public abstract class InventoryItemConditon : InventoryCondition
    {
        public string id;

        public ItemData ItemData
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(id) && ItemUtil.AllItemDataDict.TryGetValue(id, out var itemData))
                {
                    return itemData;
                }
                return null;
            }
        }

        public abstract override bool Evaluate();

        public bool EvaluateItemInstance(SpatialItemInstance instance) => EvaluateItem(instance.GetItemData<SpatialItemData>());

        public bool EvaluateItem(SpatialItemData data) => data == ItemData;
    }
}
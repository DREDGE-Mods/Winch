using System.Collections.Generic;
using System.Linq;
using Winch.Util;

namespace Winch.Serialization.WorldEvent.Condition
{
    public class NumItemsOfSizeAndTypeNetCondition : NumItemsOfTypeNetCondition
    {
        public override bool Evaluate()
        {
            int num = 0;
            List<SpatialItemInstance> list = GameManager.Instance.SaveData.TrawlNet.GetAllItemsOfType<SpatialItemInstance>(itemType, itemSubtype).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                SpatialItemData itemData = list[i].GetItemData<SpatialItemData>();
                if (max && itemData.GetSize() <= size)
                {
                    num++;
                }
                else if (min && itemData.GetSize() >= size)
                {
                    num++;
                }
            }
            return num >= minNumber;
        }

        public int size;

        public bool max;

        public bool min;
    }
}
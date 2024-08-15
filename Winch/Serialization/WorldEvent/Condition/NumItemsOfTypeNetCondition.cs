using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Winch.Util;

namespace Winch.Serialization.WorldEvent.Condition
{
    public class NumItemsOfTypeNetCondition : NumOfItemNetCondition
    {
        public override bool Evaluate() => GameManager.Instance.SaveData.TrawlNet.GetAllItemsOfType<SpatialItemInstance>(itemType, itemSubtype).Count >= minNumber;

        public ItemType itemType;

        public ItemSubtype itemSubtype;
    }
}
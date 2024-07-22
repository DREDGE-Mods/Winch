using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winch.Serialization.WorldEvent.Condition
{
    public enum InventoryConditionType
    {
        AnyOfItem,
        NumOfItem,
        NumItemsOfType,
        NumItemsOfSizeAndType,
    }
}

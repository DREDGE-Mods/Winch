using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winch.Data.WorldEvent.Condition;

public enum InventoryConditionType
{
    AnyOfItem,
    NumOfItem,
    NumItemsOfType,
    NumItemsOfSizeAndType,
}
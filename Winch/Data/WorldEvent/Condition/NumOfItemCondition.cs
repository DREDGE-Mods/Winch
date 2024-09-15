using System.Collections.Generic;
using System.Linq;
using Winch.Util;

namespace Winch.Data.WorldEvent.Condition;

public class NumOfItemCondition : InventoryItemConditon
{
    public override bool Evaluate() => GameManager.Instance.SaveData.Inventory.spatialItems.Where(EvaluateItemInstance).Count() >= minNumber;

    public int minNumber;
}
using System.Collections.Generic;
using System.Linq;
using Winch.Util;

namespace Winch.Data.WorldEvent.Condition;

public class AnyOfItemCondition : InventoryItemConditon
{
    public override bool Evaluate() => GameManager.Instance.SaveData.Inventory.spatialItems.Any(EvaluateItemInstance);
}
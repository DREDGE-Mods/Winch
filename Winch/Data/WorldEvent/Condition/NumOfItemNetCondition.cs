using System.Linq;

namespace Winch.Data.WorldEvent.Condition;

public class NumOfItemNetCondition : NumOfItemCondition
{
    public override bool Evaluate() => GameManager.Instance.SaveData.TrawlNet.spatialItems.Where(EvaluateItemInstance).Count() >= minNumber;
}

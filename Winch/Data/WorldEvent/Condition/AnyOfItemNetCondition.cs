using System.Linq;

namespace Winch.Data.WorldEvent.Condition;

public class AnyOfItemNetCondition : AnyOfItemCondition
{
    public override bool Evaluate() => GameManager.Instance.SaveData.TrawlNet.spatialItems.Any(EvaluateItemInstance);
}
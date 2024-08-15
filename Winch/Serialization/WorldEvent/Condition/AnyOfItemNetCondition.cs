using System.Collections.Generic;
using System.Linq;
using Winch.Util;

namespace Winch.Serialization.WorldEvent.Condition
{
    public class AnyOfItemNetCondition : AnyOfItemCondition
	{
        public override bool Evaluate() => GameManager.Instance.SaveData.TrawlNet.spatialItems.Any(EvaluateItemInstance);
    }
}
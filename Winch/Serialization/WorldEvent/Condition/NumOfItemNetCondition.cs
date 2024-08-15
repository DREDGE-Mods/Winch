using System.Collections.Generic;
using System.Linq;
using Winch.Util;

namespace Winch.Serialization.WorldEvent.Condition
{
    public class NumOfItemNetCondition : NumOfItemCondition
    {
        public override bool Evaluate() => GameManager.Instance.SaveData.TrawlNet.spatialItems.Where(EvaluateItemInstance).Count() >= minNumber;
    }
}
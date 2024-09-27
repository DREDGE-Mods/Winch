using Winch.Util;

namespace Winch.Data.Quest.Grid.Condition;

public class DeferredItemCountCondition : ItemCountCondition
{
    public new string item = string.Empty;

    public void Populate()
    {
        base.item = ItemUtil.GetSpatialItemData(item);
    }

    public override bool Evaluate(SerializableGrid grid)
    {
        Populate();
        return base.Evaluate(grid);
    }

    public DeferredItemCountCondition() : base()
    {
        Populate();
    }
}

namespace Winch.Data.Quest.Grid.Condition;

public class FullCondition : CompletedGridCondition
{
    public override bool Evaluate(SerializableGrid grid)
    {
        return grid.GetFillProportional() >= 1;
    }
}

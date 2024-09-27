namespace Winch.Data.Quest.Grid.Condition;

public enum CompletedGridConditionType
{
    Empty = -1,
    Full = 0,
    ItemCount,
    AberrationCount,
    ExactCountOfItemTypeAndSubtype,
    CellCountOfItemTypeAndSubtype
}
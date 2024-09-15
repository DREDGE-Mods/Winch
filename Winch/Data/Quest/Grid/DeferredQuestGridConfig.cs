using System.Linq;
using UnityEngine;
using Winch.Data.Quest.Grid.Condition;
using Winch.Util;

namespace Winch.Data.Quest.Grid;

public class DeferredQuestGridConfig : QuestGridConfig
{
    [SerializeField]
    public string id = string.Empty;

    [SerializeField]
    public new string gridConfiguration = string.Empty;

    public GridConfiguration GridConfiguration
    {
        get
        {
            return base.gridConfiguration = GridConfigUtil.GetGridConfiguration(gridConfiguration);
        }
        set
        {
            gridConfiguration = value != null ? value.name : string.Empty;
            base.gridConfiguration = value;
        }
    }

    internal void Populate()
    {
        base.gridConfiguration = GridConfigUtil.GetGridConfiguration(gridConfiguration);
        foreach (var condition in completeConditions.OfType<DeferredItemCountCondition>())
            condition.Populate();
    }
}
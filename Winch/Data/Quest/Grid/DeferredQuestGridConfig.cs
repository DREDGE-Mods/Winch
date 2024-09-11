using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.Quest.Grid;

public class DeferredQuestGridConfig : QuestGridConfig
{
    [SerializeField]
    public string id = string.Empty;

    [SerializeField]
    public new string gridConfiguration = string.Empty;

    internal void Populate()
    {
        base.gridConfiguration = GridConfigUtil.GetGridConfiguration(gridConfiguration);
    }
}
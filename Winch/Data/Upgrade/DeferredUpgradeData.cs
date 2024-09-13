using System.Collections.Generic;
using Winch.Util;

namespace Winch.Data.Upgrade;

public interface IDeferredUpgradeData
{
    public abstract void Populate();
}

public abstract class DeferredUpgradeData : UpgradeData, IDeferredUpgradeData
{
    public new string gridConfig = string.Empty;

    public new List<string> prerequisiteUpgrades = new List<string>();

    public virtual void Populate()
    {
        base.gridConfig = QuestUtil.GetQuestGridConfig(gridConfig);
        base.prerequisiteUpgrades = UpgradeUtil.TryGetUpgrades(prerequisiteUpgrades);
    }
}

public class DeferredHullUpgradeData : HullUpgradeData, IDeferredUpgradeData
{
    public new string gridConfig = string.Empty;

    public new List<string> prerequisiteUpgrades = new List<string>();

    public new string hullGridConfiguration = string.Empty;

    public virtual void Populate()
    {
        base.gridConfig = QuestUtil.GetQuestGridConfig(gridConfig);
        base.prerequisiteUpgrades = UpgradeUtil.TryGetUpgrades(prerequisiteUpgrades);
        base.hullGridConfiguration = GridConfigUtil.GetGridConfiguration(hullGridConfiguration);
    }
}

public class DeferredSlotUpgradeData : SlotUpgradeData, IDeferredUpgradeData
{
    public new string gridConfig = string.Empty;

    public new List<string> prerequisiteUpgrades = new List<string>();

    public virtual void Populate()
    {
        base.gridConfig = QuestUtil.GetQuestGridConfig(gridConfig);
        base.prerequisiteUpgrades = UpgradeUtil.TryGetUpgrades(prerequisiteUpgrades);
    }
}

using Winch.Util;

namespace Winch.Data.Recipe;

public interface IDeferredRecipeData
{
    public abstract void Populate();
}

public abstract class DeferredRecipeData : RecipeData, IDeferredRecipeData
{
    public new string questGridConfig = string.Empty;

    public virtual void Populate()
    {
        base.questGridConfig = QuestUtil.GetQuestGridConfig(questGridConfig);
    }
}

public class DeferredAbilityRecipeData : AbilityRecipeData, IDeferredRecipeData
{
    public new string questGridConfig = string.Empty;

    public new string abilityData = string.Empty;

    public virtual void Populate()
    {
        base.questGridConfig = QuestUtil.GetQuestGridConfig(questGridConfig);
        base.abilityData = AbilityUtil.GetAbilityData(abilityData);
    }
}

public class DeferredItemRecipeData : ItemRecipeData, IDeferredRecipeData
{
    public new string questGridConfig = string.Empty;

    public new string itemProduced = string.Empty;

    public virtual void Populate()
    {
        base.questGridConfig = QuestUtil.GetQuestGridConfig(questGridConfig);
        base.itemProduced = ItemUtil.GetSpatialItemData(itemProduced);
    }
}

public class DeferredBuildingRecipeData : BuildingRecipeData, IDeferredRecipeData
{
    public new string questGridConfig = string.Empty;

    public virtual void Populate()
    {
        base.questGridConfig = QuestUtil.GetQuestGridConfig(questGridConfig);
    }
}

public class DeferredHullRecipeData : HullRecipeData, IDeferredRecipeData
{
    public new string questGridConfig = string.Empty;

    public new string hullUpgradeData = string.Empty;

    public virtual void Populate()
    {
        base.questGridConfig = QuestUtil.GetQuestGridConfig(questGridConfig);
        base.hullUpgradeData = UpgradeUtil.GetHullUpgradeData(hullUpgradeData);
    }
}
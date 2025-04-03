using System;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Core;
using Winch.Util;

namespace Winch.Data.Recipe;

public class SlotRecipeData : RecipeData
{
    public SlotUpgradeData slotUpgradeData;

    public override Sprite GetSprite()
    {
        return slotUpgradeData.sprite;
    }

    public override int GetWidth()
    {
        return 2;
    }

    public override int GetHeight()
    {
        return 2;
    }

    public override LocalizedString GetItemNameKey()
    {
        return slotUpgradeData.TitleKey;
    }

    public override int GetQuantityProduced()
    {
        return 1;
    }

    public bool IsOneTimeAndAlreadyOwned()
    {
        return GameManager.Instance.SaveData.GetIsUpgradeOwned(slotUpgradeData);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Util;

namespace Winch.Data.Recipe;

public abstract class ModdedRecipeData : DeferredRecipeData
{
    public virtual bool IsOneTimeAndAlreadyOwned()
    {
        return false;
    }

    public virtual object[] GetNameArguments()
    {
        return new object[0];
    }

    public abstract void OnRecipeCompleted();

    public abstract LocalizedString GetItemDescriptionKey();

    public virtual Color GetItemNameColor() => Color.white;

    public virtual Color GetItemDescriptionColor() => Color.white;

    public virtual Sprite GetTooltipIcon() => null;

    public void Register()
    {
        if (string.IsNullOrWhiteSpace(recipeId)) throw new NullReferenceException(nameof(recipeId));

        RecipeUtil.RegisterModdedRecipeData(recipeId, this);
    }
}

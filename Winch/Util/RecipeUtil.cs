using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Winch.Core;
using Winch.Data.Recipe;
using Winch.Serialization;
using Winch.Serialization.Recipe;

namespace Winch.Util;

public static class RecipeUtil
{
    private static Dictionary<Type, IDredgeTypeConverter> Converters = new()
    {
        { typeof(DeferredAbilityRecipeData), new AbilityRecipeDataConverter() },
        { typeof(DeferredBuildingRecipeData), new BuildingRecipeDataConverter() },
        { typeof(DeferredHullRecipeData), new HullRecipeDataConverter() },
        { typeof(DeferredItemRecipeData), new ItemRecipeDataConverter() },
        { typeof(DeferredRecipeData), new RecipeDataConverter() },
    };

    internal static bool PopulateObjectFromMetaWithConverters<T>(T item, Dictionary<string, object> meta) where T : RecipeData, IDeferredRecipeData
    {
        return UtilHelpers.PopulateObjectFromMeta<T>(item, meta, Converters);
    }

    internal static List<string> VanillaRecipeIDList = new List<string>
    {
        "tir-rig-base",
        "tir-rig-science-lab-1",
        "tir-rnd-tier-1",
        "tir-rnd-tier-2",
        "tir-defenses-tier-1",
        "tir-fleet-services-tier-1",
        "tir-factory-tier-1",
        "tir-factory-tier-2",
        "tir-factory-tier-3",
        "tir-factory-tier-4",
        "tir-foundry-tier-1",
        "tir-foundry-tier-2",
        "tir-rod1-recipe",
        "tir-rod2-recipe",
        "tir-rod3-recipe",
        "tir-rod4-recipe",
        "tir-rod5-recipe",
        "tir-net1-recipe",
        "tir-net2-recipe",
        "tir-pot1-recipe",
        "tir-gadget1-recipe",
        "tir-gadget2-recipe",
        "tir-gadget3-recipe",
        "tir-gadget4-recipe",
        "tir-gadget5-recipe",
        "tir-gadget6-recipe",
        "tir-ability1-recipe",
        "tir-ability2-recipe",
        "tir-ability3-recipe",
        "tir-crate-recipe",
        "tir-lumber-recipe",
        "tir-cloth-recipe",
        "tir-scrap-recipe",
        "tir-refined-metal-recipe",
        "tir-canister-recipe",
        "tir-research-part-recipe",
        "tir-repair-panic-recipe",
        "tir-repair-pot-recipe",
        "tir-repair-kit-recipe",
        "tir-bait-ab-recipe",
        "tir-bait-exotic-recipe",
        "tir-bait-crab-recipe",
        "tier-5-hull-recipe",
    };

    internal static Dictionary<string, RecipeData> ModdedRecipeDataDict = new();
    internal static Dictionary<string, RecipeData> AllRecipeDataDict = new();
    internal static Dictionary<string, AbilityRecipeData> AllAbilityRecipeDataDict = new();
    internal static Dictionary<string, BuildingRecipeData> AllBuildingRecipeDataDict = new();
    internal static Dictionary<string, HullRecipeData> AllHullRecipeDataDict = new();
    internal static Dictionary<string, ItemRecipeData> AllItemRecipeDataDict = new();

    public static void RegisterModdedRecipeData(string id, RecipeData recipeData)
    {
        if (recipeData == null)
        {
            WinchCore.Log.Error($"Couldn't register null RecipeData");
            return;
        }

        if (VanillaRecipeIDList.Contains(id))
        {
            WinchCore.Log.Error($"Recipe {id} already exists in vanilla.");
            return;
        }

        if (ModdedRecipeDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate recipe data {id} failed to register");
            return;
        }

        recipeData.recipeId = id;
        ModdedRecipeDataDict.Add(id, recipeData);
        AddressablesUtil.AddResourceAtLocation("RecipeData", id, id, recipeData);
    }

    public static RecipeData GetModdedRecipeData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedRecipeDataDict.TryGetValue(id, out RecipeData recipeData))
            return recipeData;
        else
            return null;
    }

    public static RecipeData GetRecipeData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllRecipeDataDict.TryGetValue(id, out var recipe))
            return recipe;

        if (ModdedRecipeDataDict.TryGetValue(id, out var moddedRecipe))
            return moddedRecipe;

        return null;
    }

    public static AbilityRecipeData GetAbilityRecipeData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllAbilityRecipeDataDict.TryGetValue(id, out var recipe))
            return recipe;

        return null;
    }

    public static BuildingRecipeData GetBuildingRecipeData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllBuildingRecipeDataDict.TryGetValue(id, out var recipe))
            return recipe;

        return null;
    }

    public static HullRecipeData GetHullRecipeData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllHullRecipeDataDict.TryGetValue(id, out var recipe))
            return recipe;

        return null;
    }

    public static ItemRecipeData GetItemRecipeData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllItemRecipeDataDict.TryGetValue(id, out var recipe))
            return recipe;

        return null;
    }

    internal static List<RecipeData> TryGetRecipes(List<string> ids)
    {
        List<RecipeData> recipes = new List<RecipeData>();

        if (ids == null)
            return recipes;

        foreach (var recipe in ids)
        {
            if (!string.IsNullOrWhiteSpace(recipe) && AllRecipeDataDict.TryGetValue(recipe, out var recipeData))
            {
                recipes.Add(recipeData);
            }
        }

        return recipes;
    }

    internal static void PopulateRecipeData()
    {
        foreach (var recipeData in Resources.FindObjectsOfTypeAll<RecipeData>())
        {
            AllRecipeDataDict.SafeAdd(recipeData.recipeId, recipeData);
            WinchCore.Log.Debug($"Added recipe data {recipeData.recipeId} to AllRecipeDataDict");
            if (recipeData is AbilityRecipeData abilityRecipeData)
            {
                AllAbilityRecipeDataDict.SafeAdd(abilityRecipeData.recipeId, abilityRecipeData);
                WinchCore.Log.Debug($"Added recipe data {abilityRecipeData.recipeId} to AllAbilityRecipeDataDict");
            }
            if (recipeData is BuildingRecipeData buildingRecipeData)
            {
                AllBuildingRecipeDataDict.SafeAdd(buildingRecipeData.recipeId, buildingRecipeData);
                WinchCore.Log.Debug($"Added recipe data {buildingRecipeData.recipeId} to AllBuildingRecipeDataDict");
            }
            if (recipeData is HullRecipeData hullRecipeData)
            {
                AllHullRecipeDataDict.SafeAdd(hullRecipeData.recipeId, hullRecipeData);
                WinchCore.Log.Debug($"Added recipe data {hullRecipeData.recipeId} to AllHullRecipeDataDict");
            }
            if (recipeData is ItemRecipeData itemRecipeData)
            {
                AllItemRecipeDataDict.SafeAdd(itemRecipeData.recipeId, itemRecipeData);
                WinchCore.Log.Debug($"Added recipe data {itemRecipeData.recipeId} to AllItemRecipeDataDict");
            }
        }
        PopulateModdedRecipeData();
    }

    internal static void PopulateModdedRecipeData()
    {
        foreach (var recipeData in ModdedRecipeDataDict.Values.OfType<IDeferredRecipeData>())
        {
            recipeData.Populate();
        }
    }

    internal static void ClearRecipeData()
    {
        AllRecipeDataDict.Clear();
        AllAbilityRecipeDataDict.Clear();
        AllBuildingRecipeDataDict.Clear();
        AllHullRecipeDataDict.Clear();
        AllItemRecipeDataDict.Clear();
    }

    internal static void AddRecipeDataFromMeta<T>(string metaPath) where T : RecipeData, IDeferredRecipeData
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var recipeData = UtilHelpers.GetScriptableObjectFromMeta<T>(meta, metaPath);
        if (recipeData == null)
        {
            WinchCore.Log.Error($"Couldn't create RecipeData");
            return;
        }
        var id = (string)meta["id"];
        if (VanillaRecipeIDList.Contains(id))
        {
            WinchCore.Log.Error($"Recipe {id} already exists in vanilla.");
            return;
        }
        if (ModdedRecipeDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate recipe data {id} at {metaPath} failed to load");
            return;
        }
        meta["recipeId"] = id;
        if (PopulateObjectFromMetaWithConverters<T>(recipeData, meta))
        {
            ModdedRecipeDataDict.Add(id, recipeData);
            AddressablesUtil.AddResourceAtLocation("RecipeData", id, id, recipeData);
        }
        else
        {
            WinchCore.Log.Error($"No recipe data converter found");
        }
    }

    public static RecipeData[] GetAllRecipeData()
    {
        return AllRecipeDataDict.Values.ToArray();
    }

    public static AbilityRecipeData[] GetAllAbilityRecipeData()
    {
        return AllAbilityRecipeDataDict.Values.ToArray();
    }

    public static BuildingRecipeData[] GetAllBuildingRecipeData()
    {
        return AllBuildingRecipeDataDict.Values.ToArray();
    }

    public static HullRecipeData[] GetAllHullRecipeData()
    {
        return AllHullRecipeDataDict.Values.ToArray();
    }

    public static ItemRecipeData[] GetAllItemRecipeData()
    {
        return AllItemRecipeDataDict.Values.ToArray();
    }
}

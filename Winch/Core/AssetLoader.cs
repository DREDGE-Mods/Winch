using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Winch.Util;
using Winch.Data.Item;
using Winch.Data.POI;
using Winch.Data.POI.Conversation;
using Winch.Data.POI.Item;
using Winch.Data.POI.Dock;
using Winch.Data.POI.Harvest;
using Winch.Data.Upgrade;
using Winch.Data.Recipe;
using System.Linq;

namespace Winch.Core;

internal static class AssetLoader
{
    internal static void LoadAssets()
    {
        WinchCore.Log.Debug("Loading assets...");

        string winchAssetFolderPath = Path.Combine(Paths.WinchRootPath, "Assets");
        if (Directory.Exists(winchAssetFolderPath))
            LoadAssetFolder(winchAssetFolderPath);

        try
        {
            UpgradeUtil.Initialize();
            ItemUtil.Initialize();
            GridConfigUtil.Initialize();
            WorldEventUtil.Initialize();
            MapMarkerUtil.Initialize();
            QuestUtil.Initialize();
            BoatUtil.Initialize();
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Failed to initialize winch utils: {ex}");
        }

        foreach (var modAssembly in ModAssemblyLoader.EnabledModAssemblies.Values)
        {
            ModAssemblyLoader.ForceModContext(modAssembly);
            try
            {
                string assetFolderPath = modAssembly.AssetsPath;
                if (Directory.Exists(assetFolderPath))
                    LoadAssetFolder(assetFolderPath);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Error loading assets for {modAssembly.GUID}: {ex}");
            }
            ModAssemblyLoader.ClearModContext();
        }

        try
        {
            BoatUtil.PostInitialize();
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Failed to post initialize winch utils: {ex}");
        }
    }

    private static void LoadAssetFolder(string path)
    {
        string bundlesFolderpath = Path.Combine(path, "Bundles");
        string localizationFolderPath = Path.Combine(path, "Localization");
        string textureFolderPath = Path.Combine(path, "Textures");
        string audioFolderPath = Path.Combine(path, "Audio");
        string gridConfigFolderpath = Path.Combine(path, "GridConfigs");
        string itemFolderPath = Path.Combine(path, "Items");
        string poiFolderpath = Path.Combine(path, "POI");
        string harvestZoneFolderpath = Path.Combine(path, "HarvestZones");
        string vibrationFolderpath = Path.Combine(path, "Vibrations");
        string buildingFolderpath = Path.Combine(path, "Buildings");
        string mapMarkerFolderpath = Path.Combine(path, "MapMarkers");
        string questFolderpath = Path.Combine(path, "Quests");
        string questStepFolderpath = Path.Combine(questFolderpath, "Steps");
        string questGridConfigFolderpath = Path.Combine(questFolderpath, "GridConfigs");
        string upgradeFolderpath = Path.Combine(path, "Upgrades");
        string shopFolderpath = Path.Combine(path, "Shops");
        string dockFolderpath = Path.Combine(path, "Docks");
        string abilityFolderpath = Path.Combine(path, "Abilities");
        string worldEventFolderpath = Path.Combine(path, "WorldEvents");
        string recipeFolderpath = Path.Combine(path, "Recipes");
        string dialogueFolderpath = Path.Combine(path, "Dialogues");
        string characterFolderpath = Path.Combine(path, "Characters");
        string boatFolderpath = Path.Combine(path, "Boat");
        string paintFolderpath = Path.Combine(boatFolderpath, "Paints");
        string flagFolderpath = Path.Combine(boatFolderpath, "Flags");

        if(Directory.Exists(bundlesFolderpath)) LoadAssetBundleFiles(bundlesFolderpath);
        if(Directory.Exists(localizationFolderPath)) LoadLocalizationFiles(localizationFolderPath);
        if(Directory.Exists(textureFolderPath)) LoadTextureFiles(textureFolderPath);
        if(Directory.Exists(audioFolderPath)) LoadAudioFiles(audioFolderPath);
        if(Directory.Exists(gridConfigFolderpath)) LoadGridConfigFiles(gridConfigFolderpath);
        if(Directory.Exists(itemFolderPath)) LoadItemFiles(itemFolderPath);
        if(Directory.Exists(vibrationFolderpath)) LoadVibrationFiles(vibrationFolderpath);
        if(Directory.Exists(buildingFolderpath)) LoadBuildingFiles(buildingFolderpath);
        if(Directory.Exists(mapMarkerFolderpath)) LoadMapMarkerFiles(mapMarkerFolderpath);
        if(Directory.Exists(questStepFolderpath)) LoadQuestStepFiles(questStepFolderpath);
        if(Directory.Exists(questFolderpath)) LoadQuestFiles(questFolderpath);
        if(Directory.Exists(questGridConfigFolderpath)) LoadQuestGridConfigFiles(questGridConfigFolderpath);
        if(Directory.Exists(upgradeFolderpath)) LoadUpgradeFiles(upgradeFolderpath);
        if(Directory.Exists(shopFolderpath)) LoadShopFiles(shopFolderpath);
        if(Directory.Exists(dockFolderpath)) LoadDockFiles(dockFolderpath);
        if(Directory.Exists(poiFolderpath)) LoadPoiFiles(poiFolderpath);
        if(Directory.Exists(harvestZoneFolderpath)) LoadHarvestZoneFiles(harvestZoneFolderpath);
        if(Directory.Exists(abilityFolderpath)) LoadAbilityFiles(abilityFolderpath);
        if(Directory.Exists(worldEventFolderpath)) LoadWorldEventFiles(worldEventFolderpath);
        if(Directory.Exists(recipeFolderpath)) LoadRecipeFiles(recipeFolderpath);
        if(Directory.Exists(dialogueFolderpath)) LoadDialogueFiles(dialogueFolderpath);
        if(Directory.Exists(characterFolderpath)) LoadCharacterFiles(characterFolderpath);
        if(Directory.Exists(paintFolderpath)) LoadBoatPaintFiles(paintFolderpath);
        if(Directory.Exists(flagFolderpath)) LoadBoatFlagFiles(flagFolderpath);
    }

    /// <summary>
    /// <see cref="AlphanumComparer"/>
    /// </summary>
    public static string[] GetSortedFiles(IEnumerable<string> files)
    {
        return files.OrderBy(file => Path.GetFileNameWithoutExtension(file), AlphanumComparer.Instance).ToArray();
    }

    /// <inheritdoc cref="Directory.GetFiles(string)"/>
    public static string[] GetSortedFiles(string path)
    {
        return GetSortedFiles(Directory.GetFiles(path));
    }

    /// <inheritdoc cref="Directory.GetFiles(string, string)"/>
    public static string[] GetSortedFiles(string path, string searchPattern)
    {
        return GetSortedFiles(Directory.GetFiles(path, searchPattern));
    }

    /// <inheritdoc cref="Directory.GetFiles(string, string, SearchOption)"/>
    public static string[] GetSortedFiles(string path, string searchPattern, SearchOption searchOption)
    {
        return GetSortedFiles(Directory.GetFiles(path, searchPattern, searchOption));
    }

    private static void LoadAssetBundleFiles(string bundlesFolderpath)
    {
        string[] bundleFiles = GetSortedFiles(bundlesFolderpath);
        foreach (string file in bundleFiles)
        {
            try
            {
                if (file.EndsWith("manifest")) continue;
                AssetBundleUtil.LoadBundle(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load asset bundle from {file}: {ex}");
            }
        }
    }

    private static Dictionary<Type, string> _poiPathData = new Dictionary<Type, string>()
    {
        { typeof(CustomHarvestPOI), "Harvest"},
        { typeof(CustomItemPOI), "Item"},
        { typeof(CustomDockPOI), "Dock"},
        { typeof(CustomAutoMovePOI), "Conversation/AutoMove"},
        { typeof(CustomExplosivePOI), "Conversation/Explosive"},
        { typeof(CustomInspectPOI), "Conversation/Inspect"}
    };

    private static void LoadPoiFiles(string poiFolderPath)
    {
        foreach (KeyValuePair<Type, string> poi in _poiPathData)
        {
            var baseMethod = typeof(AssetLoader).GetMethod(nameof(AssetLoader.LoadPoiFilesOfType), BindingFlags.NonPublic | BindingFlags.Static);
            var genericMethod = baseMethod.MakeGenericMethod(poi.Key);
            var itemPath = Path.Combine(poiFolderPath, poi.Value);
            if (Directory.Exists(itemPath))
            {
                genericMethod.Invoke(null, new object[] { itemPath });
            }

        }
    }

    private static Dictionary<Type, string> _itemDataPathData = new Dictionary<Type, string>()
    {
        { typeof(NonSpatialItemData), "NonSpatial"},
        { typeof(SpatialItemData), "General"},
        { typeof(HarvestableItemData), "Harvestable"},
        { typeof(AberrationableFishItemData), "Fish"},
        { typeof(EngineItemData), "Engines"},
        { typeof(LightItemData), "Lights"},
        { typeof(RodItemData), "Rods"},
        { typeof(RelicItemData), "Relics"},
        { typeof(ResearchableItemData), "Books"},
        { typeof(MessageItemData), "Messages"},
        { typeof(GridConfigDeployableItemData), "Deployable"},
        { typeof(CrabPotItemData), "Pots"},
        { typeof(TrawlNetItemData), "Nets"},
        { typeof(DredgeItemData), "Dredge"},
        { typeof(DamageItemData), "Damage"},
        { typeof(DurableItemData), "Durable"},
        { typeof(ThawableItemData), "Thawable"},
        { typeof(GadgetItemData), "Gadgets"},
        { typeof(BaitItemData), "Baits"},
        { typeof(FlagItemData), "Flags"},
    };

    private static void LoadItemFiles(string itemFolderPath)
    {
        foreach (KeyValuePair<Type, string> item in _itemDataPathData)
        {
            var baseMethod = typeof(AssetLoader).GetMethod(nameof(AssetLoader.LoadItemFilesOfType), BindingFlags.NonPublic | BindingFlags.Static);
            var genericMethod = baseMethod.MakeGenericMethod(item.Key);
            var itemPath = Path.Combine(itemFolderPath, item.Value);
            if (Directory.Exists(itemPath))
            {
                genericMethod.Invoke(null, new object[] { itemPath });
            }
        }
    }

    private static Dictionary<Type, string> _upgradeDataPathData = new Dictionary<Type, string>()
    {
        { typeof(DeferredHullUpgradeData), "Hulls"},
        { typeof(DeferredSlotUpgradeData), "Slots"}
    };

    private static void LoadUpgradeFiles(string upgradeFolderPath)
    {
        foreach (KeyValuePair<Type, string> upgrade in _upgradeDataPathData)
        {
            var baseMethod = typeof(AssetLoader).GetMethod(nameof(AssetLoader.LoadUpgradeFilesOfType), BindingFlags.NonPublic | BindingFlags.Static);
            var genericMethod = baseMethod.MakeGenericMethod(upgrade.Key);
            var upgradePath = Path.Combine(upgradeFolderPath, upgrade.Value);
            if (Directory.Exists(upgradePath))
            {
                genericMethod.Invoke(null, new object[] { upgradePath });
            }
        }
    }

    private static Dictionary<Type, string> _recipeDataPathData = new Dictionary<Type, string>()
    {
        { typeof(DeferredAbilityRecipeData), "Abilities"},
        { typeof(DeferredBuildingRecipeData), "Buildings"},
        { typeof(DeferredHullRecipeData), "Hulls"},
        { typeof(DeferredSlotRecipeData), "Slots"},
        { typeof(DeferredItemRecipeData), "Items"}
    };

    private static void LoadRecipeFiles(string recipeFolderPath)
    {
        foreach (KeyValuePair<Type, string> recipe in _recipeDataPathData)
        {
            var baseMethod = typeof(AssetLoader).GetMethod(nameof(AssetLoader.LoadRecipeFilesOfType), BindingFlags.NonPublic | BindingFlags.Static);
            var genericMethod = baseMethod.MakeGenericMethod(recipe.Key);
            var recipePath = Path.Combine(recipeFolderPath, recipe.Value);
            if (Directory.Exists(recipePath))
            {
                genericMethod.Invoke(null, new object[] { recipePath });
            }
        }
    }

    private static void LoadGridConfigFiles(string gridConfigFolderPath)
    {
        string[] gridConfigFiles = GetSortedFiles(gridConfigFolderPath);
        foreach(string file in gridConfigFiles)
        {
            try
            {
                GridConfigUtil.AddGridConfigFromMeta(file);
            }
            catch(Exception ex)
            {
                WinchCore.Log.Error($"Failed to load grid configuration from {file}: {ex}");
            }
        }
    }

    private static void LoadVibrationFiles(string vibrationFolderPath)
    {
        string[] vibrationFiles = GetSortedFiles(vibrationFolderPath);
        foreach (string file in vibrationFiles)
        {
            try
            {
                VibrationUtil.AddVibrationDataFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load vibration from {file}: {ex}");
            }
        }
    }

    private static void LoadBuildingFiles(string buildingFolderPath)
    {
        string[] buildingFiles = GetSortedFiles(buildingFolderPath);
        foreach (string file in buildingFiles)
        {
            try
            {
                ConstructableBuildingUtil.AddConstructableBuildingDependencyDataFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load constructable building dependency data from {file}: {ex}");
            }
        }
    }

    private static void LoadDockFiles(string dockFolderPath)
    {
        string[] dockFiles = GetSortedFiles(dockFolderPath);
        foreach (string file in dockFiles)
        {
            try
            {
                DockUtil.AddDockDataFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load dock data from {file}: {ex}");
            }
        }
    }

    private static void LoadMapMarkerFiles(string mapMarkerFolderPath)
    {
        string[] mapMarkerFiles = GetSortedFiles(mapMarkerFolderPath);
        foreach (string file in mapMarkerFiles)
        {
            try
            {
                MapMarkerUtil.AddMapMarkerDataFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load map marker data from {file}: {ex}");
            }
        }
    }

    private static void LoadQuestFiles(string questFolderPath)
    {
        string[] questFiles = GetSortedFiles(questFolderPath, "*.*", SearchOption.TopDirectoryOnly);
        foreach (string file in questFiles)
        {
            try
            {
                QuestUtil.AddQuestDataFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load quest data from {file}: {ex}");
            }
        }
    }

    private static void LoadQuestStepFiles(string questStepFolderPath)
    {
        string[] questStepFiles = GetSortedFiles(questStepFolderPath);
        foreach (string file in questStepFiles)
        {
            try
            {
                QuestUtil.AddQuestStepDataFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load quest step data from {file}: {ex}");
            }
        }
    }

    private static void LoadQuestGridConfigFiles(string questGridConfigFolderPath)
    {
        string[] questGridConfigFiles = GetSortedFiles(questGridConfigFolderPath);
        foreach (string file in questGridConfigFiles)
        {
            try
            {
                QuestUtil.AddQuestGridConfigFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load quest grid config from {file}: {ex}");
            }
        }
    }

    private static void LoadShopFiles(string shopFolderPath)
    {
        string[] shopFolderFiles = GetSortedFiles(shopFolderPath);
        foreach (string file in shopFolderFiles)
        {
            try
            {
                ShopUtil.AddShopDataFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load shop data from {file}: {ex}");
            }
        }
    }

    private static void LoadPoiFilesOfType<T>(string poiFolderPath) where T : CustomPOI
    {
        string[] poiFiles = GetSortedFiles(poiFolderPath);
        foreach(string file in poiFiles)
        {
            try
            {
                PoiUtil.AddCustomPoiFromMeta<T>(file);
            }
            catch(Exception ex)
            {
                WinchCore.Log.Error($"Failed to load POI from {file}: {ex}");
            }
        }
    }

    private static void LoadItemFilesOfType<T>(string itemFolderPath) where T : ItemData
    {
        string[] itemFiles = GetSortedFiles(itemFolderPath);
        foreach (string file in itemFiles)
        {
            try
            {
                ItemUtil.AddItemFromMeta<T>(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load item from {file}: {ex}");
            }
        }
    }

    private static void LoadUpgradeFilesOfType<T>(string upgradeFolderPath) where T : UpgradeData, IDeferredUpgradeData
    {
        string[] upgradeFiles = GetSortedFiles(upgradeFolderPath);
        foreach (string file in upgradeFiles)
        {
            try
            {
                UpgradeUtil.AddUpgradeDataFromMeta<T>(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load upgrade data from {file}: {ex}");
            }
        }
    }

    private static void LoadRecipeFilesOfType<T>(string recipeFolderPath) where T : RecipeData, IDeferredRecipeData
    {
        string[] recipeFiles = GetSortedFiles(recipeFolderPath);
        foreach (string file in recipeFiles)
        {
            try
            {
                RecipeUtil.AddRecipeDataFromMeta<T>(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load recipe data from {file}: {ex}");
            }
        }
    }

    private static void LoadLocalizationFiles(string localizationFolderPath)
    {
        string[] localizationFiles = GetSortedFiles(localizationFolderPath, "*.*", SearchOption.TopDirectoryOnly);
        foreach (string file in localizationFiles)
        {
            try
            {
                LocalizationUtil.LoadLocalizationFile(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load localization file {file}: {ex}");
            }
        }
    }

    private static void LoadTextureFiles(string textureFolderPath)
    {
        string[] textureFiles = GetSortedFiles(textureFolderPath);
        foreach (string file in textureFiles)
        {
            try
            {
                TextureUtil.LoadTextureFromFile(file);
            }
            catch(Exception ex)
            {
                WinchCore.Log.Error($"Failed to load texture file {file}: {ex}");
            }
        }
    }

    private static void LoadAudioFiles(string audioFolderPath)
    {
        string[] audioFiles = GetSortedFiles(audioFolderPath);
        foreach (string file in audioFiles)
        {
            try
            {
                AudioClipUtil.LoadAudioFromFile(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load audio file {file}: {ex}");
            }
        }
    }

    private static void LoadHarvestZoneFiles(string harvestZoneFolderPath)
    {
        string[] harvestZoneFiles = GetSortedFiles(harvestZoneFolderPath);
        foreach (string file in harvestZoneFiles)
        {
            try
            {
                HarvestZoneUtil.AddCustomHarvestZoneFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load Harvest Zone from {file}: {ex}");
            }
        }
    }

    private static void LoadAbilityFiles(string abilityFolderPath)
    {
        string[] abilityFiles = GetSortedFiles(abilityFolderPath);
        foreach (string file in abilityFiles)
        {
            try
            {
                AbilityUtil.AddCustomAbilityDataFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load Ability Data from {file}: {ex}");
            }
        }
    }

    private static void LoadWorldEventFiles(string worldEventFolderPath)
    {
        var dynamicPath = Path.Combine(worldEventFolderPath, "Dynamic");
        if (Directory.Exists(dynamicPath))
        {
            string[] worldEventFiles = GetSortedFiles(dynamicPath);
            foreach (string file in worldEventFiles)
            {
                try
                {
                    WorldEventUtil.AddCustomWorldEventDataFromMeta(file);
                }
                catch (Exception ex)
                {
                    WinchCore.Log.Error($"Failed to load dynamic world event data from {file}: {ex}");
                }
            }
        }
        var staticPath = Path.Combine(worldEventFolderPath, "Static");
        if (Directory.Exists(staticPath))
        {
            string[] staticWorldEventFiles = GetSortedFiles(staticPath);
            foreach (string file in staticWorldEventFiles)
            {
                try
                {
                    WorldEventUtil.AddCustomStaticWorldEventDataFromMeta(file);
                }
                catch (Exception ex)
                {
                    WinchCore.Log.Error($"Failed to load static world event data from {file}: {ex}");
                }
            }
        }
    }

    private static void LoadDialogueFiles(string dialogueFolderPath)
    {
        try
        {
            DialogueUtil.LoadDialogueFiles(dialogueFolderPath);
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Failed to load dialogue files at path {dialogueFolderPath}: {ex}");
        }

        try
        {
            DialogueUtil.LoadLocalizedLines(dialogueFolderPath);
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Failed to load localized lines at path {dialogueFolderPath}: {ex}");
        }
    }

    private static void LoadCharacterFiles(string charactersFolderPath)
    {
        string[] charactersFiles = GetSortedFiles(charactersFolderPath);
        foreach (string file in charactersFiles)
        {
            try
            {
                CharacterUtil.AddCharacterFromMeta(file);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load character from {file}: {ex}");
            }
        }
    }

    private static void LoadBoatPaintFiles(string paintFolderpath)
    {
        string[] paintFiles = GetSortedFiles(paintFolderpath);
        foreach (string paintFile in paintFiles)
        {
            try
            {
                BoatUtil.AddBoatPaintDataFromMeta(paintFile);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load boat paint data from {paintFile}: {ex}");
            }
        }
    }

    private static void LoadBoatFlagFiles(string flagFolderpath)
    {
        string[] flagFiles = GetSortedFiles(flagFolderpath);
        foreach (string flagFile in flagFiles)
        {
            try
            {
                BoatUtil.AddBoatFlagDataFromMeta(flagFile);
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to load boat flag data from {flagFile}: {ex}");
            }
        }
    }
}

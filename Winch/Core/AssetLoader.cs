using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Winch.Util;
using Winch.Serialization.POI;
using Winch.Serialization.POI.Harvest;
using Winch.Serialization.POI.Item;
using Winch.Serialization.HarvestZone;
using Winch.Data.Item;

namespace Winch.Core
{
    internal class AssetLoader
    {
        internal static void LoadAssets()
        {
            WinchCore.Log.Debug("Loading assets...");

            string winchAssetFolderPath = Path.Combine(Paths.WinchRootPath, "Assets");
            if (Directory.Exists(winchAssetFolderPath))
                LoadAssetFolder(winchAssetFolderPath);

            foreach (var modAssembly in ModAssemblyLoader.EnabledModAssemblies.Values)
            {
                ModAssemblyLoader.ForceModContext(modAssembly);
                try
                {
                    string assetFolderPath = Path.Combine(modAssembly.BasePath, "Assets");
                    if (Directory.Exists(assetFolderPath))
                        LoadAssetFolder(assetFolderPath);
                }
                catch (Exception ex)
                {
                    WinchCore.Log.Error($"Error loading assets for {modAssembly.GUID}: {ex}");
                }
                ModAssemblyLoader.ClearModContext();
            }
        }

        private static void LoadAssetFolder(string path)
        {
            string localizationFolderPath = Path.Combine(path, "Localization");
            string textureFolderPath = Path.Combine(path, "Textures");
            string gridConfigFolderpath = Path.Combine(path, "GridConfigs");
            string itemFolderPath = Path.Combine(path, "Items");
            string poiFolderpath = Path.Combine(path, "POI");
            string harvestZoneFolderpath = Path.Combine(path, "HarvestZones");
            string abilityFolderpath = Path.Combine(path, "Abilities");
            string worldEventFolderpath = Path.Combine(path, "WorldEvents");
            string dialogueFolderpath = Path.Combine(path, "Dialogues");
            string characterFolderpath = Path.Combine(path, "Characters");

            if(Directory.Exists(localizationFolderPath)) LoadLocalizationFiles(localizationFolderPath);
            if(Directory.Exists(textureFolderPath)) LoadTextureFiles(textureFolderPath);
            if(Directory.Exists(gridConfigFolderpath)) LoadGridConfigFiles(gridConfigFolderpath);
            if(Directory.Exists(itemFolderPath)) LoadItemFiles(itemFolderPath);
            if(Directory.Exists(poiFolderpath)) LoadPoiFiles(poiFolderpath);
            if(Directory.Exists(harvestZoneFolderpath)) LoadHarvestZoneFiles(harvestZoneFolderpath);
            if(Directory.Exists(abilityFolderpath)) LoadAbilityFiles(abilityFolderpath);
            if(Directory.Exists(worldEventFolderpath)) LoadWorldEventFiles(worldEventFolderpath);
            if(Directory.Exists(dialogueFolderpath)) LoadDialogueFiles(dialogueFolderpath);
            if(Directory.Exists(characterFolderpath)) LoadCharacterFiles(characterFolderpath);
        }

        private static Dictionary<Type, string> _poiPathData = new Dictionary<Type, string>()
            {
                { typeof(CustomHarvestPOI), "Harvest"},
                { typeof(CustomItemPOI), "Item"},
                //{ typeof(BaitHarvestPOI), "Bait"},
                //{ typeof(PlacedHarvestPOI), "Placed"},
                //{ typeof(AutoMovePOI), "Conversation/AutoMove"},
                //{ typeof(ExplosivePOI), "Conversation/Explosive"},
                //{ typeof(InspectPOI), "Conversation/Inspect"}
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

        private static void LoadGridConfigFiles(string gridConfigFolderPath)
        {
            string[] gridConfigFiles = Directory.GetFiles(gridConfigFolderPath);
            foreach(string file in gridConfigFiles)
            {
                try
                {
                    GridConfigUtil.AddGridConfigFromMeta(file);
                }
                catch(Exception ex)
                {
                    WinchCore.Log.Error($"Failed to load Grid Configuration from {file}: {ex}");
                }
            }
        }

        private static void LoadPoiFilesOfType<T>(string poiFolderPath) where T : CustomPOI
        {
            string[] poiFiles = Directory.GetFiles(poiFolderPath);
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
            string[] itemFiles = Directory.GetFiles(itemFolderPath);
            foreach (string file in itemFiles)
            {
                try
                {
                    ItemUtil.AddItemFromMeta<T>(file);
                }
                catch(Exception ex)
                {
                    WinchCore.Log.Error($"Failed to load item from {file}: {ex}");
                }
            }
        }

        private static void LoadLocalizationFiles(string localizationFolderPath)
        {
            string[] localeFolders = Directory.GetDirectories(localizationFolderPath, "*", SearchOption.TopDirectoryOnly);
            foreach (string folder in localeFolders)
            {
                try
                {
                    LocalizationUtil.LoadLocaleFolder(folder);
                }
                catch (Exception ex)
                {
                    WinchCore.Log.Error($"Failed to load locale folder {folder}: {ex}");
                }
            }

            string[] localizationFiles = Directory.GetFiles(localizationFolderPath, "*.*", SearchOption.TopDirectoryOnly);
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
            string[] textureFiles = Directory.GetFiles(textureFolderPath);
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

        private static void LoadHarvestZoneFiles(string harvestZoneFolderPath)
        {
            string[] harvestZoneFiles = Directory.GetFiles(harvestZoneFolderPath);
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
            string[] abilityFiles = Directory.GetFiles(abilityFolderPath);
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
                string[] worldEventFiles = Directory.GetFiles(dynamicPath);
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
                string[] staticWorldEventFiles = Directory.GetFiles(staticPath);
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
            string[] charactersFiles = Directory.GetFiles(charactersFolderPath);
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
    }
}

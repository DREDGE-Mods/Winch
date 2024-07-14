using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Winch.Util;
using Winch.Serialization.POI;
using Winch.Serialization.POI.Harvest;

namespace Winch.Core
{
    internal class AssetLoader
    {
        internal static void LoadAssets()
        {
            WinchCore.Log.Debug("Loading assets...");

            string[] modDirs = Directory.GetDirectories("Mods");
            foreach (string modDir in modDirs)
            {
                string assetFolderPath = Path.Combine(modDir, "Assets");
                if (!Directory.Exists(assetFolderPath))
                    continue;
                LoadAssetFolder(assetFolderPath);
            }
        }

        private static void LoadAssetFolder(string path)
        {
            string localizationFolderPath = Path.Combine(path, "Localization");
            string textureFolderPath = Path.Combine(path, "Textures");
            string itemFolderPath = Path.Combine(path, "Items");
            string poiFolderpath = Path.Combine(path, "POI");

            if(Directory.Exists(localizationFolderPath)) LoadLocalizationFiles(localizationFolderPath);
            if(Directory.Exists(textureFolderPath)) LoadTextureFiles(textureFolderPath);
            if(Directory.Exists(itemFolderPath)) LoadItemFiles(itemFolderPath);
            if(Directory.Exists(poiFolderpath)) LoadPoiFiles(poiFolderpath);
        }

        private static Dictionary<Type, string> _poiPathData = new Dictionary<Type, string>()
            {
                { typeof(CustomHarvestPOI), "Harvest"},
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
                { typeof(FishItemData), "Fish"},
                { typeof(EngineItemData), "Engines"},
                { typeof(LightItemData), "Lights"},
                { typeof(RodItemData), "Rods"},
                { typeof(RelicItemData), "Relics"},
                { typeof(ResearchableItemData), "Books"},
                { typeof(MessageItemData), "Messages"},
                { typeof(DeployableItemData), "Deployable"},
                { typeof(DredgeItemData), "Dredge"},
                { typeof(DamageItemData), "Damage"},
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
            string[] localizationFiles = Directory.GetFiles(localizationFolderPath);
            foreach (string file in localizationFiles) {
                try
                {
                    LocalizationUtil.LoadLocalizationFile(file);
                }
                catch(Exception ex)
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
    }
}

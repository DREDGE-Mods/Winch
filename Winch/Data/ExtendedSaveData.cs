using InControl;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Config;
using Winch.Core;
using Winch.Util;

namespace Winch.Data
{
    public class ExtendedSaveData
    {
        [JsonIgnore]
        private int slot = -1;

        [JsonIgnore]
        public int Slot => slot == -1 ? GameManager.Instance.SaveManager.activeSaveSlot : slot;

        internal ExtendedSaveData(int slot)
        {
            this.slot = slot;
        }

        [JsonIgnore]
        private SaveData baseSaveData => slot == -1 ? GameManager.Instance.SaveManager.activeSaveData : GameManager.Instance.SaveManager.GetInMemorySaveDataForSlot(slot);

        private ModdedSaveData saveData = new ModdedSaveData();

        internal class ModdedSaveData
        {
            public Dictionary<string, SerializableGrid> grids = new Dictionary<string, SerializableGrid>();
            public List<SerializedCrabPotPOIData> serializedCrabPotPOIs = new List<SerializedCrabPotPOIData>();
            public Dictionary<string, Dictionary<string, JToken>> mods = new Dictionary<string, Dictionary<string, JToken>>();
        }

        [JsonIgnore]
        internal string Path => GameManager.Instance.SaveManager.saveStrategy.GetFilePath(Slot).Replace(WindowsSaveStrategy.fileExtension, ".json");

        [NonSerialized]
        private static string VAR_MOD_PREFIX = "using-mod";

        internal void Reset()
        {
            saveData = new ModdedSaveData();
        }

        internal void Read()
        {
            saveData = JSONConfig.ReadConfig<ModdedSaveData>(Path) ?? new ModdedSaveData();
        }

        internal void Write()
        {
            JSONConfig.WriteConfig(Path, saveData);
        }

        internal void Create()
        {
            Reset();
            Write();
        }

        internal void ExtractModdedData()
        {
            var gridsToRemove = new List<GridKey>();
            foreach (var gridByKey in baseSaveData.grids)
            {
                var key = gridByKey.Key;
                var grid = gridByKey.Value;
                if (key.IsDynamic())
                    gridsToRemove.Add(key);
                else if (grid.spatialItems.Any(WinchExtensions.IsModded) || grid.spatialUnderlayItems.Any(WinchExtensions.IsModded))
                {
                    var moddedItems = grid.spatialItems.Where(WinchExtensions.IsModded).ToList();
                    var moddedUnderlayItems = grid.spatialUnderlayItems.Where(WinchExtensions.IsModded).ToList();
                    grid.spatialItems.RemoveAll(WinchExtensions.IsModded);
                    grid.spatialUnderlayItems.RemoveAll(WinchExtensions.IsModded);
                    saveData.grids.Add(key.GetName(), new SerializableGrid
                    {
                        spatialItems = moddedItems,
                        spatialUnderlayItems = moddedUnderlayItems
                    });
                }
            }
            foreach (var key in gridsToRemove)
            {
                if (baseSaveData.grids.TryGetValue(key, out var grid))
                {
                    baseSaveData.grids.Remove(key);
                    saveData.grids.Add(key.GetName(), grid);
                }
            }

            var potsToRemove = new List<SerializedCrabPotPOIData>();
            foreach (var crabPotPOI in baseSaveData.serializedCrabPotPOIs)
            {
                if (crabPotPOI.IsModded())
                {
                    potsToRemove.Add(crabPotPOI);
                }
                else if (crabPotPOI.grid.spatialItems.Any(WinchExtensions.IsModded) || crabPotPOI.grid.spatialUnderlayItems.Any(WinchExtensions.IsModded))
                {
                    var moddedItems = crabPotPOI.grid.spatialItems.Where(WinchExtensions.IsModded).ToList();
                    var moddedUnderlayItems = crabPotPOI.grid.spatialUnderlayItems.Where(WinchExtensions.IsModded).ToList();
                    crabPotPOI.grid.spatialItems.RemoveAll(WinchExtensions.IsModded);
                    crabPotPOI.grid.spatialUnderlayItems.RemoveAll(WinchExtensions.IsModded);
                    var partialCrabPot = crabPotPOI.MakeIdentical();
                    partialCrabPot.grid.spatialItems = moddedItems;
                    partialCrabPot.grid.spatialUnderlayItems = moddedUnderlayItems;
                    saveData.serializedCrabPotPOIs.Add(partialCrabPot);
                }
            }
            foreach (var crabPotPOI in potsToRemove)
            {
                baseSaveData.serializedCrabPotPOIs.Remove(crabPotPOI);
                saveData.serializedCrabPotPOIs.Add(crabPotPOI);
            }
        }

        internal void InsertModdedData()
        {
            var gridsToRemove = new List<string>();
            foreach (var gridByKey in saveData.grids)
            {
                var key = gridByKey.Key;
                gridsToRemove.Add(key);
            }
            foreach (var key in gridsToRemove)
            {
                if (saveData.grids.TryGetValue(key, out var grid))
                {
                    if (EnumUtil.TryParse<GridKey>(key, out GridKey gridKey))
                    {
                        saveData.grids.Remove(key);
                        if (baseSaveData.grids.TryGetValue(gridKey, out var baseGrid))
                        {
                            baseGrid.spatialItems.AddRange(grid.spatialItems);
                            baseGrid.spatialUnderlayItems.AddRange(grid.spatialUnderlayItems);
                        }
                        else
                            baseSaveData.grids.Add(gridKey, grid);
                    }
                }
            }

            var potsToRemove = new List<SerializedCrabPotPOIData>();
            foreach (var crabPotPOI in saveData.serializedCrabPotPOIs)
            {
                potsToRemove.Add(crabPotPOI);
            }
            foreach (var crabPotPOI in potsToRemove)
            {
                saveData.serializedCrabPotPOIs.Remove(crabPotPOI);
                if (baseSaveData.serializedCrabPotPOIs.TryGetValue(pot => pot.Identical(crabPotPOI), out var baseCrabPotPOI))
                {
                    baseCrabPotPOI.grid.spatialItems.AddRange(crabPotPOI.grid.spatialItems);
                    baseCrabPotPOI.grid.spatialUnderlayItems.AddRange(crabPotPOI.grid.spatialUnderlayItems);
                }
                else
                    baseSaveData.serializedCrabPotPOIs.Add(crabPotPOI);
            }
        }

        internal void Save()
        {
            ExtractModdedData();
            SaveUtil.SaveParticipants(this);
            Write();
        }

        internal void LoadIntoMemory()
        {
            Read();
        }

        internal void Load()
        {
            Read();
            InsertModdedData();
            SaveUtil.LoadParticipants(this);
        }

        internal void Delete()
        {
            Reset();
            if (File.Exists(Path)) File.Delete(Path);
        }

        internal Dictionary<string, Dictionary<string, JToken>> GetMods() => saveData.mods;

        public Dictionary<string, JToken> GetData(string modGUID)
        {
            var mods = GetMods();
            if (!mods.ContainsKey(modGUID)) mods.Add(modGUID, new Dictionary<string, JToken>());

            var data = mods[modGUID];

            if (data == null)
            {
                data = new Dictionary<string, JToken>();
                mods[modGUID] = data;
            }

            return data;
        }

        public Dictionary<string, JToken> GetData(ModAssembly mod) => GetData(mod.GUID);

        public JToken GetData(string modGUID, string key)
        {
            var data = GetData(modGUID);

            if (!data.ContainsKey(key))
            {
                var value = JValue.CreateNull();
                SetData(modGUID, key, value);
                return value;
            }

            return data[key];
        }

        public JToken GetData(ModAssembly mod, string key) => GetData(mod.GUID, key);

        public T? GetData<T>(string modGUID, string key)
        {
            var data = GetData(modGUID);

            if (!data.ContainsKey(key))
            {
                var value = default(T);
                SetData(modGUID, key, value);
                return value;
            }

            return data[key].ToObject<T>(JSONConfig.jsonSerializer);
        }

        public T? GetData<T>(ModAssembly mod, string key) => GetData<T>(mod.GUID, key);

        public void SetData(string modGUID, string key, object? value)
        {
            var data = GetData(modGUID);
            data.AddOrChange(key, value.ToJToken());
        }

        public void SetData(ModAssembly mod, string key, object value) => SetData(mod.GUID, key, value);

        public bool GetSaveUsesMod(string modGUID)
        {
            string key = $"{VAR_MOD_PREFIX}-{modGUID}";
            return baseSaveData.GetBoolVariable(key);
        }

        public void SetSaveUsesMod(string modGUID, bool value)
        {
            string key = $"{VAR_MOD_PREFIX}-{modGUID}";
            baseSaveData.SetBoolVariable(key, value);
        }

        public bool GetSaveUsesMod(ModAssembly mod) => GetSaveUsesMod(mod.GUID);

        public void SetSaveUsesMod(ModAssembly mod, bool value) => SetSaveUsesMod(mod.GUID, value);

        /// <summary>
        /// A participant of the saveData system.
        /// </summary>
        public interface Participant
        {
            /// <summary>
            /// Unique identifier of the participant
            /// </summary>
            public string Key { get; }

            /// <summary>
            /// Load saveData from <paramref name="token"/>
            /// </summary>
            /// <param name="token">The saveData for you to parse</param>
            public void Load(JToken token);

            /// <summary>
            /// Save saveData
            /// </summary>
            /// <returns>The object for Winch to save</returns>
            public object Save();
        }
    }
}

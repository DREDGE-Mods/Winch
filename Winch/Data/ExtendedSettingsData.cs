using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json.Linq;
using Winch.Config;
using Winch.Core;
using Winch.Util;

namespace Winch.Data;

public sealed class ExtendedSettingsData
{
    private ModdedSettingsData settingsData = new();

    private const ushort BindingDataFormatVersion = 2;

    internal sealed class ModdedSettingsData
    {
        public List<string> mods = new();
        public Dictionary<string, Dictionary<string, ControlBindingData>> controlBindings = new();
        public Dictionary<string, Dictionary<string, JToken>> modData = new();
    }

    internal sealed class ControlBindingData
    {
        public ushort formatVersion = BindingDataFormatVersion;
        public string data = string.Empty;

        internal ControlBindingData()
        {
        }

        internal ControlBindingData(string data)
        {
            this.data = data;
        }
    }

    internal string Path =>
        System.IO.Path.Combine(
            System.IO.Path.GetDirectoryName(
                GameManager.Instance.SaveManager.saveStrategy.GetMetaFilePath()
            ),
            "winch-settings.json"
        );

    internal void Reset()
    {
        settingsData = new ModdedSettingsData();
    }

    internal void Read()
    {
        settingsData =
            JSONConfig.ReadConfig<ModdedSettingsData>(Path) ??
            new ModdedSettingsData();
    }

    internal void Write()
    {
        settingsData.mods =
            ModAssemblyLoader.EnabledModAssemblies.Keys.ToList();

        JSONConfig.WriteConfig(Path, settingsData);
    }

    internal void Create()
    {
        Reset();
        SettingsUtil.LoadParticipants(this);
        Write();
    }

    internal void Save()
    {
        settingsData.controlBindings =
            ControlUtil.SaveBindings(settingsData.controlBindings);

        SettingsUtil.SaveParticipants(this);

        Write();
    }

    internal void Load()
    {
        if (File.Exists(Path))
        {
            Read();
        }
        else
        {
            Reset();
        }

        SettingsUtil.LoadParticipants(this);

        if (!File.Exists(Path))
            Write();
    }

    internal List<string> GetMods() =>
        settingsData.mods;

    internal Dictionary<string, Dictionary<string, JToken>> GetDataForMods() =>
        settingsData.modData;

    public Dictionary<string, JToken> GetData(string modGUID)
    {
        var mods = GetDataForMods();

        if (!mods.ContainsKey(modGUID))
        {
            mods.Add(
                modGUID,
                new Dictionary<string, JToken>()
            );
        }

        var data = mods[modGUID];

        if (data == null)
        {
            data = new Dictionary<string, JToken>();
            mods[modGUID] = data;
        }

        return data;
    }

    public Dictionary<string, JToken> GetData(ModAssembly mod) =>
        GetData(mod.GUID);

    public bool HasData(string modGUID, string key) =>
        GetData(modGUID).ContainsKey(key) &&
        !GetData(modGUID, key).IsNullOrEmpty();

    public bool HasData(ModAssembly mod, string key) =>
        HasData(mod.GUID, key);

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

    public JToken GetData(ModAssembly mod, string key) =>
        GetData(mod.GUID, key);

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

    public T? GetData<T>(ModAssembly mod, string key) =>
        GetData<T>(mod.GUID, key);

    public void SetData(
        string modGUID,
        string key,
        object? value)
    {
        var data = GetData(modGUID);
        data.AddOrChange(key, value.ToJToken());
    }

    public void SetData(
        ModAssembly mod,
        string key,
        object? value) =>
        SetData(mod.GUID, key, value);

    /// <summary>
    /// A participant in the extended settings data system.
    /// </summary>
    public interface Participant
    {
        /// <summary>
        /// Unique identifier of the participant.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Loads settings data from <paramref name="token"/>.
        /// </summary>
        /// <param name="token">The settings data to parse.</param>
        void Load(JToken token);

        /// <summary>
        /// Saves the current settings data.
        /// </summary>
        /// <returns>The object for Winch to save.</returns>
        object Save();

        /// <summary>
        /// Creates the default settings data.
        /// </summary>
        /// <returns>The default settings data.</returns>
        object Create();
    }

    internal bool TryGetControlBinding(
        string modGUID,
        string key,
        out ControlBindingData binding)
    {
        binding = null;

        return settingsData.controlBindings.TryGetValue(
                   modGUID,
                   out var modBindings
               ) &&
               modBindings.TryGetValue(
                   key,
                   out binding
               );
    }

    internal bool TryGetControlBinding(
        ModAssembly mod,
        string key,
        out ControlBindingData binding) =>
        TryGetControlBinding(
            mod.GUID,
            key,
            out binding
        );

    internal void SetControlBinding(
        string modGUID,
        string key,
        ControlBindingData binding)
    {
        if (!settingsData.controlBindings.TryGetValue(
                modGUID,
                out var modBindings))
        {
            modBindings = new Dictionary<string, ControlBindingData>();
            settingsData.controlBindings.Add(modGUID, modBindings);
        }

        modBindings.AddOrChange(key, binding);
    }

    internal void SetControlBinding(
        ModAssembly mod,
        string key,
        ControlBindingData binding) =>
        SetControlBinding(
            mod.GUID,
            key,
            binding
        );
}
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
// ReSharper disable HeapView.PossibleBoxingAllocation

namespace Winch.Config
{
    public class JSONConfig
    {
        private readonly Dictionary<string, object?> _config;
        private readonly Dictionary<string, object?> _defaultConfig;
        private readonly string _configPath;

        public JSONConfig(string path, string defaultConfig) {
            _configPath = path;

            if (!File.Exists(_configPath))
            {
                File.WriteAllText(_configPath, defaultConfig);
                _defaultConfig = JsonConvert.DeserializeObject<Dictionary<string, object?>>(defaultConfig) ?? throw new InvalidOperationException("Unable to parse default config.");
            }

            string confText = File.ReadAllText(_configPath);
            _config = JsonConvert.DeserializeObject<Dictionary<string, object?>>(confText) ?? throw new InvalidOperationException("Unable to parse config file.");
        }

        internal Dictionary<string, object> GetDefaultProperties()
        {
            return _defaultConfig;
        }

        public T? GetDefaultProperty<T>(string key)
        {
            return _defaultConfig.ContainsKey(key) ? (T?)_defaultConfig[key] : default;
        }

        internal Dictionary<string, object> GetProperties()
        {
            return _config;
        }

        public T? GetProperty<T>(string key, T? defaultValue)
        {
            if (!_config.ContainsKey(key))
            {
                SetProperty(key, defaultValue);
                return defaultValue;
            }
            return (T?)_config[key];
        }

        public void SetProperty<T>(string key, T? value)
        {
            _config[key] = value;
            SaveSettings();
        }

        private void SaveSettings()
        {
            string confText = JsonConvert.SerializeObject(_config, Formatting.Indented);
            File.WriteAllText(_configPath, confText);
        }

        public override string ToString() => _configPath;
    }
}

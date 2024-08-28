using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using Winch.Serialization;
// ReSharper disable HeapView.PossibleBoxingAllocation

namespace Winch.Config
{
    public class JSONConfig
    {
        private static DynamicConverter dynamicConverter = new DynamicConverter();
        private static DredgeContractResolver contractResolver = new DredgeContractResolver();

        public static JsonSerializerSettings CreateSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
                Formatting = Formatting.Indented,
                Converters = { dynamicConverter }
            };
        }

        public static JsonSerializer CreateSerializer()
        {
            return new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
                Formatting = Formatting.Indented,
                Converters = { dynamicConverter }
            };
        }

        public static JsonSerializerSettings jsonSerializerSettings = CreateSerializerSettings();

        public static JsonSerializer jsonSerializer = CreateSerializer();

        static JSONConfig()
        {
            JsonConvert.DefaultSettings = CreateSerializerSettings;
        }

        private static StringBuilder stringBuilder = new StringBuilder();

        public event ConfigChangedEvent OnConfigChanged;

        public event ConfigValueChangedEvent OnConfigValueChanged;

        private Dictionary<string, object?> _config;
        private readonly Dictionary<string, object?> _defaultConfig;
        private readonly string _configPath;
        private readonly string _defaultConfigString;
        private readonly string _defaultConfigPath;

        public bool hasProperties => _config.Count > 0;

        public static Dictionary<string, object?> ReadConfig(string path)
        {
            if (!File.Exists(path)) return new Dictionary<string, object?>();
            return ParseConfig(File.ReadAllText(path));
        }

        public static T ReadConfig<T>(string path)
        {
            if (!File.Exists(path)) return default(T);
            return ParseConfig<T>(File.ReadAllText(path));
        }

        public static Dictionary<string, object?> ParseConfig(string value)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object?>>(value, jsonSerializerSettings);
        }

        public static T ParseConfig<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, jsonSerializerSettings);
        }

        public static string ToSerializedJson(object? value)
        {
            string json = "{}";
            using (StringWriter stringWriter = new StringWriter(stringBuilder))
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter)
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    IndentChar = '\t',
                    Indentation = 1
                })
                {
                    jsonSerializer.Serialize(jsonTextWriter, value);
                    json = stringBuilder.ToString();
                    stringBuilder.Clear();
                }
            }
            return json;
        }

        public static string ToSerializedJson(object? value, Type? type)
        {
            string json = "{}";
            using (StringWriter stringWriter = new StringWriter(stringBuilder))
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter)
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    IndentChar = '\t',
                    Indentation = 1
                })
                {
                    jsonSerializer.Serialize(jsonTextWriter, value, type);
                    json = stringBuilder.ToString();
                    stringBuilder.Clear();
                }
            }
            return json;
        }

        public static void WriteConfig(string path, object? value)
        {
            WriteConfig(path, ToSerializedJson(value));
        }

        public static void WriteConfig(string path, object? value, Type? type)
        {
            WriteConfig(path, ToSerializedJson(value, type));
        }

        public static void WriteConfig(string path, string value)
        {
            File.WriteAllText(path, value);
        }

        public JSONConfig(string path, string defaultConfig)
        {
            _configPath = path;

            if (!string.IsNullOrWhiteSpace(defaultConfig))
            {
                if (defaultConfig.Contains("{"))
                {
                    _defaultConfigString = defaultConfig;
                    _defaultConfig = ParseConfig(defaultConfig);
                }
                else
                {
                    _defaultConfigPath = defaultConfig;
                    string dconfText = File.ReadAllText(_defaultConfigPath);
                    _defaultConfigString = dconfText;
                    _defaultConfig = ParseConfig(dconfText);
                }

                if (!File.Exists(_configPath))
                {
                    WriteConfig(_configPath, _defaultConfigString);
                }
                else
                {
                    _config = ParseConfig(_defaultConfigString);
                    string pconfText = File.ReadAllText(_configPath);
                    var parsedConfig = ParseConfig(pconfText) ?? throw new InvalidOperationException("Unable to parse config file.");
                    foreach (var kvp in parsedConfig)
                    {
                        var value = kvp.Value is JObject objectValue ? objectValue["value"] : kvp.Value;
                        if (_config.TryGetValue(kvp.Key, out var defaultValue))
                        {
                            if (defaultValue is JObject setting)
                            {
                                setting["value"] = value != null ? JToken.FromObject(value, jsonSerializer) : null;
                            }
                            else
                            {
                                _config[kvp.Key] = value;
                            }
                        }
                        else
                            _config[kvp.Key] = kvp.Value;
                    }
                    WriteConfig(_configPath, _config);
                    return;
                }
            }

            string confText = File.ReadAllText(_configPath);
            _config = ParseConfig(confText) ?? throw new InvalidOperationException("Unable to parse config file.");
        }

        internal void ResetToDefaultConfig()
        {
            _config = ParseConfig(_defaultConfigString);
            WriteConfig(_configPath, _defaultConfigString);
            OnConfigChanged?.Invoke();
            foreach (var key in _config.Keys)
            {
                OnConfigValueChanged?.Invoke(key);
            }
        }

        internal void ResetPropertyToDefault(string key)
        {
            var defaultValue = GetProperty(_defaultConfig, key);
            SetProperty(_config, key, defaultValue);
            OnConfigChanged?.Invoke();
            OnConfigValueChanged?.Invoke(key);
        }

        internal static object? GetProperty(Dictionary<string, object?> config, string key, Dictionary<string, object?> defaultConfig = null)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");
            if (!config.TryGetValue(key, out var setting))
            {
                if (defaultConfig != null && defaultConfig.TryGetValue(key, out var defaultValue))
                {
                    SetProperty(config, key, defaultValue);
                    setting = defaultValue;
                }
                else
                {
                    throw new InvalidOperationException($"No default config value found for {key}.");
                }
            }
            return setting is JObject objectValue ? objectValue["value"] : setting;
        }

        internal static T? GetProperty<T>(Dictionary<string, object?> config, string key, Dictionary<string, object?> defaultConfig = null)
        {
            var type = typeof(T);
            var value = GetProperty(config, key, defaultConfig);
            return type.IsEnum ? ConvertToEnum<T>(value) : (T)Convert.ChangeType(value, type);
        }

        internal static void SetProperty<T>(Dictionary<string, object?> config, string key, T? value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");
            if (config.TryGetValue(key, out var oValue) && oValue is JObject setting)
            {
                setting["value"] = value != null ? JToken.FromObject(value, jsonSerializer) : null;
            }
            else
            {
                config[key] = value;
            }
        }

        internal Dictionary<string, object> GetDefaultProperties()
        {
            return _defaultConfig;
        }

        public T? GetDefaultProperty<T>(string key)
        {
            return GetProperty<T>(_defaultConfig, key);
        }

        internal Dictionary<string, object> GetProperties()
        {
            return _config;
        }

        public T ToObject<T>()
        {
            return JsonConvert.DeserializeObject<T>(ToSerializedJson(GetProperties().ToDictionary(kvp => kvp.Key, kvp => GetProperty(_config, kvp.Key, _defaultConfig))));
        }

        public T? GetProperty<T>(string key)
        {
            return GetProperty<T>(_config, key, _defaultConfig);
        }

        [Obsolete]
        public T? GetProperty<T>(string key, T? defaultValue) => GetProperty<T>(key);

        public void SetProperty<T>(string key, T? value)
        {
            SetProperty(_config, key, value);
            SaveSettings();
            OnConfigChanged?.Invoke();
            OnConfigValueChanged?.Invoke(key);
        }

        private void SaveSettings()
        {
            WriteConfig(_configPath, _config);
        }

        public override string ToString() => _configPath;

        private static T ConvertToEnum<T>(object value)
        {
            if (value == null) return default(T);

            if (value is float || value is double)
            {
                var floatValue = Convert.ToDouble(value);
                return (T)Enum.ToObject(typeof(T), (long)Math.Round(floatValue));
            }

            if (value is int || value is long || value is short || value is uint || value is ulong || value is ushort || value is byte || value is sbyte)
            {
                return (T)Enum.ToObject(typeof(T), value);
            }

            var valueString = Convert.ToString(value);

            try
            {
                return (T)Enum.Parse(typeof(T), valueString, true);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException($"Can't convert {valueString} to enum {typeof(T)}", ex);
            }
        }

        internal static void AddDynamicConverter(JsonConverter converter)
        {
            dynamicConverter.AddConverter(converter);
        }
    }

    public delegate void ConfigChangedEvent();
    public delegate void ConfigValueChangedEvent(string key);
}

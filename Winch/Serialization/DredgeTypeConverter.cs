using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Localization;
using Winch.Util;

// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable HeapView.PossibleBoxingAllocation

namespace Winch.Serialization;

public class DredgeTypeConverter<T> : IDredgeTypeConverter
{
    private Dictionary<string, FieldDefinition> FieldDefinitions { get; } = new();
    private Dictionary<string, string> Reroutes { get; } = new();
    protected static Dictionary<(string TableId, string Text), LocalizedString> StringDefinitionCache { get; } = new();

    public void PopulateFields(object obj, Dictionary<string, object> data)
    {
        ProcessDictionaryEntries(obj, data);
        ProcessReroutes(obj, data);
    }

    private void ProcessDictionaryEntries(object obj, Dictionary<string, object> data)
    {
        Type itemType = obj.GetType();
        foreach (var field in itemType.GetRuntimeFieldsIncludingBase())
        {
            try
            {
                if (data.TryGetValue(field.Name, out var value))
                {
                    if (FieldDefinitions.TryGetValue(field.Name, out var definition))
                    {
                        field.SetValue(obj,
                            definition.Parser != null
                                ? definition.Parser.Invoke(value)
                                : value);
                    }
                }
                else
                {
                    if (FieldDefinitions.TryGetValue(field.Name, out var definition))
                    {
                        if (definition.DefaultValue != null)
                        {
                            field.SetValue(obj, definition.DefaultValue);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                string configuredValue = data.TryGetValue(field.Name, out var value) ? value.ToString() : "UNDEFINED";
                throw new Exception($"Couldn't process field '{field.Name}' (Configured: '{configuredValue}')", ex);
            }
        }
    }

    private void ProcessReroutes(object obj, Dictionary<string, object> data)
    {
        Type objectType = obj.GetType();
        foreach (var rerouteKeyValPair in Reroutes)
        {
            var fields = objectType.GetRuntimeFieldsIncludingBase();
            var targetField = fields.FirstOrDefault(field => field.Name == rerouteKeyValPair.Key);
            var sourceField = fields.FirstOrDefault(field => field.Name == rerouteKeyValPair.Value);
            if (targetField != null && sourceField != null)
            {
                if (targetField.GetValue(obj) == null)
                {
                    targetField.SetValue(obj, sourceField.GetValue(obj));
                }
            }
        }
    }

    protected void AddDefinitions(Dictionary<string, FieldDefinition> definitions)
    {
        foreach (var fieldDefinitionEntry in definitions)
        {
            if (FieldDefinitions.ContainsKey(fieldDefinitionEntry.Key))
            {
                this.FieldDefinitions[fieldDefinitionEntry.Key] = new(
                    fieldDefinitionEntry.Value.DefaultValue,
                    FieldDefinitions[fieldDefinitionEntry.Key].Parser
                    );
            }
            else
            {
                this.FieldDefinitions.Add(fieldDefinitionEntry.Key, fieldDefinitionEntry.Value);
            }
        }
    }
    
    protected void AddReroutes(Dictionary<string, string> reroutes)
    {
        foreach (var reroute in reroutes)
        {
            this.Reroutes.Add(reroute.Key, reroute.Value);
        }
    }

    protected static LocalizedString CreateLocalizedString(string key, string value)
    {
        var keyValueTuple = (key, value);
        if (StringDefinitionCache.TryGetValue(keyValueTuple, out LocalizedString cached))
        {
            return cached;
        }
        var localizedString = LocalizationUtil.CreateReference(key, value);
        StringDefinitionCache.Add(keyValueTuple, localizedString);
        return localizedString;
    }
}

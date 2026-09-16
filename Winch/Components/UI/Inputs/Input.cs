using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using Winch.Config;
using Winch.Core;
using Winch.Util;

namespace Winch.Components.UI.Inputs;

public abstract class Input : MonoBehaviour, ISettingsRefreshable
{
    internal bool isWinch => modName == WinchCore.GUID;

    [SerializeField]
    protected internal string modName = string.Empty;

    [SerializeField]
    protected internal string key = string.Empty;

    [SerializeField]
    protected internal LocalizeStringEvent localizedStringField;

    [SerializeField]
    protected internal TextTooltipRequester textTooltipRequester;

    [SerializeField]
    protected LocalizedString localizedString = LocalizationUtil.Unknown;

    [SerializeField]
    protected LocalizedString tooltipDescriptionString = LocalizationUtil.Empty;

    protected virtual IEnumerable<TextTooltipRequester> TooltipRequesters
    {
        get
        {
            if (textTooltipRequester != null)
                yield return textTooltipRequester;
        }
    }

    public LocalizedString TitleString
    {
        get => localizedString;
        set
        {
            localizedString = value;

            if (localizedStringField != null)
                localizedStringField.StringReference = value;

            RefreshTooltips();
        }
    }

    public LocalizedString TooltipDescriptionString
    {
        get => tooltipDescriptionString;
        set
        {
            tooltipDescriptionString = value;
            RefreshTooltips();
        }
    }

    private ModConfig _modConfig;

    protected virtual void Start()
    {
        if (localizedStringField != null)
        {
            localizedStringField.OnUpdateString.Invoke(string.Empty);
            localizedStringField.StringReference = localizedString;
        }

        RefreshTooltips();

        if (!isWinch && ModConfig.TryGetConfig(modName, out var config))
        {
            _modConfig = config;
            _modConfig.OnConfigValueChanged += OnConfigValueChanged;
        }
    }

    protected virtual void OnDestroy()
    {
        if (_modConfig != null)
            _modConfig.OnConfigValueChanged -= OnConfigValueChanged;
    }

    private void OnConfigValueChanged(string changedKey)
    {
        if (changedKey == key)
            ForceRefresh();
    }

    protected virtual void RefreshTooltips()
    {
        foreach (var requester in TooltipRequesters)
        {
            if (requester == null) continue;

            requester.LocalizedTitleKey = localizedString;

            if (tooltipDescriptionString.IsEmpty)
            {
                requester.enabled = false;
            }
            else
            {
                requester.LocalizedDescriptionKey = tooltipDescriptionString;
                requester.enabled = true;
            }
        }
    }

    public void ForceRefresh()
    {
        try
        {
            OnForceRefresh();
            gameObject.Activate();
        }
        catch
        {
            gameObject.Deactivate();
        }
    }

    public abstract void OnForceRefresh();

    protected internal virtual T? GetConfigValue<T>()
    {
        if (isWinch)
        {
            return WinchConfig.GetProperty<T>(key);
        }

        if (ModConfig.TryGetConfig(modName, out var config))
        {
            return config.GetProperty<T>(key);
        }

        return default(T);
    }

    protected internal virtual T? GetDefaultConfigValue<T>()
    {
        try
        {
            if (isWinch)
            {
                return WinchConfig.GetDefaultProperty<T>(key);
            }

            if (ModConfig.TryGetConfig(modName, out var config))
            {
                return config.GetDefaultProperty<T>(key);
            }
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error(ex.Message);
        }
        return default(T);
    }

    protected internal virtual void SetConfigValue(string value) => SetConfigValue<string>(value ?? string.Empty);
    protected internal virtual void SetConfigValue<T>(T value)
    {
        if (isWinch)
        {
            WinchConfig.SetProperty<T>(key, value);
            return;
        }

        if (ModConfig.TryGetConfig(modName, out var config))
        {
            config.SetProperty<T>(key, value);
        }
    }

    protected internal virtual void ResetConfigValueToDefault()
    {
        if (isWinch)
        {
            WinchConfig.ResetPropertyToDefault(key);
            return;
        }

        if (ModConfig.TryGetConfig(modName, out var config))
        {
            config.ResetPropertyToDefault(key);
        }
    }
}

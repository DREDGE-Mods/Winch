using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Rendering.Universal;
using Winch.Config;
using Winch.Core;
using Winch.Util;

namespace Winch.Components
{
    public abstract class Input : MonoBehaviour, ISettingsRefreshable
    {
        [SerializeField]
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

        public LocalizedString TitleString
        {
            get => localizedString;
            set
            {
                localizedString = value;
                if (localizedStringField != null)
                {
                    localizedStringField.StringReference = value;
                }
                if (textTooltipRequester != null)
                {
                    textTooltipRequester.LocalizedTitleKey = value;
                }
            }
        }

        public LocalizedString TooltipDescriptionString
        {
            get => tooltipDescriptionString;
            set
            {
                tooltipDescriptionString = value;
                if (textTooltipRequester != null)
                {
                    if (value.IsEmpty)
                    {
                        textTooltipRequester.enabled = false;
                    }
                    else
                    {
                        textTooltipRequester.LocalizedDescriptionKey = value;
                        textTooltipRequester.enabled = true;
                    }
                }
            }
        }

        protected virtual void Start()
        {
            localizedStringField.OnUpdateString.Invoke(string.Empty);
            localizedStringField.StringReference = localizedString;
            textTooltipRequester.LocalizedTitleKey = localizedString;
            if (tooltipDescriptionString.IsEmpty)
            {
                textTooltipRequester.enabled = false;
            }
            else
            {
                textTooltipRequester.LocalizedDescriptionKey = tooltipDescriptionString;
                textTooltipRequester.enabled = true;
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
                return config.GetProperty<T>(key, default(T));
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
                ForceRefresh();
                return;
            }

            if (ModConfig.TryGetConfig(modName, out var config))
            {
                config.ResetPropertyToDefault(key);
                ForceRefresh();
            }
        }
    }
}

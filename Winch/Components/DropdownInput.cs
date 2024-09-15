using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using Winch.Core;
using Winch.Util;

namespace Winch.Components;

public class DropdownInput : Input
{
    [SerializeField]
    public bool populateOptions = true;

    [SerializeField]
    public bool retrieveSelectedIndex = true;

    [SerializeField]
    public bool scrollToSelectedItem = true;

    [SerializeField]
    protected internal TextMeshProUGUI selectedValueTextField;

    [SerializeField]
    protected internal TMP_Dropdown dropdown;

    [SerializeField]
    protected internal SettingsUIComponentEventNotifier dropdownEventNotifier;

    [SerializeField]
    protected List<LocalizedString> optionStrings = new List<LocalizedString>() { LocalizationUtil.Unknown };

    [SerializeField]
    protected List<string> options = new List<string>() { "Unknown" };

    protected bool initialized = false;

    public int CurrentIndex
    {
        get => dropdown.value;
        set => dropdown.value = value;
    }

    public LocalizedString CurrentLocalizedOption
    {
        get => optionStrings[CurrentIndex];
    }

    public string CurrentOption
    {
        get => options[CurrentIndex];
    }

    protected virtual void Awake()
    {
        dropdown.onValueChanged.AddListener(OnValueChanged);
    }

    protected virtual void OnComponentSubmitted()
    {
        if (scrollToSelectedItem)
        {
            var selectedItem = dropdown.GetComponentsInChildren<ScrollRectMagnet>().ElementAtOrDefault(CurrentIndex);
            if (selectedItem != null)
            {
                selectedItem.ScrollToThis();
            }
        }
    }

    protected virtual void OnEnable()
    {
        dropdownEventNotifier.OnComponentSubmitted += OnComponentSubmitted;
        ApplicationEvents.Instance.OnLocaleChanged += OnLocaleChanged;
        RefreshDropdown();
    }

    protected virtual void OnDisable()
    {
        dropdownEventNotifier.OnComponentSubmitted -= OnComponentSubmitted;
        ApplicationEvents.Instance.OnLocaleChanged -= OnLocaleChanged;
    }

    protected virtual void OnLocaleChanged(UnityEngine.Localization.Locale locale)
    {
        RefreshDropdownStrings();
    }

    protected void AddOptionString(LocalizedString str)
    {
        TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
        optionData.text = LocalizationSettings.StringDatabase.GetLocalizedString(str.TableEntryReference, null, FallbackBehavior.UseProjectSettings, Array.Empty<object>());
        dropdown.options.Add(optionData);
    }

    protected virtual void RefreshDropdownStrings()
    {
        if (populateOptions)
        {
            dropdown.options.Clear();
            optionStrings.ForEach(AddOptionString);
            selectedValueTextField.text = LocalizationSettings.StringDatabase.GetLocalizedString(optionStrings[CurrentIndex].TableEntryReference, null, FallbackBehavior.UseProjectSettings, Array.Empty<object>());
        }
    }

    protected virtual void RefreshDropdown()
    {
        RefreshDropdownStrings();
        RetrieveSelectedIndex();
    }

    protected virtual void RetrieveSelectedIndex()
    {
        if (!initialized) return;
        if (!retrieveSelectedIndex) return;

        SetSelectedOption(GetConfigValue<string>() ?? string.Empty);
    }

    protected internal virtual void SetSelectedOption(string option)
    {
        SetSelectedIndex(!string.IsNullOrWhiteSpace(option) ? options.IndexOf(option) : -1);
    }

    protected internal virtual void SetSelectedIndex(int index)
    {
        if (index <= -1) index = 0;

        dropdown.SetValueWithoutNotify(index);
    }

    protected virtual void OnValueChanged(int index)
    {
        if (!initialized) return;
        WinchCore.Log.Debug(string.Format("[DropdownInput:{0}] OnValueChanged({1})", base.name, index));
        ChangeValue(index);
    }

    protected virtual void ChangeValue(int index)
    {
        if (!initialized) return;
        SetConfigValue(options[index]);
    }

    public override void OnForceRefresh()
    {
        RefreshDropdown();
    }

    protected internal virtual void Initialize(string value, string[] options, string[]? optionStrings)
    {
        this.options = options.ToList();
        var newOptionStrings = new List<LocalizedString>();
        if (optionStrings != null)
        {
            foreach (var optionString in optionStrings)
            {
                newOptionStrings.Add(LocalizationUtil.CreateReference("Strings", optionString));
            }
        }
        for (int i = 0; i < options.Length; i++)
        {
            var option = options[i];
            if (value == option)
            {
                SetSelectedIndex(i);
            }
            if (optionStrings == null)
            {
                var optionKey = modName + "." + key + "." + option;
                LocalizationUtil.AddLocalizedString("en", optionKey, option);
                newOptionStrings.Add(LocalizationUtil.CreateReference("Strings", optionKey));
            }
        }
        this.optionStrings = newOptionStrings;
        RefreshDropdown();
        SetSelectedOption(value);
        initialized = true;
    }
}
using UnityEngine;
using UnityEngine.Localization;
using Winch.Util;
using Winch.Core;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Winch.Config;
using Sirenix.Utilities;
using Newtonsoft.Json.Linq;
using System;

namespace Winch.Components;

internal class ModsTab : MonoBehaviour
{
    internal static LocalizedString winchHeader = LocalizationUtil.CreateStringsReference("winch.name");
    internal static LocalizedString tabHeader = LocalizationUtil.CreateStringsReference("settings.tab.mods");
    internal static LocalizedString footerList = LocalizationUtil.CreateStringsReference("settings.mods.footer.list");
    internal static LocalizedString footerOptions = LocalizationUtil.CreateStringsReference("settings.mods.footer.options");

    internal static ModsTab Instance { get; private set; }

    public bool isCurrentTab => Instance.settingsDialog.dialog.CurrentIndex == ModsButton.modsTabIndex;
    public static bool isActive => Instance.isCurrentTab;
    public ResetAllSettingsButton ResetAllSettingsButton => settingsDialog.GetComponentInChildren<ResetAllSettingsButton>(true);

    internal Label labelPrefab;
    internal LocalizedLabel labelLocalizedPrefab;
    internal BasicButtonWrapper buttonPrefab;
    internal DropdownInput dropdownPrefab;
    internal ColorDropdownInput colorDropdownPrefab;
    internal OnOffDropdownInput onOffDropdownPrefab;
    internal SliderInput sliderPrefab;
    internal FieldInput inputFieldPrefab;
    internal IntegerFieldInput integerInputFieldPrefab;
    internal DecimalFieldInput decimalInputFieldPrefab;
    internal SeparatorInput separatorPrefab;
    internal SettingsDialog settingsDialog;
    internal TabbedPanel panel;
    internal TabUI tab;
    internal Transform header;
    internal Label headerText;
    internal LocalizedLabel headerTextLocalized;
    internal Transform footer;
    internal LocalizedLabel footerText;
    internal BasicButtonWrapper footerButton;
    internal BasicButtonWrapper resetAllSettingsButton;
    internal BasicButtonWrapper resumeButton;
    internal BasicButtonWrapper saveAndQuitButton;
    internal Transform list;
    internal Transform options;
    internal ScrollRect listScroller;
    internal ScrollRect optionsScroller;
    internal ControllerFocusGrabber listControllerFocusGrabber;
    internal ControllerFocusGrabber optionsControllerFocusGrabber;
    internal bool inOptions;
    internal bool currentWinch;
    internal ModAssembly currentMod;
    private List<BasicButtonWrapper> modButtons = new List<BasicButtonWrapper>();
    private List<Label> modLabels = new List<Label>();
    private List<Transform> modOptions = new List<Transform>();

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        Refresh();
        tab.Button.GetComponent<BasicButtonWrapper>().OnClick += OnTabSelected;
        headerTextLocalized.LabelString = tabHeader;
        footerButton.OnClick += ExitOptions;
    }

    public void OnEnable()
    {
        UpdateResetButton();
        Refresh();
        ApplicationEvents.Instance.OnSliderFocusToggled += OnSliderFocusToggled;
    }

    public void OnDisable()
    {
        ResetAllSettingsButton.gameObject.Activate();
        ApplicationEvents.Instance.OnSliderFocusToggled -= OnSliderFocusToggled;
    }

    private void OnSliderFocusToggled(bool hasFocus)
    {
        if (inOptions)
            settingsDialog.dialog.RemoveTabInput();
    }

    public void Update()
    {
        UpdateResetButton();
    }

    public void UpdateResetButton()
    {
        if (isCurrentTab)
        {
            ResetAllSettingsButton.gameObject.SetActive(inOptions);
        }
        else
            ResetAllSettingsButton.gameObject.Activate();
    }

    public void OnTabSelected()
    {
        Refresh();
    }

    public void Refresh()
    {
        ExitOptions();
        PopulateList();
        this.FireOnNextUpdate(ScrollToTop);
    }

    public void ScrollToTop()
    {
        listScroller.verticalNormalizedPosition = 1;
        optionsScroller.verticalNormalizedPosition = 1;
    }

    public void PopulateList()
    {
        list.DestroyAllChildrenImmediate();
        modButtons.Clear();
        modLabels.Clear();
        AddWinch();
        foreach (var mod in ModAssemblyLoader.EnabledModAssemblies.Values)
        {
            try
            {
                mod.GetConfig();
            }
            catch(Exception ex)
            {
                if (!(ex.InnerException != null && ex.InnerException.Message.Contains("file found in folder")))
                    WinchCore.Log.Error(ex.InnerException != null ? (ex.Message + " " + ex.InnerException.Message) : ex.Message);
            }
        }
        foreach (var mod in ModAssemblyLoader.EnabledModAssemblies.Values.Where(mod => mod.Config != null && mod.Config.hasProperties))
        {
            AddEnabledMod(mod);
        }
        foreach (var mod in ModAssemblyLoader.EnabledModAssemblies.Values.Where(mod => mod.Config == null || !mod.Config.hasProperties))
        {
            AddDisabledMod(mod);
        }
    }

    public void AddWinch()
    {
        var button = buttonPrefab.Instantiate(list, false).Rename("WinchButton");
        button.DeactivateButtonEffects();
        button.GetComponent<LocalizedLabel>().LabelString = winchHeader;
        button.GetComponent<BasicButtonWrapper>().OnClick += () => OnWinchClicked();
        button.gameObject.AddComponent<ScrollRectMagnet>().scrollRect = listScroller;
        listControllerFocusGrabber.SetSelectable(button.GetComponent<BasicButton>());
        listControllerFocusGrabber.SelectSelectable();
        modButtons.Add(button);
    }

    public void AddEnabledMod(ModAssembly mod)
    {
        var button = buttonPrefab.Instantiate(list, false).Rename(mod.GUID + " Button");
        button.DeactivateButtonEffects();
        button.gameObject.RemoveComponentImmediate<LocalizedLabel>();
        button.gameObject.AddComponent<Label>().LabelString = mod.Name;
        button.GetComponent<BasicButtonWrapper>().OnClick += () => OnModClicked(mod);
        button.gameObject.AddComponent<ScrollRectMagnet>().scrollRect = listScroller;
        modButtons.Add(button);
    }

    public void AddDisabledMod(ModAssembly mod)
    {
        var label = labelPrefab.Instantiate(list, false).Rename(mod.GUID + " Label");
        label.LabelString = mod.Name;
        label.gameObject.AddComponent<ScrollRectMagnet>().scrollRect = listScroller;
        modLabels.Add(label);
    }

    public void OnWinchClicked()
    {
        WinchCore.Log.Debug($"[ModsTab] OnWinchClicked()");
        inOptions = true;
        currentWinch = true;
        currentMod = null;
        settingsDialog.dialog.RemoveTabInput();
        listScroller.gameObject.Deactivate();
        options.DestroyAllChildrenImmediate();
        optionsScroller.gameObject.Activate();
        headerText.gameObject.Deactivate();
        headerTextLocalized.LabelString = winchHeader;
        headerTextLocalized.gameObject.Activate();
        footerText.LabelString = footerOptions;
        footerButton.gameObject.Activate();
        AddWinchOptions();
        var firstSelectable = options.GetComponentInChildren<Selectable>();
        Navigation footerNavigation = footerButton.Button.navigation;
        footerNavigation.mode = Navigation.Mode.Explicit;
        footerNavigation.selectOnLeft = firstSelectable;
        footerNavigation.selectOnUp = firstSelectable;
        footerNavigation.selectOnDown = resumeButton.Button;
        footerButton.Button.navigation = footerNavigation;
        optionsControllerFocusGrabber.SetSelectable(firstSelectable);
        optionsControllerFocusGrabber.SelectSelectable();
        Navigation resumeNavigation = resumeButton.Button.navigation;
        Navigation saveAndQuitNavigation = saveAndQuitButton.Button.navigation;
        Navigation resetAllSettingsNavigation = resetAllSettingsButton.Button.navigation;
        resumeNavigation.mode = Navigation.Mode.Explicit;
        saveAndQuitNavigation.mode = Navigation.Mode.Explicit;
        resetAllSettingsNavigation.mode = Navigation.Mode.Explicit;
        resumeNavigation.selectOnUp = footerButton.Button;
        saveAndQuitNavigation.selectOnUp = footerButton.Button;
        resetAllSettingsNavigation.selectOnUp = footerButton.Button;
        resetAllSettingsNavigation.selectOnRight = resumeButton.Button;
        resumeNavigation.selectOnRight = saveAndQuitButton.Button;
        resumeNavigation.selectOnLeft = resetAllSettingsButton.Button;
        saveAndQuitNavigation.selectOnLeft = resumeButton.Button;
        resumeButton.Button.navigation = resumeNavigation;
        saveAndQuitButton.Button.navigation = saveAndQuitNavigation;
        resetAllSettingsButton.Button.navigation = resetAllSettingsNavigation;
        ScrollToTop();
    }

    public void AddWinchOptions()
    {
        foreach (var obj in WinchConfig.GetProperties())
        {
            var localizedBase = "winch." + obj.Key.ToLowerInvariant();
            var title = localizedBase + ".title";
            var tooltip = localizedBase + ".tooltip";
            switch (obj.Key)
            {
                case "WriteLogsToFile":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "WriteLogsToConsole":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "LogLevel":
                    AddDropdownInput(WinchCore.GUID, obj.Key, (string)obj.Value, EnumUtil.GetNames<Winch.LogLevel>(), EnumUtil.GetNames<Winch.LogLevel>().Select(level =>
                    {
                        var key = "winch." + level;
                        LocalizationUtil.AddLocalizedString("en", key, System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(level.ToLowerInvariant()));
                        return key;
                    }).ToArray(), title, tooltip);
                    break;
                case "LogsFolder":
                    AddTextInput(WinchCore.GUID, obj.Key, (string)obj.Value, title, tooltip);
                    break;
                case "DetailedLogSources":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "EnableDeveloperConsole":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "MaxLogFiles":
                    AddIntegerInput(WinchCore.GUID, obj.Key, obj.Value, title, tooltip);
                    break;
                case "ExportYarnProgram":
                    AddToggleInput(WinchCore.GUID, obj.Key, (bool)obj.Value, title, tooltip);
                    break;
                case "LogPort":
                    break;
                default:
                    AddConfigInput(WinchCore.GUID, obj.Key, obj.Value);
                    break;
            }
        }
    }

    public void OnModClicked(ModAssembly mod)
    {
        WinchCore.Log.Debug($"[ModsTab] OnModClicked({mod.GUID})");
        inOptions = true;
        currentWinch = false;
        currentMod = mod;
        settingsDialog.dialog.RemoveTabInput();
        listScroller.gameObject.Deactivate();
        options.DestroyAllChildrenImmediate();
        optionsScroller.gameObject.Activate();
        headerTextLocalized.gameObject.Deactivate();
        headerText.LabelString = mod.Name;
        headerText.gameObject.Activate();
        footerText.LabelString = footerOptions;
        footerButton.gameObject.Activate();
        AddOptions(mod);
        var firstSelectable = options.GetComponentInChildren<Selectable>();
        Navigation footerNavigation = footerButton.Button.navigation;
        footerNavigation.mode = Navigation.Mode.Explicit;
        footerNavigation.selectOnLeft = firstSelectable;
        footerNavigation.selectOnUp = firstSelectable;
        footerNavigation.selectOnDown = resumeButton.Button;
        footerButton.Button.navigation = footerNavigation;
        optionsControllerFocusGrabber.SetSelectable(firstSelectable);
        optionsControllerFocusGrabber.SelectSelectable();
        Navigation resumeNavigation = resumeButton.Button.navigation;
        Navigation saveAndQuitNavigation = saveAndQuitButton.Button.navigation;
        Navigation resetAllSettingsNavigation = resetAllSettingsButton.Button.navigation;
        resumeNavigation.mode = Navigation.Mode.Explicit;
        saveAndQuitNavigation.mode = Navigation.Mode.Explicit;
        resetAllSettingsNavigation.mode = Navigation.Mode.Explicit;
        resumeNavigation.selectOnUp = footerButton.Button;
        saveAndQuitNavigation.selectOnUp = footerButton.Button;
        resetAllSettingsNavigation.selectOnUp = footerButton.Button;
        resetAllSettingsNavigation.selectOnRight = resumeButton.Button;
        resumeNavigation.selectOnRight = saveAndQuitButton.Button;
        resumeNavigation.selectOnLeft = resetAllSettingsButton.Button;
        saveAndQuitNavigation.selectOnLeft = resumeButton.Button;
        resumeButton.Button.navigation = resumeNavigation;
        saveAndQuitButton.Button.navigation = saveAndQuitNavigation;
        resetAllSettingsButton.Button.navigation = resetAllSettingsNavigation;
        ScrollToTop();
    }

    public void AddOptions(ModAssembly mod)
    {
        var config = mod.Config;
        if (config != null)
        {
            foreach (var obj in config.GetProperties())
            {
                AddConfigInput(mod.GUID, obj.Key, obj.Value);
            }
        }
    }

    protected Input AddConfigInput(string modName, string key, object value)
    {
        if (value is JObject obj)
        {
            var settingType = (string)obj["type"];
            if (!string.IsNullOrWhiteSpace(settingType))
            {
                return settingType switch
                {
                    "separator" => AddSeparatorAndLabelInput(modName, key, obj),
                    "slider" => AddSliderInput(modName, key, obj),
                    "toggle" => AddToggleInput(modName, key, obj),
                    "dropdown" => AddDropdownInput(modName, key, obj),
                    "color" => AddColorDropdownInput(modName, key, obj),
                    "text" => AddTextInput(modName, key, obj),
                    "integer" => AddIntegerInput(modName, key, obj),
                    "decimal" or "number" => AddDecimalInput(modName, key, obj),
                    _ => throw new InvalidOperationException("Unrecognized complex setting type: " + settingType),
                };
            }
            else
            {
                value = obj["value"].ToObject<object?>();

                if (value is bool)
                {
                    return AddToggleInput(modName, key, obj);
                }

                if (value is string)
                {
                    return AddTextInput(modName, key, obj);
                }

                if (new[] { typeof(long), typeof(int), typeof(short), typeof(byte), typeof(ulong), typeof(uint), typeof(ushort), typeof(sbyte) }.Contains(value.GetType()))
                {
                    return AddIntegerInput(modName, key, obj);
                }

                if (new[] { typeof(decimal), typeof(float), typeof(double) }.Contains(value.GetType()))
                {
                    return AddDecimalInput(modName, key, obj);
                }

                throw new InvalidOperationException("Unrecognized obj setting type: " + value.GetType());
            }
        }

        if (value is bool torf)
        {
            return AddToggleInput(modName, key, torf);
        }

        if (value is string svalue)
        {
            return AddTextInput(modName, key, svalue);
        }

        if (new[] { typeof(long), typeof(int), typeof(short), typeof(byte), typeof(ulong), typeof(uint), typeof(ushort), typeof(sbyte) }.Contains(value.GetType()))
        {
            return AddIntegerInput(modName, key, value);
        }

        if (new[] { typeof(decimal), typeof(float), typeof(double) }.Contains(value.GetType()))
        {
            return AddDecimalInput(modName, key, value);
        }

        if (value is JValue jvalue)
        {
            return AddConfigInput(modName, key, jvalue.ToObject<object?>());
        }

        throw new InvalidOperationException("Unrecognized setting type: " + value.GetType());
    }

    private SeparatorInput AddSeparatorAndLabelInput(string modName, string key, JObject obj) => AddSeparatorAndLabelInput(modName, key, (string)obj["title"]);

    private SeparatorInput AddSeparatorAndLabelInput(string modName, string key, string title)
    {
        var count = modOptions.Count == 0 ? 1 : (3 - ((modOptions.Count - 1) % 3)); //shenanigans to put empty spaces until next middle
        for (int i = 0; i < count; i++)
        {
            AddSeparatorInput(modName, key + i);
        }
        var clone = labelLocalizedPrefab.Instantiate(options, false).gameObject.AddComponent<SeparatorInput>();
        if (string.IsNullOrWhiteSpace(title))
        {
            LocalizationUtil.AddLocalizedString("en", key, key.SplitPascalCase());
            clone.GetComponent<LocalizedLabel>().LabelString = LocalizationUtil.CreateStringsReference(key);
        }
        else
        {
            clone.GetComponent<LocalizedLabel>().LabelString = LocalizationUtil.CreateStringsReference(title);
        }
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        AddScrollMagnet(clone);
        AddSeparatorInput(modName, key + "End");
        return clone;
    }

    private SeparatorInput AddSeparatorInput(string modName, string key)
    {
        var clone = separatorPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        AddScrollMagnet(clone);
        return clone;
    }

    private OnOffDropdownInput AddToggleInput(string modName, string key, bool value)
    {
        var clone = onOffDropdownPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.SetSelectedValue(value);
        SetupTitle(clone, string.Empty, key);
        AddScrollMagnet(clone);
        return clone;
    }

    private OnOffDropdownInput AddToggleInput(string modName, string key, JObject obj) => AddToggleInput(modName, key, (bool)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    private OnOffDropdownInput AddToggleInput(string modName, string key, bool value, string title, string tooltip)
    {
        var clone = onOffDropdownPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.SetSelectedValue(value);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddScrollMagnet(clone);
        return clone;
    }

    private SliderInput AddSliderInput(string modName, string key, JObject obj) => AddSliderInput(modName, key, (float)obj["value"], (float)obj["min"], (float)obj["max"], (string)obj["title"], (string)obj["tooltip"]);

    private SliderInput AddSliderInput(string modName, string key, float value, float min, float max)
    {
        var clone = sliderPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, min, max);
        SetupTitle(clone, string.Empty, key);
        AddScrollMagnet(clone);
        return clone;
    }

    private SliderInput AddSliderInput(string modName, string key, float value, float min, float max, string title, string tooltip)
    {
        var clone = sliderPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, min, max);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddScrollMagnet(clone);
        return clone;
    }

    private DropdownInput AddDropdownInput(string modName, string key, JObject obj) => AddDropdownInput(modName, key, (string)obj["value"], obj["options"].ToObject<string[]>(), obj["optionStrings"]?.ToObject<string[]>(), (string)obj["title"], (string)obj["tooltip"]);

    private ColorDropdownInput AddColorDropdownInput(string modName, string key, JObject obj) => AddColorDropdownInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    private ColorDropdownInput AddColorDropdownInput(string modName, string key, string value, string title, string tooltip)
    {
        var clone = colorDropdownPrefab.Instantiate(this.options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddScrollMagnet(clone);
        return clone;
    }

    private DropdownInput AddDropdownInput(string modName, string key, string value, string[] options, string[] optionStrings)
    {
        var clone = dropdownPrefab.Instantiate(this.options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, options, optionStrings);
        SetupTitle(clone, string.Empty, key);
        AddScrollMagnet(clone);
        return clone;
    }

    private DropdownInput AddDropdownInput(string modName, string key, string value, string[] options, string[] optionStrings, string title, string tooltip)
    {
        var clone = dropdownPrefab.Instantiate(this.options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, options, optionStrings);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddScrollMagnet(clone);
        return clone;
    }

    private FieldInput AddTextInput(string modName, string key, string value)
    {
        var clone = inputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value);
        SetupTitle(clone, string.Empty, key);
        AddScrollMagnet(clone);
        return clone;
    }

    private FieldInput AddTextInput(string modName, string key, JObject obj) => AddTextInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    private FieldInput AddTextInput(string modName, string key, string value, string title, string tooltip)
    {
        var clone = inputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddScrollMagnet(clone);
        return clone;
    }

    private IntegerFieldInput AddIntegerInput(string modName, string key, object value)
    {
        var clone = integerInputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, string.Empty, key);
        AddScrollMagnet(clone);
        return clone;
    }

    private IntegerFieldInput AddIntegerInput(string modName, string key, JObject obj) => AddIntegerInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    private IntegerFieldInput AddIntegerInput(string modName, string key, object value, string title, string tooltip)
    {
        var clone = integerInputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddScrollMagnet(clone);
        return clone;
    }

    private DecimalFieldInput AddDecimalInput(string modName, string key, object value)
    {
        var clone = decimalInputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, string.Empty, key);
        AddScrollMagnet(clone);
        return clone;
    }

    private DecimalFieldInput AddDecimalInput(string modName, string key, JObject obj) => AddDecimalInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    private DecimalFieldInput AddDecimalInput(string modName, string key, object value, string title, string tooltip)
    {
        var clone = decimalInputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddScrollMagnet(clone);
        return clone;
    }

    internal void SetupInputTooltip(Input input, string tooltip)
    {
        if (!string.IsNullOrWhiteSpace(tooltip))
        {
            input.TooltipDescriptionString = LocalizationUtil.CreateStringsReference(tooltip);
        }
    }

    internal void SetupTitle(Input input, string title, string key)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            LocalizationUtil.AddLocalizedString("en", key, key.SplitPascalCase());
            input.TitleString = LocalizationUtil.CreateStringsReference(key);
        }
        else
        {
            input.TitleString = LocalizationUtil.CreateStringsReference(title);
        }
    }

    internal void AddScrollMagnet(Input input)
    {
        input.gameObject.AddComponent<ScrollRectMagnet>().scrollRect = optionsScroller;
    }

    public void ExitOptions()
    {
        WinchCore.Log.Debug($"[ModsTab] ExitOptions()");
        inOptions = false;
        currentWinch = false;
        currentMod = null;
        settingsDialog.dialog.AddTabInput();
        optionsScroller.gameObject.Deactivate();
        modOptions.Clear();
        options.DestroyAllChildrenImmediate();
        listScroller.gameObject.Activate();
        listControllerFocusGrabber.SelectSelectable();
        modButtons.ForEach(button => button.SetCanBeClicked(true));
        headerText.gameObject.Deactivate();
        headerTextLocalized.gameObject.Activate();
        footerText.LabelString = footerList;
        footerButton.gameObject.Deactivate();
        Navigation resumeNavigation = resumeButton.Button.navigation;
        Navigation saveAndQuitNavigation = saveAndQuitButton.Button.navigation;
        Navigation resetAllSettingsNavigation = resetAllSettingsButton.Button.navigation;
        resumeNavigation.mode = Navigation.Mode.Automatic;
        saveAndQuitNavigation.mode = Navigation.Mode.Automatic;
        resetAllSettingsNavigation.mode = Navigation.Mode.Automatic;
        resumeButton.Button.navigation = resumeNavigation;
        saveAndQuitButton.Button.navigation = saveAndQuitNavigation;
        resetAllSettingsButton.Button.navigation = resetAllSettingsNavigation;
    }
}

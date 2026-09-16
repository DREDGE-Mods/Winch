using UnityEngine;
using UnityEngine.Localization;
using InControl;
using Winch.Util;
using Winch.Core;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Winch.Config;
using Sirenix.Utilities;
using Newtonsoft.Json.Linq;
using System;
using Winch.Core.API;
using Winch.Components.UI.Inputs;
using Input = Winch.Components.UI.Inputs.Input;

namespace Winch.Components.UI;

public class ModsTab : MonoBehaviour
{
    public static readonly LocalizedString winchHeader = LocalizationUtil.CreateStringsReference("winch.name");
    public static readonly LocalizedString tabHeader = LocalizationUtil.CreateStringsReference("settings.tab.mods");
    public static readonly LocalizedString footerList = LocalizationUtil.CreateStringsReference("settings.mods.footer.list");
    public static readonly LocalizedString footerOptions = LocalizationUtil.CreateStringsReference("settings.mods.footer.options");

    public static ModsTab Instance { get; private set; }

    public bool isCurrentTab => Instance.settingsDialog.dialog.CurrentIndex == ModsButton.modsTabIndex;
    public static bool isActive => Instance.isCurrentTab;
    public ResetAllSettingsButton ResetAllSettingsButton => settingsDialog.GetComponentInChildren<ResetAllSettingsButton>(true);

    public Label labelPrefab;
    public LocalizedLabel labelLocalizedPrefab;
    public BasicButtonWrapper buttonPrefab;
    public DropdownInput dropdownPrefab;
    public ColorDropdownInput colorDropdownPrefab;
    public OnOffDropdownInput onOffDropdownPrefab;
    public SliderInput sliderPrefab;
    public FieldInput inputFieldPrefab;
    public IntegerFieldInput integerInputFieldPrefab;
    public DecimalFieldInput decimalInputFieldPrefab;
    public SeparatorInput separatorPrefab;
    public SettingsDialog settingsDialog;
    public TabbedPanel panel;
    public TabUI tab;
    public Transform header;
    public Label headerText;
    public LocalizedLabel headerTextLocalized;
    public Transform footer;
    public LocalizedLabel footerText;
    public BasicButtonWrapper footerButton;
    public BasicButtonWrapper resetAllSettingsButton;
    public BasicButtonWrapper resumeButton;
    public BasicButtonWrapper saveAndQuitButton;
    public Transform list;
    public Transform options;
    public ScrollRect listScroller;
    public ScrollRect optionsScroller;
    public ControllerFocusGrabber listControllerFocusGrabber;
    public ControllerFocusGrabber optionsControllerFocusGrabber;
    public bool inOptions;
    public bool currentWinch;
    public ModAssembly currentMod;
    public List<BasicButtonWrapper> modButtons = new List<BasicButtonWrapper>();
    public List<Label> modLabels = new List<Label>();
    public List<Transform> modOptions = new List<Transform>();

    private static bool _automaticNavigation = false;
    public static bool AutomaticNavigation => _automaticNavigation;

    public void Awake()
    {
        Instance = this;
        ConfigureScrollRect(listScroller);
        ConfigureScrollRect(optionsScroller);

        SetupOptionsPadding();
    }

    private const int OptionsBottomPadding = 24;
    private const float ControllerScrollDeadZone = 0.2f;
    private const float ControllerScrollSpeed = 500f; // Pixels per second
    private const float NavigationRowTolerance = 4f;

    private void SetupOptionsPadding()
    {
        var layout = options.GetComponent<GridLayoutGroup>();
        if (layout == null)
            return;

        layout.padding.bottom = OptionsBottomPadding;
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

        if (!isCurrentTab)
            return;

        HandleScrollInput(inOptions ? optionsScroller : listScroller);
    }

    private static void ConfigureScrollRect(ScrollRect scrollRect)
    {
        if (scrollRect == null)
            return;

        var scrollbar = scrollRect.verticalScrollbar;
        if (scrollbar == null)
            return;

        scrollbar.enabled = true;
        scrollbar.interactable = true;

        // Make sure the scrollbar is in front of the viewport and can receive clicks/drags.
        scrollbar.transform.SetAsLastSibling();

        foreach (var graphic in scrollbar.GetComponentsInChildren<Graphic>(true))
        {
            graphic.raycastTarget = true;
        }
    }

    private static Selectable MakeLabelSelectable(GameObject gameObject)
    {
        if (gameObject == null)
            return null;

        var selectable = gameObject.GetOrAddComponent<Selectable>();
        selectable.interactable = true;

        var uiSelectable = gameObject.GetOrAddComponent<UISelectable>();
        uiSelectable.doesSelectableMove = true;
        uiSelectable.delayForOneFrame = true;

        if (AutomaticNavigation)
        {
            var navigation = selectable.navigation;
            navigation.mode = Navigation.Mode.Automatic;
            selectable.navigation = navigation;
        }

        return selectable;
    }

    private static Selectable ConfigureScrollContentNavigation(
        ScrollRect scrollRect,
        Selectable fallbackTarget = null
    )
    {
        if (scrollRect == null || scrollRect.content == null)
            return null;

        ForceScrollRectLayout(scrollRect);

        var content = scrollRect.content;
        var selectables = content
            .GetComponentsInChildren<Selectable>(false)
            .Where(selectable =>
                selectable != null &&
                selectable.gameObject.activeInHierarchy &&
                selectable.interactable &&
                IsTopLevelSelectable(selectable, content)
            )
            .OrderByDescending(selectable => GetSelectablePosition(selectable, content).y)
            .ThenBy(selectable => GetSelectablePosition(selectable, content).x)
            .ToList();

        if (selectables.Count == 0)
            return null;

        var rows = new List<List<Selectable>>();
        var rowY = new List<float>();

        foreach (var selectable in selectables)
        {
            var position = GetSelectablePosition(selectable, content);

            if (rows.Count == 0 ||
                Mathf.Abs(position.y - rowY[rowY.Count - 1]) > NavigationRowTolerance)
            {
                rows.Add(new List<Selectable> { selectable });
                rowY.Add(position.y);
            }
            else
            {
                rows[rows.Count - 1].Add(selectable);
            }
        }

        foreach (var row in rows)
        {
            row.Sort((a, b) =>
                GetSelectablePosition(a, content).x.CompareTo(
                    GetSelectablePosition(b, content).x
                )
            );
        }

        for (var rowIndex = 0; rowIndex < rows.Count; rowIndex++)
        {
            var row = rows[rowIndex];

            for (var columnIndex = 0; columnIndex < row.Count; columnIndex++)
            {
                var selectable = row[columnIndex];
                var navigation = selectable.navigation;

                navigation.mode = Navigation.Mode.Explicit;

                navigation.selectOnLeft =
                    columnIndex > 0
                        ? row[columnIndex - 1]
                        : fallbackTarget;

                navigation.selectOnRight =
                    columnIndex + 1 < row.Count
                        ? row[columnIndex + 1]
                        : fallbackTarget;

                navigation.selectOnUp =
                    rowIndex > 0
                        ? FindClosestOnRow(
                            rows[rowIndex - 1],
                            selectable,
                            content
                        )
                        : fallbackTarget;

                navigation.selectOnDown =
                    rowIndex + 1 < rows.Count
                        ? FindClosestOnRow(
                            rows[rowIndex + 1],
                            selectable,
                            content
                        )
                        : fallbackTarget;

                selectable.navigation = navigation;
            }
        }

        return rows[0][0];
    }

    private static bool IsTopLevelSelectable(Selectable selectable, RectTransform content)
    {
        var parent = selectable.transform.parent;

        while (parent != null && parent != content)
        {
            if (parent.GetComponent<Selectable>() != null)
                return false;

            parent = parent.parent;
        }

        return true;
    }

    private static Vector2 GetSelectablePosition(
        Selectable selectable,
        RectTransform content
    )
    {
        var navigationTransform = GetNavigationTransform(
            selectable.transform,
            content
        );

        if (navigationTransform is not RectTransform rectTransform)
        {
            return content.InverseTransformPoint(
                navigationTransform.position
            );
        }

        return content.InverseTransformPoint(
            rectTransform.TransformPoint(rectTransform.rect.center)
        );
    }

    private static Transform GetNavigationTransform(
        Transform transform,
        RectTransform content
    )
    {
        while (
            transform.parent != null &&
            transform.parent != content
        )
        {
            transform = transform.parent;
        }

        return transform;
    }

    private static Selectable FindClosestOnRow(
        IEnumerable<Selectable> row,
        Selectable source,
        RectTransform content
    )
    {
        var sourceX = GetSelectablePosition(source, content).x;

        return row
            .OrderBy(selectable =>
                Mathf.Abs(GetSelectablePosition(selectable, content).x - sourceX)
            )
            .FirstOrDefault();
    }

    private static Selectable FindBottomSelectable(ScrollRect scrollRect, Selectable source)
    {
        if (scrollRect == null || scrollRect.content == null || source == null)
            return null;

        var content = scrollRect.content;
        var sourceWorldX = source.transform.position.x;

        return content
            .GetComponentsInChildren<Selectable>(false)
            .Where(selectable =>
                selectable != null &&
                selectable.gameObject.activeInHierarchy &&
                selectable.interactable &&
                IsTopLevelSelectable(selectable, content)
            )
            .OrderBy(selectable => GetSelectablePosition(selectable, content).y)
            .ThenBy(selectable => Mathf.Abs(selectable.transform.position.x - sourceWorldX))
            .FirstOrDefault();
    }

    private static void HandleScrollInput(ScrollRect scroll)
    {
        if (scroll == null || !scroll.gameObject.activeInHierarchy)
            return;

        if (UnityEngine.Input.GetKeyDown(KeyCode.Home))
        {
            ScrollHome(scroll);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.End))
        {
            ScrollEnd(scroll);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.PageUp))
        {
            ScrollPageUp(scroll);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.PageDown))
        {
            ScrollPageDown(scroll);
        }

        var controllerScroll = InputManager.ActiveDevice.RightStickY.Value;

        if (Mathf.Abs(controllerScroll) > ControllerScrollDeadZone)
        {
            var scrollableHeight = Mathf.Max(
                1f,
                scroll.content.rect.height - scroll.viewport.rect.height
            );

            var input = Mathf.InverseLerp(
                ControllerScrollDeadZone,
                1f,
                Mathf.Abs(controllerScroll)
            ) * Mathf.Sign(controllerScroll);

            scroll.verticalNormalizedPosition = Mathf.Clamp01(
                scroll.verticalNormalizedPosition
                + input * ControllerScrollSpeed / scrollableHeight * Time.unscaledDeltaTime
            );
        }
    }

    public static void ScrollHome(ScrollRect scroll)
    {
        if (scroll == null)
            return;

        scroll.verticalNormalizedPosition = 1f;
    }

    public static void ScrollEnd(ScrollRect scroll)
    {
        if (scroll == null)
            return;

        scroll.verticalNormalizedPosition = 0f;
    }

    public static void ScrollPageUp(ScrollRect scroll)
    {
        if (scroll == null)
            return;

        scroll.verticalNormalizedPosition =
            Mathf.Clamp01(
                scroll.verticalNormalizedPosition + 0.25f
            );
    }

    public static void ScrollPageDown(ScrollRect scroll)
    {
        if (scroll == null)
            return;

        scroll.verticalNormalizedPosition =
            Mathf.Clamp01(
                scroll.verticalNormalizedPosition - 0.25f
            );
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

    public void RefreshAllInputs()
    {
        if (options == null) return;

        var inputs = options.GetComponentsInChildren<Input>(true);
        foreach (var input in inputs)
        {
            try
            {
                input.ForceRefresh();
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Error refreshing input '{input?.name}': {ex}");
            }
        }
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
            catch (Exception ex)
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

        if (!AutomaticNavigation)
            ConfigureScrollContentNavigation(listScroller);
    }

    public void AddWinch()
    {
        var button = buttonPrefab.Instantiate(list, false).Rename("WinchButton");
        button.DeactivateButtonEffects();
        button.GetOrAddComponent<LocalizedLabel>().LabelString = winchHeader;
        button.GetComponent<BasicButtonWrapper>().OnClick += () => OnWinchClicked();
        AddScrollMagnets(button.transform, listScroller);
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
        AddScrollMagnets(button.transform, listScroller);
        modButtons.Add(button);
    }

    public void AddDisabledMod(ModAssembly mod)
    {
        var label = labelPrefab.Instantiate(list, false).Rename(mod.GUID + " Label");
        label.LabelString = mod.Name;
        MakeLabelSelectable(label.gameObject);
        AddScrollMagnets(label.transform, listScroller);
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
        RefreshOptionsForController();
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
                    AddDropdownInput(WinchCore.GUID, obj.Key, (string)obj.Value,
                        EnumUtil.GetNames<Winch.LogLevel>(),
                        EnumUtil.GetNames<Winch.LogLevel>()
                            .Select(
                                level =>
                                    "winch.loglevel."
                                        + level.ToLowerInvariant()
                            ).ToArray(),
                        title, tooltip);
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
        DredgeEvent.TriggerBuildModConfigMenu(mod, this);

        modSettingsSubtabs.Open(mod);
        ConfigureOptionsNavigation(modSettingsSubtabs.GetFirstSelectable());
        ScrollToTop();
    }

    public void ConfigureOptionsNavigation(Selectable firstSelectable)
    {
        var activeScrollRect =
            modSettingsSubtabs?.ActiveScrollRect ?? optionsScroller;

        var bottomSelectable = firstSelectable;

        if (!AutomaticNavigation)
        {
            var rebuiltFirstSelectable = ConfigureScrollContentNavigation(
                activeScrollRect,
                footerButton.Button
            );

            firstSelectable = rebuiltFirstSelectable ?? firstSelectable;

            bottomSelectable =
                FindBottomSelectable(activeScrollRect, footerButton.Button) ??
                firstSelectable;
        }

        Navigation footerNavigation = footerButton.Button.navigation;
        footerNavigation.mode = Navigation.Mode.Explicit;
        footerNavigation.selectOnLeft = bottomSelectable;
        footerNavigation.selectOnUp = bottomSelectable;
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

    // Allows mods to add a custom button into the current options list programmatically.
    public BasicButtonWrapper AddOptionButton(string name, string text, Action onClick) =>
        AddOptionButton(name, text, string.Empty, onClick);

    public BasicButtonWrapper AddOptionButton(string name, string text, string tooltip, Action onClick)
    {
        var button = buttonPrefab.Instantiate(options, false).Rename(name);
        button.DeactivateButtonEffects();

        // Ensure we use a simple non-localized label.
        button.gameObject.RemoveComponentImmediate<LocalizedLabel>();

        var label = button.gameObject.AddComponent<Label>();
        label.LabelString = text;

        var wrapper = button.GetComponent<BasicButtonWrapper>();

        if (onClick != null)
            wrapper.OnClick += onClick;

        SetupButtonTooltip(wrapper, name, text, tooltip);

        AddScrollMagnets(button.transform, optionsScroller);
        modOptions.Add(button.transform);

        return wrapper;
    }

    public BasicButtonWrapper AddOptionButtonLocalized(
        string name,
        string localizedLabel,
        Action onClick
    ) =>
        AddOptionButtonLocalized(
            name,
            LocalizationUtil.CreateReference(localizedLabel),
            LocalizationUtil.Empty,
            onClick
        );

    public BasicButtonWrapper AddOptionButtonLocalized(
        string name,
        string localizedLabel,
        string localizedTooltip,
        Action onClick
    ) =>
        AddOptionButtonLocalized(
            name,
            LocalizationUtil.CreateReference(localizedLabel),
            string.IsNullOrWhiteSpace(localizedTooltip)
                ? LocalizationUtil.Empty
                : LocalizationUtil.CreateReference(localizedTooltip),
            onClick
        );

    public BasicButtonWrapper AddOptionButtonLocalized(
        string name,
        LocalizedString localizedLabel,
        Action onClick
    ) =>
        AddOptionButtonLocalized(
            name,
            localizedLabel,
            LocalizationUtil.Empty,
            onClick
        );

    public BasicButtonWrapper AddOptionButtonLocalized(
        string name,
        LocalizedString localizedLabel,
        LocalizedString localizedTooltip,
        Action onClick
    )
    {
        var button = buttonPrefab.Instantiate(options, false).Rename(name);
        button.DeactivateButtonEffects();

        button.gameObject.RemoveComponentImmediate<Label>();

        var localized = button.GetOrAddComponent<LocalizedLabel>();
        localized.LabelString = localizedLabel;

        var wrapper = button.GetComponent<BasicButtonWrapper>();

        if (onClick != null)
            wrapper.OnClick += onClick;

        SetupButtonTooltip(wrapper, localizedLabel, localizedTooltip);

        AddScrollMagnets(button.transform, optionsScroller);
        modOptions.Add(button.transform);

        return wrapper;
    }

    private void SetupButtonTooltip(
        BasicButtonWrapper button,
        string name,
        string title,
        string tooltip
    )
    {
        if (string.IsNullOrWhiteSpace(tooltip))
            return;

        var prefix = currentMod?.GUID ?? WinchCore.GUID;

        var titleKey = $"{prefix}.{name}.title";
        var tooltipKey = $"{prefix}.{name}.tooltip";

        LocalizationUtil.AddEnglishModString(titleKey, title);
        LocalizationUtil.AddEnglishModString(tooltipKey, tooltip);

        SetupButtonTooltip(
            button,
            LocalizationUtil.CreateReference(titleKey),
            LocalizationUtil.CreateReference(tooltipKey)
        );
    }

    private void SetupButtonTooltip(
        BasicButtonWrapper button,
        LocalizedString title,
        LocalizedString tooltip
    )
    {
        if (tooltip.IsEmpty)
            return;

        var requester = button.gameObject.GetOrAddComponent<TextTooltipRequester>();

        requester.LocalizedTitleKey = title;
        requester.LocalizedDescriptionKey = tooltip;
        requester.enabled = true;
    }

    public bool SetOptionCentered(Transform option, bool centered = true)
    {
        if (option == null || !modOptions.Contains(option))
            return false;

        if (centered)
            option.gameObject.GetOrAddComponent<CenteredOption>();
        else
            option.gameObject.RemoveComponentImmediate<CenteredOption>();

        RebuildOptionLayout();
        return true;
    }

    public bool SetOptionCentered(Input input, bool centered = true) =>
        input != null && SetOptionCentered(input.transform, centered);

    public bool SetOptionCentered(BasicButtonWrapper button, bool centered = true) =>
        button != null && SetOptionCentered(button.transform, centered);

    public bool SetOptionCentered(string name, bool centered = true)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        var option = modOptions.FirstOrDefault(
            option => option != null && option.name == name
        );

        return option != null && SetOptionCentered(option, centered);
    }

    public Input AddConfigInput(string modName, string key, object value)
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

    private readonly HashSet<Transform> layoutSeparators = new();

    private SeparatorInput AddLayoutSeparatorInput(string modName, string key)
    {
        var separator = AddSeparatorInput(modName, key);
        layoutSeparators.Add(separator.transform);
        return separator;
    }

    public SeparatorInput AddSeparatorAndLabelInput(string modName, string key, JObject obj) =>
        AddSeparatorAndLabelInput(modName, key, (string)obj["title"]);

    public SeparatorInput AddSeparatorAndLabelInput(string modName, string key, string title)
    {
        AddCenteredOptionPadding(modName, key);

        var clone = labelLocalizedPrefab
            .Instantiate(options, false)
            .gameObject
            .AddComponent<SeparatorInput>();

        clone.gameObject.AddComponent<CenteredOption>();

        if (string.IsNullOrWhiteSpace(title))
        {
            LocalizationUtil.AddEnglishModString(key, key.SplitPascalCase());
            clone.GetOrAddComponent<LocalizedLabel>().LabelString =
                LocalizationUtil.CreateReference(key);
        }
        else
        {
            clone.GetOrAddComponent<LocalizedLabel>().LabelString =
                LocalizationUtil.CreateReference(title);
        }

        modOptions.Add(clone.transform);

        clone.modName = modName;
        clone.key = key;
        clone.name = key;

        MakeLabelSelectable(clone.gameObject);
        AddInputScrollMagnet(clone);

        // Right side of the label row.
        AddLayoutSeparatorInput(modName, key + "End");

        return clone;
    }

    private void AddCenteredOptionPadding(string modName, string key)
    {
        // Finish the current row, then add the empty left cell of the label row.
        var count = 1 + ((3 - (modOptions.Count % 3)) % 3);

        for (int i = 0; i < count; i++)
        {
            AddLayoutSeparatorInput(modName, key + i);
        }
    }

    public SeparatorInput AddSeparatorInput(string modName, string key)
    {
        var clone = separatorPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        AddInputScrollMagnet(clone);
        return clone;
    }

    public OnOffDropdownInput AddToggleInput(string modName, string key, bool value)
    {
        var clone = onOffDropdownPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.SetSelectedValue(value);
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public OnOffDropdownInput AddToggleInput(string modName, string key, JObject obj) => AddToggleInput(modName, key, (bool)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public OnOffDropdownInput AddToggleInput(string modName, string key, bool value, string title, string tooltip)
    {
        var clone = onOffDropdownPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.SetSelectedValue(value);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public SliderInput AddSliderInput(string modName, string key, JObject obj) => AddSliderInput(modName, key, (float)obj["value"], (float)obj["min"], (float)obj["max"], (string)obj["title"], (string)obj["tooltip"]);

    public SliderInput AddSliderInput(string modName, string key, float value, float min, float max)
    {
        var clone = sliderPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, min, max);
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public SliderInput AddSliderInput(string modName, string key, float value, float min, float max, string title, string tooltip)
    {
        var clone = sliderPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, min, max);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DropdownInput AddDropdownInput(string modName, string key, JObject obj) => AddDropdownInput(modName, key, (string)obj["value"], obj["options"].ToObject<string[]>(), obj["optionStrings"]?.ToObject<string[]>(), (string)obj["title"], (string)obj["tooltip"]);

    public ColorDropdownInput AddColorDropdownInput(string modName, string key, JObject obj) => AddColorDropdownInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public ColorDropdownInput AddColorDropdownInput(string modName, string key, string value, string title, string tooltip)
    {
        var clone = colorDropdownPrefab.Instantiate(this.options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DropdownInput AddDropdownInput(string modName, string key, string value, string[] options, string[] optionStrings)
    {
        var clone = dropdownPrefab.Instantiate(this.options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, options, optionStrings);
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DropdownInput AddDropdownInput(string modName, string key, string value, string[] options, string[] optionStrings, string title, string tooltip)
    {
        var clone = dropdownPrefab.Instantiate(this.options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value, options, optionStrings);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public FieldInput AddTextInput(string modName, string key, string value)
    {
        var clone = inputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value);
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public FieldInput AddTextInput(string modName, string key, JObject obj) => AddTextInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public FieldInput AddTextInput(string modName, string key, string value, string title, string tooltip)
    {
        var clone = inputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value);
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public IntegerFieldInput AddIntegerInput(string modName, string key, object value)
    {
        var clone = integerInputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public IntegerFieldInput AddIntegerInput(string modName, string key, JObject obj) => AddIntegerInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public IntegerFieldInput AddIntegerInput(string modName, string key, object value, string title, string tooltip)
    {
        var clone = integerInputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DecimalFieldInput AddDecimalInput(string modName, string key, object value)
    {
        var clone = decimalInputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, string.Empty, key);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public DecimalFieldInput AddDecimalInput(string modName, string key, JObject obj) => AddDecimalInput(modName, key, (string)obj["value"], (string)obj["title"], (string)obj["tooltip"]);

    public DecimalFieldInput AddDecimalInput(string modName, string key, object value, string title, string tooltip)
    {
        var clone = decimalInputFieldPrefab.Instantiate(options, false);
        modOptions.Add(clone.transform);
        clone.modName = modName;
        clone.key = key;
        clone.name = key;
        clone.Initialize(value.ToString());
        SetupTitle(clone, title, key);
        SetupInputTooltip(clone, tooltip);
        AddInputScrollMagnet(clone);
        return clone;
    }

    public void SetupInputTooltip(Input input, string tooltip)
    {
        if (!string.IsNullOrWhiteSpace(tooltip))
        {
            input.TooltipDescriptionString = LocalizationUtil.CreateReference(tooltip);
        }
    }

    public void SetupTitle(Input input, string title, string key)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            LocalizationUtil.AddEnglishModString(key, key.SplitPascalCase());
            input.TitleString = LocalizationUtil.CreateReference(key);
        }
        else
        {
            input.TitleString = LocalizationUtil.CreateReference(title);
        }
    }

    public void AddInputScrollMagnet(Input input)
    {
        if (input == null)
            return;

        AddScrollMagnets(input.transform, optionsScroller);
    }

    private static void AddScrollMagnets(
        Transform root,
        ScrollRect scrollRect
    )
    {
        if (root == null || scrollRect == null)
            return;

        RectTransform scrollTarget = root as RectTransform;

        foreach (var selectable in root.GetComponentsInChildren<Selectable>(true))
        {
            if (selectable == null)
                continue;

            var magnet = selectable.GetOrAddComponent<TargetedScrollRectMagnet>();
            magnet.scrollRect = scrollRect;
            magnet.scrollTarget = scrollTarget;

            var uiSelectable = selectable.GetOrAddComponent<UISelectable>();
            uiSelectable.doesSelectableMove = true;
            uiSelectable.delayForOneFrame = true;
        }
    }

    public bool MoveOptionToStart(Transform option)
    {
        return option != null && MoveOptionsToStart(new[] { option });
    }

    public bool MoveOptionToStart(Input input) =>
        input != null && MoveOptionToStart(input.transform);

    public bool MoveOptionToStart(BasicButtonWrapper button) =>
        button != null && MoveOptionToStart(button.transform);

    public bool MoveOptionToStart(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return false;
        var t = modOptions.FirstOrDefault(mt => mt != null && mt.name == name);
        return t != null && MoveOptionToStart(t);
    }

    public bool MoveOptionsToStart(IEnumerable<Transform> options)
    {
        var movedOptions = options
            .Where(option => option != null && modOptions.Contains(option))
            .Distinct()
            .ToList();

        if (movedOptions.Count == 0)
            return false;

        foreach (var option in movedOptions)
        {
            modOptions.Remove(option);
        }

        modOptions.InsertRange(0, movedOptions);

        for (int i = 0; i < modOptions.Count; i++)
        {
            modOptions[i].SetSiblingIndex(i);
        }

        RebuildOptionLayout();

        return true;
    }

    public bool MoveOptionsToStart(IEnumerable<Input> inputs)
    {
        return MoveOptionsToStart(
            inputs
                .Where(input => input != null)
                .Select(input => input.transform)
        );
    }

    public bool MoveOptionsToStart(IEnumerable<BasicButtonWrapper> buttons)
    {
        return MoveOptionsToStart(
            buttons
                .Where(button => button != null)
                .Select(button => button.transform)
        );
    }

    public void RebuildOptionLayout()
    {
        // Remove old layout spacing.
        foreach (var separator in layoutSeparators.ToArray())
        {
            if (separator == null)
                continue;

            modOptions.Remove(separator);
            DestroyImmediate(separator.gameObject);
        }

        layoutSeparators.Clear();

        var logicalOptions = modOptions.ToList();
        modOptions.Clear();

        foreach (var option in logicalOptions)
        {
            if (option == null)
                continue;

            if (option.GetComponent<CenteredOption>() != null)
            {
                var input = option.GetComponent<Input>();

                var modName =
                    input?.modName ??
                    currentMod?.GUID ??
                    WinchCore.GUID;

                var key =
                    !string.IsNullOrWhiteSpace(input?.key)
                        ? input.key
                        : option.name;

                // Finish the current row and add the empty left cell.
                AddCenteredOptionPadding(modName, key);

                modOptions.Add(option);

                // Empty right cell of the row.
                AddLayoutSeparatorInput(
                    modName,
                    key + "End"
                );
            }
            else
            {
                modOptions.Add(option);
            }
        }

        // Sync hierarchy order with the rebuilt layout.
        for (int i = 0; i < modOptions.Count; i++)
        {
            modOptions[i].SetSiblingIndex(i);
        }
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
        layoutSeparators.Clear();
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

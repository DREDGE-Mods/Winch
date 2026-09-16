using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using Winch.Components.UI.Inputs;
using Winch.Config;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;
using Input = Winch.Components.UI.Inputs.Input;

namespace Winch.Components.UI;

public class ModsTab : MonoBehaviour
{
    public static readonly LocalizedString winchHeader = LocalizationUtil.CreateStringsReference("winch.name");
    public static readonly LocalizedString tabHeader = LocalizationUtil.CreateStringsReference("settings.tab.mods");
    public static readonly LocalizedString footerList = LocalizationUtil.CreateStringsReference("settings.mods.footer.list");
    public static readonly LocalizedString footerOptions = LocalizationUtil.CreateStringsReference("settings.mods.footer.options");

    public static ModsTab Instance { get; private set; }

    public bool isCurrentTab =>
        Instance.settingsDialog.dialog.CurrentIndex == ModsButton.modsTabIndex;

    public static bool isActive => Instance.isCurrentTab;

    public ResetAllSettingsButton ResetAllSettingsButton =>
        settingsDialog.GetComponentInChildren<ResetAllSettingsButton>(true);

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

    public ModListView ModListView { get; set; }
    public ModOptionsView ModOptionsView { get; set; }

    public bool currentWinch;
    public ModAssembly currentMod;

    public ModsTabView CurrentView { get; private set; } = ModsTabView.ModList;

    public ModsView ActiveView => CurrentView switch
    {
        ModsTabView.ModList => ModListView,
        ModsTabView.ModOptions => ModOptionsView,
        _ => ModListView
    };

    public bool IsViewingMod => CurrentView != ModsTabView.ModList;
    public bool ShowingOptions => CurrentView == ModsTabView.ModOptions;

    private bool _viewsInitialized;

    private static bool _automaticNavigation = false;
    public static bool AutomaticNavigation => _automaticNavigation;

    public void Awake()
    {
        Instance = this;
    }

    public void InitializeViews()
    {
        if (_viewsInitialized)
            return;

        ModListView?.Initialize(this);
        ModOptionsView?.Initialize(this);

        _viewsInitialized = true;

        ModListView?.Show();
        ModOptionsView?.Hide();
    }

    public void Start()
    {
        InitializeViews();

        Refresh();

        tab.Button
            .GetComponent<BasicButtonWrapper>()
            .OnClick += OnTabSelected;

        headerTextLocalized.LabelString = tabHeader;
        footerButton.OnClick += ExitOptions;
    }

    public void OnEnable()
    {
        UpdateResetButton();
        Refresh();

        ApplicationEvents.Instance.OnSliderFocusToggled +=
            OnSliderFocusToggled;
    }

    public void OnDisable()
    {
        ResetAllSettingsButton.gameObject.Activate();

        ApplicationEvents.Instance.OnSliderFocusToggled -=
            OnSliderFocusToggled;
    }

    private void OnSliderFocusToggled(bool hasFocus)
    {
        if (IsViewingMod)
            settingsDialog.dialog.RemoveTabInput();
    }

    public void Update()
    {
        UpdateResetButton();

        if (!isCurrentTab)
            return;

        ActiveView?.HandleScrollInput();
    }

    public void UpdateResetButton()
    {
        if (isCurrentTab)
        {
            ResetAllSettingsButton.gameObject.SetActive(
                CurrentView == ModsTabView.ModOptions
            );
        }
        else
        {
            ResetAllSettingsButton.gameObject.Activate();
        }
    }

    public void OnTabSelected()
    {
        Refresh();
    }

    public void Refresh()
    {
        InitializeViews();
        ExitOptions();
        ModListView?.Populate();

        this.FireOnNextUpdate(ScrollToTop);
    }

    public void ScrollToTop()
    {
        ModListView?.ScrollToTop();
        ModOptionsView?.ScrollToTop();
    }

    public void OnWinchClicked()
    {
        WinchCore.Log.Debug("[ModsTab] OnWinchClicked()");

        currentWinch = true;
        currentMod = null;

        settingsDialog.dialog.RemoveTabInput();

        ModOptionsView.Clear();

        headerText.gameObject.Deactivate();
        headerTextLocalized.LabelString = winchHeader;
        headerTextLocalized.gameObject.Activate();

        footerText.LabelString = footerOptions;
        footerButton.gameObject.Activate();

        ModOptionsView.AddWinchOptions();
        SetView(ModsTabView.ModOptions, updateNavigation: true);
        ScrollToTop();
    }

    public void OnModClicked(ModAssembly mod)
    {
        WinchCore.Log.Debug($"[ModsTab] OnModClicked({mod.GUID})");

        currentWinch = false;
        currentMod = mod;

        settingsDialog.dialog.RemoveTabInput();

        ModOptionsView.Clear();

        headerTextLocalized.gameObject.Deactivate();
        headerText.LabelString = mod.Name;
        headerText.gameObject.Activate();

        footerText.LabelString = footerOptions;
        footerButton.gameObject.Activate();

        ModOptionsView.AddOptions(mod);
        DredgeEvent.TriggerBuildModConfigMenu(mod, this);

        SetView(
            ModsTabView.ModOptions,
            updateNavigation: true
        );

        ScrollToTop();
    }

    private void SetView(
        ModsTabView view,
        bool updateNavigation)
    {
        ModListView?.Hide();
        ModOptionsView?.Hide();

        CurrentView = view;
        ActiveView?.Show();

        if (view == ModsTabView.ModList)
        {
            headerTextLocalized.LabelString = tabHeader;
            footerText.LabelString = footerList;
        }

        if (view == ModsTabView.ModOptions)
        {
            headerTextLocalized.LabelString = winchHeader;
            footerText.LabelString = footerOptions;
        }

        UpdateResetButton();

        if (!updateNavigation || view == ModsTabView.ModList)
            return;

        ConfigureCurrentViewNavigation();
        ActiveView?.ScrollToTop();
    }

    private void ConfigureCurrentViewNavigation()
    {
        var activeView = ActiveView;
        if (activeView == null)
            return;

        var firstSelectable = activeView.FirstSelectable;

        if (!AutomaticNavigation)
        {
            firstSelectable =
                activeView.ConfigureNavigation(footerButton.Button) ??
                firstSelectable;
        }

        var bottomSelectable =
            activeView.FindBottomSelectable(footerButton.Button) ??
            firstSelectable;

        var footerNavigation = footerButton.Button.navigation;
        footerNavigation.mode = Navigation.Mode.Explicit;
        footerNavigation.selectOnLeft = bottomSelectable;
        footerNavigation.selectOnRight = bottomSelectable;
        footerNavigation.selectOnUp = bottomSelectable;
        footerNavigation.selectOnDown = resumeButton.Button;
        footerButton.Button.navigation = footerNavigation;

        if (firstSelectable != null)
            activeView.Select(firstSelectable);

        ConfigureSettingsBarNavigation();
    }

    private void ConfigureSettingsBarNavigation()
    {
        var resumeNavigation = resumeButton.Button.navigation;
        var saveAndQuitNavigation = saveAndQuitButton.Button.navigation;
        var resetAllSettingsNavigation =
            resetAllSettingsButton.Button.navigation;

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
        resetAllSettingsButton.Button.navigation =
            resetAllSettingsNavigation;
    }

    public void ExitOptions()
    {
        WinchCore.Log.Debug("[ModsTab] ExitOptions()");

        currentWinch = false;
        currentMod = null;

        settingsDialog.dialog.AddTabInput();

        ModOptionsView?.Clear();

        ModOptionsView?.Hide();

        CurrentView = ModsTabView.ModList;
        ModListView?.Show();
        ModListView?.SelectFirst();

        headerText.gameObject.Deactivate();
        headerTextLocalized.gameObject.Activate();

        headerTextLocalized.LabelString = tabHeader;
        footerText.LabelString = footerList;
        footerButton.gameObject.Deactivate();

        if (ModListView != null)
        {
            foreach (var button in ModListView.ModButtons)
                button.SetCanBeClicked(true);
        }

        var resumeNavigation = resumeButton.Button.navigation;
        var saveAndQuitNavigation = saveAndQuitButton.Button.navigation;
        var resetAllSettingsNavigation =
            resetAllSettingsButton.Button.navigation;

        resumeNavigation.mode = Navigation.Mode.Automatic;
        saveAndQuitNavigation.mode = Navigation.Mode.Automatic;
        resetAllSettingsNavigation.mode = Navigation.Mode.Automatic;

        resumeButton.Button.navigation = resumeNavigation;
        saveAndQuitButton.Button.navigation = saveAndQuitNavigation;
        resetAllSettingsButton.Button.navigation =
            resetAllSettingsNavigation;
    }
}

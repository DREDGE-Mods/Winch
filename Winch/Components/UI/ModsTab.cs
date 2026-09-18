using UnityEngine;
using UnityEngine.Localization;
using Winch.Components.UI.Inputs;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Components.UI;

public class ModsTab : MonoBehaviour
{
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
    public ModControlsView ModControlsView { get; set; }

    public BasicButtonWrapper optionsSubtabButton;
    public BasicButtonWrapper controlsSubtabButton;

    public bool currentWinch;
    public ModAssembly currentMod;

    public ModsTabView CurrentView { get; private set; } = ModsTabView.ModList;

    public ModsView ActiveView => CurrentView switch
    {
        ModsTabView.ModList => ModListView,
        ModsTabView.ModOptions => ModOptionsView,
        ModsTabView.ModControls => ModControlsView,
        _ => ModListView
    };

    public bool IsViewingMod => CurrentView != ModsTabView.ModList;
    public bool ShowingOptions => CurrentView == ModsTabView.ModOptions;
    public bool ShowingControls => CurrentView == ModsTabView.ModControls;

    public bool HasCurrentModControls =>
        currentMod != null && RebindingUtil.HasRebindables(currentMod.GUID);

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
        ModControlsView?.Initialize(this);

        _viewsInitialized = true;

        ModListView?.Show();
        ModOptionsView?.Hide();
        ModControlsView?.Hide();
    }

    public void Start()
    {
        InitializeViews();

        Refresh();

        tab.Button
            .GetComponent<BasicButtonWrapper>()
            .OnClick += OnTabSelected;

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
            ResetAllSettingsButton.gameObject.SetActive(IsViewingMod);
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
        ModControlsView?.ScrollToTop();
    }

    public void OnWinchClicked()
    {
        WinchCore.Log.Debug("[ModsTab] OnWinchClicked()");

        currentWinch = true;
        currentMod = null;

        settingsDialog.dialog.RemoveTabInput();

        ModOptionsView.Clear();
        ModControlsView?.Clear();

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
        ModControlsView?.Clear();

        ModOptionsView.AddOptions(mod);
        DredgeEvent.TriggerBuildModConfigMenu(mod, this);

        if (HasCurrentModControls)
            ModControlsView?.Populate(mod);

        SetView(
            ModOptionsView.HasOptions
                ? ModsTabView.ModOptions
                : ModsTabView.ModControls,
            updateNavigation: true
        );

        ScrollToTop();
    }

    public void ShowOptions()
    {
        if (!ModOptionsView.HasOptions)
            return;

        SetView(ModsTabView.ModOptions, updateNavigation: true);
    }

    public void ShowControls()
    {
        if (!HasCurrentModControls)
            return;

        SetView(ModsTabView.ModControls, updateNavigation: true);
    }

    private void SetView(
        ModsTabView view,
        bool updateNavigation)
    {
        ModListView?.Hide();
        ModOptionsView?.Hide();
        ModControlsView?.Hide();

        CurrentView = view;

        var activeView = ActiveView;
        activeView?.Show();

        UpdateResetButton();

        if (!updateNavigation || activeView == null)
            return;

        activeView.ConfigureViewNavigation();
        activeView.ScrollToTop();
    }

    public void ExitOptions()
    {
        WinchCore.Log.Debug("[ModsTab] ExitOptions()");

        currentWinch = false;
        currentMod = null;

        settingsDialog.dialog.AddTabInput();

        ModOptionsView?.Clear();
        ModControlsView?.Clear();

        SetView(ModsTabView.ModList, updateNavigation: false);
        ModListView?.SelectFirst();
    }
}

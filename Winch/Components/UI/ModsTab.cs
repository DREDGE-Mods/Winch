using UnityEngine;
using UnityEngine.AddressableAssets;
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

    public AssetReference panelSwapSFX = AddressablesUtil.CreateAssetReferenceAudioClip("99a846b2939e13149ba4430721690747");

    public ModListView ModListView { get; set; }
    public ModOptionsView ModOptionsView { get; set; }
    public ModControlsView ModControlsView { get; set; }

    public ModsSubtab[] subtabs;
    public ControlPromptIcon leftControlPrompt;
    public ControlPromptIcon rightControlPrompt;

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
        currentMod != null && ControlUtil.HasControls(currentMod.GUID);

    private DredgePlayerActionPress _closeAction;
    private DredgePlayerActionPress leftActionPress;
    private DredgePlayerActionPress rightActionPress;

    private bool _closeActionEnabled;
    private bool _tabInputAdded;
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
        InitializeCloseAction();
        InitializeTabShortcuts();

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
        DisableCloseAction();
        RemoveTabInput();
        ShowUnpauseAction();

        ResetAllSettingsButton.gameObject.Activate();

        ApplicationEvents.Instance.OnSliderFocusToggled -=
            OnSliderFocusToggled;
    }

    private void OnSliderFocusToggled(bool hasFocus)
    {
        if (!IsViewingMod)
            return;

        settingsDialog.dialog.RemoveTabInput();

        if (hasFocus)
            RemoveTabInput();
        else
            AddTabInput();
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

    public bool CanShowSubtab(ModsTabView view)
    {
        return view switch
        {
            ModsTabView.ModOptions => ModOptionsView.HasOptions,
            ModsTabView.ModControls => HasCurrentModControls,
            _ => false
        };
    }

    public ModsSubtab GetSubtab(ModsTabView view)
    {
        if (subtabs == null)
            return null;

        foreach (var subtab in subtabs)
        {
            if (subtab != null && subtab.View == view)
                return subtab;
        }

        return null;
    }

    private int GetShowableSubtabCount()
    {
        if (subtabs == null)
            return 0;

        var count = 0;

        foreach (var subtab in subtabs)
        {
            if (subtab != null && CanShowSubtab(subtab.View))
                count++;
        }

        return count;
    }

    private void RefreshSubtabs()
    {
        var visible =
            IsViewingMod &&
            GetShowableSubtabCount() > 1;

        if (subtabs != null)
        {
            foreach (var subtab in subtabs)
            {
                subtab?.Refresh(visible);
            }
        }

        leftControlPrompt?.gameObject.SetActive(visible);
        rightControlPrompt?.gameObject.SetActive(visible);
    }

    public void ShowSubtab(ModsTabView view)
    {
        if (!CanShowSubtab(view))
            return;

        SetView(view, updateNavigation: true);
    }

    private void SetView(
        ModsTabView view,
        bool updateNavigation)
    {
        var wasViewingMod = IsViewingMod;

        ModListView?.Hide();
        ModOptionsView?.Hide();
        ModControlsView?.Hide();

        CurrentView = view;

        var activeView = ActiveView;
        activeView?.Show();

        if (IsViewingMod)
        {
            HideUnpauseAction();
            EnableCloseAction();

            if (!wasViewingMod)
                AddTabInput();
            else
                EnableTabButtons();
        }
        else
        {
            RemoveTabInput();
            DisableCloseAction();
            ShowUnpauseAction();
        }

        RefreshSubtabs();
        UpdateResetButton();

        if (!updateNavigation || activeView == null)
            return;

        activeView.ConfigureViewNavigation();
        activeView.ScrollToTop();
    }

    private void InitializeTabShortcuts()
    {
        if (leftActionPress != null || rightActionPress != null)
            return;

        leftActionPress = new DredgePlayerActionPress(
            "Tab Left",
            GameManager.Instance.Input.Controls.TabLeft
        )
        {
            evaluateWhenPaused = true
        };

        rightActionPress = new DredgePlayerActionPress(
            "Tab Right",
            GameManager.Instance.Input.Controls.TabRight
        )
        {
            evaluateWhenPaused = true
        };

        leftControlPrompt?.Init(
            leftActionPress,
            leftActionPress.GetPrimaryPlayerAction()
        );

        rightControlPrompt?.Init(
            rightActionPress,
            rightActionPress.GetPrimaryPlayerAction()
        );
    }

    public void EnableTabInput()
    {
        if (
            !IsViewingMod ||
            GetShowableSubtabCount() <= 1)
        {
            return;
        }

        EnableTabShortcuts();
        EnableTabButtons();
    }

    public void EnableTabShortcuts()
    {
        if (leftActionPress == null || rightActionPress == null)
            return;

        leftActionPress.ClearListeners();
        leftActionPress.OnPressComplete += OnLeftPressComplete;
        leftActionPress.Enable();

        rightActionPress.ClearListeners();
        rightActionPress.OnPressComplete += OnRightPressComplete;
        rightActionPress.Enable();
    }

    public void EnableTabButtons()
    {
        if (subtabs == null)
            return;

        foreach (var subtab in subtabs)
        {
            if (subtab?.Tab?.Button == null)
                continue;

            subtab.Tab.Button.interactable =
                CanShowSubtab(subtab.View);
        }
    }

    public void DisableTabInput()
    {
        DisableTabShortcuts();
        DisableTabButtons();
    }

    public void DisableTabShortcuts()
    {
        if (leftActionPress != null)
        {
            leftActionPress.Disable(dispatchPressEnd: true);
            leftActionPress.ClearListeners();
        }

        if (rightActionPress != null)
        {
            rightActionPress.Disable(dispatchPressEnd: true);
            rightActionPress.ClearListeners();
        }
    }

    public void DisableTabButtons()
    {
        if (subtabs == null)
            return;

        foreach (var subtab in subtabs)
        {
            if (subtab?.Tab?.Button != null)
                subtab.Tab.Button.interactable = false;
        }
    }

    private void AddTabInput()
    {
        if (
            !IsViewingMod ||
            GetShowableSubtabCount() <= 1 ||
            leftActionPress == null ||
            rightActionPress == null)
        {
            DisableTabInput();
            return;
        }

        if (_tabInputAdded)
        {
            EnableTabButtons();
            return;
        }

        GameManager.Instance.Input.AddActionListener(
            new DredgePlayerActionBase[]
            {
                leftActionPress,
                rightActionPress
            },
            ActionLayer.SYSTEM
        );

        _tabInputAdded = true;
        EnableTabInput();
    }

    private void RemoveTabInput()
    {
        if (
            _tabInputAdded &&
            GameManager.Instance?.Input != null)
        {
            GameManager.Instance.Input.RemoveActionListener(
                new DredgePlayerActionBase[]
                {
                    leftActionPress,
                    rightActionPress
                },
                ActionLayer.SYSTEM
            );

            _tabInputAdded = false;
        }

        DisableTabInput();
    }

    private void OnLeftPressComplete()
    {
        SwitchSubtab(-1);
    }

    private void OnRightPressComplete()
    {
        SwitchSubtab(1);
    }

    private void SwitchSubtab(int direction)
    {
        if (subtabs == null || subtabs.Length <= 1)
            return;

        var currentIndex = -1;

        for (var i = 0; i < subtabs.Length; i++)
        {
            if (subtabs[i]?.View == CurrentView)
            {
                currentIndex = i;
                break;
            }
        }

        if (currentIndex < 0)
            return;

        for (var offset = 1; offset < subtabs.Length; offset++)
        {
            var index =
                (currentIndex + direction * offset + subtabs.Length) %
                subtabs.Length;

            var subtab = subtabs[index];
            if (subtab == null || !CanShowSubtab(subtab.View))
                continue;

            ShowSubtab(subtab.View);
            GameManager.Instance.AudioPlayer.PlaySFX(panelSwapSFX, AudioLayer.SFX_UI);
            return;
        }
    }

    private void InitializeCloseAction()
    {
        if (_closeAction != null)
            return;

        _closeAction = new DredgePlayerActionPress(
            "prompt.leave",
            GameManager.Instance.Input.Controls.Unpause
        )
        {
            showInControlArea = true,
            evaluateWhenPaused = true
        };

        _closeAction.OnPressComplete += OnClosePressComplete;
    }

    public void EnableCloseAction()
    {
        if (_closeAction == null || _closeActionEnabled)
            return;

        GameManager.Instance.Input.AddActionListener(
            new DredgePlayerActionBase[] { _closeAction },
            ActionLayer.SYSTEM
        );

        _closeActionEnabled = true;
    }

    public void DisableCloseAction()
    {
        if (!_closeActionEnabled)
            return;

        GameManager.Instance.Input.RemoveActionListener(
            new DredgePlayerActionBase[] { _closeAction },
            ActionLayer.SYSTEM
        );

        _closeActionEnabled = false;
    }

    private void HideUnpauseAction()
    {
        GameManager.Instance.PauseListener.CanShowUnpauseAction(false);
    }

    private void ShowUnpauseAction()
    {
        GameManager.Instance.PauseListener.CanShowUnpauseAction(true);
    }

    private void OnClosePressComplete()
    {
        if (!IsViewingMod)
            return;

        ExitOptions();
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

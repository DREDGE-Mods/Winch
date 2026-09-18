using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Winch.Core;
using Winch.Util;

namespace Winch.Components.UI;

public sealed class ModControlsView : ModsView
{
    private const float HeaderGap = 2f;

    private readonly List<ModControlEntryUI> _entries = new();
    private readonly List<ResetControlEntryUI> _resetEntries = new();

    private DredgePlayerActionPress _unbindAction;
    private ControlBindingEntryUI _lastHoveredBindingEntry;
    private Coroutine _lerpCoroutine;

    private bool _isLerping;
    private bool _initialized;
    private bool _allowRebinding;

    public override ModsTabView ViewType => ModsTabView.ModControls;

    protected override Selectable CurrentSubtabSelectable =>
        Owner?.HasCurrentModControls == true
            ? Owner.controlsSubtabButton?.Button
            : null;

    public GameObject Header { get; set; }
    public GameObject ScrollerTopImage { get; set; }

    public GameObject ControlEntryPrefab { get; set; }
    public Selectable BottomSelectable { get; set; }

    public GameObject IdleFooter { get; set; }
    public GameObject ListeningFooter { get; set; }

    public override Selectable FirstSelectable =>
        _entries.Count > 0 &&
        _entries[0].ControlBindingEntryUIs.Count > 0
            ? _entries[0].ControlBindingEntryUIs[0].ButtonWrapper.Button
            : null;

    public override void Initialize(ModsTab owner)
    {
        base.Initialize(owner);

        if (_initialized)
            return;

        _allowRebinding = GameManager.Instance.GameConfigData
            .PlatformsSupportingControlRebindings
            .Contains(RuntimePlatform.WindowsPlayer);

        if (_allowRebinding)
        {
            _unbindAction = new DredgePlayerActionPress(
                "prompt.unbind",
                GameManager.Instance.Input.Controls.UnbindControl
            )
            {
                showInControlArea = true,
                evaluateWhenPaused = true,
                priority = 1
            };

            _unbindAction.OnPressComplete += OnUnbindPressComplete;
        }

        _initialized = true;

        SetListeningFooter(false);
        gameObject.Deactivate();
    }

    private void OnEnable()
    {
        if (!_initialized)
            return;

        GameManager.Instance.Input.OnInputChanged += OnInputChanged;

        if (_allowRebinding)
        {
            ApplicationEvents.Instance.OnPlayerActionBindingChanged +=
                OnPlayerActionBindingChanged;

            ApplicationEvents.Instance.OnPlayerActionBindingEnded +=
                OnPlayerActionBindingEnded;
        }

        UpdateFooter();
    }

    private void OnDisable()
    {
        if (!_initialized)
            return;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.Input.OnInputChanged -= OnInputChanged;

            if (_allowRebinding && ApplicationEvents.Instance != null)
            {
                ApplicationEvents.Instance.OnPlayerActionBindingChanged -=
                    OnPlayerActionBindingChanged;

                ApplicationEvents.Instance.OnPlayerActionBindingEnded -=
                    OnPlayerActionBindingEnded;
            }

            UpdateLastHoveredBindingEntry(null);
        }

        if (_lerpCoroutine != null)
        {
            StopCoroutine(_lerpCoroutine);
            _lerpCoroutine = null;
        }

        SetListeningFooter(false);
    }

    private ModControlEntryUI CreateEntry()
    {
        var instance =
            Instantiate(ControlEntryPrefab, Content);

        var vanillaEntry =
            instance.GetComponentInChildren<ControlEntryUI>();

        var entry =
            vanillaEntry.gameObject.AddComponent<ModControlEntryUI>();

        entry.localizedPromptNameField =
            vanillaEntry.localizedPromptNameField;

        entry.controlBindingEntryUIs =
            vanillaEntry.controlBindingEntryUIs;

        entry.resetEntryUI =
            vanillaEntry.resetEntryUI;

        DestroyImmediate(vanillaEntry);

        return entry;
    }

    public void Populate(ModAssembly mod)
    {
        Clear();

        var controls = ControlUtil.GetControls(mod.GUID);
        var alternatingColor = new Color(0f, 0f, 0f, 0f);

        for (var i = 0; i < controls.Count; i++)
        {
            var control = controls[i];

            var entry = CreateEntry();

            if (entry == null)
                continue;

            if (i % 2 == 0 &&
                entry.TryGetComponent<Image>(out var image))
            {
                image.color = alternatingColor;
            }

            var canRebind =
                _allowRebinding && control.Rebindable;

            var canUnbind =
                canRebind && control.Unbindable;

            entry.Init(
                control,
                canRebind,
                canUnbind
            );

            foreach (var bindingEntry in entry.ControlBindingEntryUIs)
            {
                if (bindingEntry == null)
                    continue;

                bindingEntry.OnEntrySelected += OnEntrySelected;

                if (canRebind)
                    bindingEntry.OnEntrySubmitted += OnEntrySubmitted;
            }

            _entries.Add(entry);

            if (_allowRebinding && entry.ResetEntryUI != null)
            {
                entry.ResetEntryUI.Init(
                    control.PlayerAction,
                    canRebind
                );

                entry.ResetEntryUI.OnEntrySelected += OnResetEntrySelected;
                entry.ResetEntryUI.OnEntrySubmitted += OnResetEntrySubmitted;

                _resetEntries.Add(entry.ResetEntryUI);
            }
        }

        LinkEntries();

        Canvas.ForceUpdateCanvases();
        Scroller.verticalNormalizedPosition = 1f;
    }

    public override void Show()
    {
        ApplyLayout();
        base.Show();

        if (Owner?.currentMod != null)
            ShowHeader(Owner.currentMod.Name);

        SetFooter(
            LocalizationUtil.CreateStringsReference(
                "settings.bindings.label.info-idle"
            ),
            true
        );

        var hasControls = Owner?.HasCurrentModControls == true;
        SetSubtabButtonsVisible(hasControls);

        Owner?.optionsSubtabButton?.SetCanBeClicked(
            hasControls && Owner.ModOptionsView?.HasOptions == true
        );
        Owner?.controlsSubtabButton?.SetCanBeClicked(false);

        UpdateFooter();
    }

    public override void Clear()
    {
        if (Content != null)
        {
            foreach (Transform child in Content)
                DestroyImmediate(child.gameObject);
        }

        _entries.Clear();
        _resetEntries.Clear();

        if (_initialized && GameManager.Instance != null)
            UpdateLastHoveredBindingEntry(null);
    }

    public override void SelectFirst()
    {
        var first = FirstSelectable;
        if (first == null)
            return;

        EventSystem.current?.SetSelectedGameObject(first.gameObject);
        first.Select();

        FocusGrabber?.SetSelectable(first);

        if (
            !GameManager.Instance.Input.IsUsingController &&
            first.transform is RectTransform rect)
        {
            Scroller.content.anchoredPosition =
                Scroller.GetSnapToPositionToBringChildIntoView(rect);
        }
    }

    public override Selectable ConfigureNavigation(
        Navigation fallbackNavigation = default)
    {
        if (_entries.Count == 0)
            return null;

        var firstEntry = _entries[0];
        foreach (var bindingEntry in firstEntry.ControlBindingEntryUIs)
        {
            var button = bindingEntry?.ButtonWrapper?.Button;
            if (button == null)
                continue;

            var navigation = button.navigation;
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnUp = fallbackNavigation.selectOnUp;
            button.navigation = navigation;
        }

        if (_allowRebinding && firstEntry.ResetEntryUI != null)
        {
            var resetButton = firstEntry.ResetEntryUI.ButtonWrapper.Button;
            var navigation = resetButton.navigation;
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnUp = fallbackNavigation.selectOnUp;
            resetButton.navigation = navigation;
        }

        var lastEntry = _entries[_entries.Count - 1];
        foreach (var bindingEntry in lastEntry.ControlBindingEntryUIs)
        {
            var button = bindingEntry?.ButtonWrapper?.Button;
            if (button == null)
                continue;

            var navigation = button.navigation;
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnDown = fallbackNavigation.selectOnDown;
            button.navigation = navigation;
        }

        if (_allowRebinding && lastEntry.ResetEntryUI != null)
        {
            var resetButton = lastEntry.ResetEntryUI.ButtonWrapper.Button;
            var navigation = resetButton.navigation;
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnDown = fallbackNavigation.selectOnDown;
            resetButton.navigation = navigation;
        }

        return FirstSelectable;
    }

    private void ApplyLayout()
    {
        if (
            Scroller == null ||
            Header == null ||
            Owner?.ModOptionsView?.Scroller == null)
        {
            return;
        }

        var optionsRect =
            Owner.ModOptionsView.Scroller.transform as RectTransform;

        var controlsRect =
            Scroller.transform as RectTransform;

        var headerRect =
            Header.transform as RectTransform;

        if (
            optionsRect == null ||
            controlsRect == null ||
            headerRect == null)
        {
            return;
        }

        var headerHeight = Mathf.Max(headerRect.rect.height, 48f);
        var headerTop = optionsRect.offsetMax.y;

        headerRect.anchorMin =
            new Vector2(
                optionsRect.anchorMin.x,
                optionsRect.anchorMax.y
            );

        headerRect.anchorMax =
            new Vector2(
                optionsRect.anchorMax.x,
                optionsRect.anchorMax.y
            );

        headerRect.pivot =
            new Vector2(optionsRect.pivot.x, 1f);

        headerRect.offsetMin =
            new Vector2(
                optionsRect.offsetMin.x,
                headerTop - headerHeight
            );

        headerRect.offsetMax =
            new Vector2(
                optionsRect.offsetMax.x,
                headerTop
            );

        controlsRect.anchorMin = optionsRect.anchorMin;
        controlsRect.anchorMax = optionsRect.anchorMax;
        controlsRect.pivot = optionsRect.pivot;
        controlsRect.offsetMin = optionsRect.offsetMin;

        controlsRect.offsetMax =
            new Vector2(
                optionsRect.offsetMax.x,
                headerTop - headerHeight - HeaderGap
            );
    }

    private void RefreshEntry(ModControlEntryUI entry)
    {
        if (entry == null)
            return;

        entry.Refresh();
    }

    private void LinkEntries()
    {
        for (var i = 0; i < _entries.Count; i++)
        {
            var entry = _entries[i];

            var previous =
                i > 0
                    ? _entries[i - 1]
                    : null;

            var next =
                i < _entries.Count - 1
                    ? _entries[i + 1]
                    : null;

            for (
                var j = 0;
                j < entry.ControlBindingEntryUIs.Count;
                j++)
            {
                var button =
                    entry.ControlBindingEntryUIs[j]
                        ?.ButtonWrapper
                        ?.Button;

                if (button == null)
                    continue;

                var navigation = button.navigation;
                navigation.mode = Navigation.Mode.Explicit;

                if (
                    previous != null &&
                    j < previous.ControlBindingEntryUIs.Count)
                {
                    navigation.selectOnUp =
                        previous.ControlBindingEntryUIs[j]
                            .ButtonWrapper.Button;
                }

                if (
                    next != null &&
                    j < next.ControlBindingEntryUIs.Count)
                {
                    navigation.selectOnDown =
                        next.ControlBindingEntryUIs[j]
                            .ButtonWrapper.Button;
                }
                else if (BottomSelectable != null)
                {
                    navigation.selectOnDown =
                        BottomSelectable;
                }

                button.navigation = navigation;
            }

            if (
                !_allowRebinding ||
                entry.ResetEntryUI == null)
            {
                continue;
            }

            var resetButton =
                entry.ResetEntryUI.ButtonWrapper.Button;

            var resetNavigation =
                resetButton.navigation;

            resetNavigation.mode =
                Navigation.Mode.Explicit;

            if (i > 0)
            {
                resetNavigation.selectOnUp =
                    _resetEntries[i - 1]
                        .ButtonWrapper.Button;
            }

            if (i < _resetEntries.Count - 1)
            {
                resetNavigation.selectOnDown =
                    _resetEntries[i + 1]
                        .ButtonWrapper.Button;
            }
            else if (BottomSelectable != null)
            {
                resetNavigation.selectOnDown =
                    BottomSelectable;
            }

            resetButton.navigation =
                resetNavigation;
        }
    }

    private void OnEntrySelected(
        ControlBindingEntryUI entry)
    {
        UpdateLastHoveredBindingEntry(entry);

        if (entry != null)
        {
            OnSomethingSelected(
                entry.ButtonWrapper.Button,
                entry.transform as RectTransform
            );
        }
    }

    private void OnResetEntrySelected(
        ResetControlEntryUI entry)
    {
        UpdateLastHoveredBindingEntry(null);

        OnSomethingSelected(
            entry.ButtonWrapper.Button,
            entry.transform as RectTransform
        );
    }

    private void OnSomethingSelected(
        Selectable selectable,
        RectTransform rect)
    {
        if (
            GameManager.Instance.Input.IsUsingController &&
            rect != null)
        {
            if (_lerpCoroutine != null)
                StopCoroutine(_lerpCoroutine);

            var destination =
                Scroller.GetSnapToPositionToBringChildIntoView(rect);

            _lerpCoroutine =
                StartCoroutine(
                    LerpToDestination(destination)
                );
        }

        FocusGrabber?.SetSelectable(selectable);
    }

    private IEnumerator LerpToDestination(
        Vector2 destination)
    {
        Canvas.ForceUpdateCanvases();

        _isLerping = true;
        var elapsed = 0f;

        while (_isLerping)
        {
            elapsed += Time.unscaledDeltaTime;

            var t =
                Mathf.Min(
                    10f * Time.unscaledDeltaTime,
                    1f
                );

            Scroller.content.anchoredPosition =
                Vector2.Lerp(
                    Scroller.content.anchoredPosition,
                    destination,
                    t
                );

            if (
                elapsed >= 0.15f ||
                Vector2.SqrMagnitude(
                    Scroller.content.anchoredPosition -
                    destination
                ) < 10f)
            {
                Scroller.content.anchoredPosition =
                    destination;

                _isLerping = false;
            }

            yield return null;
        }

        _lerpCoroutine = null;
    }

    private void OnEntrySubmitted(
        ControlBindingEntryUI entry)
    {
        if (
            !entry.Rebindable ||
            entry.PlayerAction.IsListeningForBinding)
        {
            return;
        }

        entry.PlayerAction.ListenForBinding();
        UpdateFooter();
    }

    private void OnResetEntrySubmitted(
        ResetControlEntryUI entry)
    {
        if (entry.Rebindable)
        {
            GameManager.Instance.Input.ResetBinding(
                entry.PlayerAction
            );
        }

        ApplicationEvents.Instance.TriggerSettingChanged(
            SettingType.CONTROL_BINDINGS
        );
    }

    private void OnPlayerActionBindingChanged(
        PlayerAction action)
    {
        var entry =
            _entries.Find(
                x => x.PlayerAction == action
            );

        RefreshEntry(entry);
    }

    private void OnPlayerActionBindingEnded(
        PlayerAction action)
    {
        UpdateFooter();
    }

    private void OnInputChanged(
        BindingSourceType bindingSourceType,
        InputDeviceStyle inputDeviceStyle)
    {
        foreach (var entry in _entries)
            RefreshEntry(entry);
    }

    private void OnUnbindPressComplete()
    {
        if (_lastHoveredBindingEntry == null)
            return;

        var binding =
            GameManager.Instance.Input.GetBindingForAction(
                _lastHoveredBindingEntry.PlayerAction,
                _lastHoveredBindingEntry.BindingSourceType,
                combineMouseKeyboard: false
            );

        if (binding == null)
            return;

        _lastHoveredBindingEntry.PlayerAction
            .RemoveBinding(binding);

        StartCoroutine(
            DelayedRefreshBinding(
                _lastHoveredBindingEntry
            )
        );
    }

    private IEnumerator DelayedRefreshBinding(
        ControlBindingEntryUI entry)
    {
        yield return new WaitForEndOfFrame();

        ApplicationEvents.Instance.TriggerSettingChanged(
            SettingType.CONTROL_BINDINGS
        );

        entry.Refresh();
    }

    private void UpdateLastHoveredBindingEntry(
        ControlBindingEntryUI entry)
    {
        _lastHoveredBindingEntry = entry;

        if (
            !_allowRebinding ||
            _unbindAction == null)
        {
            return;
        }

        var actions =
            new DredgePlayerActionBase[]
            {
                _unbindAction
            };

        if (
            _lastHoveredBindingEntry != null &&
            _lastHoveredBindingEntry.Unbindable)
        {
            GameManager.Instance.Input.AddActionListener(
                actions,
                ActionLayer.SYSTEM
            );
        }
        else
        {
            GameManager.Instance.Input.RemoveActionListener(
                actions,
                ActionLayer.SYSTEM
            );
        }
    }

    private void UpdateFooter()
    {
        if (Owner?.footerText != null)
        {
            Owner.footerText.LabelString =
                LocalizationUtil.CreateStringsReference(
                    "settings.bindings.label.info-idle"
                );
        }

        SetListeningFooter(
            GameManager.Instance.Input.Controls
                .IsListeningForBinding
        );
    }

    private void SetListeningFooter(bool listening)
    {
        if (IdleFooter != null)
            IdleFooter.SetActive(!listening);

        if (ListeningFooter != null)
            ListeningFooter.SetActive(listening);
    }
}
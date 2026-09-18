using System.Collections.Generic;
using InControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Winch.Components.UI;
using Winch.Core;
using Winch.Patches;

namespace Winch.Components.UI.Inputs;

public abstract class InnerFocusInput : Input, ISubmitHandler, IEventSystemHandler
{
    [SerializeField]
    protected internal UISelectable uiSelectable;

    [SerializeField]
    [FormerlySerializedAs("sliderFocusButton")]
    protected internal Button focusButton;

    [SerializeField]
    protected internal SelectableDisabler selectableDisabler;

    [SerializeField]
    protected internal SettingsDialog dialog;

    [SerializeField]
    protected internal TextTooltipRequester rootTextTooltipRequester;

    protected bool initialized;

    protected abstract Selectable InnerSelectable { get; }

    protected override IEnumerable<TextTooltipRequester> TooltipRequesters
    {
        get
        {
            foreach (var requester in base.TooltipRequesters)
            {
                yield return requester;
            }

            if (rootTextTooltipRequester != null &&
                rootTextTooltipRequester != textTooltipRequester)
            {
                yield return rootTextTooltipRequester;
            }
        }
    }

    protected virtual void OnEnable()
    {
        RefreshOnEnable();
        RefreshInteractionState();

        GameManager.Instance.Input.OnInputChanged += OnInputChanged;
        SubscribeFocusEvents();
    }

    protected virtual void OnDisable()
    {
        GameManager.Instance.Input.OnInputChanged -= OnInputChanged;
        UnsubscribeFocusEvents();
    }

    protected virtual void RefreshOnEnable()
    {
    }

    protected virtual void OnInputChanged(
        BindingSourceType bindingSourceType,
        InputDeviceStyle inputDeviceStyle
    )
    {
        RefreshInteractionState();
    }

    protected virtual void RefreshInteractionState()
    {
        var usingController = GameManager.Instance.Input.IsUsingController;

        InnerSelectable.interactable = !usingController;
        focusButton.interactable = usingController;
        uiSelectable.enabled = usingController;
    }

    protected virtual void OnFocusChanged(bool hasInnerFocus)
    {
        DredgePlayerActionBase[] actions =
        {
            dialog.forceExitSliderFocusAction
        };

        ModsButtonPatcher.activeInnerFocusInput = null;
        dialog.activeSlider = null;

        if (hasInnerFocus)
        {
            SetActiveInput();

            ModsTab.Instance.DisableCloseAction();
            GameManager.Instance.Input.AddActionListener(actions, ActionLayer.SYSTEM);
        }
        else
        {
            GameManager.Instance.Input.RemoveActionListener(actions, ActionLayer.SYSTEM);
            ModsTab.Instance.EnableCloseAction();
        }
    }

    protected virtual void OnDeselected()
    {
        focusButton.interactable = true;
        OnFocusChanged(false);
    }

    protected virtual void OnSubmitted()
    {
        ExitInnerFocus();
        OnFocusChanged(false);
    }

    public virtual void ForceDeselect()
    {
        ExitInnerFocus();
    }

    public virtual void OnSubmit(BaseEventData eventData)
    {
        InnerSelectable.interactable = !InnerSelectable.interactable;
        focusButton.interactable = !InnerSelectable.interactable;

        if (!InnerSelectable.interactable)
        {
            return;
        }

        EventSystem.current.SetSelectedGameObject(InnerSelectable.gameObject);
        InnerSelectable.Select();
        OnFocusChanged(true);
    }

    protected virtual void ExitInnerFocus()
    {
        InnerSelectable.interactable = false;
        EventSystem.current.SetSelectedGameObject(gameObject);
        focusButton.Select();
    }

    protected virtual void SetActiveInput()
    {
        ModsButtonPatcher.activeInnerFocusInput = this;
    }

    protected virtual void SubscribeFocusEvents()
    {
        selectableDisabler.OnDeselected += OnDeselected;
        selectableDisabler.OnSubmitted += OnSubmitted;
    }

    protected virtual void UnsubscribeFocusEvents()
    {
        selectableDisabler.OnDeselected -= OnDeselected;
        selectableDisabler.OnSubmitted -= OnSubmitted;
    }
}

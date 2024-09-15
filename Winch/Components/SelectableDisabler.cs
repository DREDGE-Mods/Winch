using System;
using InControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Winch.Components;

public class SelectableDisabler : MonoBehaviour, ISubmitHandler, IEventSystemHandler, IDeselectHandler, ISelectHandler
{
    [SerializeField]
    private Button parentSelectable;

    [SerializeField]
    private Selectable selectable;

    [HideInInspector]
    public Action OnDeselected;

    [HideInInspector]
    public Action OnSubmitted;

    private void Awake()
    {
        selectable = GetComponent<Selectable>();
        parentSelectable = GetComponentInParent<Button>();
    }

    private void OnEnable()
    {
        RefreshInteractionState();
        GameManager.Instance.Input.OnInputChanged += OnInputChanged;
    }

    private void OnDisable()
    {
        GameManager.Instance.Input.OnInputChanged -= OnInputChanged;
    }

    private void OnInputChanged(BindingSourceType bindingSourceType, InputDeviceStyle inputDeviceStyle)
    {
        RefreshInteractionState();
    }

    private void RefreshInteractionState()
    {
        selectable.interactable = !GameManager.Instance.Input.IsUsingController;
    }

    public void OnSelect(BaseEventData eventData)
    {
        ApplicationEvents.Instance.TriggerSliderFocusToggled(hasFocus: true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        OnDeselected?.Invoke();
        RefreshInteractionState();
        ApplicationEvents.Instance.TriggerSliderFocusToggled(hasFocus: false);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        OnSubmitted?.Invoke();
        ApplicationEvents.Instance.TriggerSliderFocusToggled(hasFocus: false);
    }
}
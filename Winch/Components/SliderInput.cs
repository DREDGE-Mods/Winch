using InControl;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using Winch.Core;
using Winch.Patches;
using Winch.Util;

namespace Winch.Components
{
    public class SliderInput : Input, ISubmitHandler, IEventSystemHandler
    {
        [SerializeField]
        public bool retrieveSelectedValue = true;

        [SerializeField]
        protected internal UISelectable uiSelectable;

        [SerializeField]
        protected internal Slider slider;

        [SerializeField]
        protected internal Button sliderFocusButton;

        [SerializeField]
        protected internal SliderDisabler sliderDisabler;

        [SerializeField]
        protected internal SettingsDialog dialog;

        private bool initialized = false;

        public float MinValue
        {
            get => slider.minValue;
            set => slider.minValue = value;
        }

        public float MaxValue
        {
            get => slider.maxValue;
            set => slider.maxValue = value;
        }

        public float Value
        {
            get => slider.value;
            set => slider.value = value;
        }

        protected virtual void OnEnable()
        {
            RefreshSlider();
            RefreshInteractionState();
            GameManager.Instance.Input.OnInputChanged += OnInputChanged;
            sliderDisabler.SliderDeselected += OnSliderDeselected;
            sliderDisabler.SliderSubmitted += OnSliderSubmitted;
        }

        protected virtual void OnDisable()
        {
            GameManager.Instance.Input.OnInputChanged -= OnInputChanged;
            sliderDisabler.SliderDeselected -= OnSliderDeselected;
            sliderDisabler.SliderSubmitted -= OnSliderSubmitted;
        }

        public override void OnForceRefresh()
		{
			RefreshSlider();
		}

        protected virtual void OnInputChanged(BindingSourceType bindingSourceType, InputDeviceStyle inputDeviceStyle)
        {
            RefreshInteractionState();
        }

        protected virtual void OnSliderFocusChanged(bool sliderHasInnerFocus)
        {
            DredgePlayerActionBase[] actions = new DredgePlayerActionPress[] { dialog.forceExitSliderFocusAction };
            if (sliderHasInnerFocus)
            {
                ModsButtonPatcher.activeSlider = this;
                dialog.activeSlider = null;
                GameManager.Instance.PauseListener.CanShowUnpauseAction(false);
                GameManager.Instance.Input.AddActionListener(actions, ActionLayer.SYSTEM);
            }
            else
            {
                ModsButtonPatcher.activeSlider = null;
                dialog.activeSlider = null;
                GameManager.Instance.Input.RemoveActionListener(actions, ActionLayer.SYSTEM);
                GameManager.Instance.PauseListener.CanShowUnpauseAction(true);
            }
        }

        protected virtual void OnSliderDeselected()
        {
            sliderFocusButton.interactable = true;
            OnSliderFocusChanged(false);
        }

        public virtual void ForceSliderDeselect()
        {
            slider.interactable = false;
            EventSystem.current.SetSelectedGameObject(gameObject);
            sliderFocusButton.Select();
        }

        protected virtual void OnSliderSubmitted()
        {
            slider.interactable = false;
            EventSystem.current.SetSelectedGameObject(gameObject);
            sliderFocusButton.Select();
            OnSliderFocusChanged(false);
        }

        protected virtual void RefreshInteractionState()
        {
            bool flag = !GameManager.Instance.Input.IsUsingController;
            slider.interactable = flag;
            sliderFocusButton.interactable = !flag;
            uiSelectable.enabled = !flag;
        }

        protected virtual void Awake()
        {
            slider.onValueChanged.AddListener(OnValueChanged);
        }

        protected virtual void RefreshSlider()
        {
            if (!retrieveSelectedValue) return;

            SetValue(GetConfigValue<float>());
        }

        protected virtual void SetValue(float valueWithoutNotify)
        {
            slider.SetValueWithoutNotify(valueWithoutNotify);
        }

        protected virtual void OnValueChanged(float value)
        {
            if (!initialized) return;
            WinchCore.Log.Debug(string.Format("[SliderInput] OnValueChanged({0})", value));
            ChangeValue(value);
        }

        protected virtual void ChangeValue(float value)
        {
            if (!initialized) return;
            SetConfigValue(value);
        }

        public virtual void OnSubmit(BaseEventData eventData)
        {
            slider.interactable = !slider.interactable;
            sliderFocusButton.interactable = !slider.interactable;
            if (slider.interactable)
            {
                EventSystem.current.SetSelectedGameObject(slider.gameObject);
                slider.Select();
                OnSliderFocusChanged(true);
            }
        }

        protected internal virtual void Initialize(float value, float min, float max)
        {
            SetValue(value);
            MinValue = min;
            SetValue(value);
            MaxValue = max;
            SetValue(value);
            initialized = true;
        }
    }
}

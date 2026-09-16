using UnityEngine;
using UnityEngine.UI;
using Winch.Core;
using Winch.Patches;

namespace Winch.Components.UI.Inputs;

public class SliderInput : InnerFocusInput
{
    [SerializeField]
    public bool retrieveSelectedValue = true;

    [SerializeField]
    protected internal Slider slider;

    protected override Selectable InnerSelectable => slider;

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

    protected virtual void Awake()
    {
        slider.onValueChanged.AddListener(OnValueChanged);
    }

    protected override void RefreshOnEnable()
    {
        RefreshSlider();
    }

    public override void OnForceRefresh()
    {
        RefreshSlider();
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

        WinchCore.Log.Debug($"[SliderInput] OnValueChanged({value})");
        ChangeValue(value);
    }

    protected virtual void ChangeValue(float value)
    {
        if (!initialized) return;

        SetConfigValue(value);
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

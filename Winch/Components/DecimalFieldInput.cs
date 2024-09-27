
using Winch.Core;

namespace Winch.Components;

public class DecimalFieldInput : FieldInput
{
    protected override void Awake()
    {
        base.Awake();
        inputField.keyboardType = UnityEngine.TouchScreenKeyboardType.NumbersAndPunctuation;
        inputField.characterValidation = TMPro.TMP_InputField.CharacterValidation.Decimal;
    }

    protected override bool ValidateInput(string input)
    {
        return double.TryParse(input, out _);
    }

    protected override void ChangeValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            ResetConfigValueToDefault();
            return;
        }

        if (double.TryParse(value, out double floatingValue))
            SetConfigValue(floatingValue);
        else
        {
            ResetConfigValueToDefault();
            WinchCore.Log.Error($"Invalid decimal \"{value}\" for setting {key}");
        }
    }
}

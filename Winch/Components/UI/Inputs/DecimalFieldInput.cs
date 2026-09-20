using UnityEngine;
using Winch.Core;
using static TMPro.TMP_InputField;

namespace Winch.Components.UI.Inputs;

public class DecimalFieldInput : FieldInput
{
    protected override TouchScreenKeyboardType KeyboardType => TouchScreenKeyboardType.NumbersAndPunctuation;
    protected override CharacterValidation CharacterValidation => CharacterValidation.Decimal;

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

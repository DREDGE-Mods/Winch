using UnityEngine;
using Winch.Core;
using static TMPro.TMP_InputField;

namespace Winch.Components.UI.Inputs;

public class IntegerFieldInput : FieldInput
{
    protected override TouchScreenKeyboardType KeyboardType => TouchScreenKeyboardType.NumberPad;
    protected override CharacterValidation CharacterValidation => CharacterValidation.Integer;

    protected override bool ValidateInput(string input)
    {
        return long.TryParse(input, out _) || ulong.TryParse(input, out _);
    }

    protected override void ChangeValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            ResetConfigValueToDefault();
            return;
        }

        if (long.TryParse(value, out long lvalue))
            SetConfigValue(lvalue);
        else if (ulong.TryParse(value, out ulong ulvalue))
            SetConfigValue(ulvalue);
        else
        {
            ResetConfigValueToDefault();
            WinchCore.Log.Error($"Invalid integer \"{value}\" for setting {key}");
        }
    }
}

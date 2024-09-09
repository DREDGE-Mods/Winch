
using Winch.Core;

namespace Winch.Components;

public class IntegerFieldInput : FieldInput
{
    protected override void Awake()
    {
        base.Awake();
        inputField.keyboardType = UnityEngine.TouchScreenKeyboardType.NumbersAndPunctuation;
        inputField.characterValidation = TMPro.TMP_InputField.CharacterValidation.Integer;
    }

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

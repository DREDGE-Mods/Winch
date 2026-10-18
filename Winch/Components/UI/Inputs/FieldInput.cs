using System;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Winch.Components.UI;
using Winch.Core;
using Winch.Patches;
using Winch.Util;
using static Tags;
using static TMPro.TMP_InputField;
using static UnityEngine.Networking.UnityWebRequest;

namespace Winch.Components.UI.Inputs;

public class FieldInput : InnerFocusInput
{
    [SerializeField]
    protected internal TMP_InputField inputField;

    [SerializeField]
    protected internal Label placeholder;

    protected override Selectable InnerSelectable => inputField;

    protected virtual TouchScreenKeyboardType KeyboardType => TouchScreenKeyboardType.Default;
    protected virtual CharacterValidation CharacterValidation => CharacterValidation.None;
    protected virtual LineType LineType => LineType.SingleLine;//LineType.MultiLineNewline;


    private static FieldInput activeGamepadTextInput;

    private Callback<GamepadTextInputDismissed_t> gamepadTextInputCallback;

    public string InputFieldText
    {
        get => inputField.text;
        set
        {
            inputField.text = value;
            OnValueChanged(value);
            OnEndEdit(value);
        }
    }

    public void SetInputFieldTextWithNoNotify(string value)
    {
        inputField.text = value;
    }

    public void ClearInputFieldText()
    {
        InputFieldText = string.Empty;
    }

    public void ClearInputFieldTextWithNoNotify()
    {
        SetInputFieldTextWithNoNotify(string.Empty);
    }

    protected virtual void Awake()
    {
        gamepadTextInputCallback = Callback<GamepadTextInputDismissed_t>.Create(OnGamepadTextInputDismissed);

        inputField.keyboardType = KeyboardType;
        inputField.characterValidation = CharacterValidation;
        inputField.lineType = LineType;


        inputField.ActivateInputField();
        inputField.onSelect.AddListener(OnSelect);
        inputField.onDeselect.AddListener(OnDeselect);
        inputField.onEndEdit.AddListener(OnEndEdit);
        inputField.onValueChanged.AddListener(OnValueChanged);
        inputField.onValidateInput += OnValidateInput;

        InitializePlaceholder();
    }

    protected virtual void OnDestroy()
    {
        gamepadTextInputCallback?.Dispose();

        inputField.onSelect.RemoveListener(OnSelect);
        inputField.onDeselect.RemoveListener(OnDeselect);
        inputField.onEndEdit.RemoveListener(OnEndEdit);
        inputField.onValueChanged.RemoveListener(OnValueChanged);
        inputField.onValidateInput -= OnValidateInput;
    }

    private void OnGamepadTextInputDismissed(GamepadTextInputDismissed_t param)
    {
        if (activeGamepadTextInput != this)
            return;

        activeGamepadTextInput = null;

        ForceDeselect();

        if (!param.m_bSubmitted)
            return;

        uint length = SteamUtils.GetEnteredGamepadTextLength();

        if (!SteamUtils.GetEnteredGamepadTextInput(out string result, length))
        {
            WinchCore.Log.Error($"[FieldInput:{name}] Failed to get Steam Gamepad Text Input.");
            return;
        }

        InputFieldText = result;
    }

    protected virtual void InitializePlaceholder()
    {
        placeholder.LabelString = GetDefaultConfigValue<string>() ?? string.Empty;
    }

    private void OnSelect(string value)
    {
        if (!initialized) return;

        WinchCore.Log.Debug($"[FieldInput:{name}] OnSelect({value})");
        inputField.caretPosition = inputField.text.Length;

        if (GameManager.Instance.Input.IsUsingController && activeGamepadTextInput == null)
        {
            WinchCore.Log.Debug($"[FieldInput:{name}] Opening Steam Gamepad Text Input.");

            bool success = SteamUtils.ShowGamepadTextInput(
                EGamepadTextInputMode.k_EGamepadTextInputModeNormal,
                inputField.lineType == LineType.SingleLine
                    ? EGamepadTextInputLineMode.k_EGamepadTextInputLineModeSingleLine
                    : EGamepadTextInputLineMode.k_EGamepadTextInputLineModeMultipleLines,
                LocalizationUtil.Resolve(localizedString),
                1024,
                inputField.text
            );

            if (success)
                activeGamepadTextInput = this;
            else
                WinchCore.Log.Warn($"[FieldInput:{name}] Failed to open Steam Gamepad Text Input.");
        }
    }

    private void OnDeselect(string value)
    {
        if (!initialized) return;

        WinchCore.Log.Debug($"[FieldInput:{name}] OnDeselect({value})");
        ChangeValue(value);
    }

    private void OnEndEdit(string value)
    {
        if (!initialized) return;

        WinchCore.Log.Debug($"[FieldInput:{name}] OnEndEdit({value})");
        ChangeValue(value);
    }

    protected virtual void ChangeValue(string value)
    {
        if (!initialized) return;

        if (string.IsNullOrWhiteSpace(value))
        {
            var defaultValue = GetDefaultConfigValue<string>() ?? string.Empty;
            SetConfigValue(defaultValue);
            return;
        }

        SetConfigValue(value);
    }

    protected virtual void OnValueChanged(string value)
    {
        if (!initialized) return;

        WinchCore.Log.Debug($"[FieldInput:{name}] OnValueChanged({value})");
    }

    private char OnValidateInput(string input, int charIndex, char addedChar)
    {
        WinchCore.Log.Debug(
            $"[FieldInput:{name}] OnValidateInput({input}, {charIndex}, {addedChar})"
        );

        return ValidateChar(addedChar, charIndex) &&
               ValidateInput(input.Insert(charIndex, addedChar.ToString()))
            ? addedChar
            : '\0';
    }

    protected virtual bool ValidateChar(char addedChar, int charIndex)
    {
        return !IsNRT(addedChar);
    }

    protected virtual bool ValidateInput(string input)
    {
        return true;
    }

    protected bool IsNRT(char addedChar)
    {
        if (addedChar == '\n' || addedChar == '\r')
        {
            inputField.DeactivateInputField();
            return true;
        }

        return addedChar == '\t';
    }

    public override void OnForceRefresh()
    {
        InitializePlaceholder();
        SetInputFieldTextWithNoNotify(GetConfigValue<string>() ?? string.Empty);
    }

    protected internal virtual void Initialize(string value)
    {
        InitializePlaceholder();
        SetInputFieldTextWithNoNotify(value);
        initialized = true;
    }
}

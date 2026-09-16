using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Winch.Components.UI;
using Winch.Core;
using Winch.Patches;

namespace Winch.Components.UI.Inputs;

public class FieldInput : InnerFocusInput
{
    [SerializeField]
    protected internal TMP_InputField inputField;

    [SerializeField]
    protected internal Label placeholder;

    protected override Selectable InnerSelectable => inputField;

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
        inputField.ActivateInputField();
        inputField.onSelect.AddListener(OnSelect);
        inputField.onDeselect.AddListener(OnDeselect);
        inputField.onEndEdit.AddListener(OnEndEdit);
        inputField.onValueChanged.AddListener(OnValueChanged);
        inputField.onValidateInput += OnValidateInput;

        InitializePlaceholder();
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

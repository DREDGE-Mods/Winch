using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using Winch.Core;
using Winch.Util;
using static UnityEngine.Rendering.DebugUI;

namespace Winch.Components
{
    public class FieldInput : Input
    {
        [SerializeField]
        protected internal TMP_InputField inputField;
        [SerializeField]
        protected internal Label placeholder;

        private bool initialized = false;

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
            placeholder.LabelString = GetDefaultConfigValue<string>();
        }

        private void OnSelect(string value)
        {
            if (!initialized) return;
            WinchCore.Log.Debug(string.Format("[FieldInput:{0}] OnSelect({1})", base.name, value));
        }

        private void OnDeselect(string value)
        {
            if (!initialized) return;
            WinchCore.Log.Debug(string.Format("[FieldInput:{0}] OnDeselect({1})", base.name, value));
            ChangeValue(value);
        }

        private void OnEndEdit(string value)
        {
            if (!initialized) return;
            WinchCore.Log.Debug(string.Format("[FieldInput:{0}] OnEndEdit({1})", base.name, value));
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
            WinchCore.Log.Debug(string.Format("[FieldInput:{0}] OnValueChanged({1})", base.name, value));
        }

        private char OnValidateInput(string input, int charIndex, char addedChar)
        {
            WinchCore.Log.Debug(string.Format("[FieldInput:{0}] OnValidateInput({1}, {2}, {3})", base.name, input,charIndex, addedChar));
            return ValidateChar(addedChar, charIndex) && ValidateInput(input.Insert(charIndex, addedChar.ToString())) ? addedChar : '\0';
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
            if (addedChar == '\t')
            {
                return true;
            }
            return false;
        }

        public override void OnForceRefresh()
        {
            InitializePlaceholder();
            SetInputFieldTextWithNoNotify(GetConfigValue<string>());
        }

        protected internal virtual void Initialize(string value)
        {
            InitializePlaceholder();
            SetInputFieldTextWithNoNotify(value);
            initialized = true;
        }
    }
}

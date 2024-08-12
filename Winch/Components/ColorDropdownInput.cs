using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using Winch.Util;

namespace Winch.Components
{
    public class ColorDropdownInput : DropdownInput
    {
        [SerializeField]
        internal TextMeshProUGUI textField;

        [SerializeField]
        private LocalizedString labelLocalizedString = LocalizationUtil.CreateReference("Strings", "settings.dropdown.color");

        [SerializeField]
        internal int columns;

        protected override void Awake()
        {
            populateOptions = true;
            retrieveSelectedIndex = true;
            scrollToSelectedItem = false;
            optionStrings = GameManager.Instance.GameConfigData.Colors.Select(color => labelLocalizedString).ToList();
            base.Awake();
            initialized = true;
        }

        protected override void OnLocaleChanged(Locale l)
        {
            RefreshDropdown();
        }

        protected override void RefreshDropdown()
        {
            base.RefreshDropdown();
            RefreshLabelsColor();
        }

        private void RefreshLabelsColor()
        {
            textField.color = GameManager.Instance.GameConfigData.Colors[CurrentIndex];
        }

        protected override void RetrieveSelectedIndex()
        {
            base.RetrieveSelectedIndex();
        }

        protected override void OnValueChanged(int value)
        {
            base.OnValueChanged(value);
            RefreshLabelsColor();
        }

        protected override void OnComponentSubmitted()
        {
            List<DropdownItem> items = transform.GetComponentsInChildren<DropdownItem>().ToList<DropdownItem>();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                item.background.color = GameManager.Instance.GameConfigData.Colors[i];
                Selectable toggle = item.toggle;
                Navigation navigation = toggle.navigation;
                var floatedColumns = (float)columns;
                if (i <= Mathf.Ceil((items.Count / floatedColumns) * floatedColumns) && i + columns < items.Count)
                {
                    Selectable toggle2 = items[i + columns].toggle;
                    navigation.selectOnDown = toggle2;
                }
                if (i >= columns && i - columns >= 0)
                {
                    Selectable toggle3 = items[i - columns].toggle;
                    navigation.selectOnUp = toggle3;
                }
                toggle.navigation = navigation;
            }
        }

        protected override void ChangeValue(int index)
        {
            SetConfigValue<Color>(GameManager.Instance.GameConfigData.Colors[index]);
        }
    }
}
using System.Collections.Generic;
using UnityEngine.Localization;
using Winch.Util;

namespace Winch.Components;

public class OnOffDropdownInput : DropdownInput
{
    protected override void Awake()
    {
        optionStrings = new List<LocalizedString>
        {
            LocalizationUtil.CreateStringsReference("settings.dropdown.disabled"),
            LocalizationUtil.CreateStringsReference("settings.dropdown.enabled")
        };
        options = new List<string>
        {
            "Off",
            "On"
        };
        base.Awake();
        initialized = true;
    }

    protected override void RetrieveSelectedIndex()
    {
        if (!initialized) return;
        if (!retrieveSelectedIndex) return;

        SetSelectedValue(GetConfigValue<bool>());
    }

    protected internal void SetSelectedValue(bool value)
    {
        SetSelectedIndex(value ? 1 : 0);
    }

    protected override void ChangeValue(int index)
    {
        SetConfigValue(index == 1);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
using Winch.Util;
using TMPro;

namespace Winch.Components;

public class LocalizedLabel : MonoBehaviour
{
    [SerializeField]
    private LocalizedString labelString = LocalizationUtil.Unknown;
    public LocalizedString LabelString
    {
        get => labelString;
        set
        {
            labelString = value;
            UpdateLabel();
        }
    }
    public LocalizeStringEvent LocalizedStringEvent => GetComponentInChildren<LocalizeStringEvent>(true);

    public void OnEnable()
    {
        LocalizedStringEvent.OnUpdateString.Invoke(string.Empty);
        UpdateLabel();
    }

    public void UpdateLabel()
    {
        LocalizedStringEvent.StringReference = LabelString;
    }
}
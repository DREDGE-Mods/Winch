using UnityEngine;
using TMPro;

namespace Winch.Components;

public class Label : MonoBehaviour
{
    [SerializeField]
    private string labelString = "Unknown";
    public string LabelString
    {
        get => labelString;
        set
        {
            labelString = value;
            UpdateLabel();
        }
    }
    public TextMeshProUGUI textField => GetComponentInChildren<TextMeshProUGUI>(true);

    public void OnEnable()
    {
        textField.text = string.Empty;
        UpdateLabel();
    }

    public void UpdateLabel()
    {
        textField.text = LabelString;
    }
}

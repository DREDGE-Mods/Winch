using UnityEngine;

namespace Winch.Components;

public class ModsButton : MonoBehaviour
{
    public static int modsTabIndex = -1;

    public void Awake()
    {
        GetComponent<BasicButtonWrapper>().OnClick += OnClick;
    }

    public void OnClick()
    {
        ApplicationEvents.Instance.TriggerToggleSettings(true);
        GameObject.FindObjectOfType<SettingsDialog>().dialog.ShowNewPanel(modsTabIndex, true);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace Winch.Components.UI;

public sealed class ModsSubtab : MonoBehaviour
{
    private ModsTab _modsTab;
    private ModsTabView _view;
    private TabUI _tab;

    public ModsTabView View => _view;
    public TabUI Tab => _tab;

    public void Initialize(
        ModsTab modsTab,
        ModsTabView view,
        TabUI tab,
        LocalizedString title)
    {
        _modsTab = modsTab;
        _view = view;
        _tab = tab;

        _tab.gameObject
            .GetOrAddComponent<LocalizedLabel>()
            .LabelString = title;

        var text =
            _tab.transform.Find("TabTitleText")?.GetComponent<TextMeshProUGUI>() ??
            _tab.GetComponentInChildren<TextMeshProUGUI>(true);

        if (text != null)
            text.fontStyle = FontStyles.UpperCase;

        var navigation = _tab.Button.navigation;
        navigation.mode = Navigation.Mode.None;
        _tab.Button.navigation = navigation;

        _tab.Button.onClick.AddListener(OnClick);
    }

    public void Refresh(bool visible)
    {
        var canShow =
            visible &&
            _modsTab != null &&
            _modsTab.CanShowSubtab(_view);

        gameObject.SetActive(canShow);

        if (!canShow || _tab == null)
            return;

        _tab.Button.interactable = true;
        _tab.Button.image.sprite =
            _modsTab.CurrentView == _view
                ? _tab.SelectedSprite
                : _tab.UnselectedSprite;
    }

    private void OnClick()
    {
        _modsTab?.ShowSubtab(_view);
    }
}

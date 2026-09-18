using UnityEngine;

namespace Winch.Components.UI;

public sealed class ModsSubtabButton : MonoBehaviour
{
    private ModsTab _modsTab;
    private ModsTabView _view;
    private BasicButtonWrapper _button;

    public ModsTabView View => _view;
    public BasicButtonWrapper Button => _button;

    public void Initialize(
        ModsTab modsTab,
        ModsTabView view,
        BasicButtonWrapper button)
    {
        _modsTab = modsTab;
        _view = view;
        _button = button;

        _button.OnClick += OnClick;
    }

    public void Refresh(bool visible)
    {
        var canShow =
            visible &&
            _modsTab != null &&
            _modsTab.CanShowSubtab(_view);

        gameObject.SetActive(canShow);

        if (canShow)
        {
            _button.SetCanBeClicked(
                _modsTab.CurrentView != _view
            );
        }
    }

    private void OnClick()
    {
        _modsTab?.ShowSubtab(_view);
    }
}

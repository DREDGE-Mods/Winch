using System.Collections.Generic;
using System.Linq;
using InControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;
using Winch.Util;

namespace Winch.Components.UI;

public abstract class ModsView : MonoBehaviour
{
    private const float ControllerScrollDeadZone = 0.2f;
    private const float ControllerScrollSpeed = 500f;
    private const float NavigationRowTolerance = 4f;

    public ModsTab Owner { get; private set; }
    public ScrollRect Scroller { get; private set; }
    public ControllerFocusGrabber FocusGrabber { get; private set; }

    public RectTransform Content => Scroller?.content;

    public abstract ModsTabView ViewType { get; }

    protected virtual Selectable CurrentSubtabSelectable => null;

    public virtual Selectable FirstSelectable =>
        GetTopLevelSelectables()
            .OrderByDescending(selectable => GetSelectablePosition(selectable).y)
            .ThenBy(selectable => GetSelectablePosition(selectable).x)
            .FirstOrDefault();

    public virtual void Initialize(ModsTab owner)
    {
        Owner = owner;
        Scroller = GetComponent<ScrollRect>() ?? GetComponentInChildren<ScrollRect>(true);

        if (Scroller != null)
            FocusGrabber = Scroller.gameObject.GetOrAddComponent<ControllerFocusGrabber>();

        ConfigureScrollRect();
    }

    public virtual void Show()
    {
        gameObject.Activate();
    }

    public virtual void Hide()
    {
        gameObject.Deactivate();
    }

    public virtual void Clear()
    {
    }

    public virtual void ScrollToTop()
    {
        if (Scroller != null)
            Scroller.verticalNormalizedPosition = 1f;
    }

    public virtual void SelectFirst()
    {
        Select(FirstSelectable);
    }

    public virtual void Select(Selectable selectable)
    {
        if (selectable == null)
            return;

        if (FocusGrabber != null)
        {
            FocusGrabber.SetSelectable(selectable);
            FocusGrabber.SelectSelectable();
            return;
        }

        EventSystem.current?.SetSelectedGameObject(selectable.gameObject);
        selectable.Select();
    }

    public virtual Selectable ConfigureNavigation(Navigation fallbackNavigation = default)
    {
        if (Scroller == null || Content == null)
            return null;

        ForceLayout();

        var selectables = GetTopLevelSelectables()
            .OrderByDescending(selectable => GetSelectablePosition(selectable).y)
            .ThenBy(selectable => GetSelectablePosition(selectable).x)
            .ToList();

        if (selectables.Count == 0)
            return null;

        var rows = new List<List<Selectable>>();
        var rowY = new List<float>();

        foreach (var selectable in selectables)
        {
            var position = GetSelectablePosition(selectable);

            if (rows.Count == 0 ||
                Mathf.Abs(position.y - rowY[rowY.Count - 1]) > NavigationRowTolerance)
            {
                rows.Add(new List<Selectable> { selectable });
                rowY.Add(position.y);
            }
            else
            {
                rows[rows.Count - 1].Add(selectable);
            }
        }

        foreach (var row in rows)
        {
            row.Sort((a, b) =>
                GetSelectablePosition(a).x.CompareTo(GetSelectablePosition(b).x)
            );
        }

        for (var rowIndex = 0; rowIndex < rows.Count; rowIndex++)
        {
            var row = rows[rowIndex];

            for (var columnIndex = 0; columnIndex < row.Count; columnIndex++)
            {
                var selectable = row[columnIndex];
                var navigation = selectable.navigation;

                navigation.mode = Navigation.Mode.Explicit;

                navigation.selectOnLeft =
                    columnIndex > 0
                        ? row[columnIndex - 1]
                        : fallbackNavigation.selectOnLeft;

                navigation.selectOnRight =
                    columnIndex + 1 < row.Count
                        ? row[columnIndex + 1]
                        : fallbackNavigation.selectOnRight;

                navigation.selectOnUp =
                    rowIndex > 0
                        ? FindClosestOnRow(rows[rowIndex - 1], selectable)
                        : fallbackNavigation.selectOnUp;

                navigation.selectOnDown =
                    rowIndex + 1 < rows.Count
                        ? FindClosestOnRow(rows[rowIndex + 1], selectable)
                        : fallbackNavigation.selectOnDown;

                selectable.navigation = navigation;
            }
        }

        return rows[0][0];
    }

    public Selectable FindBottomSelectable(Selectable source)
    {
        if (Scroller == null || Content == null || source == null)
            return null;

        var sourceWorldX = source.transform.position.x;

        return GetTopLevelSelectables()
            .OrderBy(selectable => GetSelectablePosition(selectable).y)
            .ThenBy(selectable =>
                Mathf.Abs(selectable.transform.position.x - sourceWorldX)
            )
            .FirstOrDefault();
    }

    public virtual void ConfigureViewNavigation()
    {
        if (Owner == null)
            return;

        var footerSelectable = Owner.footerButton?.Button;
        var subtabSelectables = GetSubtabSelectables();
        var currentSubtabSelectable = CurrentSubtabSelectable;
        var firstSelectable = FirstSelectable;

        if (!ModsTab.AutomaticNavigation)
        {
            var fallbackNavigation = new Navigation
            {
                mode = Navigation.Mode.Explicit,
                selectOnLeft = footerSelectable,
                selectOnRight = footerSelectable,
                selectOnUp = currentSubtabSelectable ?? footerSelectable,
                selectOnDown = footerSelectable
            };

            firstSelectable =
                ConfigureNavigation(fallbackNavigation) ??
                firstSelectable;
        }

        var bottomSelectable =
            FindBottomSelectable(footerSelectable) ??
            firstSelectable;

        ConfigureFooterNavigation(bottomSelectable, subtabSelectables);
        ConfigureSubtabNavigation(subtabSelectables, firstSelectable);

        if (firstSelectable != null)
            Select(firstSelectable);

        ConfigureSettingsBarNavigation(Navigation.Mode.Explicit);
    }

    protected void ShowLocalizedHeader(LocalizedString localizedString)
    {
        if (Owner == null)
            return;

        if (Owner.headerText != null)
            Owner.headerText.gameObject.Deactivate();

        if (Owner.headerTextLocalized != null)
        {
            Owner.headerTextLocalized.LabelString = localizedString;
            Owner.headerTextLocalized.gameObject.Activate();
        }
    }

    protected void ShowHeader(string text)
    {
        if (Owner == null)
            return;

        if (Owner.headerTextLocalized != null)
            Owner.headerTextLocalized.gameObject.Deactivate();

        if (Owner.headerText != null)
        {
            Owner.headerText.LabelString = text;
            Owner.headerText.gameObject.Activate();
        }
    }

    protected void SetFooter(LocalizedString localizedString, bool showButton)
    {
        if (Owner == null)
            return;

        if (Owner.footerText != null)
            Owner.footerText.LabelString = localizedString;

        Owner.footerButton?.gameObject.SetActive(showButton);
    }

    protected void SetSubtabButtonsVisible(bool visible)
    {
        if (Owner == null)
            return;

        Owner.optionsSubtabButton?.gameObject.SetActive(visible);
        Owner.controlsSubtabButton?.gameObject.SetActive(visible);
    }

    protected void ConfigureSettingsBarNavigation(Navigation.Mode mode)
    {
        if (Owner == null)
            return;

        var resumeButton = Owner.resumeButton?.Button;
        var saveAndQuitButton = Owner.saveAndQuitButton?.Button;
        var resetAllSettingsButton = Owner.resetAllSettingsButton?.Button;

        if (
            resumeButton == null ||
            saveAndQuitButton == null ||
            resetAllSettingsButton == null)
        {
            return;
        }

        var resumeNavigation = resumeButton.navigation;
        var saveAndQuitNavigation = saveAndQuitButton.navigation;
        var resetAllSettingsNavigation = resetAllSettingsButton.navigation;

        resumeNavigation.mode = mode;
        saveAndQuitNavigation.mode = mode;
        resetAllSettingsNavigation.mode = mode;

        if (mode == Navigation.Mode.Explicit)
        {
            var footerButton = Owner.footerButton?.Button;

            resumeNavigation.selectOnUp = footerButton;
            saveAndQuitNavigation.selectOnUp = footerButton;
            resetAllSettingsNavigation.selectOnUp = footerButton;

            resetAllSettingsNavigation.selectOnRight = resumeButton;
            resumeNavigation.selectOnRight = saveAndQuitButton;
            resumeNavigation.selectOnLeft = resetAllSettingsButton;
            saveAndQuitNavigation.selectOnLeft = resumeButton;
        }

        resumeButton.navigation = resumeNavigation;
        saveAndQuitButton.navigation = saveAndQuitNavigation;
        resetAllSettingsButton.navigation = resetAllSettingsNavigation;
    }

    private List<Selectable> GetSubtabSelectables()
    {
        var selectables = new List<Selectable>();

        if (Owner?.HasCurrentModControls != true)
            return selectables;

        if (Owner.ModOptionsView?.HasOptions == true &&
            Owner.optionsSubtabButton?.Button != null)
        {
            selectables.Add(Owner.optionsSubtabButton.Button);
        }

        if (Owner.controlsSubtabButton?.Button != null)
            selectables.Add(Owner.controlsSubtabButton.Button);

        return selectables
            .OrderBy(selectable => selectable.transform.position.x)
            .ToList();
    }

    private void ConfigureFooterNavigation(
        Selectable bottomSelectable,
        IReadOnlyList<Selectable> subtabSelectables)
    {
        var footerButton = Owner?.footerButton?.Button;
        if (footerButton == null)
            return;

        var navigation = footerButton.navigation;
        navigation.mode = Navigation.Mode.Explicit;
        navigation.selectOnLeft =
            subtabSelectables.Count > 0
                ? subtabSelectables[subtabSelectables.Count - 1]
                : bottomSelectable;
        navigation.selectOnRight =
            subtabSelectables.Count > 0
                ? subtabSelectables[0]
                : bottomSelectable;
        navigation.selectOnUp = bottomSelectable;
        navigation.selectOnDown = Owner.resumeButton?.Button;
        footerButton.navigation = navigation;
    }

    private void ConfigureSubtabNavigation(
        IReadOnlyList<Selectable> subtabSelectables,
        Selectable firstSelectable)
    {
        var footerButton = Owner?.footerButton?.Button;
        if (footerButton == null)
            return;

        for (var i = 0; i < subtabSelectables.Count; i++)
        {
            var subtabSelectable = subtabSelectables[i];
            var navigation = subtabSelectable.navigation;

            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft =
                i > 0
                    ? subtabSelectables[i - 1]
                    : footerButton;
            navigation.selectOnRight =
                i + 1 < subtabSelectables.Count
                    ? subtabSelectables[i + 1]
                    : footerButton;
            navigation.selectOnUp = footerButton;
            navigation.selectOnDown = firstSelectable;

            subtabSelectable.navigation = navigation;
        }
    }

    public void HandleScrollInput()
    {
        if (Scroller == null || !Scroller.gameObject.activeInHierarchy)
            return;

        if (UnityEngine.Input.GetKeyDown(KeyCode.Home))
        {
            ScrollHome();
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.End))
        {
            ScrollEnd();
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.PageUp))
        {
            ScrollPageUp();
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.PageDown))
        {
            ScrollPageDown();
        }

        var controllerScroll = InputManager.ActiveDevice.RightStickY.Value;

        if (Mathf.Abs(controllerScroll) <= ControllerScrollDeadZone)
            return;

        var scrollableHeight = Mathf.Max(
            1f,
            Scroller.content.rect.height - Scroller.viewport.rect.height
        );

        var input = Mathf.InverseLerp(
            ControllerScrollDeadZone,
            1f,
            Mathf.Abs(controllerScroll)
        ) * Mathf.Sign(controllerScroll);

        Scroller.verticalNormalizedPosition = Mathf.Clamp01(
            Scroller.verticalNormalizedPosition
            + input * ControllerScrollSpeed / scrollableHeight * Time.unscaledDeltaTime
        );
    }

    public void AddScrollMagnets(Transform root)
    {
        if (root == null || Scroller == null)
            return;

        var scrollTarget = root as RectTransform;

        foreach (var selectable in root.GetComponentsInChildren<Selectable>(true))
        {
            if (selectable == null)
                continue;

            var magnet = selectable.GetOrAddComponent<TargetedScrollRectMagnet>();
            magnet.scrollRect = Scroller;
            magnet.scrollTarget = scrollTarget;

            var uiSelectable = selectable.GetOrAddComponent<UISelectable>();
            uiSelectable.doesSelectableMove = true;
            uiSelectable.delayForOneFrame = true;
        }
    }

    protected static Selectable MakeLabelSelectable(GameObject gameObject)
    {
        if (gameObject == null)
            return null;

        var selectable = gameObject.GetOrAddComponent<Selectable>();
        selectable.interactable = true;

        var uiSelectable = gameObject.GetOrAddComponent<UISelectable>();
        uiSelectable.doesSelectableMove = true;
        uiSelectable.delayForOneFrame = true;

        return selectable;
    }

    protected virtual IEnumerable<Selectable> GetTopLevelSelectables()
    {
        if (Content == null)
            return Enumerable.Empty<Selectable>();

        return Content
            .GetComponentsInChildren<Selectable>(false)
            .Where(selectable =>
                selectable != null &&
                selectable.gameObject.activeInHierarchy &&
                selectable.interactable &&
                IsTopLevelSelectable(selectable)
            );
    }

    protected bool IsTopLevelSelectable(Selectable selectable)
    {
        var parent = selectable.transform.parent;

        while (parent != null && parent != Content)
        {
            if (parent.GetComponent<Selectable>() != null)
                return false;

            parent = parent.parent;
        }

        return true;
    }

    protected Vector2 GetSelectablePosition(Selectable selectable)
    {
        var navigationTransform = GetNavigationTransform(
            selectable.transform
        );

        if (navigationTransform is not RectTransform rectTransform)
        {
            return Content.InverseTransformPoint(
                navigationTransform.position
            );
        }

        return Content.InverseTransformPoint(
            rectTransform.TransformPoint(rectTransform.rect.center)
        );
    }

    protected Transform GetNavigationTransform(Transform transform)
    {
        while (
            transform.parent != null &&
            transform.parent != Content
        )
        {
            transform = transform.parent;
        }

        return transform;
    }

    protected Selectable FindClosestOnRow(
        IEnumerable<Selectable> row,
        Selectable source
    )
    {
        var sourceX = GetSelectablePosition(source).x;

        return row
            .OrderBy(selectable =>
                Mathf.Abs(GetSelectablePosition(selectable).x - sourceX)
            )
            .FirstOrDefault();
    }

    protected void ForceLayout()
    {
        if (Scroller == null || Content == null)
            return;

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(Content);

        if (Scroller.viewport != null)
            LayoutRebuilder.ForceRebuildLayoutImmediate(Scroller.viewport);

        Canvas.ForceUpdateCanvases();
    }

    protected void ConfigureScrollRect()
    {
        if (Scroller == null)
            return;

        var scrollbar = Scroller.verticalScrollbar;
        if (scrollbar == null)
            return;

        scrollbar.enabled = true;
        scrollbar.interactable = true;
        scrollbar.transform.SetAsLastSibling();

        foreach (var graphic in scrollbar.GetComponentsInChildren<Graphic>(true))
            graphic.raycastTarget = true;
    }

    private void ScrollHome()
    {
        Scroller.verticalNormalizedPosition = 1f;
    }

    private void ScrollEnd()
    {
        Scroller.verticalNormalizedPosition = 0f;
    }

    private void ScrollPageUp()
    {
        Scroller.verticalNormalizedPosition = Mathf.Clamp01(
            Scroller.verticalNormalizedPosition + 0.25f
        );
    }

    private void ScrollPageDown()
    {
        Scroller.verticalNormalizedPosition = Mathf.Clamp01(
            Scroller.verticalNormalizedPosition - 0.25f
        );
    }
}

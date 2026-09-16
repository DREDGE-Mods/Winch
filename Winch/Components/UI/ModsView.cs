using System.Collections.Generic;
using System.Linq;
using InControl;
using UnityEngine;
using UnityEngine.EventSystems;
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

    public virtual Selectable FirstSelectable =>
        GetTopLevelSelectables()
            .OrderByDescending(selectable => GetSelectablePosition(selectable).y)
            .ThenBy(selectable => GetSelectablePosition(selectable).x)
            .FirstOrDefault();

    public virtual void Initialize(ModsTab owner)
    {
        Owner = owner;
        Scroller = GetComponent<ScrollRect>();
        FocusGrabber = gameObject.GetOrAddComponent<ControllerFocusGrabber>();

        ConfigureScrollRect();
    }

    public virtual void Show()
    {
        Scroller?.gameObject.Activate();
    }

    public virtual void Hide()
    {
        Scroller?.gameObject.Deactivate();
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

    public virtual Selectable ConfigureNavigation(Selectable fallbackTarget = null)
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
                        : fallbackTarget;

                navigation.selectOnRight =
                    columnIndex + 1 < row.Count
                        ? row[columnIndex + 1]
                        : fallbackTarget;

                navigation.selectOnUp =
                    rowIndex > 0
                        ? FindClosestOnRow(rows[rowIndex - 1], selectable)
                        : fallbackTarget;

                navigation.selectOnDown =
                    rowIndex + 1 < rows.Count
                        ? FindClosestOnRow(rows[rowIndex + 1], selectable)
                        : fallbackTarget;

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

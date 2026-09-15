using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Winch.Components.UI;

public class TargetedScrollRectMagnet : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
    public ScrollRect scrollRect;
    public RectTransform scrollTarget;

    public void OnSelect(BaseEventData eventData)
    {
        if (GameManager.Instance.Input.IsUsingController)
        {
            ScrollToThis();
        }
    }

    public void ScrollToThis()
    {
        if (scrollRect == null || scrollRect.content == null)
            return;

        var target = scrollTarget != null
            ? scrollTarget
            : transform as RectTransform;

        if (target == null)
            return;

        scrollRect.content.anchoredPosition =
            scrollRect.GetSnapToPositionToBringChildIntoView(target);
    }
}

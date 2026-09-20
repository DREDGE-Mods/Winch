using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Winch.Components.UI;

public class TargetedScrollRectMagnet : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
    public ScrollRectMagnetController magnetController;
    public RectTransform scrollTarget;

    private void Awake()
    {
        FindMagnetController();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (GameManager.Instance.Input.IsUsingController)
        {
            ScrollToThis();
        }
    }

    public void ScrollToThis()
    {
        if (magnetController == null)
        {
            FindMagnetController();
        }

        if (magnetController == null)
            return;

        RectTransform target = scrollTarget != null
            ? scrollTarget
            : transform as RectTransform;

        magnetController.ScrollTo(target);
    }

    private void FindMagnetController()
    {
        if (magnetController == null)
        {
            magnetController = GetComponentInParent<ScrollRectMagnetController>();
        }
    }
}
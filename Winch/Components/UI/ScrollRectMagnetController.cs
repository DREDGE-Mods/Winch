using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Winch.Components.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollRectMagnetController : MonoBehaviour
{
    [SerializeField]
    private ScrollRect scrollRect;

    [SerializeField]
    private float scrollSpeed = 10f;

    [SerializeField]
    private float maxScrollTime = 0.15f;

    [SerializeField]
    private float distanceThreshold = 3f;

    [SerializeField]
    private float padding;

    private Coroutine lerpCoroutine;

    private void Awake()
    {
        if (scrollRect == null)
        {
            scrollRect = GetComponent<ScrollRect>();
        }
    }

    private void OnDisable()
    {
        StopScrolling();
    }

    public void ScrollTo(RectTransform target, bool immediate = false)
    {
        if (scrollRect == null || scrollRect.content == null || target == null)
            return;

        if (target != scrollRect.content && !target.IsChildOf(scrollRect.content))
            return;

        StopScrolling();

        Canvas.ForceUpdateCanvases();

        Vector2 destination = GetDestinationPosition(target);

        if (immediate)
        {
            scrollRect.content.anchoredPosition = destination;
            return;
        }

        if (Vector2.SqrMagnitude(scrollRect.content.anchoredPosition - destination) <=
            distanceThreshold * distanceThreshold)
        {
            scrollRect.content.anchoredPosition = destination;
            return;
        }

        scrollRect.StopMovement();
        lerpCoroutine = StartCoroutine(LerpToDestination(destination));
    }

    public void StopScrolling()
    {
        if (lerpCoroutine != null)
        {
            StopCoroutine(lerpCoroutine);
            lerpCoroutine = null;
        }

        if (scrollRect != null)
        {
            scrollRect.StopMovement();
        }
    }

    private Vector2 GetDestinationPosition(RectTransform target)
    {
        RectTransform viewport = scrollRect.viewport != null
            ? scrollRect.viewport
            : scrollRect.transform as RectTransform;

        if (viewport == null)
            return scrollRect.content.anchoredPosition;

        Bounds targetBounds =
            RectTransformUtility.CalculateRelativeRectTransformBounds(viewport, target);

        Rect viewportRect = viewport.rect;

        float xMin = viewportRect.xMin + padding;
        float xMax = viewportRect.xMax - padding;
        float yMin = viewportRect.yMin + padding;
        float yMax = viewportRect.yMax - padding;

        Vector2 correction = Vector2.zero;

        if (scrollRect.horizontal)
        {
            if (targetBounds.min.x < xMin)
            {
                correction.x = xMin - targetBounds.min.x;
            }
            else if (targetBounds.max.x > xMax)
            {
                correction.x = xMax - targetBounds.max.x;
            }
        }

        if (scrollRect.vertical)
        {
            if (targetBounds.min.y < yMin)
            {
                correction.y = yMin - targetBounds.min.y;
            }
            else if (targetBounds.max.y > yMax)
            {
                correction.y = yMax - targetBounds.max.y;
            }
        }

        if (correction == Vector2.zero)
            return scrollRect.content.anchoredPosition;

        Vector3 worldCorrection = viewport.TransformVector(correction);

        Transform contentParent = scrollRect.content.parent;

        Vector2 localCorrection = contentParent != null
            ? (Vector2)contentParent.InverseTransformVector(worldCorrection)
            : (Vector2)worldCorrection;

        Vector2 destination =
            scrollRect.content.anchoredPosition + localCorrection;

        if (!scrollRect.horizontal)
        {
            destination.x = scrollRect.content.anchoredPosition.x;
        }

        if (!scrollRect.vertical)
        {
            destination.y = scrollRect.content.anchoredPosition.y;
        }

        return destination;
    }

    private IEnumerator LerpToDestination(Vector2 destination)
    {
        float scrollTime = 0f;

        while (true)
        {
            scrollTime += Time.unscaledDeltaTime;

            float t = Mathf.Min(scrollSpeed * Time.unscaledDeltaTime, 1f);

            scrollRect.content.anchoredPosition = Vector2.Lerp(
                scrollRect.content.anchoredPosition,
                destination,
                t
            );

            if (scrollTime >= maxScrollTime ||
                Vector2.SqrMagnitude(
                    scrollRect.content.anchoredPosition - destination
                ) <= distanceThreshold * distanceThreshold)
            {
                scrollRect.content.anchoredPosition = destination;
                break;
            }

            yield return null;
        }

        lerpCoroutine = null;
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;
using Winch.Components;
using Winch.Util;

namespace Winch.Data.Character
{
    public class AdvancedSpeakerData : SpeakerData
    {
        public string id;

        public string paralinguisticsNameKey;

        public Sprite portraitSprite;

        public void AddPortraitPrefab()
        {
            portraitPrefab = new GameObject($"{id} PortraitPrefab", typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster), typeof(SpeakerPortraitAnimator)).Prefabitize();
            portraitPrefab.layer = Layer.UI;
            var imageObj = new GameObject(id, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            var rt = (RectTransform)imageObj.transform;
            rt.SetParent(portraitPrefab.transform, false);
            rt.localScale = Vector3.one * 100f;
            rt.sizeDelta = Vector2.one * 7f;
            var image = imageObj.GetComponent<Image>();
            image.sprite = portraitSprite;
            image.preserveAspect = true;
            image.raycastTarget = false;
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
using Winch.Util;

namespace Winch.Serialization.Character
{
    public class AdvancedSpeakerData : SpeakerData
    {
        public string id;

        public string paralinguisticsNameKey;

        public Sprite portraitSprite;

        public void AddPortraitPrefab()
        {
            portraitPrefab = new GameObject($"{id} PortraitPrefab", typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster), typeof(SpeakerPortraitAnimator));
            portraitPrefab.layer = Layer.UI;
            var imageObj = new GameObject(id, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            imageObj.transform.SetParent(portraitPrefab.transform, false);
            imageObj.transform.localScale = Vector3.one * 100f;
            (imageObj.transform as RectTransform).sizeDelta = Vector2.one * 7f;
            var image = imageObj.GetComponent<Image>();
            image.sprite = portraitSprite;
            image.preserveAspect = true;
            image.raycastTarget = false;
            portraitPrefab.DontDestroyOnLoad();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Winch.Serialization.Character
{
    public class SpeakerPortraitAnimator : MonoBehaviour
    {
        private static readonly int animationTime = 45;
        private static readonly AnimationCurve xAnchorCurve = new AnimationCurve(new Keyframe(0, -75), new Keyframe(20, -7), new Keyframe(animationTime, 0));
        private static readonly AnimationCurve colorRGBCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(30, 1), new Keyframe(animationTime, 1));
        private static readonly AnimationCurve colorACurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(15, 1), new Keyframe(animationTime, 1));

        private RectTransform _rectTransform;
        private Image _image;
        private float _currentFrame = 0;

        public void Start()
        {
            _image = GetComponentInChildren<Image>(true);
            _rectTransform = (RectTransform)_image.transform;
            Evaluate(0);
        }

        public void OnEnable()
        {
            Evaluate(0);
            _currentFrame = 0;
        }

        public void FixedUpdate()
        {
            Evaluate(_currentFrame);
            if (_currentFrame < animationTime)
                _currentFrame++;
        }

        public void Evaluate(float time)
        {
            var xAnchor = xAnchorCurve.Evaluate(time);
            _rectTransform.SetAnchoredPosX(xAnchor);
            var rgb = colorRGBCurve.Evaluate(time);
            var a = colorACurve.Evaluate(time);
            _image.color = new Color(rgb, rgb, rgb, a);
        }
    }
}

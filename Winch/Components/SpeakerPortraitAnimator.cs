using UnityEngine;
using UnityEngine.UI;

namespace Winch.Components
{
    public class SpeakerPortraitAnimator : MonoBehaviour
    {
        private static readonly float oneThird = 0.33333334f;
        [SerializeField]
        private int animationTime = 60;
        [SerializeField]
        private AnimationCurve xAnchorCurve = new AnimationCurve(new Keyframe(0, -75, 0, 0, oneThird, oneThird), new Keyframe(oneThird, 0, 0, 0, oneThird, oneThird), new Keyframe(0.75f, 0, 0, 0, oneThird, oneThird));
        [SerializeField]
        private AnimationCurve colorRGBCurve = new AnimationCurve(new Keyframe(0, 0, 0, 0, oneThird, oneThird), new Keyframe(0.5f, 1, 0, 0, oneThird, oneThird));
        [SerializeField]
        private AnimationCurve colorACurve = new AnimationCurve(new Keyframe(0, 0, 0, 0, oneThird, oneThird), new Keyframe(0.25f, 1, 0, 0, oneThird, oneThird));

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
            Tick();
        }

        public void Tick()
        {
            Evaluate(_currentFrame / animationTime);
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

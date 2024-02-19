using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RB.UI
{
    public class HealthSmoothBarView : HealthView
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _fillerImage;
        [SerializeField] private Color _transitionColor;
        [SerializeField, Range(0.1f, 1.5f)] private float _transitionTime;

        private IEnumerator _transition;
        private Color _originColor;

        private void Awake()
        {
            _originColor = _fillerImage.color;
        }

        protected override void OnHealthChanged(int targetValue)
        {
            if (_transition != null)
                StopCoroutine(_transition);

            _transition = UpdateView(targetValue);

            StartCoroutine(_transition);
        }

        private IEnumerator UpdateView(int targetValue)
        {
            float startValue = _slider.value;
            float endValue = (float)targetValue / MaxValue;
            float elapsedTime = 0;

            while (_slider.value != endValue)
            {
                _slider.value = Mathf.Lerp(startValue, endValue, elapsedTime / _transitionTime);
                _fillerImage.color = Color.Lerp(_transitionColor, _originColor, elapsedTime / _transitionTime);

                elapsedTime += Time.deltaTime;

                yield return null;
            }
        }
    }
}
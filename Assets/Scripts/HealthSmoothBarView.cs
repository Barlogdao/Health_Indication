using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RB.UI
{
    public class HealthSmoothBarView : HealthView
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _transitionSpeed;

        private IEnumerator _transition;
        protected override void OnHealthChanged(int targetValue)
        {
            if (_transition != null)
                StopCoroutine(_transition);

            _transition = UpdateView(targetValue);

            StartCoroutine(_transition);
        }

        private IEnumerator UpdateView(int targetValue)
        {
            float endValue = (float)targetValue / MaxValue;
            while (_slider.value != endValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, endValue, _transitionSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }
}
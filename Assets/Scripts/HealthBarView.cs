using UnityEngine;
using UnityEngine.UI;

namespace RB.UI
{
    public class HealthBarView : HealthView
    {
        [SerializeField] private Slider _slider;
        protected override void OnHealthChanged(int targetValue)
        {
            _slider.value = (float)targetValue / MaxValue;
        }
    }
}
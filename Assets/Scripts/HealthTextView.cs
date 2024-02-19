using UnityEngine;
using TMPro;

namespace RB.UI
{
    public class HealthTextView : HealthView
    {
        [SerializeField] private TextMeshProUGUI _textLabel;

        protected override void OnHealthChanged(int targetValue)
        {
            _textLabel.text = $"{targetValue}/{MaxValue}";
        }
    }
}
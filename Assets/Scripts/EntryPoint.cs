using RB.UI;
using UnityEngine;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private HealthText _textView;
    [SerializeField] private HealthBar _barView;
    [SerializeField] private HealthBarSmooth _smoothBarView;

    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damageAmount;
    [SerializeField] private int _healAmount;

    private Health _health;

    private void Awake()
    {
        _health = new Health(_maxHealth);

        _textView.Initialize(_health);
        _barView.Initialize(_health);
        _smoothBarView.Initialize(_health);
    }

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(OnDamageButtonClicked);
        _healButton.onClick.AddListener(OnHealButtonClicked);
    }

    private void OnDestroy()
    {
        _damageButton.onClick.RemoveListener(OnDamageButtonClicked);
        _healButton.onClick.RemoveListener(OnHealButtonClicked);
    }

    private void OnHealButtonClicked()
    {
        _health.Add(_healAmount);
    }

    private void OnDamageButtonClicked()
    {
        _health.Subtract(_damageAmount);
    }
}

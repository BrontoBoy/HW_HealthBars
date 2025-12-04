using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = _health.MaxHealthValue;
        _slider.value = _health.Value;
    }

    private void OnEnable()
    {
        if (_health != null)
        {
            _health.DamageTaken += OnHealthChanged;
            _health.Healed += OnHealthChanged;
        }
    }
    
    private void OnDisable()
    {
        if (_health != null)
        {
            _health.DamageTaken -= OnHealthChanged;
            _health.Healed -= OnHealthChanged;
        }
    }
    
    private void OnHealthChanged(int changeAmount)
    {
        _slider.value = _health.Value;
    }
}
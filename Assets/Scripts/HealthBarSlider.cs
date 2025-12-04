using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : HealthView
{
    [SerializeField] private Slider _slider;

    protected override void Initialize()
    {
        _slider.maxValue = _health.maxValue;
        _slider.value = _health.Value;
    }
    
    protected override void OnHealthChanged(int amount)
    {
        _slider.value = _health.Value;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : HealthView
{
    [SerializeField] private Slider _slider;

    protected override void Initialize()
    {
        _slider.maxValue = Health.MaxValue;
        _slider.value = Health.Value;
    }
    
    protected override void OnHealthChanged(int amount)
    {
        _slider.value = Health.Value;
    }
}
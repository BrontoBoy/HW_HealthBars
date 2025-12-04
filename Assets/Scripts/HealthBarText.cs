using UnityEngine;
using TMPro;

public class HealthBarText : HealthView
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Initialize()
    {
        UpdateText(_health.Value, _health.maxValue);
    }
    
    protected override void OnHealthChanged(int amount)
    {
        UpdateText(_health.Value, _health.maxValue);
    }
    
    private void UpdateText(int currentValue, int maxValue)
    {
        _text.text = $"Здоровье: {currentValue}/{maxValue}";
    }
}
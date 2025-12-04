using UnityEngine;
using TMPro;

public class HealthBarText : HealthView
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Initialize()
    {
        UpdateText(Health.Value, Health.MaxValue);
    }
    
    protected override void OnHealthChanged(int amount)
    {
        UpdateText(Health.Value, Health.MaxValue);
    }
    
    private void UpdateText(int currentValue, int maxValue)
    {
        _text.text = $"Здоровье: {currentValue}/{maxValue}";
    }
}
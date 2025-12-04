using UnityEngine;
using TMPro;

public class HealthBarText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        UpdateText(_health.Value, _health.MaxHealthValue);
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
        UpdateText(_health.Value, _health.MaxHealthValue);
    }

    private void UpdateText(int currentHealth, int maxHealth)
    {
        _text.text = $"Здоровье: {currentHealth}/{maxHealth}"; 
    }
}
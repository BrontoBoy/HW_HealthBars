using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBarSlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothSpeed = 3f;
    [SerializeField] private float _threshold = 0.1f;

    private float _targetValue;
    private bool _isUpdating;

    private void Start()
    {
        _slider.maxValue = _health.MaxHealthValue;
        _slider.value = _health.Value;
        _targetValue = _health.Value;
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
    
    private void Update()
    {
        if (_isUpdating == false) 
            return;
        
        float currentValue = _slider.value;
        float newValue = Mathf.MoveTowards(currentValue,
            _targetValue, _smoothSpeed * Time.deltaTime
        );
        
        _slider.value = newValue;
        
        if (Mathf.Abs(newValue - _targetValue) < _threshold)
        {
            _slider.value = _targetValue;
            _isUpdating = false;
        }
    }
    
    private void OnHealthChanged(int changeAmount)
    {
        _targetValue = _health.Value;
        _isUpdating = true;
    }
}
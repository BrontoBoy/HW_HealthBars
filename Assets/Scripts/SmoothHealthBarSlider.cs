using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmoothHealthBarSlider : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothSpeed = 3f;
    [SerializeField] private float _threshold = 0.1f;

    private Coroutine _smoothCoroutine;

    protected override void OnDisable()
    {
        base.OnDisable();
        
        if (_smoothCoroutine != null)
        {
            StopCoroutine(_smoothCoroutine);
            _smoothCoroutine = null;
        }
    }
    
    protected override void Initialize()
    {
        _slider.maxValue = _health.maxValue;
        _slider.value = _health.Value;
    }
    
    protected override void OnHealthChanged(int amount)
    {
        if (_smoothCoroutine != null)
            StopCoroutine(_smoothCoroutine);
        
        _smoothCoroutine = StartCoroutine(SmoothUpdateCoroutine(_health.Value));
    }

    private IEnumerator SmoothUpdateCoroutine(float targetValue)
    {
        while (Mathf.Abs(_slider.value - targetValue) > _threshold)
        {
            float newValue = Mathf.MoveTowards(_slider.value, targetValue,
                _smoothSpeed * Time.deltaTime);
            _slider.value = newValue;

            yield return null;
        }
        
        _slider.value = targetValue;
        _smoothCoroutine = null;
    }
}
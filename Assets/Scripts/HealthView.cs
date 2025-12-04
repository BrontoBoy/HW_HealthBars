using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health _health;
    
    private void Start()
    {
        Initialize();
    }
    
    protected virtual void OnEnable()
    {
        if (_health != null)
        {
            _health.DamageTaken += OnHealthChanged;
            _health.Healed += OnHealthChanged;
        }
    }
    
    protected virtual void OnDisable()
    {
        if (_health != null)
        {
            _health.DamageTaken -= OnHealthChanged;
            _health.Healed -= OnHealthChanged;
        }
    }
    
    protected virtual void OnHealthChanged(int amount) { }
    
    protected virtual void Initialize() { }
}
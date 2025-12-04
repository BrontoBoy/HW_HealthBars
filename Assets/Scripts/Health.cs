using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    
    private int _currentHealth;
    
    public event System.Action<int> DamageTaken;
    public event System.Action<int> Healed;

    public int MaxHealthValue => _maxHealth;
    public int Value => _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    
    public void Heal(int amount)
    {
        if (amount <= 0)
            return;
        
        int oldHealth = _currentHealth;
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
        int actualHeal = _currentHealth - oldHealth;
        
        Healed?.Invoke(actualHeal);
    }
    
    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            return;
        
        int oldHealth = _currentHealth;
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        int actualDamage = oldHealth - _currentHealth;
        
        DamageTaken?.Invoke(actualDamage);
    }
}
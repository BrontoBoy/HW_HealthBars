using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private Health _targetHealth;
    [SerializeField] private Button _button;
    [SerializeField] private int _amount = 10;
    
    private void OnEnable()
    {
        if (_button != null)
            _button.onClick.AddListener(OnClick);
    }
    
    private void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(OnClick);
    }
    
    private void OnClick()
    {
        if (_targetHealth == null)
            return;

        if (_amount <= 0)
            return;
        
        _targetHealth.TakeDamage(_amount);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _button;
    [SerializeField] private int _amount = 15;
    
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
        if (_health == null)
            return;
        
        if (_amount <= 0)
            return;
        
        _health.Heal(_amount);
    }
}
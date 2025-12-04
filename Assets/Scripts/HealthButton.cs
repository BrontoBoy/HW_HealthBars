using UnityEngine;
using UnityEngine.UI;

public abstract class HealthButton : MonoBehaviour
{
    [SerializeField] protected Health _target;
    [SerializeField] protected Button _button;
    [SerializeField] protected int _amount = 10;
    
    protected virtual void OnClick()
    {
        if (_target == null)
            return;

        if (_amount <= 0)
            return;
    }
    
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
}
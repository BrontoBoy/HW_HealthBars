using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class HealthButton : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] protected Button Button;
    [SerializeField] protected int Amount = 10;
    
    protected virtual void OnClick()
    {
        if (Health == null)
            return;

        if (Amount <= 0)
            return;
    }
    
    private void OnEnable()
    {
        if (Button != null)
            Button.onClick.AddListener(OnClick);
    }
    
    private void OnDisable()
    {
        if (Button != null)
            Button.onClick.RemoveListener(OnClick);
    }
}
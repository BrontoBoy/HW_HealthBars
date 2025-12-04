public class AttackButton : HealthButton
{    protected override void OnClick()
    {
        base.OnClick();
        _target.TakeDamage(_amount);
    }
}
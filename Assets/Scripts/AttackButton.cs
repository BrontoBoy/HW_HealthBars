public class AttackButton : HealthButton
{    protected override void OnClick()
    {
        base.OnClick();
        Health.TakeDamage(Amount);
    }
}
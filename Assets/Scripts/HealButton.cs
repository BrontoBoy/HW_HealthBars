public class HealButton : HealthButton
{
    protected override void OnClick()
    {
        base.OnClick();
        Health.Heal(Amount);
    }
}
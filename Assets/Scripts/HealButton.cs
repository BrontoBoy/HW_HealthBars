public class HealButton : HealthButton
{
    protected override void OnClick()
    {
        base.OnClick();
        _target.Heal(_amount);
    }
}
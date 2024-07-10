public class SharpHealthBar : HealthBar 
{
    protected sealed override void Enable() =>
        Health.Changed += SetValue;

    protected sealed override void Disable() =>
        Health.Changed -= SetValue;
}
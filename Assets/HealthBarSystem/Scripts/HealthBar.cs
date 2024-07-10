using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [field: SerializeField] protected Health Health { get; private set; }

    private void OnEnable() =>
        Health.Changed += SetValue;

    private void OnDisable() =>
        Health.Changed -= SetValue;

    protected abstract void SetValue(float value);
}
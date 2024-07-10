using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private HealButton _healButton;
    [SerializeField] private DamageButton _damageButton;
    
    private Slider _slider;

    [field: SerializeField] protected Health Health { get; private set; }

    protected float SliderValue => _slider.value;

    private void Awake() =>
        InitAwake();

    private void OnEnable()
    {
        _healButton.Clicked += Health.Increase;
        _damageButton.Clicked += Health.Decrease;

        Enable();
    }

    private void Start() =>
        InitStart();

    private void OnValidate()
    {
        if (_slider != null && _slider.value != Health.Current)
            SetValue(Health.Current);
    }

    private void OnDisable()
    {
        _healButton.Clicked -= Health.Increase;
        _damageButton.Clicked -= Health.Decrease;

        Disable();
    }

    protected virtual void Disable() { }
    protected virtual void Enable() { }

    protected void SetValue(float value)
    {
        _slider.value = value;
        _value.text = $"{value:F0}/{Health.Max}";
    }

    private void InitAwake() => 
        _slider = GetComponent<Slider>();

    private void InitStart()
    {
        _slider.wholeNumbers = false;

        _slider.minValue = Health.Min;
        _slider.maxValue = Health.Max;

        SetValue(Health.Current);
    }
}
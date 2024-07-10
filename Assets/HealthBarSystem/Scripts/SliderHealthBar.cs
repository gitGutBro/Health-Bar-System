using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthBar : HealthBar 
{
    [SerializeField] private TMP_Text _value;

    protected Slider Slider { get; private set; }

    private void Awake() => 
        Slider = GetComponent<Slider>();

    protected override void SetValue(float value)
    {
        SetSliderValue(value);
        SetTextValue(value);
    }

    protected void SetSliderValue(float value) =>
        Slider.value = value / Health.Max;

    protected void SetTextValue(float value)
    {
        value = Mathf.Round(value);
        _value.text = $"{value:F0}/{Health.Max:F0}";
    }
}
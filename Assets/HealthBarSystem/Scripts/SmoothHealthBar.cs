using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using TMPro;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
{
    private const float Min = 0f;
    private const float Max = 100f;

    private const float MinDelta = 0.1f;
    private const float MaxDelta = 50f;

    [SerializeField][Range(Min, Max)] private float _current;
    [SerializeField][Range(MinDelta, MaxDelta)] private float _delta;

    [SerializeField] private TextMeshProUGUI _value;

    private Slider _slider;

    private void Awake() => 
        InitAwake();

    private void Start() => 
        InitStart();

    private void OnValidate()
    {
        if (_slider != null && _slider.value != _current)
            SetValue(_current);
    }

    public void Decrease(float amount)
    {
        _current = Mathf.Clamp(_current - amount, Min, Max);

        ChangeSliderValue();
    }

    public void Increase(float amount)
    {
        _current = Mathf.Clamp(_current + amount, Min, Max);

        ChangeSliderValue();
    }

    public async void ChangeSliderValue()
    {
        while (_slider.value != _current)
        {
            SetValue(Mathf.MoveTowards(_slider.value, _current, _delta * Time.deltaTime));

            await UniTask.Yield();
        }
    }

    private void SetValue(float current)
    {
        _slider.value = current;
        _value.text = $"{current:F0}/{Max}";
    }

    private void InitAwake() => 
        _slider = GetComponent<Slider>();

    private void InitStart()
    {
        _slider.wholeNumbers = false;

        _slider.minValue = Min;
        _slider.maxValue = Max;
        
        SetValue(_current);
    }
}
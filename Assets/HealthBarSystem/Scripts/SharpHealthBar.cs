using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SharpHealthBar : MonoBehaviour
{
    private const int Min = 0;
    private const int Max = 100;

    [SerializeField][Range(Min, Max)] private int _current;

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

    public void Decrease(int amount)
    {
        _current = Mathf.Clamp(_current - amount, Min, Max);

        SetValue(_current);
    }

    public void Increase(int amount)
    {
        _current = Mathf.Clamp(_current + amount, Min, Max);

        SetValue(_current);
    }

    private void SetValue(int value)
    {
        _slider.value = value;
        _value.text = $"{value:F0}/{Max}";
    }

    private void InitAwake() => 
        _slider = GetComponent<Slider>();

    private void InitStart()
    {
        _slider.wholeNumbers = true;

        _slider.minValue = Min;
        _slider.maxValue = Max;
        
        SetValue(_current);
    }
}
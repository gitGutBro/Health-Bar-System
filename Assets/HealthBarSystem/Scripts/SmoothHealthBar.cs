using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : HealthBar
{
    private const float MinDelta = 0.1f;
    private const float MaxDelta = 50f;

    [SerializeField][Range(MinDelta, MaxDelta)] private float _delta;

    public async void ChangeValueSmooth(float target)
    {
        while (SliderValue != target)
        {
            SetValue(Mathf.MoveTowards
                (SliderValue, Health.Current, _delta * Time.deltaTime));

            await UniTask.Yield();
        }
    }

    protected sealed override void Enable() =>
        Health.Changed += ChangeValueSmooth;

    protected sealed override void Disable() =>
        Health.Changed -= ChangeValueSmooth;
}
using System;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;

public class SmoothHealthBar : SliderHealthBar
{
    private const float MinDelta = 0.1f;
    private const float MaxDelta = 1.0f;
    
    private CancellationTokenSource _tokenSource;
    private UniTask _currentTask;

    [SerializeField][Range(MinDelta, MaxDelta)] private float _delta;

    protected sealed override void SetValue(float target)
    {
        _tokenSource?.Cancel();
        _tokenSource = new();

        _currentTask = SetValueAsync(target, _tokenSource.Token);
    }

    private async UniTask SetValueAsync(float target, CancellationToken token)
    {
        float targetCoefficient = target / Health.Max;

        while (Slider.value != targetCoefficient && token.IsCancellationRequested == false)
        {
            Slider.value = Mathf.MoveTowards
                (Slider.value, targetCoefficient, _delta * Time.deltaTime);

            SetTextValue(Slider.value * Health.Max);

            await UniTask.Yield();
        }
    }
}
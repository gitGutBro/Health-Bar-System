using System;
using UnityEngine;

[Serializable]
public class Health : MonoBehaviour
{
    public const float Min = 0f;

    [SerializeField][Min(Min + 1)] private float _max;
    [SerializeField][Min(Min)] private float _current;

    public event Action<float> Changed;

    public float Max => _max;
    public float Current => _current;

    private void OnValidate()
    {
        if (_current > _max)
            _current = _max;
    }

    public void Decrease(float amount)
    {
        _current = Mathf.Clamp(_current - amount, Min, _max);

        Changed.Invoke(_current);
    }

    public void Increase(float amount)
    {
        _current = Mathf.Clamp(_current + amount, Min, _max);

        Changed.Invoke(_current);
    }
}
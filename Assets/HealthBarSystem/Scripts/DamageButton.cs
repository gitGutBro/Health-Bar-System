using System;
using UnityEngine;

public class DamageButton : ParentButton
{
    public event Action<float> Clicked;

    [field: SerializeField] public float Damage { get; private set; }

    protected sealed override void OnClick() =>
        Clicked.Invoke(Damage);
}
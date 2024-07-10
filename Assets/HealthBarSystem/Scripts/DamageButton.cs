using System;
using UnityEngine;

public class DamageButton : ParentButton
{
    [field: SerializeField] public float Damage { get; private set; }

    public event Action<float> Clicked;

    protected sealed override void OnClick() =>
        Clicked.Invoke(Damage);
}
using System;
using UnityEngine;

public class HealButton : ParentButton
{
    [field: SerializeField] public float Heal { get; private set; }

    public event Action<float> Clicked;

    protected sealed override void OnClick() => 
        Clicked.Invoke(Heal);
}
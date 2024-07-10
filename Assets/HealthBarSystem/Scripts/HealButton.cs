using System;
using UnityEngine;

public class HealButton : ParentButton
{
    public event Action<float> Clicked;

    [field: SerializeField] public float Heal { get; private set; }

    protected sealed override void OnClick() => 
        Clicked.Invoke(Heal);
}
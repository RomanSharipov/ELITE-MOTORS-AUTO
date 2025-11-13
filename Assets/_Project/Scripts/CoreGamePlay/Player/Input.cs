using System;
using UnityEngine;

public abstract class Input : MonoBehaviour
{
    public abstract event Action Jumped;

    public abstract float Direction { get; }
}
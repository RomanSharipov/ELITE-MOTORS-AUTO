using UnityEngine;

public abstract class Input : MonoBehaviour
{
    public abstract bool JumpInput { get; }

    public abstract float Direction { get; }
}
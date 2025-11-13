using UnityEngine;

public abstract class Input : MonoBehaviour
{
    public abstract float GetHorizontalInput();
    public abstract bool GetJumpInput();
}
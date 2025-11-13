using UnityEngine;

public class KeyboardInput : Input
{
    public override float GetHorizontalInput()
    {
        float horizontal = 0f;

        if (UnityEngine.Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }
        else if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }

        return horizontal;
    }

    public override bool GetJumpInput()
    {
        return UnityEngine.Input.GetKeyDown(KeyCode.Space);
    }
}

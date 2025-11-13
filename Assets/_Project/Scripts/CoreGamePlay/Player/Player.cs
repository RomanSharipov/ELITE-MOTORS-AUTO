using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Input _input;

    public void RotatePlayer(GravityDirection targetGravity)
    {
        switch (targetGravity)
        {
            case GravityDirection.Down:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case GravityDirection.Up:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;

            case GravityDirection.Left:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;

            case GravityDirection.Right:
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
        }
    }

    private void Update()
    {
        if (movement == null || _input == null)
            return;

        float horizontalInput = _input.GetHorizontalInput();
        bool jumpInput = _input.GetJumpInput();

        movement.Move(horizontalInput);

        if (jumpInput)
        {
            movement.Jump();
        }
    }
}
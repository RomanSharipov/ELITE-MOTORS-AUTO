using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private InputType _inputType;
    [SerializeField] private KeyboardInput _keyboardInput;
    [SerializeField] private TouchInput _touchInput;

    private void Start()
    {
        switch (_inputType)
        {
            case InputType.Touch:
                movement.Init(_touchInput);
                break;
            case InputType.Keyboard:
                movement.Init(_keyboardInput);
                break;
            default:
                break;
        }


        
    }

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
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;

            case GravityDirection.Right:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }
}
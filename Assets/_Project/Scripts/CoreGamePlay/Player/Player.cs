using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Movement movement;
    

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
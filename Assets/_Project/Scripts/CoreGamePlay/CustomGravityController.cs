using TriInspector;
using UnityEngine;

public class CustomGravityController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private float gravityStrength = 9.81f;
    [SerializeField] private Player player;

    [SerializeField] private GravityDirection _currentGravityDirection;
    [SerializeField] private Vector2 gravityVector;

    private void Start()
    {
        _player.gravityScale = 0f;
        
        SetGravityDirection(GravityDirection.Down);
    }

    private void FixedUpdate()
    {
        _player.AddForce(gravityVector * _player.mass);
    }

    [Button]
    public void SetGravityDirection(GravityDirection direction)
    {
        if (_currentGravityDirection == direction)
        {
            return;
        }

        _currentGravityDirection = direction;
        _player.gravityScale = 0f;
        _player.velocity = Vector2.zero;
        _player.angularVelocity = 0f;

        player.RotatePlayer(_currentGravityDirection);

        
        switch (direction)
        {
            case GravityDirection.Down:
                gravityVector = Vector2.down * gravityStrength;
                break;

            case GravityDirection.Up:
                gravityVector = Vector2.up * gravityStrength;
                break;

            case GravityDirection.Left:
                gravityVector = Vector2.left * gravityStrength;
                break;

            case GravityDirection.Right:
                gravityVector = Vector2.right * gravityStrength;
                break;
        }
    }

    public GravityDirection GetCurrentGravityDirection()
    {
        return _currentGravityDirection;
    }
}
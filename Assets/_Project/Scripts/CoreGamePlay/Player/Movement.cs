using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private bool isGrounded;
    
    private void FixedUpdate()
    {
        CheckGround();
    }

    public void Move(float direction)
    {
        Vector2 velocity = _rigidbody2D.velocity;
        velocity = transform.right * direction * _moveSpeed;
        velocity.y = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = velocity;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            Vector2 velocity = _rigidbody2D.velocity;
            velocity.y = 0f;
            _rigidbody2D.velocity = velocity;

            _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void CheckGround()
    {
        if (_groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius);
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
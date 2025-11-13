using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Input _input; 
    
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    
    private void FixedUpdate()
    {
        Move(_input.Direction);


        if (_input.JumpInput)
        {
            Jump();
        }
    }


    public void Move(float direction)
    {
        Vector2 desiredVelocityX = (Vector2)transform.right * direction * _moveSpeed;
        
        Vector2 currentVelocity = _rigidbody2D.velocity;
        
        float currentVelocityY = Vector2.Dot(currentVelocity, transform.up);
        
        Vector2 newVelocity = desiredVelocityX + (Vector2)transform.up * currentVelocityY;

        _rigidbody2D.velocity = newVelocity;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            float currentVelocityX = Vector2.Dot(_rigidbody2D.velocity, transform.right);
            
            _rigidbody2D.velocity = (Vector2)transform.right * currentVelocityX;
            
            _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius);
    }
}
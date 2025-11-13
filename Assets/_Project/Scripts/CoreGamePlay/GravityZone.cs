using UnityEngine;

public class GravityZone : MonoBehaviour
{
    [SerializeField] private GravityDirection _targetGravity;
    [SerializeField] private CustomGravityController _customGravityController;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.RotatePlayer(_targetGravity);
            _customGravityController.SetGravityDirection(_targetGravity);
        }
    }


}
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] FixedJoystick _joystick;
    [SerializeField] Animator _animator;

    [SerializeField] float _moveSpeed;
    
    void Update()
    {
        PlayerMovementWithJoystick();
    }

    void PlayerMovementWithJoystick()
    {
        // For the move
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed * Time.deltaTime, _rigidbody.velocity.y,
            _joystick.Vertical * _moveSpeed * Time.deltaTime);
        
        // For the rotation
        if (_joystick.Horizontal != 0 || _joystick.Horizontal != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }
}

using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] FloatingJoystick _joystick;
    [SerializeField] Animator _animator;

    [SerializeField] float _moveSpeed;

    public static Action collectBricks;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            collectBricks.Invoke();
            other.gameObject.SetActive(false);
        }
    }
}

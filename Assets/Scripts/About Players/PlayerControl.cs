using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] FloatingJoystick _joystick;
    [SerializeField] Animator _animator;

    [SerializeField] float _moveSpeed;

    public event Action collectBricks;
    public event Action winGame;

    AudioSource audioSource;
    public AudioClip collectBrickSound;
    
    public bool playerFalse;

    #region Singleton

    public static PlayerControl Instance;
    void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        
        Instance = this;
    }

    #endregion
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        PlayerMovementWithJoystick();
    }

    void PlayerMovementWithJoystick()
    {
        if (!playerFalse)
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BlueBrick>())
        {
            var brick = other.gameObject.GetComponent<BlueBrick>();
            brick.isTaken = true;
            collectBricks.Invoke();
            audioSource.time = 0.2f;
            audioSource.PlayOneShot(collectBrickSound);
            other.gameObject.SetActive(false);
        }
        
        if (other.gameObject.CompareTag("Finish"))
        {
            _moveSpeed = 0;
            winGame?.Invoke();
        }
    }
}

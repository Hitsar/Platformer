using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private PlayerVfx _playerVfx;
    private Rigidbody2D _rigidbody2D;
    private InputSystem _inputSystem;
    
    private float _moveInput;
    private bool _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerVfx = GetComponentInChildren<PlayerVfx>();
        
        _inputSystem = new InputSystem();
        _inputSystem.Player.Jump.performed += _ => Jump();
        _inputSystem.Player.Enable();
    }

    private void FixedUpdate()
    {
        float direction = _inputSystem.Player.Move.ReadValue<float>();
        _rigidbody2D.velocity = new Vector2(_speed * direction, _rigidbody2D.velocity.y);
        _playerVfx.Flip(direction);
    }

    private void Jump() { if (_isGround) _rigidbody2D.velocity = Vector2.up * _jumpForce; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isGround = true;
        _playerVfx.OnGround();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGround = false;
        _playerVfx.OnAir();
    }

    public void Knockback(Vector2 position)
    {
        Vector2 knockback = ((Vector2)transform.position - position).normalized * 30;
        _rigidbody2D.AddForceAtPosition(knockback * _jumpForce, position);
    }
}

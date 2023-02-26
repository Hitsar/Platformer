using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private PlayerAnimation _playerAnimation;
    private Rigidbody2D _rigidbody2D;
    private float _moveInput;
    private bool _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");

        if (Input.GetButton("Horizontal"))
        {
            _rigidbody2D.velocity = new Vector2(_moveInput * _speed, _rigidbody2D.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && _isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground groun))
        {
            _isGround = true;
            _playerAnimation.OnAir();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground groun))
        {
            _isGround = false;
            _playerAnimation.OnGround();
        }
    }
}

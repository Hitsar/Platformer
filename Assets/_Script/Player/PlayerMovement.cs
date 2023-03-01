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
        DontDestroyOnLoad(gameObject);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isGround = true;
        _playerAnimation.OnGround();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGround = false;
        _playerAnimation.OnAir();
    }

    public void Knockback(Vector2 position)
    {
        Vector2 knockback = ((Vector2)transform.position - position).normalized * 30;
        _rigidbody2D.AddForceAtPosition(knockback * _jumpForce, position);
    }
}

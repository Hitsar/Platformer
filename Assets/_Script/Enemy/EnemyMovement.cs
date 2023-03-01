using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _leftPoint, _rightPoint;

    private Rigidbody2D _rigidbody;
    private Vector2 _velocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _velocity = Vector2.left;
    }

    private void Update()
    {
        _rigidbody.velocity = _velocity * _speed;
        
        if (gameObject.transform.position.x >= _rightPoint.transform.position.x)
        {
            _velocity = Vector2.left;
        }
        if (gameObject.transform.position.x <= _leftPoint.transform.position.x)
        {
            _velocity = Vector2.right;
        }
    }
}

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private PlayerAnimation _playerAnimation;
    private PlayerMovement _playerMovement;
    private LozeMenu _lozeMenu;

    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerMovement = GetComponent<PlayerMovement>();
        _lozeMenu = FindObjectOfType<LozeMenu>(true).GetComponent<LozeMenu>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyMovement enemy))
        {
            TakeDamage();
            _playerMovement.Knockback(enemy.transform.position);
        }
    }

    public void TakeDamage()
    {
        _health--;
        if (_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        _playerAnimation.OnDie();
        _lozeMenu.gameObject.SetActive(true);
    }
}

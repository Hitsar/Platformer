using UnityEngine;

public class EnemyTouch : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;
    private PlayerMovement _playerMovement;
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _playerAnimation = FindObjectOfType<PlayerMovement>().GetComponentInChildren<PlayerAnimation>();
        _playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            _playerHealth = player;
            PlayerTakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            EnemyTakeDamage();
        }
    }

    private void EnemyTakeDamage()
    {
        _playerMovement.Knockback(transform.position);
        _enemyHealth.TakeDamage();
    }

    private void PlayerTakeDamage()
    {
        _playerHealth.TakeDamage();
        _playerMovement.Knockback(transform.position);
        _playerAnimation.OnDamage();
    }
}

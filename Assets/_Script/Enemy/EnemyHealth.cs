using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private EnemyVfx _enemyVfx;

    private void Start()
    {
        _enemyVfx = GetComponent<EnemyVfx>();
    }

    public void TakeDamage()
    {
        _health--;
        _enemyVfx.OnDamage();

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _enemyVfx.OnDie();
    }
}

using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private EnemyAnimation _enemyAnimation;

    private void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    public void TakeDamage()
    {
        _health--;
        _enemyAnimation.OnDamage();

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _enemyAnimation.OnDie();
    }
}

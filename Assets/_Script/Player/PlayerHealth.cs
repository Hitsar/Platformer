using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private PlayerAnimation _playerAnimation;
    private LozeMenu _lozeMenu;

    private void Start()
    {
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
        _lozeMenu = FindObjectOfType<LozeMenu>(true).GetComponent<LozeMenu>();
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

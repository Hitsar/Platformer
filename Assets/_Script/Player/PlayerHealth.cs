using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private PlayerVfx _playerVfx;
    private LozeMenu _lozeMenu;

    private void Start()
    {
        _playerVfx = GetComponentInChildren<PlayerVfx>();
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
        _playerVfx.OnDie();
        _lozeMenu.gameObject.SetActive(true);
    }
}

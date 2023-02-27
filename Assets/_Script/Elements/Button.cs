using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject _disable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _disable.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _disable.SetActive(true);
    }
}

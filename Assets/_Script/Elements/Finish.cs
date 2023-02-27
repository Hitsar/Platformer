using DG.Tweening;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private FinishMenu _finishMenu;

    private void Start()
    {
        _finishMenu = FindObjectOfType<FinishMenu>(true).GetComponent<FinishMenu>();
        transform.DOScale(new Vector2(0.63f, 0.63f), 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            _finishMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

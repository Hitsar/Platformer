using DG.Tweening;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public void OnDamage()
    {
        _spriteRenderer.DOFade(0.3f, 0.3f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            _spriteRenderer.DOFade(1f, 0.3f).SetEase(Ease.OutSine);
        });
    }

    public void OnDie()
    {
        transform.DOScale(new Vector2(0.06f, 0.06f), 0.5f).SetEase(Ease.InCubic).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}

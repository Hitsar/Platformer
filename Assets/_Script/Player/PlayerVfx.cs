using DG.Tweening;
using UnityEngine;

public class PlayerVfx : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;

    public void TouchBox()
    {
        _playerSpriteRenderer.DOColor(Color.red, 0.3f).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public void ExitBox()
    {
        _playerSpriteRenderer.DOColor(Color.white, 0.3f).SetEase(Ease.OutSine);
    }

    public void OnAir()
    {
        transform.DOLocalRotate(Vector3.zero, 0);
        transform.DOLocalRotate(Vector3.forward * 90, 0.3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void OnGround()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = Mathf.Round(rotation.z / 90) * 90;
        transform.DOLocalRotate(rotation, 0.2f).SetEase(Ease.OutCubic);
    }

    public void OnDamage() => _playerSpriteRenderer.DOColor(Color.red, 0.3f).SetEase(Ease.OutSine).SetLoops(1, LoopType.Incremental);

    public void OnDie()
    {
        transform.DOScale(new Vector2(0.1f, 0.1f), 0.3f).SetEase(Ease.InCubic).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Flip(float direction) { if (direction == 0) return; transform.localScale *= direction > 0 ? -1 : 1; }
}

using DG.Tweening;
using UnityEditorInternal;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
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
        transform.DOLocalRotate(new Vector3(0, 0, 90), 0.3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void OnGround()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = Mathf.Round(rotation.z / 90) * 90;
        transform.DOLocalRotate(rotation, 0.4f).SetEase(Ease.OutCubic);
    }

    public void OnDamage()
    {
        _playerSpriteRenderer.DOColor(Color.red, 0.3f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            _playerSpriteRenderer.DOColor(Color.white, 0.3f).SetEase(Ease.OutSine);
        });
    }

    public void OnDie()
    {
        transform.DOScale(new Vector2(0.1f, 0.1f), 0.3f).SetEase(Ease.InCubic).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}

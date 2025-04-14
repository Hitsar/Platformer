using UnityEngine;

public class BigBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerVfx player))
        {
            player.TouchBox();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerVfx player))
        {
            player.ExitBox();
        }
    }
}
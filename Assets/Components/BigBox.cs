using UnityEngine;

public class BigBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerAnimation player))
        {
            player.TouchBox();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerAnimation player))
        {
            player.ExitBox();
        }
    }
}
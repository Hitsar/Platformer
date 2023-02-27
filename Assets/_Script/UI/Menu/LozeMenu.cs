using UnityEngine;
using UnityEngine.SceneManagement;

public class LozeMenu : MonoBehaviour
{
    private PlayerMovement _player;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene(0);
    }
}

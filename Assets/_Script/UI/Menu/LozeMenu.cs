using UnityEngine;
using UnityEngine.SceneManagement;

public class LozeMenu : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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

using UnityEngine.SceneManagement;

public class FinishMenu : LozeMenu
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
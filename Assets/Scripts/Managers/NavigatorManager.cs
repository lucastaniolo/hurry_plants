using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigatorManager : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

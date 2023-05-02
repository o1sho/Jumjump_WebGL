using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayGame1()
    {
        SceneManager.LoadScene("Game 1");
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene("Game 2");
    }

    public void BackMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
}

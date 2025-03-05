using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Quit()
    {
        print("quitting game");
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("IntroCutscene");
    }

}

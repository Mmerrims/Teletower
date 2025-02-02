using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Quit");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Amber Scene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Amber Menu");
    }
}

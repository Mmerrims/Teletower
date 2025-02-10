using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuObjects;
    [SerializeField] private GameObject ControlsObjects;

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

    public void ShowControls()
    {
        MainMenuObjects.SetActive(false);
        ControlsObjects.SetActive(true);
    }

    public void HideControls()
    {
        MainMenuObjects.SetActive(true);
        ControlsObjects.SetActive(false);
    }
}

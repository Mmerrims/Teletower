using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuObjects;
    [SerializeField] private GameObject ControlsObjects;
    public PlayerInput MPI;
    private InputAction back;

    private void Awake()
    {
        MPI = GetComponent<PlayerInput>();
        back = MPI.currentActionMap.FindAction("Back");
        MPI.currentActionMap.Enable();
        back.started += Back;
    }

    public void OnDisable()
    {
        MPI.currentActionMap.Disable();
        back.started -= Back;
    }

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

    public void Back(InputAction.CallbackContext obj)
    {
        MainMenuObjects.SetActive(true);
        ControlsObjects.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuObjects;
    [SerializeField] private GameObject ControlsObjects;
    [SerializeField] private GameObject CreditsObject;
    public PlayerInput MPI;
    private InputAction back;

    private void Awake()
    {
        MPI = GetComponent<PlayerInput>();
        if (MPI != null)
        {
            back = MPI.currentActionMap.FindAction("Back");
            MPI.currentActionMap.Enable();
            back.started += Back;
        }
    }

    public void OnDisable()
    {
        if (MPI != null)
        {
            MPI.currentActionMap.Disable();
            back.started -= Back;
        }
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
        CreditsObject.SetActive(false);
    }

    public void HideControls()
    {
        MainMenuObjects.SetActive(true);
        ControlsObjects.SetActive(false);
        CreditsObject.SetActive(false);
    }

    public void Back(InputAction.CallbackContext obj)
    {
        MainMenuObjects.SetActive(true);
        ControlsObjects.SetActive(false);
        CreditsObject.SetActive(false);
    }

    public void ShowCredits()
    {
        MainMenuObjects.SetActive(false);
        ControlsObjects.SetActive(false);
        CreditsObject.SetActive(true);
    }

    public void HideCredits()
    {
        MainMenuObjects.SetActive(true);
        ControlsObjects.SetActive(false);
        CreditsObject.SetActive(false);
    }
}

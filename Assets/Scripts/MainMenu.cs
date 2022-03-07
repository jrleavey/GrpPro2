using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _pausemenu;
    public GameObject _loseMenu;
    public GameObject _winMenu;
    public GameObject pCamera;
    public bool _isPauseMenuOpen = false;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && _isPauseMenuOpen == false)
        {
            pCamera.GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isPaused();
        }
        else if ((Input.GetKeyDown(KeyCode.P) && _isPauseMenuOpen == true))
        {
            pCamera.GetComponent<MouseLook>().enabled = true;
            isNotPaused();
        }
    }
    public void ExitButton() { 
        Application.Quit();
    }

    public void StartButton() 
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }

    public void AboutButton()
    {
        SceneManager.LoadScene("About");
    }

    public void Main()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void isPaused()
    {
        _isPauseMenuOpen = true;
        _pausemenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void isNotPaused()
    {
        Time.timeScale = 1;
        _isPauseMenuOpen = false;
        _pausemenu.SetActive(false);
        pCamera.GetComponent<MouseLook>().enabled = true;
    }
}
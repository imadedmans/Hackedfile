using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject[] defaultUIElements;
    public GameObject newGameMenu;
    public GameObject settingsMenu;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //For testing only, delete it once in release
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void NewGame()
    {
        for(int i = 0; i < defaultUIElements.Length; i++)
        {
            defaultUIElements[i].SetActive(false);
        }

        newGameMenu.SetActive(true);
    }

    public void LeaveNewGame()
    {
        for(int i = 0; i < defaultUIElements.Length; i++)
        {
            defaultUIElements[i].SetActive(true);
        }

        newGameMenu.SetActive(false);
    }

    public void NormalModeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SpecialModeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {

    }

    public void Settings()
    {
        for(int i = 0; i < defaultUIElements.Length; i++)
        {
            defaultUIElements[i].SetActive(false);
        }

        settingsMenu.SetActive(true);
    }

    public void LeaveSettings()
    {
        for(int i = 0; i < defaultUIElements.Length; i++)
        {
            defaultUIElements[i].SetActive(true);
        }

        settingsMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
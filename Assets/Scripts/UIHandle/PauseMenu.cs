using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject buttonA;
    public GameObject FailText;
    public GameObject CloseButton;
    public GameObject error;
    public GameObject RestartCheck;
    public GameObject Player2Check;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        FailText.SetActive(false);
        RestartCheck.SetActive(false);
        Player2Check.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        RestartCheck.SetActive(true);
    }

    public void ActualRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Options()
    {
        FailText.SetActive(true);
    }

    public void Player2()
    {
        Player2Check.SetActive(true);
    }

    public void PlayerClose()
    {
        Player2Check.SetActive(false);
    }

    public void Press()
    {
        error.SetActive(false);
    }

    public void Press2()
    {
        RestartCheck.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Player 1 has quited Hackerfile! Shit!");
    }
}

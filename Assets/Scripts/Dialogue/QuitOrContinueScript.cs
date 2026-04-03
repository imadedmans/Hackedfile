using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitOrContinueScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            MoveOn();
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    void MoveOn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Oh no.");
    }

    void ExitGame()
    {
        Application.Quit();
        Debug.Log("Player1 has exited the game");
    }
}

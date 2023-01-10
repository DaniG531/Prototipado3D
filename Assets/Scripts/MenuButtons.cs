using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public bool PauseOpen = false;

    public void GoToPlayScene()
    {
        GameManager.Instance.RequestChangeState(GameState.kGAME);
    }

    public void GoToLevelD()
    {
        GameManager.Instance.RequestChangeState(GameState.kLEVELD);
    }

    public void GoToLevel1()
    {
        GameManager.Instance.RequestChangeState(GameState.kLEVEL1);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UIManager.Instance.SwitchPause(false);
        UIManager.Instance.CloseMenu(2);
        UIManager.Instance.CloseMenu(3);
    }

    public void GoToMainMenu()
    {
        GameManager.Instance.RequestChangeState(GameState.kMAIN_MENU);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }

    public void Update()
    {
    if(GameManager.Instance.CurrentState != GameState.kMAIN_MENU && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOpen = !PauseOpen;
            UIManager.Instance.SwitchPause(PauseOpen);
        }

    }
}

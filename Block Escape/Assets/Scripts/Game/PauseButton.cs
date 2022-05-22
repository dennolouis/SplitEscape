using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseButton : MonoBehaviour
{
    public bool GameIsPaused = false;

    //public GameObject pauseButtonUI;
    public GameObject resumeButtonUI;
    public GameObject quitbutton;



    private void Start()
    {
        gameObject.SetActive(true);
        resumeButtonUI.SetActive(false);
        quitbutton.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        resumeButtonUI.SetActive(false);
        quitbutton.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        resumeButtonUI.SetActive(true);
        quitbutton.SetActive(true);
        HidePause();
    }

    public void togglePauseState(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void HidePause()
    {
        gameObject.SetActive(false);
        
    }
    public void ShowPause()
    {
        gameObject.SetActive(true);

    }

    public void test()
    {
        print("test");
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuScript : MonoBehaviour
{
    
    public static bool isPaused = false;
    public GameObject PauseMenu;
    public GameObject PauseText;
    //private int stopInsta;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && isPaused)
        {
            Application.Quit();
        }
        if (Input.GetKeyDown("escape")/* && stopInsta <=0*/)
        {
            if (isPaused == true)
            {
                //Pause();
                Resume();
            }
            else// if (stopInstaResume <= 0)
            {
                //Resume();
                Pause();
            }
        }
        //stopInsta--;
              
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        PauseText.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        //stopInsta = 50;
    }

    private void Resume()
    {
        PauseMenu.SetActive(false);
        PauseText.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        //stopInsta = 50;
    }
}

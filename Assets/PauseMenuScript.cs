using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private InputActionReference shootInput;

    public static bool isPaused = false;
    public GameObject PauseMenu;
    private int stopInstaQuit;
    // Update is called once per frame
    void Update()
    {
        if (isPaused == true)
        {
            if(Input.GetKey("escape") && stopInstaQuit <= 0)
            {
                    Application.Quit();
            }
            else if (shootInput.action.IsPressed())
            {
                Resume();
            }
        }

        else if (Input.GetKey("escape"))
        {
            Pause();
            stopInstaQuit = 26;
        }
        stopInstaQuit--;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    private void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}

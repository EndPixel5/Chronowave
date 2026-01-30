using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuScript : MonoBehaviour
{
    /*[SerializeField]
    private InputActionReference shootInput;*/

    public static bool isPaused = false;
    public GameObject PauseMenu;
    private int stopInstaQuit;
    // Update is called once per frame
    void Update()
    {
        if (isPaused == true)
        {
            if (Input.GetKey("escape") && stopInstaQuit <= 0)
            {
                Application.Quit();
            }
            else if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                TDResume();
            }
        }
        else if (Input.GetKey("escape"))
        {
            TDPause();
            stopInstaQuit = 26;
        }
        stopInstaQuit--;
    }

    void TDPause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    private void TDResume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScript : MonoBehaviour
{
    private bool begin = false;
    public titleAudio audioManager;
    private int timer = 100;

    
    void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0 && begin == false)
        {
            begin = true;
            //audioManager.PlaySound(audioManager.sword);

            //Debug.Log("shmack");
        }

    }
    private void FixedUpdate()
    {
        if (begin)
        {
            audioManager.PlaySound(audioManager.start);
            if (timer > 0) { timer--; } 
            else 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
    }
}

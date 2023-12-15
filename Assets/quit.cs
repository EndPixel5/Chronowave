using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class quit : MonoBehaviour
{
    // Start is called before the first frame update
    //private bool quit = false;
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        
    }
   /* private void FixedUpdate()
    {
        if (quit)
        {
            //timer++;
            //if (timer >= 35)
            //{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            //}
        }
    }*/
}

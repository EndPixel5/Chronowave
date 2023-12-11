using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScript : MonoBehaviour
{
    private bool begin = false;
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
            //timer++;
            //if (timer >= 35)
            //{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            //}
        }
    }
}

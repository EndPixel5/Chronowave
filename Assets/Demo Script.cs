using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoScript : MonoBehaviour
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
            SceneManager.LoadScene(0);
        }
    }
}

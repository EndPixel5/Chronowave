using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoScript : MonoBehaviour
{
    private bool begin = false;
    private int allowContinue = 50;

    private void Start()
    {
        if (GameObject.Find("scenetrack"))
        {
            Destroy(GameObject.Find("scenetrack"));
        }
    }
    void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0 && begin == false && allowContinue>0)
        {
            begin = true;
            //audioManager.PlaySound(audioManager.sword);

            //Debug.Log("shmack");
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        allowContinue--;
    }
    private void FixedUpdate()
    {
        if (begin)
        {
            SceneManager.LoadScene(0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DemoScript : MonoBehaviour
{
    //[SerializeField] bool begin = false;

    [SerializeField] InputActionReference shootInput;
    [SerializeField] int allowContinue = 70;

    private void Start()
    {
        if (GameObject.Find("scenetrack"))
        {
            Destroy(GameObject.Find("scenetrack"));
        }
    }
    void Update()
    {
        if (shootInput.action.IsPressed() /*&& begin == false */&& allowContinue<0)
        {
            SceneManager.LoadScene(0);

            //begin = true;
            //audioManager.PlaySound(audioManager.sword);

            //Debug.Log("shmack");
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        allowContinue--;
    }
    /*private void FixedUpdate()
    {
        if (begin)
        {
            SceneManager.LoadScene(0);
        }
    }*/
}

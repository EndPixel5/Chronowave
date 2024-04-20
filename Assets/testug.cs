using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class testug : MonoBehaviour
{
    public int tracked;
   
   private int respawnTimer = -1;
    
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
       
    }

    // Update is called once per frame

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene bul, LoadSceneMode mode)
    {


        if (GameObject.Find("combatlelvl"))
        {
            tracked = SceneManager.GetActiveScene().buildIndex;
        }
    else if (GameObject.Find("gameOv"))
        {
             respawnTimer = 120;
        }
    }
    private void FixedUpdate()
    {
    if (respawnTimer > 0) { respawnTimer--; }
        else if (respawnTimer == 0)
        {
            respawnTimer = -1;
            SceneManager.LoadScene(tracked);
        }
    
}

}

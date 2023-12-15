using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimeMachine : Interactable
{
   
    
    public GameObject player;
    public int partsReq;
    public int partsHeld;
    public int done = 0;
    public GameObject text;
    public Vector3 textVec;

   

    public override void Interact()
    {
        if (partsHeld >= partsReq)
        {
            textVec.x = player.transform.position.x;
            textVec.z = player.transform.position.z;
            textVec.y = player.transform.position.y - 4;
            Instantiate(text, textVec, player.transform.rotation);
            partsHeld = 0;
            done++;
        }
       
    }

    

    private void Update()
    {
        partsHeld = player.GetComponent<Player_Interaction>().parts;
        if (done > 0) {
            SceneManager.LoadScene(3);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcdialogu : Interactable
{
   
    public GameObject text;
    public Vector3 textVec;
    public GameObject player;

    

    public override void Interact()
    {
       
           
        
    }

   

    void Start()
    {
        textVec.x = player.transform.position.x;
        textVec.z = player.transform.position.z;
        textVec.y = player.transform.position.y - 5;
        Instantiate(text, textVec, player.transform.rotation);
        player.GetComponent<TDplayer_controller>().canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (player.GetComponent<TDplayer_controller>().canMove == false && text.GetComponent<textbox>().count == text.GetComponent<textbox>().text.Length)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<TDplayer_controller>().canMove = true;
            }
        }
    }
}

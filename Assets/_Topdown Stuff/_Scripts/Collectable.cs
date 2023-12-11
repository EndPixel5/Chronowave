using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Collectable : Interactable
{
    
    public GameObject player;

   
    public override void Interact()
    {
        if (gameObject.CompareTag("key")) 
        {
            player.GetComponent<Player_Interaction>().keys++;
        }
        if (gameObject.CompareTag("part"))
        {
            player.GetComponent<Player_Interaction>().parts++;
        }

        Destroy(gameObject);
    }

   
}

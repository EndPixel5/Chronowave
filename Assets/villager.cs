using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villager : Interactable
{


    public GameObject player;
    public GameObject text;
    public Vector3 textVec;


    public override void Interact()
    {
        textVec.x = player.transform.position.x;
        textVec.z = player.transform.position.z;
        textVec.y = player.transform.position.y - 4;
        Instantiate(text, textVec, player.transform.rotation);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedOpenable : Interactable
{
    public Sprite open;
    public Sprite closed;
    private SpriteRenderer sr;
    private bool isOpen;
    public GameObject player;
    public int keysReq;
    public int keysHeld;
    public GameObject ah;
    public GameObject yessir;
    public GameObject text;
    public Vector3 textVec;
    public GameObject e;

    public override void Interact()
    {
        if (keysHeld == keysReq)
        {
            if (!isOpen)
            {
                sr.sprite = open;
                isOpen = true;
                ah.GetComponent<Collectable>().player = player;
                Instantiate(ah, yessir.transform.position, gameObject.transform.rotation);
                player.GetComponent<Player_Interaction>().keys = 0;
            }
        }
        else if (keysHeld != keysReq && sr.sprite == closed) 
        {
            textVec.x = player.transform.position.x;
            textVec.z = player.transform.position.z;
            textVec.y = player.transform.position.y - 4;
            Instantiate(text, textVec, player.transform.rotation);
            player.GetComponent<TDplayer_controller>().canMove = false;
        }
    }

    private void Update()
    {
        keysHeld = player.GetComponent<Player_Interaction>().keys;
        /*if (player.GetComponent<TDplayer_controller>().canMove == false) 
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                player.GetComponent<TDplayer_controller>().canMove = true;
            }
        }*/
    }
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        isOpen = false;
        sr.sprite = closed;
        sr.sortingLayerID = default;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
 
    public GameObject e;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text NPCname;
    public string yer;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool isPlayerClose;
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
            if (Input.GetKeyDown(KeyCode.E) && isPlayerClose)
            {
                if (dialoguePanel.activeInHierarchy)
                {
                    ZeroText();
                }
                else
                {
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing());
                }

            }
        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

    }

    public void NextLine()
    {

        contButton.SetActive(false);
        if (index < dialogue.Length)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = false;
            ZeroText();
        }
    }
}

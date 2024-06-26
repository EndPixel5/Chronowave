using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Text NPCname;
    public string yer;
    public string[] dialogue;
    private int index;
    private char[] hugh;
    //public Sprite image;

    public GameObject contButton;
    public float wordSpeed;
    public bool isPlayerClose;

    // Update is called once per frame
    private void Start()
    {
        isPlayerClose = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerClose) 
        {
            if (dialoguePanel.activeInHierarchy)
            {
                //ZeroText();
                dialogueText.text = null;
            }
            else
            {
                NPCname.text = yer;
                dialoguePanel.SetActive(true);
                dialogueText.text = null;
                StartCoroutine(Typing());
            }

        }

        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                NextLine();
            }
        }

        
        
    }

    public void NextLine()
    {

        contButton.SetActive(false);
        if(index < dialogue.Length)
        {
            index++;
            if (index >= dialogue.Length)
            {
                ZeroText();
            }
            else 
            {
                dialogueText.text = "";
                StartCoroutine(Typing());
            }
        }
        
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        StopCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        hugh = dialogue[index].ToCharArray();
        foreach (char letter in hugh)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
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
            hugh = new char[0];
            
        }
    }
}

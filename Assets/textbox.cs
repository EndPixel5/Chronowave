using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textbox : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] text = new Sprite[10];
    public GameObject player;
    public int count;
   
    private void Start()
    {
        sr.sprite = text[0];
        count = 1;
        
        
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && count < text.Length)
        {
            if (text[count] != null) 
            {
                
                sr.sprite = text[(int)count];
                count++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && count == text.Length) 
        {
            player.GetComponent<TDplayer_controller>().canMove = true;
            Destroy(gameObject);
        }
    }
}

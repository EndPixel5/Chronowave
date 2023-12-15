using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textbox : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] text = new Sprite[10];
    public GameObject player;
    public int count;
    private int textTimer;
    private bool clicked = false;
   
    private void Start()
    {
        sr.sprite = text[0];
        count = 1;
        
        
        
    }

    private void Update()
    {
        if(Input.GetAxis("Fire1") == 1 && clicked == false)
        {
            clicked = true;
            textTimer = 15;
        }
    }

    void FixedUpdate()
    {
        if (textTimer > 0){ textTimer--; }
        else if (clicked && count < text.Length)
        {
            clicked= false;
            if (text[count] != null) 
            {
                
                sr.sprite = text[(int)count];
                count++;
            }
        }
        else if (Input.GetAxis("Fire1") == 1 && count == text.Length) 
        {
           // player.GetComponent<TDplayer_controller>().canMove = true;
            Destroy(gameObject);
        }

    }
}

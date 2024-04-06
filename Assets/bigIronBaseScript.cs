using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class bigIronBaseScript : MonoBehaviour
{

    public GameObject shot;
    public GameObject spot;
    public float speed = -5;
    public Rigidbody2D body;
    public float attackTimer = -1;
    public float attackChoice = 0;
   // private bool allowPrevious = false;
    private float prev = -100;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (attackTimer == 0)
        {
            attackChoice = Random.Range(0, 2);
            attackTimer = -1;
        }
        else if (attackTimer > 0)
        {
            attackTimer--;

        }
        else
        {
            if (attackChoice == 0)
            {
                if (prev == attackChoice)
                {
                    attackTimer = 0;
                }
                else { 
                    prev = attackChoice;
                    steam();
                }
            }
            else if (attackChoice == 1)
            {
                prev = attackChoice;
                charge();
            }
        }
    }

    private void steam()
    {
        Instantiate(shot, spot.transform.position, spot.transform.rotation);
        attackTimer = 10;
       // allowPrevious = false;
    }

    private void charge()
    {
        body.velocity = transform.right * speed;

        //allowPrevious = true;       
    }
}

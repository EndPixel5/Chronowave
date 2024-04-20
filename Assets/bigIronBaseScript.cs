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
    public bool justBeganCharge = false;
   // private bool allowPrevious = false;
    private float prev = -100;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Physics2D.IgnoreLayerCollision(1, 4);
        if (attackTimer == 0)
        {
            attackChoice = Random.Range(0, 2);
            attackTimer = -1;
        }
        else if (attackTimer > 0)
        {
            attackTimer--;

        }
        else if (attackTimer == -1)
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
        attackTimer = 30;
       // allowPrevious = false;
    }

    private void charge()
    {
        body.velocity = transform.right * speed;
        justBeganCharge = true;
        attackTimer = -2;
        //allowPrevious = true;       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WAWAWAWA")
        {
            if (justBeganCharge == true) { justBeganCharge = false; }
            else
            {
                body.velocity *= 0;
                transform.Rotate(0, 180, 0);
                attackTimer = 45;
            }
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
                Physics.IgnoreCollision(GameObject.collision, collision);
        }        
    }*/
}

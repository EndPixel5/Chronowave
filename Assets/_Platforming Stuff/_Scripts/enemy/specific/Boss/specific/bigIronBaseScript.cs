using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class bigIronBaseScript : MonoBehaviour
{

    public GameObject shot;
    public GameObject spot;
    public float speed = -5;
    public Rigidbody2D body;
    public float attackTimer = 10;
    public float attackChoice = 0;
    public bool justBeganCharge = false;
    public float knockbackForce;
    // private bool allowPrevious = false;
    private float prev = -100;
    private AudioSource blastSound;

    // Start is called before the first frame update
    void Start()
    {
        blastSound = GetComponent<AudioSource>();

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
        blastSound.Play();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.transform.position.x >= transform.position.x)
            {
                collision.gameObject.GetComponent<PlayerMovement>().knockRight = false;
                //knockRight = true;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerMovement>().knockRight = true;
                // knockRight = false;

            }
            collision.gameObject.GetComponent<PlayerMovement>().kbTimer = collision.gameObject.GetComponent<PlayerMovement>().kbTotalTime;
            collision.gameObject.GetComponent<PlayerMovement>().knockback = knockbackForce;
            collision.gameObject.GetComponent<PlayerHealth>().health -= 1;
            body.velocity = transform.right * speed;


        }
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

    /*private void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
}

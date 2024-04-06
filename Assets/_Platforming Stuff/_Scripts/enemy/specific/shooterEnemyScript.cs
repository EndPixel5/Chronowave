using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterEnemyScript : MonoBehaviour
{
    public float speed = 2;
    public float knockbackForce = 3;
    private GameObject player;
    private float start;
    public float maxDist;
   /* private float leftBound;
    private float rightBound;*/
    public Rigidbody2D body;


    private void Start()
    {
        start = gameObject.transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x > gameObject.transform.position.x) { transform.Rotate(0, 180, 0); }
        body.velocity = transform.right * speed;
       /* leftBound = start - maxDist;
        rightBound = start + maxDist;*/

    }
    void FixedUpdate()
    {
        Movement();
       // AttackCode();
      //  if (health <= 0) { Destroy(gameObject); }

    }

    void Movement()
    {
        /*if (gameObject.transform.position.x <= leftBound)
        {
           if(body.velocity.x <= 0)
            {

            }
                
        }
        if (gameObject.transform.position.x >= rightBound)
        {
            transform.Rotate(0, 180, 0);
            body.velocity = transform.right * speed;
        }*/
        if(gameObject.transform.position.x <= start - maxDist)
        {
            if (body.velocity.x <= 0)
            {
                body.velocity = transform.right * speed * -1;
                transform.Rotate(0, 180, 0);
            }
        }
        if(gameObject.transform.position.x >= start + maxDist)
        {
            if (body.velocity.x >= 0)
            {
                transform.Rotate(0, 180, 0);
                body.velocity = transform.right * speed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.transform.position.x >= transform.position.x)
            {
                collision.gameObject.GetComponent<PlayerMovement>().knockRight = false;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerMovement>().knockRight = true;
            }
            collision.gameObject.GetComponent<PlayerMovement>().kbTimer = collision.gameObject.GetComponent<PlayerMovement>().kbTotalTime;
            collision.gameObject.GetComponent<PlayerMovement>().knockback = knockbackForce;
            //collision.gameObject.GetComponent<PlayerHealth>().health -= damage;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        body.velocity = transform.right * speed;
    }

    /* void AttackCode()
     {
         if (attackAgain)
         {
             if (secondAttackTimer > 0) { secondAttackTimer--; }
             else
             {
                 Instantiate(shot, new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y +.43), gameObject.transform.position.x), gameObject.transform.rotation);
                 secondAttackTimer = 25;
                 attackAgain = false;
             }
         }
         else if (attackTimer > 0)
         {
             attackTimer--;

         }
         else {
             Instantiate(shot, new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y + .43), gameObject.transform.position.x), gameObject.transform.rotation);
             attackTimer = 85;
             attackAgain = (Random.value > 0.5f);
         }
     }*/
}

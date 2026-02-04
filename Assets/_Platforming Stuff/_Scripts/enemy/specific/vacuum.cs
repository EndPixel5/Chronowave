using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class vacuum : MonoBehaviour
{
    public float speed = 4;
    public float damage;
    public float knockbackForce;
    public Rigidbody2D body;
    private GameObject player;
    private float kbTimer;
    private bool knockRight;


    //public PlayerMovement pllayeerMovement;

    //public float timeAlive = 1200;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Vector3 scale = transform.localScale;
        if (player.transform.position.x > gameObject.transform.position.x) { transform.Rotate(0, 180, 0); }//scale.x = Mathf.Abs(scale.x) * -1; }
        //transform.localScale = scale;
        body.velocity = transform.right * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (kbTimer <= 0)
        {
            body.velocity = transform.right * speed;
        }
        else
        {
            body.velocity = transform.right * 0;
            if (!knockRight)
            {
                
                body.velocity = new Vector2(-1, 0);
            }
            else
            {
                
                body.velocity = new Vector2(1, 0);
            }
            kbTimer--;
        }*/
        /*if(body.velocity.x < transform.right * speed)
        {
            body.velocity = transform.right * speed;
        }*/
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_Attack")
        {
            health--;
            if (health == 0) { Destroy(gameObject); }
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" /*|| collision.gameObject.tag == "Wall"*/)// || collision.gameObject.tag == "Platform")
        {

            //body.velocity = transform.right * speed * -1;
            //body.velocity = body.velocity * 1.5;
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
                collision.gameObject.GetComponent<PlayerHealth>().health -= damage;

            }
            transform.Rotate(0, 180, 0);
            body.velocity = transform.right * speed;
            //kbTimer = 2;

        }
        if (collision.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }
       /* if (collision.gameObject.tag == "Wall" )//|| collision.gameObject.tag == "Platform")
        {
            transform.Rotate(0, 180, 0);
            body.velocity = transform.right * speed;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WAWAWAWA" || collision.gameObject.tag == "part")
        {
            transform.Rotate(0, 180, 0);
            body.velocity = transform.right * speed;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            body.velocity = transform.right * speed * -1;
        }
    }*/
}

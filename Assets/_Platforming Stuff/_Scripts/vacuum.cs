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
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {

            //body.velocity = transform.right * speed * -1;
            //body.velocity = body.velocity * 1.5;
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
                collision.gameObject.GetComponent<PlayerHealth>().health -= damage;

            }
            transform.Rotate(0, 180, 0);
            body.velocity = transform.right * speed;


        }
        if (collision.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
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

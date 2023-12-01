using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ovenman : MonoBehaviour
{
    public float speed = 1;
    public float maxDist;
    public float knockbackForce;
    public Rigidbody2D body;
    

    private GameObject player;
    private float start;
    

    private void Start()
    {
        start = gameObject.transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.x > gameObject.transform.position.x) { transform.Rotate(0, 180, 0); }
        body.velocity = transform.right * speed;


    }
    void FixedUpdate()
    {
        Movement();
        // AttackCode();
        //  if (health <= 0) { Destroy(gameObject); }

    }

    void Movement()
    {
        if (gameObject.transform.position.x < start - maxDist)
        {
            body.velocity = transform.right * speed * 1;
            //transform.Rotate(0, 180, 0);
        }
        if (gameObject.transform.position.x > start + maxDist)
        {
           // transform.Rotate(0, 180, 0);
            body.velocity = transform.right * speed * -1;
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

}

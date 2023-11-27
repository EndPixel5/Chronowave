using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ovenman : MonoBehaviour
{
    public float speed = 1;
    //  public float health = 2;

    public Rigidbody2D body;
    private GameObject player;
    private float start;
    public float maxDist;

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
}

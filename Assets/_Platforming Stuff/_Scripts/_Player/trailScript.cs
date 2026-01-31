using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailScript : MonoBehaviour
{

    // Update is called once per frame
    //public float damage = 1;
    public float speed = 1;
    public Rigidbody2D body;
   // public float timeAlive;// = 1200;
    void Start()
    {
        body.velocity = Vector3.zero;
        body.velocity = transform.right * speed;
    }

    /*void FixedUpdate()
    {
        if(timeAlive <= 0) { Destroy(gameObject); }
        timeAlive--;
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "part")
        {
            
            Destroy(gameObject);
        }
        
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            timeAlive -= 50;
        }
    }*/
}

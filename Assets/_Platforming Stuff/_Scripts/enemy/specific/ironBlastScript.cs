using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ironBlastScript : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D body;
    public float damage;
    public float timeAlive = 200;
    void Start()
    {
        body.velocity = transform.right * speed * -1;
    }
    void FixedUpdate()
    {
        if (timeAlive <= 0) { Destroy(gameObject); }
        timeAlive--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }*/
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
        else if (collision.gameObject.tag != "Player_Attack")
        {
            timeAlive -= 50;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}

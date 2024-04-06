using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coalAttack : MonoBehaviour
{
    public float speed = 7;
    public float launch = 7;
    public Rigidbody2D body;
    public float damage;
    public float timeAlive = 1200;
    void Start()
    {
        body.velocity = transform.right * speed;
        body.AddForce(new Vector2(0, launch), ForceMode2D.Impulse);
        //body.velocity = transform.right * speed;
    }
    void FixedUpdate()
    {
        body.velocity = new Vector2(body.velocity.x, body.velocity.y);
        if (timeAlive == 0) { Destroy(gameObject); }
        timeAlive--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }
    }
}

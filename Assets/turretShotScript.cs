using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShotScript : MonoBehaviour
{
    public float speed = 4;
    public Rigidbody2D body;
    public float damage;
    public float timeAlive = 1200;
    void Start()
    {
        body.velocity = transform.right * speed;
    }
    void Update()
    {
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
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAttackController : MonoBehaviour
{

    // Update is called once per frame
    public float damage = 1;
    public float speed = 7;
    public Rigidbody2D body;
    public float timeAlive = 1200;
    void Start()
    {
        body.velocity = transform.right * speed;
    }

    void Update()
    {
        if(timeAlive == 0) { Destroy(gameObject); }
        timeAlive--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= damage;

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy_Attack")
        {
            Destroy(gameObject);
        }
    }
}

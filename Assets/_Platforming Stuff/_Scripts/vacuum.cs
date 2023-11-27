using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class vacuum : MonoBehaviour
{
    public float speed = 4;
    //public float health = 4;
    public float damage;
    public Rigidbody2D body;
    private GameObject player;


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
            body.velocity = transform.right * speed * -1;
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
                Destroy(gameObject);
            }
            
        }
        if (collision.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }
    }
}

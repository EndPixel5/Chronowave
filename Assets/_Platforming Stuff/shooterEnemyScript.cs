using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2;
  //  public float health = 2;
    public GameObject shot;
    private float attackTimer = 85;
    private bool attackAgain = false;
    private float secondAttackTimer = 25; //(have 25 if true);
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
        AttackCode();
      //  if (health <= 0) { Destroy(gameObject); }

    }

    void Movement()
    {
        if(gameObject.transform.position.x < start - maxDist)
        {
            body.velocity = transform.right * speed * -1;
            transform.Rotate(0, 180, 0);
        }
        if(gameObject.transform.position.x > start + maxDist)
        {
            transform.Rotate(0, 180, 0);
            body.velocity = transform.right * speed;
        }
    }

    void AttackCode()
    {
        if (attackAgain)
        {
            if (secondAttackTimer > 0) { secondAttackTimer--; }
            else
            {
                Instantiate(shot, new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y +.43), gameObject.transform.position.x), gameObject.transform.rotation);
                secondAttackTimer = 25;
                attackAgain = false;
            }
        }
        else if (attackTimer > 0)
        {
            attackTimer--;
            
        }
        else {
            Instantiate(shot, new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y + .43), gameObject.transform.position.x), gameObject.transform.rotation);
            attackTimer = 85;
            attackAgain = (Random.value > 0.5f);
        }
    }
}

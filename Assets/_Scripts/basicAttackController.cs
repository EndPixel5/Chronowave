using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAttackController : MonoBehaviour
{

    // Update is called once per frame
    public float speed = 7;
    public Rigidbody2D body;
    public float timeAlive = 1200;
    void Start()
    {
        body.velocity = transform.right * speed;
    }

    private void Update()
    {
        if(timeAlive == 0) { Destroy(gameObject); }
        timeAlive--;
    }
}

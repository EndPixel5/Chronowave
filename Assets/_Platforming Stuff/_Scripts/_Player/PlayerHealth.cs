using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 5;
    public float health;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0) 
        {
            /*Destroy(gameObject);*/
            health = maxHealth;
            transform.position = startPos;
        }
    }
    /*public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0) {Destroy(gameObject); }
    }*/
}

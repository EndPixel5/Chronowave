using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 5;
    public float health;
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0) { Destroy(gameObject); }
    }
    /*public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0) {Destroy(gameObject); }
    }*/
}

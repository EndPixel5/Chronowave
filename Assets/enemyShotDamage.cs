using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShotDamage : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;
    public PlayerHealth playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.takeDamage(damage);
        }
    }
}

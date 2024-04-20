using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"|| collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<PlayerHealth>().health = 0;

        }
    }
}

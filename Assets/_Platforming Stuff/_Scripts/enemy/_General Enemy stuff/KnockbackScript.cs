using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackScript : MonoBehaviour
{
    public float knockbackForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.transform.position.x >= transform.position.x)
            {
                collision.gameObject.GetComponent<PlayerMovement>().knockRight = true;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerMovement>().knockRight = false;

            }
            collision.gameObject.GetComponent<PlayerMovement>().kbTimer = collision.gameObject.GetComponent<PlayerMovement>().kbTotalTime;
            collision.gameObject.GetComponent<PlayerMovement>().knockback = knockbackForce;        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseSpawnScript : MonoBehaviour
{
    public GameObject enemy;
    public float respawnTimer = 0; //250 when waiting to respawn
    //public float givenDist;
    private void FixedUpdate()
    {
        if (respawnTimer > 0) { respawnTimer--; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            respawnTimer = 100;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "MainCamera" && respawnTimer == 0)
        {
            GameObject newEnemy = Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
            //newEnemy.GetComponent<shooterEnemyScript>().maxDist = givenDist;
        }
    }
}


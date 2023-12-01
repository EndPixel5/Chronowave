using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float respawnTimer = 0; //250 when waiting to respawn
    public float givenDist;
    public bool onlySpawnOnce;
    private void FixedUpdate()
    {
        if(respawnTimer > 0) { respawnTimer--; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera" && respawnTimer == 0 && onlySpawnOnce == false)
        {
            GameObject newEnemy = Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
            
            if(enemy.name == "shooterEnemy")
            {
                newEnemy.GetComponent<shooterEnemyScript>().maxDist = givenDist;
            }
            else if (enemy.name == "ovenman")
                {
                    newEnemy.GetComponent<ovenman>().maxDist = givenDist;
                }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            respawnTimer = 250;
        }
    }
}

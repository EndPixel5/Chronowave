using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterEnemyShootScript : MonoBehaviour
{
    public GameObject shot;
    private float attackTimer = 85;
    private bool attackAgain = false;
    private float secondAttackTimer = 25; //(have 25 if true);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attackAgain)
        {
            if (secondAttackTimer > 0) { secondAttackTimer--; }
            else
            {
                Instantiate(shot, gameObject.transform.position, gameObject.transform.rotation);
                secondAttackTimer = 25;
                attackAgain = false;
            }
        }
        else if (attackTimer > 0)
        {
            attackTimer--;

        }
        else
        {
            Instantiate(shot, gameObject.transform.position, gameObject.transform.rotation);
            attackTimer = 85;
            attackAgain = (Random.value > 0.5f);
        }
    }
}

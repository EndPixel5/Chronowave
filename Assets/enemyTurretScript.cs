using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTurretScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shot;
    private float attackTimer = 250;
   void FixedUpdate()
    {
        if(attackTimer == 0) 
        {
            Instantiate(shot, gameObject.transform.position, gameObject.transform.rotation);
            attackTimer = 250;
        }
        else { attackTimer--; }
    }
}

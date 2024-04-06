using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ovenmanShootScript : MonoBehaviour
{
    public GameObject shot;
    private float attackTimer = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attackTimer > 0)
        {
            attackTimer--;

        }
        else
        {
            Instantiate(shot, gameObject.transform.position, gameObject.transform.rotation);
            attackTimer = 50;
        }
    }
}

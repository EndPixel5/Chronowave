using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigIronBaseScript : MonoBehaviour
{

    public GameObject shot;
    public GameObject spot;
    private float attackTimer = 85;

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
            steam();
            attackTimer = 900;
        }
    }

    private void steam()
    {
        Instantiate(shot, spot.transform.position, spot.transform.rotation);
    }
}

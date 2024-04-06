using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float despawnTimer = 250;
    private bool offscreen = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (offscreen)
        {
            despawnTimer--;
        }
        if(despawnTimer == 0) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            offscreen = false;
            despawnTimer = 250;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            offscreen = true;
        }
    }
}

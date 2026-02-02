using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialWaveScript : MonoBehaviour
{
    public bool specialAvailable = false;
    public GameObject trailPrefab;
    public float speed;
    public Rigidbody2D body;
   // public bool specialAvailable = false;
    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.up * speed;
    }

    void FixedUpdate()
    {
        Instantiate(trailPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "key")
        {
            transform.Rotate(180, 0, 0);
            body.velocity = transform.up * speed;
        }
        if(collision.gameObject.tag == "part")
        {
            specialAvailable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "part")
        {
            specialAvailable = false;
        }
    }

}

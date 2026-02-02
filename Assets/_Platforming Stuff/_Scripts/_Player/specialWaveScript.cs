using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialWaveScript : MonoBehaviour
{
    public bool specialAvailable = false;
    //public GameObject trailPrefab;
    //public float speed;
    //public Rigidbody2D body;



    [SerializeField] float moveSpeed = .05f;
    [SerializeField] float frequency = 1;
    [SerializeField] float magnitude = .05f;
    private bool facingRight = true;
    Vector3 pos, localScale;
    [SerializeField] int mids = 0;
   // public bool specialAvailable = false;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;
        //body.velocity = transform.up * speed;
    }

    private void Update()
    {
        if(facingRight)
        {
            moveRight();
        }
        else
        {
            moveLeft();
        }
    }

    private void moveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void moveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    /*void FixedUpdate()
    {
        Instantiate(trailPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "key")
        {
            transform.Rotate(180, 0, 0);
            body.velocity = transform.up * speed;
        }*/
        if(collision.gameObject.tag == "part")
        {
            specialAvailable = true;
            mids++;
        }
        if(mids == 4)
        {
            mids = 1;
            facingRight = !facingRight;
            localScale.x *= -1;
        }
        /*else if(collision.gameObject.tag == "key")
        {
            facingRight = !facingRight;
            if((facingRight && localScale.x <0) || !facingRight && localScale.x>0)
            {
                localScale.x *= -1;
            }
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "part")
        {
            specialAvailable = false;
        }
    }

}

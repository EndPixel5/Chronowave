using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    /*public float moveForce;
    public float jumpForce;*/
    private Rigidbody2D body;
    public float speed;
    public float jump;
    private float Move;
    public bool isJumping;
    private float jumpsUsed;
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        if(Move < 0 ) gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else if(Move > 0 ) gameObject.GetComponent<SpriteRenderer>().flipX = false;
        body.velocity = new Vector2(Move * speed, body.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        //if (Input.GetButtonDown("Jump") && jumpsUsed < 2)
        {
            body.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            //jumpsUsed++;
            //isJumping = true;
        }
           

        }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector3 normal = collision.getContact(0).normal;

        if (collision.gameObject.tag == "Platform")
        {
            Vector3 normal = collision.GetContact(0).normal;
            if(normal == Vector3.up)
            {
                isJumping = false;
            }
            //jumpsUsed = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}

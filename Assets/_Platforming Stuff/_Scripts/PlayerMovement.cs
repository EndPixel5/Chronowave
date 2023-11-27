using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    /*public float moveForce;
    public float jumpForce;*/
    private Rigidbody2D body;
    public GameObject childSprite;

    public float speed;
    public float jump;
    private float Move;
    
    public bool isJumping;
    //private float jumpsUsed;
    private bool isFacingRight;
    private bool jumpCheck;

    private float collisions;
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        isFacingRight = true;
        collisions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();    

    }

    private void FixedUpdate()
    {
        Movement();       
    }

    void Inputs()
    {
        Move = Input.GetAxis("Horizontal");

        if (Move < 0 && isFacingRight == true) Flip();
        else if (Move > 0 && isFacingRight == false) Flip();

        if (Input.GetButtonDown("Jump") && isJumping == false)
        //if (Input.GetButtonDown("Jump") && jumpsUsed < 2)
        {
            jumpCheck = true;
        }
    }

    private void Movement()
    {
        body.velocity = new Vector2(Move * speed, body.velocity.y);
        if (jumpCheck == true)
        {
            isJumping = true;
            body.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
        jumpCheck = false;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0, 180, 0);
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
            collisions++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            collisions--;
            if (collisions == 0) { isJumping = true; }
        }
    }
   
}

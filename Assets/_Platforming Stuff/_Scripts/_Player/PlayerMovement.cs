using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*public float moveForce;
    public float jumpForce;*/
    private Rigidbody2D body;
    //public GameObject childSprite;
    //private bool isFacingRight;
    private float direction = 1;
    public float speed;
    public float jump;
    private float Move;

    public float knockback;
    public float kbTimer;
    public float kbTotalTime;
    public bool knockRight;

    Vector2 movement;
    public bool isJumping;
    //private float jumpsUsed;
    //private bool isFacingRight;
    private bool jumpCheck;
    public Animator animator;
    private float collisions;
    
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        collisions = 0;
        animator.SetFloat("Horizontal", direction);
        //isFacingRight = true;
    }

    
    // Update is called once per frame
    void Update()
    {
        Inputs();
        AnimationStuff();
       
        /*movement.x = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", movement.x * speed);
        animator.SetFloat("Speed", movement.sqrMagnitude);*/
    }

    private void FixedUpdate()
    {
        Movement();
        
        
    }

    void Inputs()
    {
        Move = Input.GetAxis("Horizontal");
        movement.x = Move;
        if (movement.x > 0) direction = 1;
        else if(movement.x < 0) direction = -1;

        if (Input.GetButtonDown("Jump") && isJumping == false)
        //if (Input.GetButtonDown("Jump") && jumpsUsed < 2)
        {
            jumpCheck = true;
        }
    }

    private void Movement()
    {
        if (kbTimer <= 0)
        {
            body.velocity = new Vector2(Move * speed, body.velocity.y);
            if (jumpCheck == true)
            {
                isJumping = true;
                body.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }
            jumpCheck = false;
        }
        else
        {
            if (knockRight)
            {
                if(!isJumping) body.velocity = new Vector2(-knockback, 1);
                else body.velocity = new Vector2(-knockback, body.velocity.y);
            }
            else
            {
                if (!isJumping) body.velocity = new Vector2(knockback, 1);
                else body.velocity = new Vector2(knockback, body.velocity.y);
            }
            kbTimer --;
        }
    }

   private void AnimationStuff()
    {
        animator.SetFloat("Horizontal", direction);// movement.x); // * speed);
        animator.SetFloat("Speed", movement.sqrMagnitude);
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

   /* private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0, 180, 0);
    }*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDplayer_controller : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Rigidbody2D rb;
    
    private Vector2 moveInput;
    private Vector2 movement;
    private Vector2 boxSize = new Vector2(0.1f, 1f);
    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public GameObject interactIcon;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        { 
            Checkinteraction();
        }
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

       
    }

    public void OpenInteractableIcon()
    { 
        interactIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactIcon.SetActive(false);
    }

    private void Checkinteraction() 
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if(rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }

        }
    }
}

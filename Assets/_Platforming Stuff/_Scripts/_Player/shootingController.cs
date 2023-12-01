using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingController : MonoBehaviour
{
    //public Transform shotPoint;
    public GameObject playerAttackPrefab;
    private bool isShooting;
    private float attackTimer;
   // public GameObject player;
    private bool isFacingRight;
    private float Direction;


    private void Start()
    {
        attackTimer = 0;
        isFacingRight = true;
        Direction = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Direction = Input.GetAxis("Horizontal");
        /*if(Direction < 0) { isFacingRight  = false; }
        else if(Direction > 0) { isFacingRight = true; }*/

        if (Direction < 0 && isFacingRight == true)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0, 180, 0);
        }
        else if (Direction > 0 && isFacingRight == false)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0, 180, 0);
        }
        if (Input.GetAxisRaw("Fire1") > 0 && attackTimer == 0) { isShooting = true; }
    }

    void FixedUpdate()
    {
        //if(Direction == 1 && )
        if (attackTimer > 0) { attackTimer--; }
        if (isShooting)
        {
            Shoot();
        }
        isShooting=false;
    }

    void Shoot()
    {
        Instantiate(playerAttackPrefab, gameObject.transform.position, gameObject.transform.rotation);
        attackTimer = 20;
    }
}

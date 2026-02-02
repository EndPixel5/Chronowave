using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class shootingController : MonoBehaviour
{
    //public Transform shotPoint;
    public GameObject playerAttackPrefab;
    public GameObject strongPlayerAttackPrefab;

    private bool isShooting;
    private float attackTimer;
    public newSpecialScript special;
    //private float specialTimer;
   // public GameObject player;
    private bool isFacingRight;
    private float Direction;

    [SerializeField]
    private InputActionReference moveInput, shootInput;

    private void Start()
    {
        attackTimer = 0;
        //specialTimer = 0;
        isFacingRight = true;
        Direction = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Direction = moveInput.action.ReadValue<Vector2>().x; //Input.GetAxis("Horizontal");
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
        if (shootInput.action.IsPressed() /*Input.GetAxisRaw("Fire1") > 0*/ && attackTimer == 0) { isShooting = true; }
    }

    void FixedUpdate()
    {
        //if(Direction == 1 && )
        if (attackTimer > 0) { attackTimer--; }
        /*if (specialTimer > 0) {  specialTimer--; }
        else if (specialTimer == 0) { specialTimer = 7; }*/
        if (isShooting)
        {
            /*if (specialTimer == 0) { SpecialShoot(); }
            else { Shoot(); }*/
            Shoot();
        }
        isShooting=false;
    }

    void Shoot()
    {
        if (special.specialAvailable == true/*specialTimer == 0*/)
        {
            Instantiate(strongPlayerAttackPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
        else { Instantiate(playerAttackPrefab, gameObject.transform.position, gameObject.transform.rotation); }
        attackTimer = 20;
    }
   /* void SpecialShoot()
    {
        Instantiate(strongPlayerAttackPrefab, gameObject.transform.position, gameObject.transform.rotation);
        attackTimer = 20;
    }*/
}

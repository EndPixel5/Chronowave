using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingController : MonoBehaviour
{
    //public Transform shotPoint;
    public GameObject playerAttackPrefab;
    private bool isShooting;
    private float attackTimer;

    private void Start()
    {
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0) { attackTimer--; }
        if (Input.GetAxisRaw("Fire1") > 0 && attackTimer == 0) { isShooting = true; }
    }

    void FixedUpdate()
    {
        if (isShooting)
        {
            Shoot();
        }
        isShooting=false;
    }

    void Shoot()
    {
        Instantiate(playerAttackPrefab, gameObject.transform.position, gameObject.transform.rotation);
        attackTimer = 80;
    }
}

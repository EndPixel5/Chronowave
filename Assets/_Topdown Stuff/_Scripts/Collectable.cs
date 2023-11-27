using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Collectable : Interactable
{
    private GameObject thi;
    private void Start()
    {
        thi = GetComponent<GameObject>();
    }
    public override void Interact()
    {
       

        Destroy(gameObject);
    }
}

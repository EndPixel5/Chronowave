using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedOpenable : Interactable
{
    public Sprite open;
    public Sprite closed;
    public Vector3 place;
    private SpriteRenderer sr;
    private bool isOpen;
    public GameObject part;

    public override void Interact()
    {
        if (isOpen)
        {
            sr.sortingLayerID = default;
            sr.sprite = closed;
            
        }
        else
        {
            sr.sortingLayerID = SortingLayer.NameToID("inside");
            sr.sprite = open;
            Instantiate(part, place, gameObject.transform.rotation);
        }
        isOpen = !isOpen;
    }
    public void Start()
    {
        isOpen = true;
    }
}


using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Openable : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;
    private bool isOpen;

   

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
        }
        isOpen = !isOpen;
    }

    

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sortingLayerID = default;  
        sr.sprite = closed;
    }
}

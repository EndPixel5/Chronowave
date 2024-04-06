using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layerIgnore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

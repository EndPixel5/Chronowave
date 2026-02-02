using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSpecialScript : MonoBehaviour
{
    [SerializeField] Transform[] points;
    private int pointsIndex;
    private int direction = 1;
    [SerializeField] private int speed = 1;
    public bool specialAvailable;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == 1)
        {
            if(pointsIndex <= points.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, points[pointsIndex].transform.position, speed * Time.deltaTime);
                if (transform.position == points[pointsIndex].transform.position) { pointsIndex++; }
                if(pointsIndex == points.Length) 
                {
                    direction = 0;
                    pointsIndex -= 2;
                } 
            }
        }
        else if(direction == 0) 
        {
            if (pointsIndex >= -1)
            {
                transform.position = Vector2.MoveTowards(transform.position, points[pointsIndex].transform.position, speed * Time.deltaTime);
                if (transform.position == points[pointsIndex].transform.position) { pointsIndex--; }
                if (pointsIndex == -1)
                {
                    direction = 1;
                    pointsIndex += 2;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "part")
        {
            specialAvailable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "part")
        {
            specialAvailable = false;
        }
    }
}

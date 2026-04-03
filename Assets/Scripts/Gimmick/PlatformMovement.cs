using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform player; 
    public float speed;

    public Transform[] setPoint;
    private int pointCounter; 

    // Start is called before the first frame update
    void Start()
    {
        transform.position = setPoint[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; 
        transform.position = Vector2.MoveTowards(transform.position, setPoint[pointCounter].position, step);

        if(transform.position == setPoint[pointCounter].position)
        {
            pointCounter++;
        }

        if(pointCounter == setPoint.Length)
        {
            pointCounter = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Test collision");
        col.transform.SetParent(player);
    }

    private void OnCollisionExit2D(Collision2D ocl)
    {
        Debug.Log("Test collision again");
        ocl.transform.SetParent(null);
    }

}

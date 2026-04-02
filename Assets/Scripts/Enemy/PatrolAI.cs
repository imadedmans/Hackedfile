using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float speed = 10;
    public float distance = 5;
    private bool movingRight = true;
    public Transform groundDetection;
    public HealthScript healthScript;
    Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        switch(transform.rotation.z)
        {
            case 0:
                direction = Vector2.down;
                break;
            case 90:
                direction = Vector2.right;
                break;
            case 180:
                direction = Vector2.up;
                break;
            case 270:
                direction = Vector2.left;
                break;
            default:
                break;
        }

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, direction, distance);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
       
        if(groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.Rotate(0, 180, 0);
                movingRight = false;
            }
            else
            {
                transform.Rotate(0, 180, 0);
                movingRight = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            healthScript.Damage(1);
        }
    }
}

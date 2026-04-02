using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAIHorizontal : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingDown = true;
    public Transform groundDetection;
    public HealthScript healthScript;
    public int zRotation = -90;

   // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, distance);
       
        if(groundInfo.collider == false)
        {
            if (movingDown == true)
            {
                transform.eulerAngles = new Vector3(180, 0, zRotation);
                movingDown = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, zRotation);
                movingDown = true;
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

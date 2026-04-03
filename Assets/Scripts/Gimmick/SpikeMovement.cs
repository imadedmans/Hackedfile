using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Wall")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(other.name == "Wall 2")
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementbutBad1 : MonoBehaviour
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

    public void Movement()
    {
        
    }

    public void OnCollisionEnter2D (Collider2D col)
    {
        
    }
}

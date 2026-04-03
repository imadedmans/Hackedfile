using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFall : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.name.Equals("Player"))
        {
            rb.isKinematic = false;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            gameManager.GameOver2();
        }
    }

}


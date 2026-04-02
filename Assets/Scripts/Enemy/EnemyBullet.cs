using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 40f;
    public bool canMoveAsRigidbody = false; 
    public float timeBeforeDelete = 5f; 

    private GameObject player;
    private Rigidbody2D rigidbody;
    private HealthScript healthScript;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        healthScript = player.GetComponent<HealthScript>();

        rigidbody = GetComponent<Rigidbody2D>();
    }
//hey
    void Update()
    {
        if(canMoveAsRigidbody)
        {
            rigidbody.isKinematic = false;
            rigidbody.velocity = Vector2.left * speed; 
        }
        else if(!canMoveAsRigidbody)
        {
            rigidbody.isKinematic = true; 
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if(timeBeforeDelete > 0)
        {
            timeBeforeDelete -= Time.deltaTime; 
        }
        else if(timeBeforeDelete <= 0)
        {
            DestroySelf();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            healthScript.Damage(1);
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

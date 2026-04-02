using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBullet : MonoBehaviour
{
    public float speed;
    public float timeBeforeDelete; 

    public Rigidbody2D rb;
    // public BouncerEnemy enemyParent; 
    public HealthScript healthScript;

    void Awake()
    {
        healthScript = Object.FindObjectOfType<HealthScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyItself", timeBeforeDelete);
    }

    public void MovementRotation(int facePositionInt)
    {
        switch(facePositionInt)
        {
            case 0:
                //Up and Right
                rb.AddForce(new Vector2(speed, speed));
                return;
            case 1:
                //Down and Right
                rb.AddForce(new Vector2(speed, -speed));
                return;
            case 2:
                //Down and Left
                rb.AddForce(new Vector2(-speed, -speed));
                return;
            case 3:
                //Up and Left
                rb.AddForce(new Vector2(-speed, speed));
                return;
            default:
                Debug.Log("Intangible amount reached, goodbye cruel world");
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            healthScript.Damage(1);
            Destroy(gameObject);
        }
    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}

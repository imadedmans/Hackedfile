using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStraight : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 40f;
    
    private SpriteRenderer spriteRenderer;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        rb.velocity = Vector2.left * speed;
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            gameManager.GameOver();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health = 100f;
    public float[] healthValueEvents;

    private float currentHealth;
    public HealthScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<HealthScript>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.Damage(1);
        }
    }

    public void Damage(float damageValue)
    {
        currentHealth -= damageValue;

        if(currentHealth <= 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossOld : MonoBehaviour
{
    public float speed; 
    private float currentSpeed;
    private float fasterSpeed;
    private bool flipToPlayer;

    public float health;
    private float currentHealth;
    private float halfHealth;

    private float shootFrequency = 3f; 
    public GameObject bullet;
    public Transform firePoint;
    public GameObject debris;
    public Transform player;

    void Start()
    {
        currentHealth = health;
        halfHealth = health / 2; 
        currentSpeed = speed;
        fasterSpeed = currentSpeed / 3f;

        InvokeRepeating("ShootCommand", 10f, 10f);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * currentSpeed);
    }

    void OnCollisionEnter2D(Collision2D collisi)
    {
        if(collisi.gameObject.name == "WallLeft")
        {
            transform.Rotate(0f, 180f, 0f);
        }  

        if(collisi.gameObject.name == "WallRight")
        {
            transform.Rotate(0f, 180f, 0f);
        }

    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        if(currentHealth == halfHealth)
        {
            //Add other attacks such as the ability to jump and increase frequency of shooting
            shootFrequency = 4f;
            currentSpeed += fasterSpeed;
        }

        if(currentHealth == 0f)
        {
            Destroy(gameObject);
            Debug.Log("Boss defeated");
        }
    }

    public void ShootCommand()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        currentSpeed = 0f;
        FacePlayer();
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < shootFrequency; i++) 
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(0.333f);
        }
        
        yield return new WaitForSeconds(2f);
        currentSpeed = speed; 
    }

    public void FacePlayer()
    {
        Vector3 bossFlip = transform.localScale;
        bossFlip.z *= -1f;

        if(transform.position.x > player.position.x && !flipToPlayer)
        {
            transform.localScale = bossFlip;
            transform.Rotate(0f, 180f, 0f);
            flipToPlayer = true;
        }
        else if(transform.position.x < player.position.x && flipToPlayer)
        {
            transform.localScale = bossFlip;
            transform.Rotate(0f, 180f, 0f);
            flipToPlayer = false;
        }
    }
}
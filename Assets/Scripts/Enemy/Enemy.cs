using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    SpriteRenderer enemySprite; 
    public static Vector2 playerPos;
    public static Quaternion playerRot;
    GameObject playerObj;

    int enemyHealth;
    int currentHealth;
    float actualCurHealth;
    bool canDamage = true;
    public bool enemyIsEnabled;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = enemyData.name;
        enemyHealth = enemyData.healthPoints;
        currentHealth = enemyHealth;
        actualCurHealth = (float)currentHealth;

        enemySprite = GetComponent<SpriteRenderer>();
        playerObj = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerObj.transform.position;
        playerRot = playerObj.transform.rotation;
    }

    public void Visibility(bool isEnabled)
    {
        enemyIsEnabled = isEnabled ? true : false;
        canDamage = isEnabled ? true : false;
        currentHealth = isEnabled ? currentHealth : enemyHealth;

        Behaviour[] enemyComponents = gameObject.GetComponents<Behaviour>();
        foreach(Behaviour component in enemyComponents)
        {
            if(component is Enemy || component is BoxCollider2D)
            {
                string enableStatus = isEnabled ? "Enabled" : "Disabled";
                Debug.Log(enableStatus);
            }
            else
            {
                component.enabled = isEnabled ? true : false;
            }
        }

        enemySprite.enabled = isEnabled ? true : false;
    }

    public void Damage(float damageFloat)
    {
        if(canDamage)
        {
            actualCurHealth -= damageFloat;

            if(actualCurHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

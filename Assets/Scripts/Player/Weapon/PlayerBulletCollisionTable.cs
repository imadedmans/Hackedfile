using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollisionTable : MonoBehaviour
{
    public float damageToEnemy = 1f;
    public bool collideWithGround = true;
    public bool collideWithEnemy = true;
    public GameObject burstEffect;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Standable" && collideWithGround)
        {
            if(burstEffect != null) Instantiate(burstEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Enemy" && collideWithEnemy)
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            if(enemy.enemyIsEnabled)
            {
                enemy.Damage(damageToEnemy);
                Destroy(gameObject);
            }
        }
    }
}

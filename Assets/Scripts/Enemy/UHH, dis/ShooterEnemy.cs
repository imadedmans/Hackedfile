using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootTran;
    public float timeInBetweenShoot;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        transform.eulerAngles = (transform.position.x <= Enemy.playerPos.x) ? Vector3.zero : new Vector3(0f, 180f, 0f);
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeInBetweenShoot);
            Instantiate(bullet, shootTran.position, transform.rotation);
        }
    }
}

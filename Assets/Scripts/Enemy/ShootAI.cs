using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool allowShoot = true; 
    Vector2 direction;

    // Update is called once per frame
    void Update()
    {      
        switch(transform.rotation.z)
        {
            case 0:
                direction = Vector2.down;
                break;
            case 90:
                direction = Vector2.right;
                break;
            case 180:
                direction = Vector2.up;
                break;
            case 270:
                direction = Vector2.left;
                break;
            default:
                break;
        }

        RaycastHit2D detect = Physics2D.Raycast(firePoint.position, direction * 100f);
        Debug.DrawRay(firePoint.position, Vector2.down * 100f, Color.green);

        if(detect.collider.tag == "Player")
        {
            if(allowShoot == true)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                allowShoot = false;
                StartCoroutine(ShootCooldown());
            }
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(2f);
        allowShoot = true;
    }
}


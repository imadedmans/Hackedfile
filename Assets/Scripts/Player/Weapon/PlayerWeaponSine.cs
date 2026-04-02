using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSine : MonoBehaviour
{
    public PlayerMovement pM;
    public GameObject firePoint;
    public GameObject bulletObj;
    public static bool canShoot;
    bool canCos;

    void Awake()
    {
        pM = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && PlayerMovement.actualDashTime <= 0)
        {
            Instantiate(bulletObj, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}

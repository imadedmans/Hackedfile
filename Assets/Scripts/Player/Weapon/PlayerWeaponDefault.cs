using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponDefault : MonoBehaviour
{
    public PlayerMovement pM;
    public GameObject firePoint;
    public GameObject bulletObj;
    public static bool canShoot;

    void Awake()
    {
        pM = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && PlayerMovement.actualDashTime <= 0)
        {
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                firePoint.transform.localPosition = new Vector2(0f, 0.5f);
                firePoint.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            }
            else if((Input.GetAxisRaw("Vertical") < 0) && !PlayerMovement.playerIsGrounded)
            {
                firePoint.transform.localPosition = new Vector2(0f, -0.5f);
                firePoint.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
            }
            else
            {
                firePoint.transform.localPosition = new Vector2(0.7f, 0f);
                firePoint.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }

            Instantiate(bulletObj, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}

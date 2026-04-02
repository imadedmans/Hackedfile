using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetect : MonoBehaviour
{
    public TurretEnemy turretEnemy;

    // Start is called before the first frame update
    void Start()
    {
        turretEnemy.GetComponent<TurretEnemy>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 facedDirection;

        if(transform.rotation.eulerAngles.y == 180)
        {
            facedDirection = Vector2.right;
        }
        else
        {
            facedDirection = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, facedDirection * 999f);
        Debug.DrawRay(transform.position, facedDirection * 999f, Color.green);

        if(hit.collider.tag == "Player")
        {
            LaunchScript();
        }
    }

    public void LaunchScript()
    {
        Debug.Log("Player detected!");
        turretEnemy.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAngular : MonoBehaviour
{
    public float speed;
    float angle;
    Vector2 vectorRotation;

    public bool constantFollow;

    void Update()
    {
        if(!constantFollow)
        {
            if(transform.rotation.z != 0f)
            {   
                angle = transform.eulerAngles.z;
                Debug.Log("Angle: " + angle);
                transform.rotation = Quaternion.identity;
            }

            float radX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float radY = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 radAngle = new Vector2(radX, radY);
            transform.Translate(radAngle * speed * Time.deltaTime);
        }
        else
        {
            float distanceX = Enemy.playerPos.x - transform.position.x;
            float distanceY = Enemy.playerPos.y - transform.position.y;
            Debug.Log("Player Position: " + Enemy.playerPos);

            float angleTest = Mathf.Atan2(distanceY, distanceX);
            vectorRotation = new Vector2(Mathf.Cos(angleTest), Mathf.Sin(angleTest));
            transform.Translate(vectorRotation * speed * Time.deltaTime);
        }
    }
}

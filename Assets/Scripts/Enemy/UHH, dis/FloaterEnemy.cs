using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterEnemy : MonoBehaviour
{
    public float speed;
    public float amplitude;

    public float timeBeforeShoot;
    public GameObject bullet;

    float sineWave;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootCorou());
    }

    // Update is called once per frame
    void Update()
    {
        sineWave = amplitude * Mathf.Sin(speed * Time.time) + transform.position.y;
        transform.position = new Vector2(transform.position.x, sineWave);
    }

    IEnumerator ShootCorou()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeBeforeShoot);
            float angleDirection = CodeUtilities.AngularAim(transform.position, true);
            Quaternion dotRot = Quaternion.Euler(new Vector3(0, 0, angleDirection));
            GameObject bulletObj = Instantiate(bullet, transform.position, dotRot);
        }
    }
}

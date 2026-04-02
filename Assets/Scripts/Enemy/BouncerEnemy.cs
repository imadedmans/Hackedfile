using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerEnemy : MonoBehaviour
{
    [Header("Transform Objects")]
    public Transform projectile; 
    public Transform[] firePoints;

    [Range(0, 3)]
    public int startingPointNumber = 0; 
    private int pointNumber;

    [Header("Components")]
    public Animator anim;
    public AudioClip shootSFX;
    private AudioSource adS;
    public HealthScript healthScript;

    [Header("Attack Variables")]
    public float timeBeforeStartingShot = 5f;
    public float timeBetweenShot = 3f;

    // Start is called before the first frame update
    void Start()
    {
        pointNumber = startingPointNumber; 
        Debug.Log(firePoints.Length - 1);
        Invoke("StartCororo", timeBeforeStartingShot);
    }

    // Update is called once per frame
    void Update()
    {
        switch(startingPointNumber)
        {
            case 0:
                //Insert animation code here
                break;
            case 1:
                //Insert animation code here
                break;
            case 2:
                //Insert animation code here
                break;
            case 3:
                //Insert animation code here
                break;
            default:
                Debug.Log("Intangible amount reached, self destruct sequence activated");
                break;
        } 
    }

    void StartCororo()
    {
        StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        Instantiate(projectile, firePoints[pointNumber].position, firePoints[pointNumber].rotation);

        GameObject bounceObj = GameObject.Find("Bounce Projectile(Clone)");
        PongBullet pongBullet = bounceObj.GetComponent<PongBullet>();
        pongBullet.MovementRotation(pointNumber);

        pointNumber++;
        yield return new WaitForSeconds(timeBetweenShot);

        if(bounceObj == null)
        {
            if(pointNumber > firePoints.Length - 1)
            {
                pointNumber = 0;
            }
            
            StartCoroutine(Shoot());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            healthScript.Damage(1);
        }
    }
}

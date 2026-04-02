using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    public HealthScript player;
    private bool canShoot = false;
    public GameObject bullet;
    public Transform firePoint;
    public Animator revealAnimator;
    public RaycastDetect detect;
    public BoxCollider2D collider2D;
    public EnemyHealth enemyHealth;

    void Awake()
    {
        collider2D.GetComponent<BoxCollider2D>();
        revealAnimator.GetComponent<Animator>();
        enemyHealth.GetComponent<EnemyHealth>();
    }

    // Start is called before the first frame update
    void Start()
    {
        detect.enabled = false;
        collider2D.enabled = true;
        enemyHealth.enabled = true;
        revealAnimator.enabled = true;
        StartCoroutine(ShootBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ShootBehaviour()
    {
        if(canShoot)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(bullet, firePoint.position, firePoint.rotation);

            yield return new WaitForSeconds(1f);
            StartCoroutine(ShootBehaviour());
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            player.Damage(1);
        }
    }

    void OnEnable()
    {
        canShoot = true;
    }

    void OnDisable()
    {
        canShoot = false;
    }
}

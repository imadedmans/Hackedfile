using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{    
    public GameObject bulletPrefab;
    public Transform FirePoint;
    public AudioClip bulletSFX;
    private AudioSource source;
    public Animator anim;

    private float speed = 1f;
    public int varble = 2;
    public HealthScript healthScript;
    private bool canShoot = false;
    public bool glitchEffect = false;
    private bool glitchMovement = false; 

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        InvokeRepeating("Shoot", 0.1f, 2.0f);   
    }

    // Update is called once per frame
    void Update()
    {
        if (glitchMovement == true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    public void Death() 
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            healthScript.Damage(1);
        }
    }

    public void Shoot() 
    {
        if(canShoot)
        {
            Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
            source.PlayOneShot(bulletSFX, 0.5F);
            StartCoroutine(ShootAnimationTimer());
        }
    }

    IEnumerator ShootAnimationTimer()
    {
        anim.SetBool("Shoot", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Shoot", false);
    }

    IEnumerator GlitchDeath()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Neccesitated Components")]

    public SpriteRenderer sr;
    public LevelManager lm;
    public AudioSource auds;

    [Header("Health Variables")]

    public int startinghealthPoints;
    public int minhealthNum = 3;
    public int maxhealthNum = 9;
    private int currentHealth;

    public float invisibilityTime;
    public float flickerTime;
    private bool isDamaged = false;

    [Header("Sprite Variables and Objects")]

    public SpriteRenderer healthBorder;
    public Sprite[] healthBorderSprites;
    public GameObject[] healthUnits;

    [Header("Audio Thingies")]
    public AudioClip dmgSound;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        auds = gameObject.GetComponent<AudioSource>();
        lm = FindObjectOfType<LevelManager>();
        healthBorder = GameObject.Find("HealthBorder").GetComponent<SpriteRenderer>();

        healthBorder.sprite = healthBorderSprites[startinghealthPoints - 3];
        currentHealth = Mathf.Clamp(startinghealthPoints, minhealthNum, maxhealthNum);

        for(int i = startinghealthPoints; i < maxhealthNum; i++)
        {
            healthUnits[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Damage(1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(isDamaged == false)
        {
            if(col.gameObject.tag == "Damagable")
            {
                Damage(1);
            }
            else if(col.gameObject.tag == "Enemy")
            {
                Enemy enemy = col.gameObject.GetComponent<Enemy>();
                if(enemy.enemyIsEnabled)
                {
                    Damage(1);
                } 
            }
            else if(col.gameObject.tag == "InstantDeath")
            {
                Damage(currentHealth);
            }
        }
    }

    void Damage(int damageInt)
    {
        if((currentHealth - damageInt) < 0) damageInt -= currentHealth;

        currentHealth -= damageInt;
        auds.clip = dmgSound;
        auds.Play();

        for(int i = 0; i < damageInt; i++)
        {
            healthUnits[currentHealth + i].SetActive(false);
        }

        if(currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            isDamaged = true; 
            StartCoroutine(Invicibility());
        }
    }

    IEnumerator Invicibility()
    {
        auds.clip = dmgSound;
        auds.Play();

        float flickerRate = (invisibilityTime / flickerTime) / 2f;

        for(float i = 0; i < flickerRate; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(flickerTime);
            sr.enabled = true;
            yield return new WaitForSeconds(flickerTime);
        }

        isDamaged = false; 
    }

    public void Revival()
    {
        currentHealth = startinghealthPoints;
    }
}

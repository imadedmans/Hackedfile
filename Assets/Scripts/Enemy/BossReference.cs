using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossReference : MonoBehaviour
{
    //Hi! This is my custom boss script! A very simple one to be more specific
    //You may want to use it in your game, if you use Unity of course...
    //Anyway, I'll give you quick tour if you're confused!

    //Main variables to access other objects
    public GameObject fireball;
    public Transform mouth;
    public GameObject[] projectiles;
    public GameObject dropProjectile;
    public HealthScript healthScript;

    //Repeat rate variable for shooting
    private float shootRepeatRate = 2.0f;

    //Boss health variable, along with other variations of it
    private float currentHealth;
    public float bossHealth = 50;
    private float formulatedHealth;
    private float halfHealth;

    //These objects should be accessed when the boss has been defeated and finished its death animation 
    public GameObject panel;
    public GameObject textTitle;
    public GameObject descriptionText;
    
    //Variable to specify the Vector's presence
    Vector2 zx;

    //This method will launch functions that don't need to be constantly updated 
    //It will begin boss
    void Start()
    {
        StartCoroutine(BattlePhase());

        Debug.Log("Fight!");

        currentHealth = bossHealth;
        halfHealth = bossHealth / 2;

        panel.SetActive(false);
        textTitle.SetActive(false);
        descriptionText.SetActive(false);
    
    }

    void Update()
    {
        //Other specific functions and commands 
        formulatedHealth = currentHealth * 2;
        zx = new Vector2(Random.Range(-50f, 26f), 58f);   
        //If the boss has no more health, the Death method will be initiated 
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    //The main and most prominent method of the script, where the boss attacks the player
    IEnumerator BattlePhase()
    {
        //Attack function(you can change this to whatever you want at your own will!)
        Instantiate(fireball, mouth.position, mouth.rotation);
        //The loop function, repeats the attack after a specific amount of time
        yield return new WaitForSeconds(shootRepeatRate);
        StartCoroutine(BattlePhase());

        //If the boss loses half of it's health, the repeat delay will become shorter, indicating more frequent fireballs.
        if(currentHealth <= 25)
        {
            shootRepeatRate = 1.0f;
            Debug.Log("It will get harder");
        }
    }

    //This function will cause the player to die upon colliding with the boss
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
           healthScript.Damage(1);
        }
    }

    //This method makes the boss lose health if hit by player bullets
    public void Damage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(formulatedHealth + "% chance of death");
    }

    void Death()
    {
        //This is where a death animation is called out.

        //Placeholder death 
        Debug.Log("Boss has been defeated");
        Destroy(gameObject);

        //What actually needs to happen
        Time.timeScale = 0.0f;
        Error();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Error()
    {
        panel.SetActive(true);
        textTitle.SetActive(true);
        descriptionText.SetActive(true);
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public float waitTime = 3f;
    private Animator flashEffect;
    private Animator fadeEffect;
    private AudioSource musicPlayer;

    public AudioSource audioSource;
    public AudioClip flashSFX;
    public bool stageHasMusic = true; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = flashSFX;

        flashEffect = GameObject.Find("FlashEffect").GetComponent<Animator>();
        fadeEffect = GameObject.Find("FadeEffect").GetComponent<Animator>();

        flashEffect.enabled = false;
        fadeEffect.enabled = false;

        if(stageHasMusic) musicPlayer = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.gameObject.SetActive(false);
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        if(stageHasMusic) musicPlayer.enabled = false;
        
        if(!flashEffect.enabled) flashEffect.enabled = true;
        else flashEffect.Play("FlashEffect", 0, 0f);
        
        audioSource.PlayOneShot(flashSFX, 0.3f);

        yield return new WaitForSeconds(waitTime);
        fadeEffect.enabled = true;
        yield return new WaitForSeconds(2f);
        ButtonPress();
    }

    public void ButtonPress() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
